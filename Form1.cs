using StudentTaskManager.Services;

namespace StudentTaskManager
{
    public partial class Form1 : Form
    {
        private StudentsManager studentsmanager = new StudentsManager();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            string nume = txtNume.Text;
            string prenume = txtPrenume.Text;
            try
            {
                studentsmanager.AddStudent(nume, prenume);
                RefreshTabel();
                MessageBox.Show("Student adaugat cu succes!");
                txtNume.Clear();    
                txtPrenume.Clear();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSterge_Click(object sender, EventArgs e)
        {
            string nume = txtNume.Text;
            string prenume = txtPrenume.Text;
            try
            {
                studentsmanager.RemoveStudent(nume, prenume);
                RefreshTabel();
                MessageBox.Show("Student sters cu succes!");
                txtNume.Clear();     
                txtPrenume.Clear();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void RefreshTabel()
        {
            var students = studentsmanager.GetAllStudents();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = students;
        }
    }
}
