using StudentTaskManager.Models;

namespace StudentTaskManager
{
    public partial class Form1 : Form
    {
        private List<TaskItem> tasks = new();

        public Form1()
        {
            InitializeComponent();
            LoadDummyTasks();
        }

        private void LoadDummyTasks()
        {
            tasks.Add(new TaskItem { Title = "Math Homework", IsCompleted = false });
            tasks.Add(new TaskItem { Title = "Science Project", IsCompleted = false });
            tasks.Add(new TaskItem { Title = "History Essay", IsCompleted = false });

            RefreshTaskList();
        }

        private void RefreshTaskList()
        {
            clbTasks.Items.Clear();

            foreach (var task in tasks)
            {
                clbTasks.Items.Add(task.Title, task.IsCompleted);
            }
        }

        private void clbTasks_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index >= 0 && e.Index < tasks.Count)
            {
                tasks[e.Index].IsCompleted =
                    e.NewValue == CheckState.Checked;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save logic comes next
        }
    }
}
