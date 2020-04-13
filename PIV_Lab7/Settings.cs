using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace z7_winforms2
{
    public partial class Settings : Form
    {
        public string MySetting { get; private set; }
        public Settings()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MySetting = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();//powino byc zabezpiecznie cos jaksi if
            var font = fontDialog1.Font;
            var color = fontDialog1.Color;
            richTextBox1.Font = font;
            richTextBox1.ForeColor = color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //progressBar1.Value = 20;
            progressBar1.PerformStep();
        }
    }
}
