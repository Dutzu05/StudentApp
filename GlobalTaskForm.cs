using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using StudentTaskManager.Models;

namespace StudentTaskManager
{
    public partial class GlobalTaskForm : Form
    {
        public string TaskTitle { get; private set; }
        public DateTime TaskDeadline { get; private set; }
        public List<Student> SelectedStudents { get; private set; }

        private CheckedListBox clbStudents;
        private CheckBox chkSelectAll;
        private TextBox txtTaskTitle;
        private DateTimePicker dtpTaskDeadline;
        private Button btnOK;
        private Button btnCancel;
        private Label lblTitle;
        private Label lblDeadline;
        private Label lblStudents;

        private List<Student> allStudents;

        public GlobalTaskForm(List<Student> students)
        {
            allStudents = students;
            SelectedStudents = new List<Student>();
            InitializeComponent();
            LoadStudents();
        }

        private void InitializeComponent()
        {
            this.Text = "Add Global Task";
            this.Size = new System.Drawing.Size(450, 450);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Task Title Label
            lblTitle = new Label();
            lblTitle.Text = "Task Title:";
            lblTitle.Location = new System.Drawing.Point(20, 20);
            lblTitle.AutoSize = true;
            this.Controls.Add(lblTitle);

            // Task Title TextBox
            txtTaskTitle = new TextBox();
            txtTaskTitle.Location = new System.Drawing.Point(20, 45);
            txtTaskTitle.Size = new System.Drawing.Size(390, 23);
            this.Controls.Add(txtTaskTitle);

            // Deadline Label
            lblDeadline = new Label();
            lblDeadline.Text = "Deadline:";
            lblDeadline.Location = new System.Drawing.Point(20, 80);
            lblDeadline.AutoSize = true;
            this.Controls.Add(lblDeadline);

            // Deadline DateTimePicker
            dtpTaskDeadline = new DateTimePicker();
            dtpTaskDeadline.Location = new System.Drawing.Point(20, 105);
            dtpTaskDeadline.Size = new System.Drawing.Size(250, 23);
            dtpTaskDeadline.Format = DateTimePickerFormat.Short;
            dtpTaskDeadline.Value = DateTime.Today.AddDays(7);
            this.Controls.Add(dtpTaskDeadline);

            // Students Label
            lblStudents = new Label();
            lblStudents.Text = "Select Students:";
            lblStudents.Location = new System.Drawing.Point(20, 145);
            lblStudents.AutoSize = true;
            this.Controls.Add(lblStudents);

            // Select All CheckBox
            chkSelectAll = new CheckBox();
            chkSelectAll.Text = "Select All";
            chkSelectAll.Location = new System.Drawing.Point(20, 170);
            chkSelectAll.AutoSize = true;
            chkSelectAll.CheckedChanged += ChkSelectAll_CheckedChanged;
            this.Controls.Add(chkSelectAll);

            // Students CheckedListBox
            clbStudents = new CheckedListBox();
            clbStudents.Location = new System.Drawing.Point(20, 200);
            clbStudents.Size = new System.Drawing.Size(390, 140);
            this.Controls.Add(clbStudents);

            // OK Button
            btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.Location = new System.Drawing.Point(240, 360);
            btnOK.Size = new System.Drawing.Size(80, 30);
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Click += BtnOK_Click;
            this.Controls.Add(btnOK);

            // Cancel Button
            btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Location = new System.Drawing.Point(330, 360);
            btnCancel.Size = new System.Drawing.Size(80, 30);
            btnCancel.DialogResult = DialogResult.Cancel;
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
        }

        private void LoadStudents()
        {
            clbStudents.Items.Clear();
            foreach (var student in allStudents)
            {
                clbStudents.Items.Add(student.Name, false);
            }
        }

        private void ChkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clbStudents.Items.Count; i++)
            {
                clbStudents.SetItemChecked(i, chkSelectAll.Checked);
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaskTitle.Text))
            {
                MessageBox.Show("Please enter a task title!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            if (clbStudents.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one student!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            TaskTitle = txtTaskTitle.Text.Trim();
            TaskDeadline = dtpTaskDeadline.Value.Date;
            
            SelectedStudents.Clear();
            for (int i = 0; i < clbStudents.Items.Count; i++)
            {
                if (clbStudents.GetItemChecked(i))
                {
                    SelectedStudents.Add(allStudents[i]);
                }
            }
        }
    }
}
