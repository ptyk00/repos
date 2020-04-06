using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace PIV_Lab6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
        }

        BindingList<Number> numbers = new BindingList<Number>();

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var dialog = (OpenFileDialog)sender;
           
            var path = dialog.FileName;
            var fileContent = File.ReadAllText(path);

            label1.Visible = true;
            button1.Enabled = true;

            foreach (var item in fileContent
                .Split(new[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries))
            {
                flowLayoutPanel1.Controls.Add(GenerateNumber(Convert.ToInt32(item)));
            }

         
        }

        private TextBox GenerateNumber(int number)
        {
            return new TextBox()
            {
                Text = number.ToString(),
                ReadOnly = true,
                Width = 25
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                var rndNumber = rnd.Next(100);
                textBox1.Text = rndNumber.ToString();
                flowLayoutPanel2.Controls.Add(GenerateNumber(rndNumber));
                Application.DoEvents();
                Thread.Sleep(10);
            }
        }
    }
}
