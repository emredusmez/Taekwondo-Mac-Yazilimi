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
    /// Interaction logic for frmMacKayitlari.xaml
    /// </summary>
    public partial class frmMacKayitlari : Window
    {
        public frmMacKayitlari()
        {
            InitializeComponent();
            MacKaydiListele();
        }
        void MacKaydiListele()
        {
            var Kayitlar = Global.db.Kayitlar.Where(a => a.macid == Global.MacId).OrderByDescending(a => a.tarih);
            foreach (var item in Kayitlar)
            {
                lsbKayitlar.Items.Add(item.islem);
            }
        }
    }
}
