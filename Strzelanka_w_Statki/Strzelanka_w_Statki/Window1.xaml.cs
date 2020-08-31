using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Strzelanka_w_Statki
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public string nazwaGracza { get; set; }
        
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            nazwaGracza = NazwaGracza.Text;
            var mainWindow = new MainWindow(nazwaGracza);
            mainWindow.Show();           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var Window2 = new Window2();
            Window2.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
