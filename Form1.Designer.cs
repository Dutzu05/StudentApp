namespace StudentTaskManager
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            SuspendLayout();

            cmbStudents = new ComboBox();
            clbTasks = new CheckedListBox();
            lblProgress = new Label();
            btnSave = new Button();
            btnLoad = new Button();

            cmbStudents.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStudents.FormattingEnabled = true;
            cmbStudents.Location = new Point(50, 10);
            cmbStudents.Name = "cmbStudents";
            cmbStudents.Size = new Size(350, 23);
            cmbStudents.TabIndex = 0;
            cmbStudents.SelectedIndexChanged += cmbStudents_SelectedIndexChanged;

            clbTasks.FormattingEnabled = true;
            clbTasks.Location = new Point(50, 50);
            clbTasks.Name = "clbTasks";
            clbTasks.Size = new Size(350, 220);
            clbTasks.TabIndex = 1;
            clbTasks.ItemCheck += clbTasks_ItemCheck;

            lblProgress.AutoSize = true;
            lblProgress.Location = new Point(50, 285);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(120, 15);
            lblProgress.TabIndex = 2;
            lblProgress.Text = "Completed: 0 / 0";

            int x = 450;

            var lblStudent = new Label();
            lblStudent.Text = "New student:";
            lblStudent.Location = new Point(x, 10);
            lblStudent.AutoSize = true;
            Controls.Add(lblStudent);

            txtStudent = new TextBox();
            txtStudent.Location = new Point(x, 30);
            txtStudent.Size = new Size(240, 23);
            Controls.Add(txtStudent);

            btnAddStudent = new Button();
            btnAddStudent.Location = new Point(x + 250, 30);
            btnAddStudent.Size = new Size(80, 23);
            btnAddStudent.Text = "Add";
            btnAddStudent.Click += AddStudent_Click;
            Controls.Add(btnAddStudent);

            var lblTask = new Label();
            lblTask.Text = "New task + deadline:";
            lblTask.Location = new Point(x, 70);
            lblTask.AutoSize = true;
            Controls.Add(lblTask);

            txtTask = new TextBox();
            txtTask.Location = new Point(x, 90);
            txtTask.Size = new Size(330, 23);
            Controls.Add(txtTask);

            dtpDeadline = new DateTimePicker();
            dtpDeadline.Location = new Point(x, 120);
            dtpDeadline.Size = new Size(240, 23);
            dtpDeadline.Format = DateTimePickerFormat.Short;
            dtpDeadline.Value = DateTime.Today.AddDays(7);
            Controls.Add(dtpDeadline);

            btnAddTask = new Button();
            btnAddTask.Location = new Point(x + 250, 120);
            btnAddTask.Size = new Size(80, 23);
            btnAddTask.Text = "Add Task";
            btnAddTask.Click += AddTask_Click;
            Controls.Add(btnAddTask);

            btnDeleteTask = new Button();
            btnDeleteTask.Location = new Point(x, 150);
            btnDeleteTask.Size = new Size(100, 23);
            btnDeleteTask.Text = "Delete Task";
            btnDeleteTask.Click += DeleteTask_Click;
            Controls.Add(btnDeleteTask);

            // Global Task Section
            var lblGlobalTask = new Label();
            lblGlobalTask.Text = "Global task for students:";
            lblGlobalTask.Location = new Point(x, 190);
            lblGlobalTask.AutoSize = true;
            lblGlobalTask.Font = new Font(lblGlobalTask.Font, FontStyle.Bold);
            Controls.Add(lblGlobalTask);

            btnAddGlobalTask = new Button();
            btnAddGlobalTask.Location = new Point(x, 215);
            btnAddGlobalTask.Size = new Size(150, 30);
            btnAddGlobalTask.Text = "Create Global Task...";
            btnAddGlobalTask.Click += AddGlobalTask_Click;
            Controls.Add(btnAddGlobalTask);

            btnSave.Location = new Point(450, 285);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            btnLoad.Click += btnLoad_Click;


            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(535, 285);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 23);
            btnLoad.TabIndex = 4;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;

            // --- form ---
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "Form1";
            Text = "Student Task Manager";

            // adaugari in form (stanga + jos)
            Controls.Add(cmbStudents);
            Controls.Add(clbTasks);
            Controls.Add(lblProgress);
            Controls.Add(btnSave);
            Controls.Add(btnLoad);

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Button btnLoad;
        private CheckedListBox clbTasks;
        private Label lblProgress;
        private ComboBox cmbStudents;
        private TextBox txtStudent;
        private Button btnAddStudent;
        private TextBox txtTask;
        private Button btnAddTask;
        private Button btnDeleteTask;

        private DateTimePicker dtpDeadline;
        
        private Button btnAddGlobalTask;



    }
}