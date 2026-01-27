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
            btnSave = new Button();
            btnLoad = new Button();
            clbTasks = new CheckedListBox();
            lblProgress = new Label();
            cmbStudents = new ComboBox();

            SuspendLayout();

            // 
            // clbTasks
            // 
            clbTasks.FormattingEnabled = true;
            clbTasks.Location = new Point(50, 40);
            clbTasks.Name = "clbTasks";
            clbTasks.Size = new Size(300, 154);
            clbTasks.TabIndex = 0;
            clbTasks.ItemCheck += clbTasks_ItemCheck;

            // 
            // btnSave
            // 
            btnSave.Location = new Point(205, 255);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;

            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(325, 255);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 23);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(clbTasks);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(lblProgress);
            Controls.Add(cmbStudents);
            Name = "Form1";
            Text = "Student Task Manager";

            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Location = new Point(50, 210);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(120, 15);
            lblProgress.TabIndex = 3;
            lblProgress.Text = "Completed: 0 / 0";

            // 
            // cmbStudents
            // 
            cmbStudents.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStudents.FormattingEnabled = true;
            cmbStudents.Location = new Point(50, 10);
            cmbStudents.Name = "cmbStudents";
            cmbStudents.Size = new Size(300, 23);
            cmbStudents.TabIndex = 0;
            cmbStudents.SelectedIndexChanged += cmbStudents_SelectedIndexChanged;

            ResumeLayout(false);
        }

        #endregion

        private Button btnSave;
        private Button btnLoad;
        private CheckedListBox clbTasks;
        private Label lblProgress;
        private ComboBox cmbStudents;

    }
}
