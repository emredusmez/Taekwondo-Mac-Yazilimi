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
    /// Interaction logic for frmSporcu.xaml
    /// </summary>
    public partial class frmSporcu : Window
    {
        public frmSporcu()
        {
            InitializeComponent();
            btnSecileniSil.Visibility = Visibility.Hidden;
            Listele();
        }
        Sporcular Secilen;

        private void btnSecileniSil_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (Secilen==null)
            {
                Ekle();
            }
            else
            {
                Duzenle();
            }
        }
        void Listele()
        {
            lsbListe.Items.Clear();
            var Liste = Global.db.Sporcular;
            foreach (var item in Liste)
            {
                lsbListe.Items.Add(new ListBoxItem { Tag=item.id,Content=item.ad});
            }
        }
        void Ekle()
        {
            var Yeni = new Sporcular
            {
                ad=txtAd.Text
            };
            Global.db.Sporcular.InsertOnSubmit(Yeni);
            Global.db.SubmitChanges();
            Listele();
        }
        void Duzenle()
        {
            Secilen.ad = txtAd.Text;
            Global.db.SubmitChanges();
            Listele();
        }
        void Sil()
        {
            Global.db.Sporcular.DeleteOnSubmit(Secilen);
            Global.db.SubmitChanges();
            Listele();
            btnSecileniSil.Visibility = Visibility.Visible;
        }
        private void btnSecileniSil_Click(object sender, RoutedEventArgs e)
        {
            Sil();
        }

        private void lsbListe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (lsbListe.SelectedItem!=null)
            {
                Secilen = Global.db.Sporcular.Where(a => a.id == (int)((ListBoxItem)lsbListe.SelectedItem).Tag).FirstOrDefault();
                if (Secilen != null)
                {
                    btnSecileniSil.Visibility = Visibility.Visible;
                    txtAd.Text = Secilen.ad;
                }
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secilen = null;
            txtAd.Text = "";
        }
    }
}
