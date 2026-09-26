using Lab1.Class_lab2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab1
{
    public partial class UnitTest : Form
    {
        public UnitTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms[0];
            form.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var calc = new Calculation_abc(
                    Convert.ToInt32(textBox1.Text),
                    Convert.ToInt32(textBox2.Text),
                    Convert.ToInt32(textBox3.Text));
                label4.Text = calc.D().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var calc = new Calculation_ab(
                    Convert.ToInt32(textBox4.Text),
                    Convert.ToInt32(textBox5.Text));
                label7.Text = calc.Sum().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var t = new Triangle(
                    Convert.ToDouble(textBox8.Text),
                    Convert.ToDouble(textBox7.Text),
                    Convert.ToDouble(textBox6.Text));
                label8.Text = t.CalculateArea().ToString();
                label12.Text = t.GetTriangleType().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
