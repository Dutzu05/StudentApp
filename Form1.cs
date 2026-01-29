using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace StudentTaskManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // BUTON SAVE
        private void btnSave_Click(object sender, EventArgs e)
        {
            AppData data = new AppData
            {
                Studenti = new List<Student>
                {
                    new Student { Id = 1, Nume = "Ana" },
                    new Student { Id = 2, Nume = "Ion" }
                },
                Taskuri = new List<StudentTask>
                {
                    new StudentTask { Titlu = "Tema 1", Completat = false },
                    new StudentTask { Titlu = "Proiect", Completat = true }
                }
            };

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText("data.json", json);
            MessageBox.Show("Datele au fost salvate!");
        }

        // BUTON LOAD
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!File.Exists("data.json"))
            {
                MessageBox.Show("Nu exista fisierul data.json");
                return;
            }

            string json = File.ReadAllText("data.json");
            AppData data = JsonSerializer.Deserialize<AppData>(json);

            MessageBox.Show(
                $"Incarcati {data.Studenti.Count} studenti si {data.Taskuri.Count} taskuri."
            );
        }
    }

    // clase demo

    public class Student
    {
        public int Id { get; set; }
        public string Nume { get; set; }
    }

    public class StudentTask
    {
        public string Titlu { get; set; }
        public bool Completat { get; set; }
    }

    public class AppData
    {
        public List<Student> Studenti { get; set; }
        public List<StudentTask> Taskuri { get; set; }
    }
}
