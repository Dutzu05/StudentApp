namespace StudentTaskManager
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
            btnSave = new Button();
            btnLoad = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            txtNume = new TextBox();
            txtPrenume = new TextBox();
            btnAdauga = new Button();
            btnSterge = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(205, 255);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            btnLoad.Click += btnLoad_Click;


            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(325, 255);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 23);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(436, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(352, 150);
            dataGridView1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(205, 80);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 3;
            label1.Text = "nume";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(298, 80);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 4;
            label2.Text = "prenume";
            // 
            // txtNume
            // 
            txtNume.Location = new Point(166, 113);
            txtNume.Name = "txtNume";
            txtNume.Size = new Size(100, 23);
            txtNume.TabIndex = 5;
            // 
            // txtPrenume
            // 
            txtPrenume.Location = new Point(283, 113);
            txtPrenume.Name = "txtPrenume";
            txtPrenume.Size = new Size(100, 23);
            txtPrenume.TabIndex = 6;
            txtPrenume.TextChanged += textBox2_TextChanged;
            // 
            // btnAdauga
            // 
            btnAdauga.Location = new Point(180, 152);
            btnAdauga.Name = "btnAdauga";
            btnAdauga.Size = new Size(75, 23);
            btnAdauga.TabIndex = 7;
            btnAdauga.Text = "Adauga";
            btnAdauga.UseVisualStyleBackColor = true;
            btnAdauga.Click += btnAdauga_Click;
            // 
            // btnSterge
            // 
            btnSterge.Location = new Point(308, 152);
            btnSterge.Name = "btnSterge";
            btnSterge.Size = new Size(75, 23);
            btnSterge.TabIndex = 8;
            btnSterge.Text = "Sterge";
            btnSterge.UseVisualStyleBackColor = true;
            btnSterge.Click += btnSterge_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSterge);
            Controls.Add(btnAdauga);
            Controls.Add(txtPrenume);
            Controls.Add(txtNume);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Button btnLoad;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private TextBox txtNume;
        private TextBox txtPrenume;
        private Button btnAdauga;
        private Button btnSterge;
    }
}
