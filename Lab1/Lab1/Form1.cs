using Lab1.Class_lab1;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //створення об'єкта класу табулювання
            Tabul tabul = new Tabul();
            //оголошення змінних
            double xn, xk, xh, a;
            xn = Convert.ToDouble(textBox1.Text);
            xk = Convert.ToDouble(textBox2.Text);
            xh = Convert.ToDouble(textBox3.Text);
            a = Convert.ToDouble(textBox4.Text);
            //очищуємо грід та графік
            dataGridView1.Rows.Clear();
            chart1.Series[0].Points.Clear();
            tabul.tab(xn, xk, xh, a);
            //У циклі заповнюємо грід та графік
            for (int i = 0; i < tabul.n; i++)
            {
                //Округлюємо дані до 2 знаків після коми
                dataGridView1.Rows.Add(Math.Round(tabul.xy[i, 0], 2), Math.Round(tabul.xy[i, 1], 2));
                chart1.Series[0].Points.AddXY(tabul.xy[i, 0], tabul.xy[i, 1]);
            }
        }
        private void одновимірніМасивиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }
        private void двовимірнімасивиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }

        private void unitTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnitTest f = new UnitTest();
            f.Show();
            this.Hide();
        }
    }
}
