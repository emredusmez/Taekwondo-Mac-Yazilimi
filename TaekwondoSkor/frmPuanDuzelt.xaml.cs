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
using TaekwondoSkor.Classes;

namespace TaekwondoSkor
{
    /// <summary>
    /// Interaction logic for frmPuanDuzelt.xaml
    /// </summary>
    public partial class frmPuanDuzelt : Window
    {
        public frmPuanDuzelt()
        {
            InitializeComponent();
        }

        private void btnGamJeomKirmizi_Click(object sender, RoutedEventArgs e)
        {
            Global.GamJeumKirmizi();
        }

        private void btnGamJeomMavi_Click(object sender, RoutedEventArgs e)
        {
            Global.GamJeumMavi();
        }

        private void btnDeukJeomKirmizi_Click(object sender, RoutedEventArgs e)
        {
            Global.DeukJeumKirmizi();
        }

        private void btnDeukJeomMavi_Click(object sender, RoutedEventArgs e)
        {
            Global.DeukJeumMavi();
        }

        private void btnDeukJeomKirmizi_Copy_Click(object sender, RoutedEventArgs e)
        {
            Global.KirmiziSkor += 1;
        }

        private void btnDeukJeomMavi_Copy_Click(object sender, RoutedEventArgs e)
        {
            Global.MaviSkor += 1;
        }

        private void btnDeukJeomKirmizi_Copy1_Click(object sender, RoutedEventArgs e)
        {
            Global.KirmiziSkor -= 1;
        }

        private void btnDeukJeomMavi_Copy1_Click(object sender, RoutedEventArgs e)
        {
            Global.MaviSkor -= 1;
        }
    }
}
