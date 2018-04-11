using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mathQuiz
{
    public partial class Form2 : Form
    {
        int time=61;
        Random randomizer = new Random();
        int operators;
        double number1;
        double number2;
        double answer;
        double input1;

        public Form2()

        {
            InitializeComponent();
        }

        private bool CheckTheAnswer()
        {
            if (answer == input1)
                return true;
            else
                return false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            number1 = randomizer.Next(50, 100);
            number2 = randomizer.Next(1, 49);

            label1.Text = number1.ToString();
            label4.Text = number2.ToString();
                       
            int operators = randomizer.Next(4);

            switch (operators)
            {
                case 0:
                    answer = number1 + number2;
                    label3.Text = "+";
                        break;
                case 1:
                    answer = number1 * number2;
                    label3.Text = "*";
                        break;
                case 2:
                    answer = number1 - number2;
                    label3.Text = "-";
                    break;
                case 3:
                    answer = SneakieRounder(number1 / number2);
                    label3.Text = "/";
                    break;
            }

            int SneakieRounder(double answer)
            {
                return (int)(answer + 0.5);
            }

        }

        private void lblTimeLeft_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) || e.KeyChar == '.';
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(time > 0)
            {
                time = time - 1;
                lblTimeLeft.Text = time + " seconds";
            }
            else
            {
                timer1.Stop();
                //timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                Application.Exit();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Input needed");
                return;
            }

            string input = textBox1.Text;
            input1 = Convert.ToDouble(input);

            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("you da best");
                Application.Exit();
            }
            else if (time > 0)
            { 
                MessageBox.Show("wrong, try again");
                time = time++;
                lblTimeLeft.Text = time + " seconds";

            }
            else
            {
                timer1.Stop();
                MessageBox.Show("Times up");
                Application.Exit();
            }
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) || e.KeyChar == '.';
        }

        private void label6_Click(object sender, EventArgs e)
        {
            //number3
        }

        private void label7_Click(object sender, EventArgs e)
        {
            //operator2
        }

        private void label8_Click(object sender, EventArgs e)
        {
            //number4
        }
    }
}
