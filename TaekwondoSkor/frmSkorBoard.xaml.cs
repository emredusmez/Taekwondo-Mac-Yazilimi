using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using TaekwondoSkor.Classes;

namespace TaekwondoSkor
{
    /// <summary>
    /// frmSkorBoard.xaml etkileşim mantığı
    /// </summary>
    public partial class frmSkorBoard : Window
    {
        public frmSkorBoard()
        {
            InitializeComponent();
            lblMaviSkor.Foreground = Global.SkorRenk.Clone();
            lblKirmiziSkor.Foreground = Global.SkorRenk.Clone();
            DispatcherTimer timer = new DispatcherTimer();
            Global.KirmiziGamJeomEvent += Global_KirmiziGamJeomEvent;
            Global.MaviGamJeomEvent += Global_MaviGamJeomEvent;
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
            MainWindow.MolaSureEvent += MainWindow_MolaSureEvent;
            timer.Start();

        }

        private void MainWindow_MolaSureEvent(string MolaSure)
        {
            lblSayac.Dispatcher.Invoke(() =>
            {
                var converter = new System.Windows.Media.BrushConverter();
                var Kirmizi = (Brush)converter.ConvertFromString("#DD00FF9F");
                lblSayac.Foreground = Kirmizi;
            });
            lblSayac.Dispatcher.Invoke(() =>
            {
                string output = string.Format("{0}:{1:00}", (int)Global.TimeoutKalanSure.TotalMinutes, // <== Note the casting to int.
Global.TimeoutKalanSure.Seconds);
                lblSayac.Content = output;

            
            });
        }

        private void Global_MaviGamJeomEvent(int GamjeomSayisi)
        {
            Grid grd = new Grid();
            grd.Width = 50;
            grd.Margin = new Thickness(0, 0, 5, 0);
            grd.Background = Global.MaviRenk.Clone();
            grd.HorizontalAlignment = HorizontalAlignment.Left;
            pnlMaviCeza.Children.Add(grd);
        }

        private void Global_KirmiziGamJeomEvent(int GamjeomSayisi)
        {
            Grid grd = new Grid();
            grd.Width = 50;
            grd.Margin = new Thickness(0, 0, 5, 0);
            grd.Background = Global.KirmiziRenk.Clone();
            grd.HorizontalAlignment = HorizontalAlignment.Left;
            pnlKirmiziCeza.Children.Add(grd);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            VeriGoruntule();
        }

       
        void VeriGoruntule()
        {
          
            lblBaslik.Content = Global.Baslik;
            lblBilgiAlani1.Content = Global.BilgiAlani1;
            lblBilgiAlani2.Content = Global.BilgiAlani2;
            lblBilgiAlani3.Content = Global.BilgiAlani3;
            lblBilgiAlani4.Content = Global.BilgiAlani4;
            lblErkekBayan.Content = Global.ErkekBayan;
            lblKg.Content = Global.Kg;
            lblKirmiziIsim.Content = Global.KirmiziAd;
            lblKirmiziSkor.Content = Global.KirmiziSkor;
            lblKirmiziUlke.Content = Global.KirmiziUlke;
            lblMaviIsim.Content = Global.MaviAd;
            lblMaviSkor.Content = Global.MaviSkor;
            lblMaviUlke.Content = Global.MaviUlke;
            lblMaviSkor.Foreground = Global.SkorRenk.Clone();
            lblKirmiziSkor.Foreground = Global.SkorRenk.Clone();
            lblRaund.Content = Global.Raund;
            if (MainWindow.raundda==true)
            {
                lblSayac.Dispatcher.Invoke(() =>
                {
                    var converter = new System.Windows.Media.BrushConverter();
                    var Kirmizi = (Brush)converter.ConvertFromString("#DDFFC000");
                    lblSayac.Foreground = Kirmizi;
                });
                string output = string.Format("{0}:{1:00}",
       (int)Global.KalanSure.TotalMinutes, // <== Note the casting to int.
       Global.KalanSure.Seconds);
                lblSayac.Content = output;
            }
            
            lblYas.Content = Global.Yas;
            try
            {
                ImageSource imageSource = new BitmapImage(new Uri(Global.KirmiziUlkeBayrak));
                imgBayrakKirmizi.Source = imageSource;
            }
            catch (Exception)
            {

               
            }
            try
            {
                ImageSource imageSource = new BitmapImage(new Uri(Global.MaviUlkeBayrak));
                imgBayrakMavi.Source = imageSource;
            }
            catch (Exception)
            {


            }
        }
    }
}
