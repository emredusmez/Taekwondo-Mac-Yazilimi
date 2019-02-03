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
    /// Interaction logic for frmMacBitir.xaml
    /// </summary>
    public partial class frmMacBitir : Window
    {
        public frmMacBitir()
        {
            InitializeComponent();
            Listele();
        }
        void Listele()
        {
            btnKazananMavi.Background = Global.MaviRenk;
            btnKazananKirmizi.Background = Global.KirmiziRenk;
        }
        public bool Bitti { get; set; }
        public bool Kazanan { get; set; }
        private void btnKazananKirmizi_Click(object sender, RoutedEventArgs e)
        {
            Global.db.Kayitlar.InsertOnSubmit(new Kayitlar
            {
                macid=Global.MacId,
                tarih=DateTime.Now,
                islem=Global.KayitBaslik+" Maç Bitti Kazanan: "+Global.KirmiziAd
            });
            Global.db.SubmitChanges();
            Bitti = true;
            Kazanan = true;
            this.Close();
        }

        private void btnKazananMavi_Click(object sender, RoutedEventArgs e)
        {
            Global.db.Kayitlar.InsertOnSubmit(new Kayitlar
            {
                macid = Global.MacId,
                tarih = DateTime.Now,
                islem = Global.KayitBaslik + " Maç Bitti Kazanan: " + Global.MaviAd
            });
            Global.db.SubmitChanges();
            Bitti = true;
            Kazanan = false;
            this.Close();
        }
    }
}
