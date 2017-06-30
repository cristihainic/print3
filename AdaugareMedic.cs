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
    public partial class AdaugareMedic : Form
    {
        MySqlConnection conn = new MySqlConnection("DataSource=localhost; UserID = root; database=clinica");
        public AdaugareMedic()
        {
            InitializeComponent();
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nume = textBox1.Text;
            string orar = textBox2.Text;
            MySqlCommand insertDoctor = conn.CreateCommand();
            insertDoctor.CommandText = $"INSERT INTO medici (nume, orar) VALUES ('{nume}', '{orar}')";
            insertDoctor.ExecuteReader();
            MessageBox.Show("Adaugat!");
            textBox1.Clear();
            textBox2.Clear();
            conn.Close();
        }
    }
}
