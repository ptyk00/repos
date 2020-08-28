using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            var settings = new Settings();
            settings.ShowDialog();
            textBox1.Text = settings.MySetting;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.ShowBalloonTip(1000, "Tytuł", "Treść", ToolTipIcon.Warning);


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Azure;
            var result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                button2.BackColor = colorDialog1.Color;
            }
        }
    }
}
