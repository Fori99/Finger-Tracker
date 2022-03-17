using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO.Ports;
namespace DarkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Funksione_MySql.Gjej_Punonjesit_Online(dataGridView1);            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 regjistrohu = new Form2();
            this.Hide();
            regjistrohu.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 modifiko = new Form3();
            this.Hide();
            modifiko.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Funksione_MySql.Gjej_Punonjesit_Online(dataGridView1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Open();
                MessageBox.Show("Connection achieved successfully !");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //Funksione_MySql.login_logout(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void login_logout(object sender, SerialDataReceivedEventArgs e)
        {
            string arduino_Data = serialPort1.ReadLine();
            //string msg = "Finger ID :";
            //MessageBox.Show(arduino_Data, msg);

            Funksione_MySql.login_logout(int.Parse(arduino_Data));
            //Funksione_MySql.Gjej_Punonjesit_Online(dataGridView1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
