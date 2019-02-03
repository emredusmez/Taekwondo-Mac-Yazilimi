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
    /// Interaction logic for frmAyarlar.xaml
    /// </summary>
    public partial class frmAyarlar : Window
    {
        public frmAyarlar()
        {
            InitializeComponent();
            AyarListele();
        }
        void AyarListele()
        {
            cmbRaundSayisi.Items.Add(new ComboBoxItem { Tag = 2, Content = "2 Raund + Altın Vuruş" });
            cmbRaundSayisi.Items.Add(new ComboBoxItem { Tag = 3, Content = "3 Raund + Altın Vuruş" });
            cmbRaundSayisi.Items.Add(new ComboBoxItem { Tag = 4, Content = "4 Raund + Altın Vuruş" });
            cmbRaundSayisi.Items.Add(new ComboBoxItem { Tag = 0, Content = "Sadece Altın Vuruş" });
            foreach (ComboBoxItem item in cmbRaundSayisi.Items)
            {
                if (item.Tag.ToString()==Global.RaundSayisi.ToString())
                {
                    cmbRaundSayisi.SelectedItem = item;
                }
            }
            for (int i = 1; i < 6; i++)
            {
                cmbKafaPuani.Items.Add(i);
                cmbVucutPuani.Items.Add(i);
             
                
            }
            foreach (int item in cmbKafaPuani.Items)
            {
                if (item==Global.KafaPuani)
                {
                    cmbKafaPuani.SelectedItem = item;
                }
            }
            foreach (int item in cmbVucutPuani.Items)
            {
                if (item==Global.VucutPuani)
                {
                    cmbVucutPuani.SelectedItem = item;
                }
            }
            for (int i = 1; i < 1000; i++)
            {
                cmbMaxPuan.Items.Add(i);
            }
            foreach (int item in cmbMaxPuan.Items)
            {
                if (item==Global.MaxPuanSayi)
                {
                    cmbMaxPuan.SelectedItem = item;
                }
            }
            txtRaundSuresi.Text = Global.RaundSuresi.ToString();
            txtTimeOutSure.Text = Global.AraSuresi.ToString();
            chbMaxPuan.IsChecked = Global.MaxPuan;
            if (Global.TimeOutSureArtan)
            {
                rdbTimeOutArtan.IsChecked = true;
            }
            else
            {
                rdbTimeOutAzalan.IsChecked = true;
            }
            if (Global.SureArtan)
            {
                rdbRaundArtan.IsChecked = true;
            }
            else
            {
                rdbRaundAzalan.IsChecked = true;
            }
            if (Global.OnikiFarkPuani)
            {
                chbOnikiFarkPuani.IsChecked = true;
            }
            Brush newColor = Global.KirmiziRenk.Clone();
            SolidColorBrush newBrush = (SolidColorBrush)newColor;
            clrKirmiziRenk.SelectedColor = newBrush.Color;
            Brush newColor2 = Global.MaviRenk.Clone();
            SolidColorBrush newBrush2= (SolidColorBrush)newColor2;
          clrMaviRenk.SelectedColor = newBrush2.Color;
            Brush newColor3 = Global.SkorRenk.Clone();

            SolidColorBrush newBrush3 = (SolidColorBrush)newColor3;
            clrSkorRenk.SelectedColor = newBrush3.Color;
        }

        private void clrMaviRenk_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            try
            {
                var converter = new System.Windows.Media.BrushConverter();
                var Renk = (Brush)converter.ConvertFromString(clrMaviRenk.SelectedColorText);
                MaviRenk.Background = Renk;
            }
            catch (Exception)
            {

                
            }
           
        }

        private void clrKirmiziRenk_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            try
            {
                var converter = new System.Windows.Media.BrushConverter();
                var Renk = (Brush)converter.ConvertFromString(clrKirmiziRenk.SelectedColorText);
                KirmiziRenk.Background = Renk;
            }
            catch (Exception)
            {

                
            }
          
        }

        void AyarGuncelle()
        {
            var converter = new System.Windows.Media.BrushConverter();
            var KirmiziRenk = (Brush)converter.ConvertFromString(clrKirmiziRenk.SelectedColorText);
            var MaviRenk = (Brush)converter.ConvertFromString(clrMaviRenk.SelectedColorText);
            var SkorRenk = (Brush)converter.ConvertFromString(clrSkorRenk.SelectedColorText);

            Global.MaviRenk = MaviRenk;
            Global.KirmiziRenk = KirmiziRenk;
            Global.AraSuresi = TimeSpan.Parse(txtTimeOutSure.Text);
            Global.KafaPuani = (int)cmbKafaPuani.SelectedItem;
            Global.SkorRenk = SkorRenk;
            Global.MaxPuanSayi = (int)cmbMaxPuan.SelectedItem;
            Global.MaxPuan = chbMaxPuan.IsChecked == true ? true : false;
            Global.OnikiFarkPuani = chbOnikiFarkPuani.IsChecked == true ? true : false;
            Global.RaundSayisi = (int)((ComboBoxItem)cmbRaundSayisi.SelectedItem).Tag;
            Global.RaundSuresi = TimeSpan.Parse(txtRaundSuresi.Text);
            Global.SureArtan = rdbRaundArtan.IsChecked == true ? true : false;
            Global.TimeOutSureArtan = rdbTimeOutArtan.IsChecked == true ? true : false;
            Global.VucutPuani = (int)cmbVucutPuani.SelectedItem;
            Global.SesEfekti = chbSesEfekti.IsChecked == true ? true : false;
            var Ayar = Global.db.Global_Veriler.FirstOrDefault();
            if (Ayar!=null)
            {
                Ayar.arasuresi = Global.AraSuresi;
                Ayar.mavirenk = clrMaviRenk.SelectedColorText;
                Ayar.kirmizirenk = clrKirmiziRenk.SelectedColorText;
                Ayar.kafapuani = Global.KafaPuani;
                Ayar.maxpuansayi = Global.MaxPuanSayi;
                Ayar.maxpuan = Global.MaxPuan;
                Ayar.onikifarkpuani = Global.OnikiFarkPuani;
                Ayar.raundsayisi = Global.RaundSayisi;
                Ayar.sureartan = Global.SureArtan;
                Ayar.timeoutsureartan = Global.TimeOutSureArtan;
                Ayar.vucutpuani = Global.VucutPuani;
                Ayar.raundsuresi = Global.RaundSuresi;
                Ayar.skorrenk = clrSkorRenk.SelectedColorText;
                
            }
            else
            {
                var YeniAyar = new Global_Veriler {
                    arasuresi = Global.AraSuresi,
                    timeoutsureartan = Global.TimeOutSureArtan,
                    vucutpuani = Global.VucutPuani,
                    sureartan = Global.SureArtan,
                    kafapuani = Global.KafaPuani,
                    maxpuan = Global.MaxPuan,
                    onikifarkpuani = Global.OnikiFarkPuani,
                    raundsayisi = Global.RaundSayisi,
                    mavirenk = clrMaviRenk.SelectedColorText,
                    kirmizirenk = clrKirmiziRenk.SelectedColorText,
                    maxpuansayi = Global.MaxPuanSayi,
                    raundsuresi = Global.RaundSuresi,
                    skorrenk=clrSkorRenk.SelectedColorText
                };
                Global.db.Global_Veriler.InsertOnSubmit(YeniAyar);
            }
            Global.db.SubmitChanges();
            

        }
        public bool Kaydet { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Geçerli ayarları kaydetmek istediğinize emin misiniz ?","Ayarları Kaydet",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Kaydet = true;
                AyarGuncelle();
                this.Close();
            }
        }
    }
   
}
