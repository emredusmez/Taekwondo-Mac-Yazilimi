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

namespace TaekwondoSkor
{
    /// <summary>
    /// Interaction logic for frmMacBitti.xaml
    /// </summary>
    public partial class frmMacBitti : Window
    {
        Brush _KazananRenk;
        public frmMacBitti(string Kazanan,string KazananUlke,string KazananBayrak,Brush KazananRenk)
        {
            InitializeComponent();
            _KazananRenk = KazananRenk;
            Bitir(Kazanan,KazananUlke,KazananBayrak,KazananRenk);
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0,0,500);
            dispatcherTimer.Start();
        }
        bool normal;
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (normal)
            {
                normal = false;
              
                lblWinner.Background = _KazananRenk.Clone();
            }
            else
            {
                normal = true;
                var converter = new System.Windows.Media.BrushConverter();
                var Renk = (Brush)converter.ConvertFromString("#FFCED443");
                lblWinner.Background = Renk;
            }
        }

        void Bitir(string Kazanan, string KazananUlke, string KazananBayrak,Brush KazananRenk)
        {
            lblKazananAd.Content = Kazanan;
            lblUlke.Content = KazananUlke;
            lblUlke.Visibility = Visibility.Hidden;
            try
            {
                ImageSource imageSource = new BitmapImage(new Uri(KazananBayrak));
                imgBayrak.Source = imageSource;
            }
            catch (Exception)
            {

             
            }
          
            lblKazananAd.Background = KazananRenk;

        }
    }
}
