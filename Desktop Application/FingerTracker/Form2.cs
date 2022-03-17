using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkDemo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Funksione_MySql.Rifresko(dataGridView1);            
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 regjistrohu = new Form1();
            this.Hide();
            regjistrohu.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Funksione_MySql.insert(int.Parse(idBox.Text), emriBox.Text, mbiemriBox.Text, pozicioniBox.Text, int.Parse(rrogaBox.Text), dateTimePicker1.Value.Date, celBox.Text, mailBox.Text, kodiBox.Text, dataGridView1);
            emriBox.Clear();
            mbiemriBox.Clear();
            pozicioniBox.Clear();
            rrogaBox.Clear();            
            celBox.Clear();
            mailBox.Clear();
            kodiBox.Clear();
            idBox.Clear();
            Funksione_MySql.Rifresko(dataGridView1);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 modifiko = new Form3();
            this.Hide();
            modifiko.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

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
        }

        private void enroll(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {            
            string data = serialPort1.ReadLine();
            string caption = "Enroll Fingerprint";

            MessageBox.Show(data, caption);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
