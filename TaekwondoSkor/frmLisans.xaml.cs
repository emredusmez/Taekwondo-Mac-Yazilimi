using FoxLearn.License;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for frmLisans.xaml
    /// </summary>
    public partial class frmLisans : Window
    {
        public frmLisans()
        {
            InitializeComponent();
            txtCpuId.Text = ComputerInfo.GetComputerId();
        }
        public partial class hata
        {
            public string aciklama = "";
            public bool sonuc = false;
        }
        public static hata ilk_kurulum()
        {



            hata rdata = new hata();
            string connectionstring = System.Configuration.ConfigurationManager.
       ConnectionStrings["TaekwondoSkor.Properties.Settings.taekwondo_skorConnectionString"].ConnectionString; ; //"Server=localhost\\SQLEXPRESS;Trusted_Connection=True;";
            connectionstring = connectionstring.Replace("Initial Catalog=taekwondo_skor", "Database=master;");
            using (var connection = new SqlConnection(connectionstring))
            {

                string datetime = DateTime.Now.ToString("yyyy-MM-dd");
                try
                {

                    //ALTER DATABASE TO KILL ALL PROCESS ON DB TO DROP DB AND CREATE AGAIN
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "USE master ;" +
                                        " IF EXISTS(select * from sys.databases where name= 'taekwondo_skor') BEGIN " +
                                        "ALTER DATABASE taekwondo_skor SET SINGLE_USER WITH ROLLBACK IMMEDIATE" +
                                        " DROP DATABASE taekwondo_skor; END " +
                                        " CREATE DATABASE taekwondo_skor;";
                    command.ExecuteNonQuery();

                    rdata.aciklama += "SQL tamam\n";

                    rdata.sonuc = true;
                }
                catch (Exception ex)
                {
                    //rdata.aciklama += "SQL bağlanamadı " + connectionstring + "\n " + ex;
                    Console.WriteLine(ex.ToString());
                    rdata.sonuc = false;
                }

                try
                {
                    if (rdata.sonuc == true)
                    {

                        var connection2 = new SqlConnection(connectionstring);
                        connection2.Open();
                        string script = File.ReadAllText(@".\dbo.sql");
                        var scripts = Regex.Split(script, @"^\w+GO$", RegexOptions.Multiline);
                        foreach (var item in scripts)
                        {
                            var command2 = connection2.CreateCommand();
                            command2.CommandText = "use taekwondo_skor; " + item;
                            command2.ExecuteNonQuery();
                        }


                        connection2.Close();


                        //MessageBox.Show(command3.CommandText);

                        // rdata.aciklama += "DB created\n";
                        // MessageBox.Show("procedure oluşturuldu");
                        File.Delete("dbo.sql");

                    }
                    else
                    {

                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());


                    //rdata.aciklama += "SQL Atılamadı \n " + ex;
                    rdata.sonuc = false;
                }

                try
                {
                   

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    //rdata.aciklama += "Lisans Atılamadı \n " + ex;
                    rdata.sonuc = false;
                }
                //MessageBox.Show(rdata.aciklama);
            }

            return rdata;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string LisansText = txtLisansKodu.Text;
                string lsc = Kripto.RsaSifreCoz(LisansText);

                if (lsc != ComputerInfo.GetComputerId())
                {
                    MessageBox.Show("Geçersiz lisans kodu");
                    

                }
                else
                {
                    File.WriteAllText("ls.lc",LisansText);
                    ilk_kurulum();
                    MessageBox.Show("İşlem başarılı. Yazılımı tekrar çalıştırarak kullanmaya başlayabilirsiniz");

                }

            }
            catch (Exception ex )
            {
                MessageBox.Show("Geçersiz lisans kodu" + ex.ToString());



            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
