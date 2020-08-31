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
using System.Windows.Threading;

namespace Strzelanka_w_Statki
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Wyniki wyn = new Wyniki();

        public string nazGracza { get; set; }

        DispatcherTimer licznikGry = new DispatcherTimer();
        
        bool prawo, lewo;

        List<Rectangle> usunObiekt = new List<Rectangle>();

        Random rand = new Random();

        int Kontra = 0;
        int SzybkoscPojWrogow = 100;
        int szybkoscGracza = 10;
        int szybkoscWroga = 13;
        int limit = 50;
        int pkty = 0;
        int obr = 0;

        Rect HitBoxGracza;
        
        public MainWindow(string nazwaGracza)
        {
            InitializeComponent();

            nazGracza = nazwaGracza;

            licznikGry.Interval = TimeSpan.FromMilliseconds(20);
            licznikGry.Tick += petla;
            licznikGry.Start();

            MyCanvas.Focus(); //zeby onkeje zastartowaly

            ImageBrush tło = new ImageBrush();
            tło.ImageSource = new BitmapImage(new Uri("pack://application:,,,/obiekty/purple.png"));
            tło.TileMode = TileMode.Tile;
            tło.Viewport = new Rect(0, 0, 0.15, 0.15);
            tło.ViewportUnits = BrushMappingMode.RelativeToBoundingBox;
            MyCanvas.Background = tło;

            ImageBrush ObGracza = new ImageBrush();
            ObGracza.ImageSource = new BitmapImage(new Uri("pack://application:,,,/obiekty/player.png"));
            gracz.Fill = ObGracza;
        }

        private void petla(object sender, EventArgs e)
        {
            HitBoxGracza = new Rect(Canvas.GetLeft(gracz), Canvas.GetTop(gracz), gracz.Width, gracz.Height );
            SzybkoscPojWrogow -= 1;

            punkty.Content = "Ilość zestrzeleń: " + pkty;
            obrazenia.Content = "Obrażenia: " + obr;

            if(SzybkoscPojWrogow < 0)
            {
                wrogowie();
                SzybkoscPojWrogow = limit;
            }
            //Poruszanie się gracza
            if(lewo == true && Canvas.GetLeft(gracz) > 0)
            {
                Canvas.SetLeft(gracz, Canvas.GetLeft(gracz) - szybkoscGracza);
            }
            if (prawo == true && Canvas.GetLeft(gracz) - 100 < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(gracz, Canvas.GetLeft(gracz) + szybkoscGracza);
            }
            //strzały (razem z hitboxem)
            foreach (var x in MyCanvas.Children.OfType<Rectangle>())
            {
                if( x is Rectangle && (string)x.Tag == "pocisk")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) - 20);

                   Rect HitBoxStrzalu = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if(Canvas.GetTop(x)<10)
                    {
                       usunObiekt.Add(x);
                    }
                    
                    //trafienie

                    foreach (var y in MyCanvas.Children.OfType<Rectangle>())
                    {
                        if(y is Rectangle && (string)y.Tag == "przeciwnik")
                        {
                            Rect Trafienie = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                            if (HitBoxStrzalu.IntersectsWith(Trafienie))
                            {
                                usunObiekt.Add(x);
                                usunObiekt.Add(y);

                                pkty++;
                            }
                        }
                    }
                }
                //Poruszanie wrogów(razem z hitboxem)
                if(x is Rectangle && (string)x.Tag == "przeciwnik")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) + szybkoscWroga);
                    if (Canvas.GetTop(x) > 750)
                    {
                        usunObiekt.Add(x);
                        obr += 10;
                    }

                    Rect HitBoxPrzeciwnika = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (HitBoxGracza.IntersectsWith(HitBoxPrzeciwnika))
                    {
                        usunObiekt.Add(x);
                        obr += 5;
                    }
                }
            }
            //kasowanie przeciwnikow
            foreach (Rectangle i in usunObiekt)
            {
                MyCanvas.Children.Remove(i);
            }

            if(obr > 99)
            {
                licznikGry.Stop();
                obrazenia.Content = "Obrazenia: 100";
                obrazenia.Foreground = Brushes.Red;
                if (MessageBox.Show("Gratulacje " + nazGracza + ", Udało ci się zestrzelić" + pkty + " wrogich statków. Czy chcesz zapisać grę?", "GM", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    wyn.Gracz = nazGracza.Trim();
                    wyn.Wynik = pkty;
                    using (TabelaWynikowEntities2 db = new TabelaWynikowEntities2())
                    {
                        db.Wyniki.Add(wyn);
                        db.SaveChanges();
                    }
                    this.Close();
                }
                else
                {
                    this.Close();
                }   
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Left)
            {
                lewo = true;
            }
            if (e.Key == Key.Right)
            {
                prawo = true;
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                lewo = false;
            }
            if (e.Key == Key.Right)
            {
                prawo = false;
            }

            if(e.Key == Key.Space)
            {
                Rectangle nowyPocisk = new Rectangle
                {
                    Tag = "pocisk",
                    Height = 15,
                    Width = 5,
                    Fill = Brushes.White,
                    Stroke = Brushes.Red
                };
                Canvas.SetLeft(nowyPocisk, Canvas.GetLeft(gracz) + gracz.Width / 2 - 2);
                Canvas.SetTop(nowyPocisk, Canvas.GetTop(gracz) - nowyPocisk.Height);

                MyCanvas.Children.Add(nowyPocisk);
            }
        }

        private void wrogowie()
        {
            ImageBrush ObPrzeciwnika = new ImageBrush();

            Kontra = rand.Next(1, 5);

            switch(Kontra)
            {
                case 1:
                    ObPrzeciwnika.ImageSource = new BitmapImage(new Uri("pack://application:,,,/obiekty/1.png"));
                    break;
                case 2:
                    ObPrzeciwnika.ImageSource = new BitmapImage(new Uri("pack://application:,,,/obiekty/2.png"));
                    break;
                case 3:
                    ObPrzeciwnika.ImageSource = new BitmapImage(new Uri("pack://application:,,,/obiekty/3.png"));
                    break;
                case 4:
                    ObPrzeciwnika.ImageSource = new BitmapImage(new Uri("pack://application:,,,/obiekty/4.png"));
                    break;
                case 5:
                    ObPrzeciwnika.ImageSource = new BitmapImage(new Uri("pack://application:,,,/obiekty/5.png"));
                    break;
            }

            Rectangle nowyPrzeciwnik = new Rectangle
            {
                Tag = "przeciwnik",
                Height = 50,
                Width = 56,
                Fill = ObPrzeciwnika
            };

            Canvas.SetTop(nowyPrzeciwnik, -100);
            Canvas.SetLeft(nowyPrzeciwnik, rand.Next(30, 430));
            MyCanvas.Children.Add(nowyPrzeciwnik);
        }
    }
}
