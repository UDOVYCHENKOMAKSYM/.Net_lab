namespace Lab1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            button1 = new Button();
            label5 = new Label();
            dataGridView1 = new DataGridView();
            x = new DataGridViewTextBoxColumn();
            y = new DataGridViewTextBoxColumn();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            масивиToolStripMenuItem = new ToolStripMenuItem();
            одновимірніToolStripMenuItem = new ToolStripMenuItem();
            двовимірніМасивиToolStripMenuItem = new ToolStripMenuItem();
            unitTestToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 43);
            label1.Name = "label1";
            label1.Size = new Size(26, 20);
            label1.TabIndex = 0;
            label1.Text = "Xn";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(27, 85);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(57, 27);
            textBox1.TabIndex = 1;
            textBox1.Text = "-1,25";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(142, 43);
            label2.Name = "label2";
            label2.Size = new Size(25, 20);
            label2.TabIndex = 2;
            label2.Text = "Xk";
            label2.Click += label2_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(142, 85);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(57, 27);
            textBox2.TabIndex = 3;
            textBox2.Text = "67,32";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(245, 43);
            label3.Name = "label3";
            label3.Size = new Size(17, 20);
            label3.TabIndex = 4;
            label3.Text = "h";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(245, 85);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(57, 27);
            textBox3.TabIndex = 5;
            textBox3.Text = "0,3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(352, 43);
            label4.Name = "label4";
            label4.Size = new Size(17, 20);
            label4.TabIndex = 6;
            label4.Text = "a";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(352, 85);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(57, 27);
            textBox4.TabIndex = 7;
            textBox4.Text = "0,5";
            // 
            // button1
            // 
            button1.Location = new Point(478, 83);
            button1.Name = "button1";
            button1.Size = new Size(103, 29);
            button1.TabIndex = 8;
            button1.Text = "Обрахувати";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(166, 121);
            label5.Name = "label5";
            label5.Size = new Size(84, 20);
            label5.TabIndex = 9;
            label5.Text = "Результати";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { x, y });
            dataGridView1.Location = new Point(27, 157);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(382, 397);
            dataGridView1.TabIndex = 10;
            // 
            // x
            // 
            x.HeaderText = "x";
            x.MinimumWidth = 6;
            x.Name = "x";
            x.Width = 125;
            // 
            // y
            // 
            y.HeaderText = "y";
            y.MinimumWidth = 6;
            y.Name = "y";
            y.Width = 125;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            chart1.Location = new Point(452, 157);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(594, 397);
            chart1.TabIndex = 11;
            chart1.Text = "chart1";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Знімок_екрана_2026_09_07_164046;
            pictureBox1.Location = new Point(662, 33);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(332, 93);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { масивиToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1079, 28);
            menuStrip1.TabIndex = 13;
            menuStrip1.Text = "menuStrip1";
            // 
            // масивиToolStripMenuItem
            // 
            масивиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { одновимірніToolStripMenuItem, двовимірніМасивиToolStripMenuItem, unitTestToolStripMenuItem });
            масивиToolStripMenuItem.Name = "масивиToolStripMenuItem";
            масивиToolStripMenuItem.Size = new Size(77, 24);
            масивиToolStripMenuItem.Text = "Масиви";
            // 
            // одновимірніToolStripMenuItem
            // 
            одновимірніToolStripMenuItem.Name = "одновимірніToolStripMenuItem";
            одновимірніToolStripMenuItem.Size = new Size(239, 26);
            одновимірніToolStripMenuItem.Text = "Одновимірні масиви";
            одновимірніToolStripMenuItem.Click += одновимірніМасивиToolStripMenuItem_Click;
            // 
            // двовимірніМасивиToolStripMenuItem
            // 
            двовимірніМасивиToolStripMenuItem.Name = "двовимірніМасивиToolStripMenuItem";
            двовимірніМасивиToolStripMenuItem.Size = new Size(239, 26);
            двовимірніМасивиToolStripMenuItem.Text = "Двовимірні масиви";
            двовимірніМасивиToolStripMenuItem.Click += двовимірнімасивиToolStripMenuItem_Click;
            // 
            // unitTestToolStripMenuItem
            // 
            unitTestToolStripMenuItem.Name = "unitTestToolStripMenuItem";
            unitTestToolStripMenuItem.Size = new Size(239, 26);
            unitTestToolStripMenuItem.Text = "Unit Test";
            unitTestToolStripMenuItem.Click += unitTestToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1079, 602);
            Controls.Add(pictureBox1);
            Controls.Add(chart1);
            Controls.Add(dataGridView1);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
        private Button button1;
        private Label label5;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn x;
        private DataGridViewTextBoxColumn y;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem масивиToolStripMenuItem;
        private ToolStripMenuItem одновимірніToolStripMenuItem;
        private ToolStripMenuItem двовимірніМасивиToolStripMenuItem;
        private ToolStripMenuItem unitTestToolStripMenuItem;
    }
}
