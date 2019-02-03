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
    /// Interaction logic for frmGecmisKayitlar.xaml
    /// </summary>
    public partial class frmGecmisKayitlar : Window
    {
        public frmGecmisKayitlar()
        {
            InitializeComponent();
            txtBaslangicTarih.SelectedDate = DateTime.Now;
            txtBitisTarih.SelectedDate = DateTime.Now;
            Listele();
        }
        void Listele()
        {
            var Kayitlar = Global.db.Maclar.Where(a => a.tarih >= txtBaslangicTarih.SelectedDate && a.tarih <= txtBitisTarih.SelectedDate.Value.AddDays(1) && (txtAra.Text=="" || a.kisi1.Contains(txtAra.Text) || a.kisi2.Contains(txtAra.Text) || a.tarih.ToString().Contains(txtAra.Text) || a.Id.ToString()==txtAra.Text));
            lsbMaclar.Items.Clear();
            foreach (var item in Kayitlar)
            {
                lsbMaclar.Items.Add(new ListBoxItem { Tag=item.Id,Content=item.kisi1+" & "+item.kisi2+" | "+item.tarih.ToString()});
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Listele();
        }

        private void lsbMaclar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                lsbKayitlar.Items.Clear();
                var Kayitlar = Global.db.Kayitlar.Where(a => a.macid == (int)((ListBoxItem)lsbMaclar.SelectedItem).Tag);
                foreach (var item in Kayitlar)
                {
                    lsbKayitlar.Items.Add(item.islem);
                }
            }
            catch (Exception)
            {

                
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
