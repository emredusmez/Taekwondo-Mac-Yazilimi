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

namespace TaekwondoSkor
{
    /// <summary>
    /// FrmCihazTest.xaml etkileşim mantığı
    /// </summary>
    public partial class FrmCihazTest : Window
    {
        BrushConverter converter = new System.Windows.Media.BrushConverter();
        Brush Kirmizi;
        Brush Mavi;
        public FrmCihazTest()
        {
            InitializeComponent();
            Kirmizi = (Brush)converter.ConvertFromString("#FFB70A0A");
            Mavi = (Brush)converter.ConvertFromString("#FF0B189C");
        }
        public void Mavi1()
        {
           btnMavi1.Dispatcher.Invoke(() =>
            {
                btnMavi1.Background = Brushes.Green;
              
            });
            Thread.Sleep(500);
            btnMavi1.Dispatcher.Invoke(() =>
            {
               
                btnMavi1.Background = Mavi.Clone();
            });
        }
        public void Mavi2()
        {
            btnMavi2.Dispatcher.Invoke(() =>
            {
                btnMavi2.Background = Brushes.Green;
                
            }); Thread.Sleep(500);
            btnMavi2.Dispatcher.Invoke(() =>
            {
              
                btnMavi2.Background = Mavi.Clone();
            });
        }
        public void Mavi3()
        {
            btnMavi3.Dispatcher.Invoke(() =>
            {
                btnMavi3.Background = Brushes.Green;
               
            }); Thread.Sleep(500);
            btnMavi3.Dispatcher.Invoke(() =>
            {
                
                btnMavi3.Background = Mavi.Clone();
            });
        }

        public void Kirmizi1()
        {
            btnKirmizi1.Dispatcher.Invoke(() =>
            {
                btnKirmizi1.Background = Brushes.Green;
               
            });
            Thread.Sleep(500);
            btnKirmizi1.Dispatcher.Invoke(() =>
            {
               
               
                btnKirmizi1.Background = Kirmizi.Clone();
            });
        }
        public void Kirmizi2()
        {
            btnKirmizi2.Dispatcher.Invoke(() =>
            {
                btnKirmizi2.Background = Brushes.Green;
            
            });
            Thread.Sleep(500);
            btnKirmizi2.Dispatcher.Invoke(() =>
            {
              
                btnKirmizi2.Background = Kirmizi.Clone();
            });
        }
        public void Kirmizi3()
        {
            btnKirmizi3.Dispatcher.Invoke(() =>
            {
                btnKirmizi3.Background = Brushes.Green;
               
            }); Thread.Sleep(500);
            btnKirmizi3.Dispatcher.Invoke(() =>
            {
            
                
                btnKirmizi3.Background = Kirmizi.Clone();
            });
        }
        private void btnMavi1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
