using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

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
        private void ShowOverdueNotification()
        {
            if (currentStudent == null) return;

            int overdueCount = currentStudent.Tasks.Count(t => t.IsOverdue);
            if (overdueCount > 0)
            {
                MessageBox.Show($"{currentStudent.Name} has {overdueCount} overdue task(s)!",
                    "Overdue tasks",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }


       

        private void cmbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentStudent = cmbStudents.SelectedItem as Student;
            RefreshTaskList();
            //ShowOverdueNotification();

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
                 var text = $"{task.Title} | due: {task.Deadline:yyyy-MM-dd}";
                if (task.IsOverdue) text = "!!!" + text + " (Overdue)";

                clbTasks.Items.Add(text, task.IsCompleted);
            }
            UpdateProgress();
            ShowOverdueNotification();
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

        currentStudent.Tasks.Add(new TaskItem
        {
            Title = title,
            IsCompleted = false,
            Deadline = dtpDeadline.Value.Date
        });

            RefreshTaskList();
            txtTask.Clear();
        }

        private void AddGlobalTask_Click(object sender, EventArgs e)
        {
            if (students.Count == 0)
            {
                MessageBox.Show("No students available to assign the global task!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var globalTaskForm = new GlobalTaskForm(students))
            {
                if (globalTaskForm.ShowDialog() == DialogResult.OK)
                {
                    var globalTask = new TaskItem
                    {
                        Title = globalTaskForm.TaskTitle,
                        IsCompleted = false,
                        Deadline = globalTaskForm.TaskDeadline
                    };

                    foreach (var student in globalTaskForm.SelectedStudents)
                    {
                        student.Tasks.Add(new TaskItem
                        {
                            Title = globalTask.Title,
                            IsCompleted = globalTask.IsCompleted,
                            Deadline = globalTask.Deadline
                        });
                    }

                    RefreshTaskList();
                    
                    MessageBox.Show($"Global task '{globalTask.Title}' added to {globalTaskForm.SelectedStudents.Count} student(s)!", 
                        "Success", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                }
            }
        }

        private void DeleteTask_Click(object sender, EventArgs e)
        {
            if (currentStudent == null)
            {
                MessageBox.Show("Please select a student first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clbTasks.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a task to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedIndex = clbTasks.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < currentStudent.Tasks.Count)
            {
                var taskToDelete = currentStudent.Tasks[selectedIndex];
                var result = MessageBox.Show(
                    $"Are you sure you want to delete the task '{taskToDelete.Title}'?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    currentStudent.Tasks.RemoveAt(selectedIndex);
                    RefreshTaskList();
                    MessageBox.Show("Task deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // BUTON SAVE
        private void btnSave_Click(object sender, EventArgs e)
        {
            AppData data = new AppData
            {
                Students = students,
                Tasks = currentStudent?.Tasks ?? new List<TaskItem>()
            };

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText("data.json", json);
            MessageBox.Show("Data has been saved!");
        }

        // BUTON LOAD
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!File.Exists("data.json"))
            {
                MessageBox.Show("The file data.json does not exist");
                return;
            }

            string json = File.ReadAllText("data.json");
            AppData data = JsonSerializer.Deserialize<AppData>(json);

            if (data != null && data.Students != null)
            {
                students = data.Students;
                cmbStudents.DataSource = null;
                cmbStudents.DataSource = students;
                cmbStudents.DisplayMember = "Name";

                MessageBox.Show(
                    $"Loaded {data.Students.Count} student(s) with their tasks."
                );
            }
        }
    }

    // Data class for JSON serialization
    public class AppData
    {
        public List<Student> Students { get; set; } = new();
        public List<TaskItem> Tasks { get; set; } = new();
    }
}
