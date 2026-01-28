using StudentTaskManager.Models;
using System.Linq;


namespace StudentTaskManager
{
    public partial class Form1 : Form
    {
        private List<Student> students = new();
        private Student? currentStudent;


        public Form1()
        {
            InitializeComponent();
            LoadDummyData();
        }

        private void LoadDummyData()
        {
            students = new List<Student>
    {
        new Student
        {
            Name = "Alice",
            Tasks = new List<TaskItem>
            {
                new TaskItem { Title = "Math Homework", IsCompleted = false },
                new TaskItem { Title = "Science Project", IsCompleted = true },
            }
        },
        new Student
        {
            Name = "Bob",
            Tasks = new List<TaskItem>
            {
                new TaskItem { Title = "History Essay", IsCompleted = false },
                new TaskItem { Title = "Reading", IsCompleted = false },
            }
        }
    };

            // Populate dropdown
            cmbStudents.DataSource = students;
            cmbStudents.DisplayMember = "Name";

            // Select first student by default (if any)
            if (students.Count > 0)
            {
                cmbStudents.SelectedIndex = 0; // triggers selection event or you set manually below
            }
        }

        private void cmbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentStudent = cmbStudents.SelectedItem as Student;
            RefreshTaskList();
        }


        private void UpdateProgress()
        {
            if (currentStudent == null)
            {
                lblProgress.Text = "Progress: -";
                return;
            }

            int completedCount = currentStudent.Tasks.Count(t => t.IsCompleted);
            int totalCount = currentStudent.Tasks.Count;

            lblProgress.Text = $"{currentStudent.Name}: {completedCount}/{totalCount} tasks completed";
        }


        private void RefreshTaskList()
        {
            clbTasks.Items.Clear();

            if (currentStudent == null)
            {
                lblProgress.Text = "Progress: -";
                return;
            }

            foreach (var task in currentStudent.Tasks)
            {
                clbTasks.Items.Add(task.Title, task.IsCompleted);
            }

            UpdateProgress();
        }


        private void clbTasks_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (currentStudent == null) return;
            if (e.Index < 0 || e.Index >= currentStudent.Tasks.Count) return;

            currentStudent.Tasks[e.Index].IsCompleted = (e.NewValue == CheckState.Checked);
            UpdateProgress();
        }

        private void AddStudent_Click(object sender, EventArgs e)
        {
            var name = txtStudent.Text.Trim();
            if (string.IsNullOrEmpty(name)) return;

            if (!students.Any(s => s.Name == name))
            {
                students.Add(new Student { Name = name });
                cmbStudents.DataSource = null;
                cmbStudents.DataSource = students;
                cmbStudents.DisplayMember = "Name";
                txtStudent.Clear();
            }
        }

        private void AddTask_Click(object sender, EventArgs e)
        {
            if (currentStudent == null) return;

            var title = txtTask.Text.Trim();
            if (string.IsNullOrEmpty(title)) return;

            currentStudent.Tasks.Add(new TaskItem { Title = title, IsCompleted = false });
            RefreshTaskList();
            txtTask.Clear();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save logic comes next
        }
    }
}
