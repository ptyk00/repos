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
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Strzelanka_w_Statki.TabelaWynikowDataSet tabelaWynikowDataSet = ((Strzelanka_w_Statki.TabelaWynikowDataSet)(this.FindResource("tabelaWynikowDataSet")));
            // Załaduj dane do tabeli Wyniki. Możesz modyfikować ten kod w razie potrzeby.
            Strzelanka_w_Statki.TabelaWynikowDataSetTableAdapters.WynikiTableAdapter tabelaWynikowDataSetWynikiTableAdapter = new Strzelanka_w_Statki.TabelaWynikowDataSetTableAdapters.WynikiTableAdapter();
            tabelaWynikowDataSetWynikiTableAdapter.Fill(tabelaWynikowDataSet.Wyniki);
            System.Windows.Data.CollectionViewSource wynikiViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("wynikiViewSource")));
            wynikiViewSource.View.MoveCurrentToFirst();
        }
    }
}
