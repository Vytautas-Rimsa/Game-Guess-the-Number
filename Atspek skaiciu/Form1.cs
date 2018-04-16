using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atspek_skaiciu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random random = new Random();
        int returnValue;
        
        void RefreshCounter()
        {
            label2.Text = "Total Guesses: " + Convert.ToString(listBox1.Items.Count);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = true;
            comboBox1.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = false;
            comboBox1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            returnValue = random.Next(0, 101);
            

            radioButton1.Checked = true;
            comboBox1.Enabled = false;
            RefreshCounter();
            trackBar2.Value = trackBar2.Minimum;
            trackBar1.Value = trackBar1.Maximum;
            MessageBox.Show("Choose Your difficulty and guess a Number");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            returnValue = random.Next(0, 101);

            int guess = Convert.ToInt32(textBox1.Text);
            if (guess < 0 || guess > 100)
            {
                MessageBox.Show("Invalid Number, try again");
            }
            else
            {


                /*Random random = new Random();
                if (comboBox1.SelectedIndex == 0) returnValue = random.Next(1, 11);
                if (comboBox1.SelectedIndex == 1) returnValue = random.Next(1, 51);
                if (comboBox1.SelectedIndex == 2) returnValue = random.Next(1, 101);*/



                if (guess > returnValue)
                {
                    MessageBox.Show("Lesser");
                }
                if (guess < returnValue)
                {
                    MessageBox.Show("Bigger");
                }
                if (guess == returnValue)
                {
                    MessageBox.Show("CONGRATULATIONS!!!" + Environment.NewLine + "      Yor are right!!!");
                }
            }
            listBox1.Items.Add(textBox1.Text);
            textBox1.Clear();
            RefreshCounter();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            comboBox1.Enabled = false;
            comboBox1.ResetText();
            textBox1.Clear();
            listBox1.Items.Clear();
            RefreshCounter();
            trackBar2.Value = trackBar2.Minimum;
            trackBar1.Value = trackBar1.Maximum;
        }
    }
}


