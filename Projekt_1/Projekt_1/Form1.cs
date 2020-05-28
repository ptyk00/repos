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
    public partial class Form1 : Form
    {
        Produkty produkty = new Produkty();
        public Form1()
        {
            InitializeComponent();
        }

        public void Dane()
        {
            using (BDII_projEntities db = new BDII_projEntities())
            {
                dataGridView1.DataSource = db.Produkty.ToList<Produkty>();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           Dane();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            produkty.IDProduktu       = Convert.ToInt32(textBox1.Text.Trim());
            produkty.NazwaProduktu    = textBox2.Text.Trim();
            produkty.IDKategori       = Convert.ToInt32(textBox3.Text.Trim());
            produkty.IlośćJedkostkowa = Convert.ToInt32(textBox4.Text.Trim());
            produkty.CenaSprzedaży    = Convert.ToDecimal(textBox5.Text.Trim());
            produkty.CenaZakupu       = Convert.ToDecimal(textBox6.Text.Trim());
            produkty.StanMagazynu     = Convert.ToInt32(textBox7.Text.Trim());

            using (BDII_projEntities db = new BDII_projEntities())
            {
                db.Produkty.Add(produkty);
                db.SaveChanges();
            }
            MessageBox.Show("Dodwanie powiodło się", "dodawanie");
            Dane();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            using (BDII_projEntities db = new BDII_projEntities())
            {
                var k = db.Entry(produkty);
                if (k.State == EntityState.Detached)
                    db.Produkty.Attach(produkty); 
                db.Produkty.Remove(produkty);
                db.SaveChanges();
                Dane();
            }
         
            MessageBox.Show("Usunięto wiersz", "usuwanie");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            produkty.IDProduktu = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IDProduktu"].Value);
            using(BDII_projEntities db = new BDII_projEntities())
            {
                produkty = db.Produkty.Where(x => x.IDProduktu == produkty.IDProduktu).FirstOrDefault();

                textBox1.Text = Convert.ToString(produkty.IDProduktu);
                textBox2.Text = produkty.NazwaProduktu;
                textBox3.Text = Convert.ToString(produkty.IDKategori);
                textBox4.Text = Convert.ToString(produkty.IlośćJedkostkowa);
                textBox5.Text = Convert.ToString(produkty.CenaSprzedaży);
                textBox6.Text = Convert.ToString(produkty.CenaZakupu);
                textBox7.Text = Convert.ToString(produkty.StanMagazynu);
            }
        }
    }
}
