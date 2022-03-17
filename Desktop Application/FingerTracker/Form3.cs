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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Funksione_MySql.Rifresko(dataGridView1);
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 dashbard = new Form1();
            this.Hide();
            dashbard.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 regjistro = new Form2();
            this.Hide();
            regjistro.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Funksione_MySql.update_emri(int.Parse(idBox.Text), emriBox.Text);
                emriBox.Clear();
            }

            if (checkBox2.Checked == true)
            {
                Funksione_MySql.update_mbiemri(int.Parse(idBox.Text), mbiemriBox.Text);
                mbiemriBox.Clear();
            }

            if (checkBox3.Checked == true)
            {
                Funksione_MySql.update_pozicioni(int.Parse(idBox.Text), pozicioniBox.Text);
                pozicioniBox.Clear();
            }

            if (checkBox4.Checked == true)
            {
                Funksione_MySql.update_rrogen(int.Parse(idBox.Text), int.Parse(rrogaBox.Text));
                rrogaBox.Clear();
            }

            if (checkBox5.Checked == true)
            {
                Funksione_MySql.update_ditelindja(int.Parse(idBox.Text), dateTimePicker1.Value.Date);
                //dateTimePicker1.def();
            }

            if (checkBox6.Checked == true)
            {
                Funksione_MySql.update_nrCel(int.Parse(idBox.Text), celBox.Text);
                celBox.Clear();
            }

            if (checkBox7.Checked == true)
            {
                Funksione_MySql.update_eMail(int.Parse(idBox.Text), mailBox.Text);
                mailBox.Clear();
            }

            if (checkBox8.Checked == true)
            {
                Funksione_MySql.update_kodin(int.Parse(idBox.Text), kodiBox.Text);
                kodiBox.Clear();
            }
            idBox.Clear();
            Funksione_MySql.Rifresko(dataGridView1);
        }

        private void datarecived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Funksione_MySql.kerko(dataGridView1, textBox2.Text, textBox1.Text);
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
