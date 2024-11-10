using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGraphVisualization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string folderPath = Path.Combine(Application.StartupPath, "RGraph");

            if (Directory.Exists(folderPath))
            {
                string[] files = Directory.GetFiles(folderPath);

                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    comboBox1.Items.Add(fileName);
                }
            }
            else
            {
                MessageBox.Show("Belirtilen klasör bulunamadı: " + folderPath);
            }
        }

        private void addFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();

            // Seçilen klasörün yolunu al
            string selectedPath = folderDialog.SelectedPath;

            // Klasördeki dosyaları al ve ilk dosyanın ismini Label'a ekle
            string[] files = Directory.GetFiles(selectedPath);
            label1.Text = (folderDialog.ShowDialog() == DialogResult.OK) ? Path.GetFileName(files[0]) : "Dosya bulunamadı."; // Klasörde dosya yoksa
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearDynamicControls();

            if (comboBox1.SelectedItem.ToString() == "Seçenek 1")
            {
                // Buton ekleyin
                Button button = new Button();
                button.Text = "Dinamik Buton";
                button.Location = new Point(50, 100);
                button.Click += new EventHandler(DynamicButton_Click); // Buton tıklama olayı
                this.Controls.Add(button);

                // RadioButton ekleyin
                RadioButton radio1 = new RadioButton();
                radio1.Text = "Radio 1";
                radio1.Location = new Point(50, 150);
                this.Controls.Add(radio1);

                RadioButton radio2 = new RadioButton();
                radio2.Text = "Radio 2";
                radio2.Location = new Point(50, 180);
                this.Controls.Add(radio2);
            }
            else if (comboBox1.SelectedItem.ToString() == "Seçenek 2")
            {
                // Farklı bir seçim için farklı buton ve radiolar ekleyin
                Button button2 = new Button();
                button2.Text = "Başka Bir Buton";
                button2.Location = new Point(50, 100);
                button2.Click += new EventHandler(DynamicButton_Click);
                this.Controls.Add(button2);

                RadioButton radio3 = new RadioButton();
                radio3.Text = "Radio 3";
                radio3.Location = new Point(50, 150);
                this.Controls.Add(radio3);
            }
        }

        private void DynamicButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dinamik buton tıklandı!");
        }

        private void ClearDynamicControls()
        {
            // Formdaki geçici kontrolleri temizleyin
            foreach (Control ctrl in this.Controls.OfType<Button>().ToList())
            {
                this.Controls.Remove(ctrl);
                ctrl.Dispose(); // Kontrolü hafızadan serbest bırakın
            }

            foreach (Control ctrl in this.Controls.OfType<RadioButton>().ToList())
            {
                this.Controls.Remove(ctrl);
                ctrl.Dispose(); // Kontrolü hafızadan serbest bırakın
            }
        }
    }
}
