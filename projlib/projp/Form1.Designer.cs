namespace projp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            textBox1 = new TextBox();
            listBox1 = new ListBox();
            button2 = new Button();
            button4 = new Button();
            listBox2 = new ListBox();
            button3 = new Button();
            button5 = new Button();
            button6 = new Button();
            textBox2 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(40, 82);
            button1.Name = "button1";
            button1.Size = new Size(130, 28);
            button1.TabIndex = 0;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(40, 36);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(244, 26);
            textBox1.TabIndex = 1;
            textBox1.Text = "Добавить проект";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(194, 171);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(254, 224);
            listBox1.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(480, 82);
            button2.Name = "button2";
            button2.Size = new Size(160, 28);
            button2.TabIndex = 4;
            button2.Text = "Добавить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.Location = new Point(480, 126);
            button4.Name = "button4";
            button4.Size = new Size(160, 28);
            button4.TabIndex = 6;
            button4.Text = "Редактировать";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 20;
            listBox2.Location = new Point(760, 36);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(254, 224);
            listBox2.TabIndex = 7;
            // 
            // button3
            // 
            button3.Location = new Point(480, 171);
            button3.Name = "button3";
            button3.Size = new Size(160, 28);
            button3.TabIndex = 8;
            button3.Text = "Удалить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button5
            // 
            button5.Location = new Point(40, 126);
            button5.Name = "button5";
            button5.Size = new Size(130, 28);
            button5.TabIndex = 9;
            button5.Text = "Удалить";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(40, 171);
            button6.Name = "button6";
            button6.Size = new Size(130, 28);
            button6.TabIndex = 10;
            button6.Text = "Редактировать";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(480, 35);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(217, 27);
            textBox2.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1038, 441);
            Controls.Add(textBox2);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button3);
            Controls.Add(listBox2);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(listBox1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private ListBox listBox1;
        private Button button2;
        private Button button4;
        private ListBox listBox2;
        private Button button3;
        private Button button5;
        private Button button6;
        private TextBox textBox2;
    }
}