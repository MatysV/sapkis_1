using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sapkis_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public double a, b, result; char c; bool old = false;

        public void printIn(String n)
        {
            if (n == ",")
            {
                if (!label1.Text.Contains(",") && !old) label1.Text += ",";
                else if (old)
                {
                    label1.Text = "0,";
                    old = false;
                }
            }
            else if (n == "-")
            {
                if (label1.Text[0] != '-' && label1.Text != "0") label1.Text = "-" + label1.Text;
                else if (label1.Text[0] == '-') label1.Text = label1.Text.Remove(0, 1);
            }
            else if (label1.Text == "0" || old)
            {
                label1.Text = n;
                old = false;
            }
            else if (label1.Text.Length < 20) label1.Text += n;
        }

        public void pressed(String n, bool active)
        {
            if (active)
            {
                Controls["button" + n].BackColor = Color.White;
                Controls["button" + n].ForeColor = Color.DarkOrange;
            }
            else
            {
                Controls["button" + n].BackColor = Color.DarkOrange;
                Controls["button" + n].ForeColor = Color.White;
            }
        }
        public void clear()
        {
            label1.Text = "0";
            a = b = 0; c = '\0';
            for (int i = 12; i <= 16; i++)
            {
                pressed(Convert.ToString(i), false);
            }
        }
        public	void doFunction(double a, double b, char c)
        {
            if (c != 0)
            {
                switch (c)
                {
                    case '+':
                        {
                            result = a + b;
                            pressed("13", false);
                            break;
                        };
                    case '-':
                        {
                            result = a - b;
                            pressed("14", false);
                            break;
                        };
                    case '×':
                        {
                            result = a * b;
                            pressed("15", false);
                            break;
                        };
                    case '/':
                        {
                            result = a / b;
                            pressed("16", false);
                            break;
                        };
                    default: break;
                };
                label1.Text = Convert.ToString(result);
                old = true;
            }
        }
        private void button1_Click(object sender, EventArgs e) { printIn("1"); }
        private void button2_Click(object sender, EventArgs e) { printIn("2"); }
        private void button3_Click(object sender, EventArgs e) { printIn("3"); }
        private void button4_Click(object sender, EventArgs e) { printIn("4"); }
        private void button5_Click(object sender, EventArgs e) { printIn("5"); }
        private void button6_Click(object sender, EventArgs e) { printIn("6"); }
        private void button7_Click(object sender, EventArgs e) { printIn("7"); }
        private void button8_Click(object sender, EventArgs e) { printIn("8"); }
        private void button9_Click(object sender, EventArgs e) { printIn("9"); }
        private void button10_Click(object sender, EventArgs e) { printIn("0"); }
        private void button11_Click(object sender, EventArgs e) { printIn(","); }
	    private void button17_Click(object sender, EventArgs e) {
            if (a == 0)
            {
                label1.Text = Convert.ToString(Convert.ToDouble(label1.Text) * 0.01);
                old = true;
            }
            else
            {
                label1.Text = Convert.ToString(a * (Convert.ToDouble(label1.Text) * 0.01));
                old = true;
            }
        }
	    private void button18_Click(object sender, EventArgs e) { printIn("-"); }
	    private void button19_Click(object sender, EventArgs e) { clear(); }

        private void button12_Click(object sender, EventArgs e)
        {
            if (c != 0)
            {
                b = Convert.ToDouble(label1.Text);
                doFunction(a, b, c);
                a = b = 0; c = '\0';
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            pressed("13", true);
            if (c != 0)
            {
                doFunction(a, b = Convert.ToDouble(label1.Text), c);
                pressed("13", true);
            }
            a = Convert.ToDouble(label1.Text);
            old =true;
            c = '+';
        }
        private void button14_Click(object sender, EventArgs e)
        {
            pressed("14", true);
            if (c != 0)
            {
                doFunction(a, b = Convert.ToDouble(label1.Text), c);
                pressed("14", true);
            }
            a = Convert.ToDouble(label1.Text);
            old =true;
            c = '-';
        }


        private void button15_Click(object sender, EventArgs e)
        {
            pressed("15", true);
            if (c != 0)
            {
                doFunction(a, b = Convert.ToDouble(label1.Text), c);
                pressed("15", true);
            }
            a = Convert.ToDouble(label1.Text);
            old =true;
            c = '×';
        }
        private void button16_Click(object sender, EventArgs e)
        {
            pressed("16", true);
            if (c != 0)
            {
                doFunction(a, b = Convert.ToDouble(label1.Text), c);
                pressed("16", true);
            }
            a = Convert.ToDouble(label1.Text);
            old =true;
            c = '/';
        }
        private void button20_Click(object sender, EventArgs e)
        {
            if (label1.Text.Length > 1) label1.Text = label1.Text.Remove(label1.Text.Length - 1, 1);
            else label1.Text = "0";
        }
        private void button21_Click(object sender, EventArgs e)
        {
            label1.Text = Convert.ToString(Math.Pow(Convert.ToDouble(label1.Text), 2));
        }
        private void button22_Click(object sender, EventArgs e)
        {
            label1.Text = Convert.ToString(Math.Pow(Convert.ToDouble(label1.Text), 0.5));
        }
        private void button23_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
        }
        private void button24_Click(object sender, EventArgs e)
        {
            label1.Text = Convert.ToString(1.0 / System.Convert.ToDouble(label1.Text));
            old = true;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.D0:
                case Keys.NumPad0: {
                        button10.PerformClick();
                        break;
                    };
                case Keys.D1 :
                case Keys.NumPad1:
                    {
                        button1.PerformClick();
                        break;
                    }
                case Keys.D2:
                case Keys.NumPad2:
                    {
                        button2.PerformClick();
                        break;
                    }
                case Keys.D3:
                case Keys.NumPad3:
                    {
                        button3.PerformClick();
                        break;
                    }
                case Keys.D4:
                case Keys.NumPad4:
                    {
                        button4.PerformClick();
                        break;
                    }
                case Keys.D5:
                case Keys.NumPad5:
                    {
                        button5.PerformClick();
                        break;
                    }
                case Keys.D6:
                case Keys.NumPad6:
                    {
                        button6.PerformClick();
                        break;
                    }
                case Keys.D7:
                case Keys.NumPad7:
                    {
                        button7.PerformClick();
                        break;
                    }
                case Keys.D8:
                case Keys.NumPad8:
                    {
                        button8.PerformClick();
                        break;
                    }
                case Keys.D9:
                case Keys.NumPad9:
                    {
                        button9.PerformClick();
                        break;
                    }
                case Keys.Decimal:
                    {
                        button11.PerformClick();
                        break;
                    }
                case Keys.Add:
                    {
                        button13.PerformClick();
                        break;
                    }
                case Keys.Subtract:
                    {
                        button14.PerformClick();
                        break;
                    }
                case Keys.Multiply:
                    {
                        button15.PerformClick();
                        break;
                    }
                case Keys.Divide:
                    {
                        button16.PerformClick();
                        break;
                    }
                case Keys.Back:
                    {
                        button20.PerformClick();
                        break;
                    }
                case Keys.Enter:
                    {
                        button12.PerformClick();
                        break;
                    }

            }
        }
    }
}
