using System;
using System.Windows.Forms;

namespace Atspek_skaiciu
{
    public partial class Form1 : Form
    {
        private static int maxNumber = 1000;
        private static int randomNumber;
        int guess, preguess = 0;

        public Form1()
        {
            InitializeComponent();
            setRandom();
            label6.Text = Convert.ToString(trackBar2.Minimum);
            label7.Text = Convert.ToString(trackBar1.Maximum);
        }

        private static void setRandom()
        {
            Random Random = new Random();
            randomNumber = Random.Next(1, maxNumber);
        }

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
            radioButton1.Checked = true;
            comboBox1.Enabled = false;
            RefreshCounter();
            trackBar2.Value = trackBar2.Minimum;
            trackBar1.Value = trackBar1.Maximum;
            MessageBox.Show("Choose Your difficulty and guess a Number");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guess = Convert.ToInt32(textBox1.Text);
            trackBar1.Maximum = Convert.ToInt32(maxNumber);
            trackBar2.Maximum = Convert.ToInt32(maxNumber);

            if (guess < 0 || guess > maxNumber)
            {
                MessageBox.Show("Invalid Number, try again");
            }

            else if (guess > randomNumber)
            {
                if (guess >= preguess && preguess > randomNumber || guess > trackBar1.Value)
                {
                    label7.Text = Convert.ToString(trackBar1.Value);
                    MessageBox.Show("Dumb answer, your previous guess was higher");
                }
                else
                {
                    trackBar1.Value = Convert.ToInt32(guess);
                    label7.Text = Convert.ToString(trackBar1.Value);
                    MessageBox.Show("Lesser");
                }
                preguess = guess;
            }

            else if (guess < randomNumber)
            {
                if (guess <= preguess && preguess < randomNumber || guess < trackBar2.Value)
                {
                    label6.Text = Convert.ToString(trackBar2.Value);
                    MessageBox.Show("Dumb answer, your previous guess was lower");
                }
                else
                {
                    trackBar2.Value = Convert.ToInt32(guess);
                    label6.Text = Convert.ToString(trackBar2.Value);
                    MessageBox.Show("Bigger");
                }
                preguess = guess;
            }

            if (guess == randomNumber)
            {
                MessageBox.Show("CONGRATULATIONS!!!" + Environment.NewLine + "      Yor are right!!!");
                setRandom();
            }

            listBox1.Items.Add(textBox1.Text);
            textBox1.Clear();
            RefreshCounter();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Beginner":
                    maxNumber = 10;
                    trackBar1.Maximum = 10;
                    trackBar1.Value = 10;
                    break;
                case "Medium":
                    maxNumber = 100;
                    trackBar1.Maximum = 100;
                    trackBar1.Value = 100;
                    break;
                case "Expert":
                    maxNumber = 1000;
                    trackBar1.Maximum = 1000;
                    trackBar1.Value = 1000;
                    break;
            }
            label4.Text = "Choose a Number from 0 - " + maxNumber;
            label7.Text = Convert.ToString(trackBar1.Maximum);
            setRandom();
            textBox1.Clear();
            listBox1.Items.Clear();
            RefreshCounter();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            maxNumber = Convert.ToInt32(numericUpDown1.Value);
            trackBar1.Maximum = int.Parse(numericUpDown1.Value.ToString());
            trackBar1.Value = int.Parse(numericUpDown1.Value.ToString());
            label7.Text = Convert.ToString(trackBar1.Maximum);
            label5.Text = "Choose a Number from 0 - " + maxNumber.ToString();
            setRandom();
            textBox1.Clear();
            listBox1.Items.Clear();
            RefreshCounter();
        }
    }
}


/*while (guess != randomNumber)
            {
                while (guess < 0 || guess > maxNumber)
                {
                    MessageBox.Show("Invalid Number, try again");
                }
                if (guess > randomNumber)               {
                   

                    if (guesscount > 1 && guess >= preQuess && preQuess > randomNumber)
                    {
                        trackBar1.Value = Convert.ToInt32(preQuess);
                        label7.Text = Convert.ToString(trackBar1.Value);
                        MessageBox.Show("Dumb answer, your previous guess was higher");
                    }
                    else
                    {
                        MessageBox.Show("Lesser");
                    }
                }
                else
                {                    
                    if (guesscount > 1 && guess <= preQuess && preQuess<randomNumber)
                    {
                        trackBar2.Value = Convert.ToInt32(preQuess);
                        label6.Text = Convert.ToString(trackBar2.Value);
                        MessageBox.Show("Dumb answer, your previous guess was lower");
                    }
                    else
                    {
                        MessageBox.Show("Bigger");
                    }
                }
                preQuess = guess;
                //++guesscount;
                MessageBox.Show("Guess again: ");
                guess = Convert.ToInt32(Console.ReadLine());
            }
            MessageBox.Show("CONGRATULATIONS!!!" + Environment.NewLine + "      Yor are right!!!");
            setRandom();
listBox1.Items.Add(textBox1.Text);
            textBox1.Clear();
            RefreshCounter();*/
