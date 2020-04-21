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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int AllAnsCnt = 0;
        Dictionary<string, int> answers = new Dictionary<string, int>()
        {
            {"A",0 },
            {"B",0 },
            {"C",0 },
            {"D",0 }
        };
        public MainWindow()
        {
            InitializeComponent();
            QuestionTextBloc.Text = "Wolisz A, B, C, czy D?";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var choise = button.Content.ToString();
            answers[choise]++;
            AllAnsCnt++;
            AllAns.Text = AllAnsCnt.ToString();
            RedrawGraph();
        }

        public void RedrawGraph()
        {
            var maxHeight = Canvas.ActualHeight;
            RA.Height = maxHeight * (answers["A"] / (double)AllAnsCnt);
            RB.Height = maxHeight * (answers["B"] / (double)AllAnsCnt);
            RC.Height = maxHeight * (answers["C"] / (double)AllAnsCnt);
            RD.Height = maxHeight * (answers["D"] / (double)AllAnsCnt);

            Stat.Text = answers.Max(x => x.Value).ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
