using System;
using System.Collections.Generic;
using Npgsql;
using System.Linq;
namespace projlib
{
    public class projclass
    {
        private List<Project> projects;

        public projclass()
        {
            projects = new List<Project>();
        }

        public void AddProject(string projectName)
        {
            Project newProject = new Project(projectName);
            projects.Add(newProject);
        }

        public void RemoveProject(string projectName)
        {
            Project projectToRemove = projects.Find(p => p.Name == projectName);
            if (projectToRemove != null)
            {
                projects.Remove(projectToRemove);
            }
        }

        public void EditProject(string oldName, string newName)
        {
            Project projectToEdit = projects.Find(p => p.Name == oldName);
            if (projectToEdit != null)
            {
                projectToEdit.Edit(newName);
            }
        }

        public List<string> GetProjects()
        {
            return projects.Select(p => p.Name).ToList();
        }
    }

    public class zadclass
    {
        private List<Task> tasks;
        private List<Project> projects;

        public zadclass(List<Project> projects)
        {
            this.projects = projects;
            tasks = new List<Task>();
        }

        public void AddTask(string projectName, string taskName)
        {
            Project project = projects.Find(p => p.Name == projectName);
            if (project != null)
            {
                Task newTask = new Task(taskName);
                project.AddTask(newTask);
            }
        }

        public void MarkTaskAsDone(string projectName, string taskName)
        {
            Project project = projects.Find(p => p.Name == projectName);
            if (project != null)
            {
                Task task = project.Tasks.Find(t => t.Name == taskName);
                if (task != null)
                {
                    task.MarkAsDone();
                }
            }
        }

        public void EditTask(string projectName, string oldTaskName, string newTaskName)
        {
            Project project = projects.Find(p => p.Name == projectName);
            if (project != null)
            {
                Task taskToEdit = project.Tasks.Find(t => t.Name == oldTaskName);
                if (taskToEdit != null)
                {
                    taskToEdit.Edit(newTaskName);
                }
            }
        }

        public List<string> GetTasksForProject(string projectName)
        {
            Project project = projects.Find(p => p.Name == projectName);
            return project?.Tasks.Select(t => t.Name).ToList() ?? new List<string>();
        }
    }

    public class dbclass
    {
        private NpgsqlConnection connection;

        public dbclass(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
        }

        public void ConnectToDatabase()
        {
            connection.Open();
        }

        public void DisconnectFromDatabase()
        {
            connection.Close();
        }

        public void CreateProjectsTable()
        {
            using (NpgsqlCommand command = new NpgsqlCommand("CREATE TABLE Projects (Id SERIAL PRIMARY KEY, Name VARCHAR(255))", connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void CreateTasksTable()
        {
            using (NpgsqlCommand command = new NpgsqlCommand("CREATE TABLE Tasks (Id SERIAL PRIMARY KEY, ProjectId INT, Name VARCHAR(255), IsDone BOOLEAN)", connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void AddProjectToDatabase(string projectName)
        {
            using (NpgsqlCommand command = new NpgsqlCommand("INSERT INTO Projects (Name) VALUES (@Name)", connection))
            {
                command.Parameters.AddWithValue("@Name", projectName);
                command.ExecuteNonQuery();
            }
        }

        public void RemoveProjectFromDatabase(string projectName)
        {
            using (NpgsqlCommand command = new NpgsqlCommand("DELETE FROM Projects WHERE Name = @Name", connection))
            {
                command.Parameters.AddWithValue("@Name", projectName);
                command.ExecuteNonQuery();
            }
        }

        private List<Project> projects;

        public dbclass(string connectionString, List<Project> projects)
        {
            connection = new NpgsqlConnection(connectionString);
            this.projects = projects;
        }

        public void AddTaskToDatabase(string projectName, string taskName)
        {
            Project project = projects.Find(p => p.Name == projectName);
            if (project != null)
            {
                using (NpgsqlCommand command = new NpgsqlCommand("INSERT INTO Tasks (ProjectId, Name, IsDone) VALUES (@ProjectId, @Name, @IsDone)", connection))
                {
                    command.Parameters.AddWithValue("@ProjectId", project.Id);
                    command.Parameters.AddWithValue("@Name", taskName);
                    command.Parameters.AddWithValue("@IsDone", false);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void MarkTaskAsDoneInDatabase(string projectName, string taskName)
        {
            Project project = projects.Find(p => p.Name == projectName);
            if (project != null)
            {
                using (NpgsqlCommand command = new NpgsqlCommand("UPDATE Tasks SET IsDone = true WHERE ProjectId = @ProjectId AND Name = @Name", connection))
                {
                    command.Parameters.AddWithValue("@ProjectId", project.Id);
                    command.Parameters.AddWithValue("@Name", taskName);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    public class InterfaceManager
    {
        private projclass projclass;
        private zadclass zadclass;
        private dbclass dbclass;

        public InterfaceManager(projclass manager, zadclass taskManager, dbclass databaseManager)
        {
            this.projclass = manager;
            this.zadclass = taskManager;
            this.dbclass = databaseManager;
        }

        public List<string> DisplayProjects()
        {
            return projclass.GetProjects();
        }

        public void AddProjectThroughInterface(string projectName)
        {
            projclass.AddProject(projectName);
            dbclass.AddProjectToDatabase(projectName);
        }

        public void AddTaskThroughInterface(string projectName, string taskName)
        {
            zadclass.AddTask(projectName, taskName);
            dbclass.AddTaskToDatabase(projectName, taskName);
        }
    }

    public class Project
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<Task> Tasks { get; private set; }

        public Project(string name)
        {
            Id = GenerateUniqueId();
            Name = name;
            Tasks = new List<Task>();
        }

        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }

        public void Edit(string newName)
        {
            Name = newName;
        }

        private static int GenerateUniqueId()
        {
            return Guid.NewGuid().GetHashCode();
        }
    }

    public class Task
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool IsDone { get; private set; }

        public Task(string name)
        {
            Id = GenerateUniqueId();
            Name = name;
            IsDone = false;
        }

        public void MarkAsDone()
        {
            IsDone = true;
        }

        public void Edit(string newName)
        {
            Name = newName;
        }

        private static int GenerateUniqueId()
        {
            return Guid.NewGuid().GetHashCode();
        }
    }
}