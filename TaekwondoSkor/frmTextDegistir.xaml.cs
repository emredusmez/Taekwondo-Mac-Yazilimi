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
    /// Interaction logic for frmTextDegistir.xaml
    /// </summary>
    public partial class frmTextDegistir : Window
    {
        Label _label;
        public frmTextDegistir(Label Label)
        {
            InitializeComponent();
            _label = Label;
            txtText.Text = _label.Content.ToString();
            try
            {
                txtText.Focus();
                txtText.SelectionStart = txtText.Text.Length;
            }
            catch (Exception)
            {

               
            }
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_label.Name== "lblBilgiAlani1")
            {
                if (txtText.Text=="")
                {
                    _label.Content ="Bilgi Alanı 1";
                    Global.BilgiAlani1 = "Bilgi Alanı 1";
                }
                else
                {
                    _label.Content = txtText.Text;
                    Global.BilgiAlani1 = txtText.Text;
                }
             
            }
          if(_label.Name == "lblBilgiAlani2")
            {
                if (txtText.Text == "")
                {
                    _label.Content = "Bilgi Alanı 2";
                    Global.BilgiAlani2 = "Bilgi Alanı 2";
                }
                else
                {
                    _label.Content = txtText.Text;
                    Global.BilgiAlani2 = txtText.Text;
                }
            }
            if (_label.Name == "lblBilgiAlani3")
            {
                if (txtText.Text == "")
                {
                    _label.Content = "Bilgi Alanı 3";
                    Global.BilgiAlani3 = "Bilgi Alanı 3";
                }
                else
                {
                    _label.Content = txtText.Text;
                    Global.BilgiAlani3 = txtText.Text;
                }
            }
            if (_label.Name == "lblBilgiAlani4")
            {
                if (txtText.Text == "")
                {
                    _label.Content = "Bilgi Alanı 4";
                    Global.BilgiAlani4 = "Bilgi Alanı 4";
                }
                else
                {
                    _label.Content = txtText.Text;
                    Global.BilgiAlani4 = txtText.Text;
                }
            }
            if (_label.Name == "lblBaslik")
            {
                if (txtText.Text == "")
                {
                    _label.Content = "TAEKWONDO MÜSABAKASI";
                    Global.Baslik = "TAEKWONDO MÜSABAKASI";
                }
                else
                {
                    _label.Content = txtText.Text;
                    Global.Baslik = txtText.Text;
                }
            }
            if (_label.Name == "lblErkekBayan")
            {
                if (txtText.Text == "")
                {
                    _label.Content = "ERKEK / BAYAN";
                    Global.ErkekBayan = "ERKEK / BAYAN";
                }
                else
                {
                    _label.Content = txtText.Text;
                    Global.ErkekBayan= txtText.Text;
                }
            }
            if (_label.Name == "lblKg")
            {
                if (txtText.Text == "")
                {
                    _label.Content = "--- KG";
                    Global.Kg = "--- KG";
                }
                else
                {
                    _label.Content = txtText.Text;
                    Global.Kg = txtText.Text;
                }
            }
            if (_label.Name == "lblYas")
            {
                if (txtText.Text == "")
                {
                    _label.Content = "--- YAŞ";
                    Global.Yas = "--- YAŞ";
                }
                else
                {
                    _label.Content = txtText.Text;
                    Global.Yas = txtText.Text;
                }
            }
            if (_label.Name == "lblKirmiziIsim")
            {
                if (txtText.Text == "")
                {
                    _label.Content = "İsim";
                    Global.KirmiziAd = "İsim";
                }
                else
                {
                    _label.Content = txtText.Text;
                    Global.KirmiziAd = txtText.Text;
                }
            }
            if (_label.Name == "lblMaviIsim")
            {
                if (txtText.Text == "")
                {
                    _label.Content = "İsim";
                    Global.MaviAd = "İsim";
                }
                else
                {
                    _label.Content = txtText.Text;
                    Global.MaviAd = txtText.Text;
                }
            }
            if (_label.Name == "lblKirmiziUlke")
            {
                if (txtText.Text == "")
                {
                    _label.Content = "TR";
                    Global.KirmiziUlke = "TR";
                }
                else
                {
                    _label.Content = txtText.Text;
                    Global.KirmiziUlke = txtText.Text;
                }
            }
            if (_label.Name == "lblMaviUlke")
            {
                if (txtText.Text == "")
                {
                    _label.Content = "TR";
                    Global.KirmiziUlke = "TR";
                }
                else
                {
                    _label.Content = txtText.Text;
                    Global.MaviUlke = txtText.Text;
                }
            }
            this.Close();
        }
    }
}
