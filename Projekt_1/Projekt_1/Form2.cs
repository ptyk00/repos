using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_1
{
    public partial class Form2 : Form
    {
        FakturaSprzedaży fakturasprz = new FakturaSprzedaży();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Dane();
        }

        public void Dane()
        {
            using (BDII_projEntities1 db = new BDII_projEntities1())
            {
                dataGridView1.DataSource = db.FakturaSprzedaży.ToList<FakturaSprzedaży>();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fakturasprz.NrFakturySprz = Convert.ToInt32(textBox1.Text.Trim());
            fakturasprz.Opis = textBox2.Text.Trim();
            fakturasprz.DataWystawienia = dateTimePicker1.Value;
            fakturasprz.IDProduktu = Convert.ToInt32(textBox4.Text.Trim());
            fakturasprz.CenaNetto = Convert.ToDecimal(textBox5.Text.Trim());
            fakturasprz.CenaBrutto = Convert.ToDecimal(textBox6.Text.Trim());
            fakturasprz.IDKontrahenta = Convert.ToInt32(textBox7.Text.Trim());
            fakturasprz.TerminPłatności = dateTimePicker2.Value;
            fakturasprz.VAT = Convert.ToInt32(textBox9.Text.Trim());

            using (BDII_projEntities1 db = new BDII_projEntities1())
            {
                db.FakturaSprzedaży.Add(fakturasprz);
                db.SaveChanges();
            }
            MessageBox.Show("Dodwanie powiodło się", "dodawanie");
            Dane();
            textBox1.Text = "";
            textBox2.Text = "";            
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";            
            textBox9.Text = "";
        }
    }
}
