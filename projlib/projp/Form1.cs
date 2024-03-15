using System;
using projlib;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace projp
{
    public partial class Form1 : Form
    {
        private InterfaceManager interfaceManager;
        private projclass projectManager;
        private zadclass taskManager;
        private dbclass databaseManager;
        public Form1()
        {
            InitializeComponent();
            InitializeManagers();
        }

        private void InitializeManagers()
        {
            string connectionString = "Host=localhost;Username=postgres;Password=1111;Database=biblio"; // Замените это на ваше подключение к базе данных

            projectManager = new projclass();
            databaseManager = new dbclass(connectionString);
            List<string> projectNames = projectManager.GetProjects(); // Получаем список имен проектов
            List<Project> projects = projectNames.Select(name => new Project(name)).ToList(); // Создаем список объектов Project
            taskManager = new zadclass(projects); // Передаем список объектов Project в конструктор zadclass


            // Создаем таблицы в базе данных, если они еще не существуют
            databaseManager.ConnectToDatabase();
            databaseManager.CreateProjectsTable();
            databaseManager.CreateTasksTable();
            databaseManager.DisconnectFromDatabase();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string projectName = textBox1.Text;
            databaseManager.ConnectToDatabase();
            projectManager.AddProject(projectName);
            databaseManager.AddProjectToDatabase(projectName);
            databaseManager.DisconnectFromDatabase();
            UpdateProjectsList();
        }

        private void UpdateProjectsList()
        {
            listBox1.Items.Clear();
            foreach (string project in projectManager.GetProjects())
            {
                listBox1.Items.Add(project);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateProjectsList();
        }

        private void UpdateTasksList(string projectName)
        {
            listBox2.Items.Clear();
            foreach (string task in taskManager.GetTasksForProject(projectName))
            {
                listBox2.Items.Add(task);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string taskName = textBox2.Text;
            listBox2.Items.Add(taskName);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string taskName = textBox2.Text;
            listBox2.Items.Add(taskName);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string projectName = listBox1.SelectedItem as string;
            if (!string.IsNullOrEmpty(projectName))
            {
                projectManager.RemoveProject(projectName); // Используем projectManager для удаления проекта
                UpdateProjectsList();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string oldProjectName = listBox1.SelectedItem as string;
            string newProjectName = textBox1.Text;
            if (!string.IsNullOrEmpty(oldProjectName) && !string.IsNullOrEmpty(newProjectName))
            {
                projectManager.EditProject(oldProjectName, newProjectName);
                UpdateProjectsList();
            }
        }
    }
}