using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace print3
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("DataSource=localhost; UserID = root; database=clinica");
        public Form1()
        {
            InitializeComponent();
            conn.Open();
            loadDoctors();
        }

        void loadDoctors()
        {
            MySqlCommand fetchDoctors = conn.CreateCommand();
            fetchDoctors.CommandText = "Select medic_id, nume, orar from medici";
            MySqlDataReader readDoctors = fetchDoctors.ExecuteReader();
            while (readDoctors.Read())
            {
                listBox1.Items.Add($"ID: {readDoctors["medic_id"]} <> Nume: {readDoctors["nume"]} <> Orar: {readDoctors["orar"]}");
            }
            readDoctors.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdaugareMedic adaugMedic = new AdaugareMedic();
            adaugMedic.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Programare consultatie = new Programare();
            consultatie.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Raportare raport = new Raportare();
            raport.ShowDialog();
        }
    }
}
