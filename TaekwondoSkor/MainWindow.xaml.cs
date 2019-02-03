using HidLibrary;
using Microsoft.Win32;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TaekwondoSkor.Classes;
using FoxLearn.License;

namespace TaekwondoSkor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        static FrmCihazTest testfrm = new FrmCihazTest();
        static string SoundLocation1 = "media\\mc1.mp3";
        static string SoundLocation2 = "media\\mc2.mp3";
        static string SoundLocation3 = "media\\mc3.mp3";
        static string GeriSayim = "media\\cd.mp3";
        static SoundPlayer Player;
        MemoryStream ms = new MemoryStream();
        private IWavePlayer Player1;
        private WaveStream fileStream1;
        private IWavePlayer Player2;
        private WaveStream fileStream2;
        private IWavePlayer Player3;
        private WaveStream fileStream3;
        private IWavePlayer Playergs;
        private WaveStream fileStreamgs;
        public delegate void MolaSureArtis(string MolaSure);
        public static event MolaSureArtis MolaSureEvent;
        public static event MolaSureArtis MolaBittiEvent;
        //  MediaPlayer Player = new MediaPlayer();
        public MainWindow()
        {
            InitializeComponent();
            
            Global.KirmiziGamJeomEvent += Global_KirmiziGamJeomEvent;
            Global.MaviGamJeomEvent += Global_MaviGamJeomEvent;
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            MolaSureEvent += MainWindow_MolaSureEvent;

            ////------------Player
            var inputStream = new AudioFileReader(SoundLocation1);
            fileStream1 = inputStream;
            var aggregator = new SampleAggregator(inputStream);
            aggregator.NotificationCount = inputStream.WaveFormat.SampleRate / 100;
            aggregator.PerformFFT = true;
            Player1 = new WaveOut { DesiredLatency = 500 };
            Player1.Init(aggregator);
            ////------------------Player
            ////------------Player
            var inputStream2 = new AudioFileReader(SoundLocation2);
            fileStream2 = inputStream2;
            var aggregator2 = new SampleAggregator(inputStream2);
            aggregator2.NotificationCount = inputStream2.WaveFormat.SampleRate / 100;
            aggregator2.PerformFFT = true;
            Player2 = new WaveOut { DesiredLatency = 500 };
            Player2.Init(aggregator2);
            ////------------------Player
            ////------------Player
            var inputStream3 = new AudioFileReader(SoundLocation3);
            fileStream3 = inputStream3;
            var aggregator3 = new SampleAggregator(inputStream3);
            aggregator3.NotificationCount = inputStream3.WaveFormat.SampleRate / 100;
            aggregator3.PerformFFT = true;
            Player3 = new WaveOut { DesiredLatency = 500 };
            Player3.Init(aggregator3);
            ////------------------Player

            ////------------Player
            var inputStreamgs = new AudioFileReader(GeriSayim);
            fileStreamgs = inputStreamgs;
            var aggregatorgs = new SampleAggregator(inputStreamgs);
            aggregatorgs.NotificationCount = inputStreamgs.WaveFormat.SampleRate / 100;
            aggregatorgs.PerformFFT = true;
            Playergs = new WaveOut { DesiredLatency = 500 };
            Playergs.Init(aggregatorgs);
            ////------------------Player
            //   SoundLocation = dir + "\\" + SoundLocation;
            var Ayar = Global.db.Global_Veriler.FirstOrDefault();

            EventManager.RegisterClassHandler(typeof(Window),
     Keyboard.KeyUpEvent, new KeyEventHandler(keyUp), true);
            AyarDegistir();

            Global.KirmiziSkorDegistiEvent += Global_KirmiziSkorDegistiEvent;
            Global.MaviSkorDegistiEvent += Global_MaviSkorDegistiEvent;
            Global.RaundDegistiEvent += Global_RaundDegistiEvent;
            var productId = 0x0011;
            Thread Th = new Thread(Timer);
            Th.IsBackground = true;
            Th.Start();
            int VendorId = 0x0079;
            Global.Cihaz = HidDevices.Enumerate(VendorId, productId).FirstOrDefault();
            var _device = Global.Cihaz;
            btnSureyiDurdur.Content = "Süreyi Başlat";
            btnSureyiDurdur.IsEnabled = false;
            btnMaciBitir.IsEnabled = false;
            btnRaundBaslat.IsEnabled = false;
            btnScoreDuzeltme.IsEnabled = false;
            btnSayacArttir.Visibility = Visibility.Hidden;
            btnSayacDusur.Visibility = Visibility.Hidden;
            var vr = Global.db.Maclar;
            if (Ayar != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var KirmiziRenk = (Brush)converter.ConvertFromString(Ayar.kirmizirenk);
                var MaviRenk = (Brush)converter.ConvertFromString(Ayar.mavirenk);
                var SkorRenk = (Brush)converter.ConvertFromString(Ayar.skorrenk);
                Global.AraSuresi = Ayar.arasuresi;
                Global.MaxPuanSayi = Ayar.maxpuansayi;
                Global.MaxPuan = Ayar.maxpuan;
                Global.RaundSayisi = Ayar.raundsayisi;
                Global.OnikiFarkPuani = Ayar.onikifarkpuani;
                Global.SureArtan = Ayar.sureartan;
                Global.TimeOutSureArtan = Ayar.timeoutsureartan;
                Global.VucutPuani = Ayar.vucutpuani;
                Global.KafaPuani = Ayar.kafapuani;
                Global.RaundSuresi = Ayar.raundsuresi.Value;
                Global.KirmiziRenk = KirmiziRenk;
                Global.MaviRenk = MaviRenk;
                Global.SkorRenk = SkorRenk;
                Global.SesEfekti = true;
                lblMaviSkor.Foreground = SkorRenk;
                lblKirmiziSkor.Foreground = SkorRenk;


            }
            Global.KirmiziAd = "Hasan";
            Global.MaviAd = "Ahmet";
            lblMaviIsim.Content = Global.MaviAd;
            lblKirmiziIsim.Content = Global.KirmiziAd;
            if (Global.Cihaz != null)
            {
                Thread.Sleep(300);
                _device.OpenDevice();

                _device.Inserted += DeviceAttachedHandler;
                _device.Removed += DeviceRemovedHandler;

                _device.MonitorDeviceEvents = true;


            }
            pnlCezalar.IsEnabled = false;
        }

        private void MainWindow_MolaSureEvent(string MolaSure)
        {
           
        }

        private void Global_MaviGamJeomEvent(int GamjeomSayisi)
        {
            Grid grd = new Grid();
            grd.Width = 50;
            grd.Margin = new Thickness(0, 0, 5, 0);
            grd.Background = Global.MaviRenk.Clone();
            grd.HorizontalAlignment = HorizontalAlignment.Left;
            pnlMaviCeza.Children.Add(grd);
        }

        private void Global_KirmiziGamJeomEvent(int GamjeomSayisi)
        {
            Grid grd = new Grid();
            grd.Width = 50;
            grd.Margin = new Thickness(0, 0, 5, 0);
            grd.Background = Global.KirmiziRenk.Clone();
            grd.HorizontalAlignment = HorizontalAlignment.Left;
            pnlKirmiziCeza.Children.Add(grd);
        }

        private void keyUp(object sender, KeyEventArgs e)
        {

            switch (e.Key.ToString())
            {
                case "F1":
                    if (btnYeniMac.IsEnabled)
                    {
                        Button_Click_4(new object(), new RoutedEventArgs());
                    }
                    break;
                case "F2":
                    if (btnRaundBaslat.IsEnabled)
                    {
                        Button_Click_5(new object(), new RoutedEventArgs());
                    }
                    break;
                case "F3":
                    if (btnSureyiDurdur.IsEnabled)
                    {
                        Button_Click_6(new object(), new RoutedEventArgs());
                    }
                    break;
                case "F4":
                    if (btnMaciBitir.IsEnabled)
                    {
                        btnMaciBitir_Click(new object(), new RoutedEventArgs());
                    }
                    break;
                case "F7":
                    if (btnGamJeomKirmizi.IsEnabled)
                    {
                        btnGamJeomKirmizi_Click(new object(), new RoutedEventArgs());
                    }
                    break;
                case "F8":
                    if (btnGamJeomMavi.IsEnabled)
                    {
                        btnGamJeomMavi_Click(new object(), new RoutedEventArgs());
                    }
                    break;
                case "F9":
                    if (btnDeukJeomKirmizi.IsEnabled)
                    {
                        btnDeukJeomKirmizi_Click(new object(), new RoutedEventArgs());
                    }
                    break;
                case "F10":
                    if (btnDeukJeomMavi.IsEnabled)
                    {
                        btnDeukJeomMavi_Click(new object(), new RoutedEventArgs());
                    }
                    break;
                default:
                    break;
            }
        }
      public static  bool raundda = true;
        TimeSpan SonTimeoutKalanSUre = new TimeSpan();
        void Timer()
        {
            while (true)
            {
                Thread.Sleep(500);
                if (raundda == false)
                {
                    if (Global.TimerIslemYap)
                    {
                        if (Global.TimeOutSureArtan == false)
                        {
                            if (Global.TimeoutKalanSure > new TimeSpan(0, 0, 0, 0))
                            {

                                Global.TimeoutKalanSure = Global.HedefSure - DateTime.Now;
                                lblSayac.Dispatcher.Invoke(() =>
                                {
                                    string output = string.Format("{0}:{1:00}", (int)Global.TimeoutKalanSure.TotalMinutes, // <== Note the casting to int.
             Global.TimeoutKalanSure.Seconds);
                                    lblSayac.Content = output;
                                   
                                   MolaSureEvent(output);
                                });
                                if (Global.TimeoutKalanSure <= new TimeSpan(0, 0, 5))
                                {
                                    fileStreamgs.Position = 0;
                                    Playergs.Play();

                                }
                            }
                            else
                            {
                                raundda = true;
                                lblSayac.Dispatcher.Invoke(() =>
                                {
                                    var converter = new System.Windows.Media.BrushConverter();
                                    var Kirmizi = (Brush)converter.ConvertFromString("#DDFFC000");
                                    lblSayac.Foreground = Kirmizi;
                                });
                                btnScoreDuzeltme.Dispatcher.Invoke(() =>
                                {
                                    btnScoreDuzeltme.IsEnabled = false;
                                });
                                if (Global.SureArtan == false)
                                {
                                    Global.HedefSure = DateTime.Now.Add(Global.KalanSure);
                                }
                                Global.TimerIslemYap = false;
                                btnScoreDuzeltme.Dispatcher.Invoke(() =>
                                {
                                    btnScoreDuzeltme.IsEnabled = true;

                                });
                                btnSayacArttir.Dispatcher.Invoke(() =>
                                {
                                    btnSayacArttir.Visibility = Visibility.Visible;
                                });
                                btnSayacDusur.Dispatcher.Invoke(() =>
                                {
                                    btnSayacDusur.Visibility = Visibility.Visible;
                                });

                                SureyiBaslat = true;
                                Global.TimerIslemYap = false;
                                pnlCezalar.Dispatcher.Invoke(() =>
                                {
                                    pnlCezalar.IsEnabled = true;
                                });
                                btnSureyiDurdur.Dispatcher.Invoke(()=> {
                                    btnSureyiDurdur.Content = "Süreyi Başlat";
                                });
                         
                            }
                        }
                        else
                        {
                            if (Global.TimeoutKalanSure < Global.AraSuresi)
                            {

                                Global.TimeoutKalanSure = Global.HedefSure.Subtract(DateTime.Now);
                                lblSayac.Dispatcher.Invoke(() =>
                                {
                                    string output = string.Format("{0}:{1:00}", (int)Global.TimeoutKalanSure.TotalMinutes, // <== Note the casting to int.
             Global.TimeoutKalanSure.Seconds);
                                    lblSayac.Content = output;
                                    MolaSureEvent(output);
                                });

                                if (Global.TimeoutKalanSure <= Global.AraSuresi - new TimeSpan(0, 0, 5))
                                {
                                    fileStreamgs.Position = 0;
                                    Playergs.Play();
                                }


                            }
                            else
                            {
                                raundda = true;
                                lblSayac.Dispatcher.Invoke(() =>
                                {
                                    var converter = new System.Windows.Media.BrushConverter();
                                    var Kirmizi = (Brush)converter.ConvertFromString("#DDFFC000");
                                    lblSayac.Foreground = Kirmizi;
                                });
                                btnScoreDuzeltme.Dispatcher.Invoke(() =>
                                {
                                    btnScoreDuzeltme.IsEnabled = false;
                                });
                                if (Global.SureArtan == false)
                                {
                                    Global.HedefSure = DateTime.Now.Add(Global.KalanSure);
                                }
                                Global.TimerIslemYap = false;
                                btnScoreDuzeltme.Dispatcher.Invoke(() =>
                                {
                                    btnScoreDuzeltme.IsEnabled = true;

                                });
                                btnSayacArttir.Dispatcher.Invoke(() =>
                                {
                                    btnSayacArttir.Visibility = Visibility.Visible;
                                });
                                btnSayacDusur.Dispatcher.Invoke(() =>
                                {
                                    btnSayacDusur.Visibility = Visibility.Visible;
                                });

                                SureyiBaslat = true;
                                Global.TimerIslemYap = false;
                                pnlCezalar.Dispatcher.Invoke(() =>
                                {
                                    pnlCezalar.IsEnabled = true;
                                });
                                btnSureyiDurdur.Dispatcher.Invoke(() => {
                                    btnSureyiDurdur.Content = "Süreyi Başlat";
                                });

                            }
                        }
                    }

                }
                else
                {
                    if (Global.TimerIslemYap)
                    {
                        if (Global.SureArtan == false)
                        {
                            if (Global.KalanSure > new TimeSpan(0, 0, 0, 0))
                            {

                                Global.KalanSure = Global.HedefSure - DateTime.Now;
                                lblSayac.Dispatcher.Invoke(() =>
                                {
                                    string output = string.Format("{0}:{1:00}", (int)Global.KalanSure.TotalMinutes, // <== Note the casting to int.
             Global.KalanSure.Seconds);
                                    lblSayac.Content = output;
                                });
                            }
                            else
                            {
                                if (Global.Raund < Global.RaundSayisi)
                                {
                                    Global.Raund += 1;
                                    RaundBitti();
                                    btnRaundBaslat.Dispatcher.Invoke(() =>
                                    {

                                        btnRaundBaslat.IsEnabled = true;
                                    });
                                    btnSureyiDurdur.Dispatcher.Invoke(() =>
                                    {
                                        btnSureyiDurdur.IsEnabled = false;
                                    });

                                    //Global.TimerIslemYap = false;
                                    Global.TimeoutKalanSure = Global.AraSuresi;
                                    if (Global.TimeOutSureArtan == false)
                                    {
                                        Global.HedefSure = DateTime.Now.Add(Global.AraSuresi);
                                    }
                                    raundda = false;
                                    lblSayac.Dispatcher.Invoke(() =>
                                    {
                                        var converter = new System.Windows.Media.BrushConverter();
                                        var Kirmizi = (Brush)converter.ConvertFromString("#DD00FF9F");
                                        lblSayac.Foreground = Kirmizi;
                                    });

                                    btnScoreDuzeltme.Dispatcher.Invoke(() =>
                                    {
                                        btnScoreDuzeltme.IsEnabled = true;
                                    });
                                }
                                else
                                {
                                    Global.TimerIslemYap = false;
                                    MacBitti();
                                }
                            }
                        }
                        else
                        {
                            if (Global.KalanSure < Global.RaundSuresi)
                            {

                                Global.KalanSure = Global.HedefSure.Subtract(DateTime.Now);
                                lblSayac.Dispatcher.Invoke(() =>
                                {
                                    string output = string.Format("{0}:{1:00}", (int)Global.KalanSure.TotalMinutes, // <== Note the casting to int.
             Global.KalanSure.Seconds);
                                    lblSayac.Content = output;
                                });
                            }
                            else
                            {
                                if (Global.Raund < Global.RaundSayisi)
                                {
                                    Global.Raund += 1;
                                    RaundBitti();
                                    btnRaundBaslat.Dispatcher.Invoke(() =>
                                    {

                                        btnRaundBaslat.IsEnabled = true;

                                    });
                                    btnSureyiDurdur.Dispatcher.Invoke(() =>
                                    {
                                        btnSureyiDurdur.IsEnabled = false;
                                    });
                                    raundda = false;
                                    lblSayac.Dispatcher.Invoke(() =>
                                    {
                                        var converter = new System.Windows.Media.BrushConverter();
                                        var Kirmizi = (Brush)converter.ConvertFromString("#DD00FF9F");
                                        lblSayac.Foreground = Kirmizi;
                                    });

                                    btnScoreDuzeltme.Dispatcher.Invoke(() =>
                                    {
                                        btnScoreDuzeltme.IsEnabled = true;
                                    });
                                    Global.TimeoutKalanSure = Global.AraSuresi;
                                    if (Global.TimeOutSureArtan == false)
                                    {
                                        Global.HedefSure = DateTime.Now.Add(Global.AraSuresi);
                                    }
                                    //  Global.TimerIslemYap = false;

                                }
                                else
                                {
                                    Global.TimerIslemYap = false;
                                    MacBitti();
                                }
                            }
                        }
                    }
                }

            }
        }

        private void Global_MolaSureEvent(string MolaSure)
        {
            throw new NotImplementedException();
        }

        private void Global_RaundDegistiEvent(int Raund, int Adet)
        {
            lblRaund.Dispatcher.Invoke(() =>
            {
                lblRaund.Content = Raund;
            });

        }
        void MacBitti()
        {
            Global.MacBitti2 = true;
            Global.MacBitti = true;
            btnRastgeleMac.Dispatcher.Invoke(() =>
            {
                btnRastgeleMac.IsEnabled = true;
            });
            btnSureyiDurdur.Dispatcher.Invoke(() =>
            {
                btnSureyiDurdur.IsEnabled = false;
            });
            btnMaciBitir.Dispatcher.Invoke(() =>
            {
                btnMaciBitir.IsEnabled = false;
            });
            btnRaundBaslat.Dispatcher.Invoke(() =>
            {
                btnRaundBaslat.IsEnabled = false;
            });
            btnScoreDuzeltme.Dispatcher.Invoke(() =>
            {
                btnScoreDuzeltme.IsEnabled = false;
            });
            btnSayacArttir.Dispatcher.Invoke(() =>
            {
                btnSayacArttir.Visibility = Visibility.Hidden;
            });
            btnSayacDusur.Dispatcher.Invoke(() =>
            {
                btnSayacDusur.Visibility = Visibility.Hidden;
            });

            if (Global.MaviSkor > Global.KirmiziSkor)
            {
                Global.MacBitti = true;
                ////frmMacBitti frm = new frmMacBitti(Global.MaviAd, Global.MaviUlke, Global.MaviUlkeBayrak, Global.MaviRenk.Clone());
                ////frm.ShowDialog();
            }
            else if (Global.KirmiziSkor > Global.MaviSkor)
            {
                Global.MacBitti = true;
                //frmMacBitti frm = new frmMacBitti(Global.KirmiziAd, Global.KirmiziUlke, Global.KirmiziUlkeBayrak, Global.KirmiziRenk.Clone());
                //frm.ShowDialog();
            }
        }
        void DegerSifirla()
        {
            Global.MacBitti2 = false;
            Global.MaviGamJeom = 0;
            Global.KirmiziGamJeom = 0;
            Global.KalanSure = Global.RaundSuresi;
            Global.TimeoutKalanSure = Global.AraSuresi;
            Global.KirmiziSkor = 0;
            Global.MaviSkor = 0;
            Global.Raund = 1;
            string output = string.Format("{0}:{1:00}",
        (int)Global.KalanSure.TotalMinutes, // <== Note the casting to int.
        Global.KalanSure.Seconds);
            lblSayac.Dispatcher.Invoke(() =>
            {
                lblSayac.Content = output;
            })
;
        }
        void RaundBitti()
        {

            Global.KalanSure = Global.RaundSuresi;
            // Global.KirmiziSkor = 0;
            // Global.MaviSkor = 0;

            string output = string.Format("{0}:{1:00}",
        (int)Global.KalanSure.TotalMinutes, // <== Note the casting to int.
        Global.KalanSure.Seconds);
            lblSayac.Dispatcher.Invoke(() =>
            {
                lblSayac.Content = output;
            })
;
        }
        private static void DeviceAttachedHandler()
        {
            Global.CihazBaglandi = true;
            Console.WriteLine("Gamepad attached.");
            Global.Cihaz.ReadReport(OnReport);
        }

        private static void DeviceRemovedHandler()
        {
            Global.CihazBaglandi = false;
            Console.WriteLine("Gamepad removed.");
        }
        static DateTime SonOkunmaZamani = new DateTime();

        private static void OnReport(HidReport report)
        {
            try
            {
                if (raundda==false)
                {
                    return;
                }
                if (Global.CihazBaglandi == false)
                {
                    return;
                }



                var Fark = DateTime.Now - SonOkunmaZamani;
                if (Global.TestModu)
                {
                    if (report.Data[5] == 31)
                    {

                        testfrm.Kirmizi1();
                    }
                    else if (report.Data[3] == 0)
                    {

                        testfrm.Kirmizi2();

                    }
                    else if (report.Data[5] == 47)
                    {

                        testfrm.Kirmizi3();
                    }

                    if (report.Data[5] == 79)
                    {
                        testfrm.Mavi1();
                    }
                    else if (report.Data[4] == 255)
                    {
                        testfrm.Mavi2();
                    }
                    else if (report.Data[5] == 143)
                    {
                        testfrm.Mavi3();
                    }


                }
                else
                {
                    if (Fark > new TimeSpan(0, 0, 0, 0, 500))
                    {
                        bool varmi = false;

                        if (report.Data[5] == 31)
                        {

                            if (Global.TimerIslemYap)
                            {
                                Global.KirmiziSkor += 1;
                            }
                            varmi = true;
                        }
                        else if (report.Data[3] == 0)
                        {

                            if (Global.TimerIslemYap)
                            {
                                Global.KirmiziSkor += 2;
                            }
                            varmi = true;

                        }
                        else if (report.Data[5] == 47)
                        {
                            if (Global.TimerIslemYap)
                            {
                                Global.KirmiziSkor += 3;
                            }

                            varmi = true;

                        }

                        if (report.Data[5] == 79)
                        {
                            if (Global.TimerIslemYap)
                            {
                                Global.MaviSkor += 1;
                            }
                            varmi = true;
                        }
                        else if (report.Data[4] == 255)
                        {
                            if (Global.TimerIslemYap)
                            {
                                Global.MaviSkor += 2;
                            }
                         ; varmi = true;
                        }
                        else if (report.Data[5] == 143)
                        {
                            if (Global.TimerIslemYap)
                            {
                                Global.MaviSkor += 3;
                            }
                            varmi = true;
                        }
                        if (varmi)
                        {
                            SonOkunmaZamani = DateTime.Now;

                        }

                    }
                }


            }
            catch (Exception)
            {

                Thread.Sleep(500);
            }


            Global.Cihaz.ReadReport(OnReport);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            if (Global.MacBitti)
            {
                if (Global.MaviSkor > Global.KirmiziSkor)
                {
                    frmMacBitti frm = new frmMacBitti(Global.MaviAd, Global.MaviUlke, Global.MaviUlkeBayrak, Global.MaviRenk.Clone());

                    frm.ShowDialog();
                }
                else if (Global.KirmiziSkor > Global.MaviSkor)
                {
                    frmMacBitti frm = new frmMacBitti(Global.KirmiziAd, Global.KirmiziUlke, Global.KirmiziUlkeBayrak, Global.KirmiziRenk.Clone());

                    frm.ShowDialog();
                }

                Global.MacBitti = false;
            }

        }
        private void Global_MaviSkorDegistiEvent(int Skor, int Adet)
        {

            lblMaviSkor.Dispatcher.Invoke(() =>
            {
                lblMaviSkor.Content = Skor;
            });
            //  playbackDevice.Stop();
            if (Adet == 1)
            {
                fileStream1.Position = 0;
                if (Global.SesEfekti)
                {
                    Player1.Play();
                }

            }
            else if (Adet == 2)
            {
                fileStream2.Position = 0;
                if (Global.SesEfekti)
                {
                    Player2.Play();
                }

            }
            else if (Adet == 3)
            {
                fileStream3.Position = 0;
                if (Global.SesEfekti)
                {
                    Player3.Play();
                }

            }

            if (Skor >= Global.MaxPuanSayi && Global.MaxPuan)
            {

                Global.MacBitti = true;
                MacBitti();

            }
            if (Skor - Global.KirmiziSkor >= 20 && Global.OnikiFarkPuani)
            {
                frmMacBitti frm = new frmMacBitti(Global.MaviAd, Global.MaviUlke, Global.MaviUlkeBayrak, Global.MaviRenk.Clone());
                frm.ShowDialog();
                MacBitti();
            }
            if (Global.RaundSayisi == 0)
            {
                frmMacBitti frm = new frmMacBitti(Global.MaviAd, Global.MaviUlke, Global.MaviUlkeBayrak, Global.MaviRenk.Clone());
                frm.ShowDialog();
                MacBitti();
            }

        }

        private void Global_KirmiziSkorDegistiEvent(int Skor, int Adet)
        {
            lblKirmiziSkor.Dispatcher.Invoke(() =>
            {
                lblKirmiziSkor.Content = Skor;
            });

            if (Adet == 1)
            {
                fileStream1.Position = 0;
                if (Global.SesEfekti)
                {
                    Player1.Play();
                }

            }
            else if (Adet == 2)
            {
                fileStream2.Position = 0;
                if (Global.SesEfekti)
                {
                    Player2.Play();
                }

            }
            else if (Adet == 3)
            {
                fileStream3.Position = 0;
                if (Global.SesEfekti)
                {
                    Player3.Play();

                }

            }
            if (Skor >= Global.MaxPuanSayi && Global.MaxPuan)
            {

                Global.MacBitti = true;
                MacBitti();
            }
            if (Skor - Global.MaviSkor >= 20 && Global.OnikiFarkPuani)
            {
                frmMacBitti frm = new frmMacBitti(Global.KirmiziAd, Global.KirmiziUlke, Global.KirmiziUlkeBayrak, Global.KirmiziRenk.Clone());
                frm.ShowDialog();
                MacBitti();
            }
            if (Global.RaundSayisi==0)
            {
                frmMacBitti frm = new frmMacBitti(Global.KirmiziAd, Global.KirmiziUlke, Global.KirmiziUlkeBayrak, Global.KirmiziRenk.Clone());
                frm.ShowDialog();
                MacBitti();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frmAyarlar frm = new frmAyarlar();
            frm.ShowDialog();
            if (frm.Kaydet)
            {
                AyarListele();
            }

        }
        bool DuzenleModu = true;
        void AyarDegistir()
        {
            Global.AraSuresi = new TimeSpan(0, 0, 30);
            Global.BilgiAlani1 = "Bilgi Alanı 1";
            Global.BilgiAlani2 = "Bilgi Alanı 2";
            Global.BilgiAlani3 = "Bilgi Alanı 3";
            Global.BilgiAlani4 = "Bilgi Alanı 4";
            Global.ErkekBayan = "EKREK/BAYAN";
            Global.MaviAd = "Kişi 2";
            Global.KirmiziAd = "Kişi 1";
            Global.KafaPuani = 3;
            Global.VucutPuani = 1;
            Global.KalanSure = new TimeSpan();
            Global.Kg = "";
            var converter = new System.Windows.Media.BrushConverter();
            var Kirmizi = (Brush)converter.ConvertFromString("#FFB70A0A");
            var Mavi = (Brush)converter.ConvertFromString("#FF0B189C");
            Global.KirmiziRenk = Kirmizi;
            Global.MaviRenk = Mavi;
            Global.MaviUlke = "TR";
            Global.MaviUlkeBayrak = "";
            Global.MaxPuan = false;
            Global.MaxPuanSayi = 12;
            Global.OnikiFarkPuani = false;
            Global.RaundSayisi = 2;
            Global.RaundSuresi = new TimeSpan(0, 1, 30);
            Global.SureArtan = false;
            Global.TimeOutSureArtan = false;
            Global.Yas = "";
        }
        void AyarListele()
        {
            lblBilgiAlani1.Content = Global.BilgiAlani1;
            lblBilgiAlani2.Content = Global.BilgiAlani2;
            lblBilgiAlani3.Content = Global.BilgiAlani3;
            lblBilgiAlani4.Content = Global.BilgiAlani4;
            lblErkekBayan.Content = Global.ErkekBayan;
            lblYas.Content = Global.Yas;
            lblKg.Content = Global.Kg;
            pnlKirmizi.Background = Global.KirmiziRenk;
            pnlMavi.Background = Global.MaviRenk;
            btnDeukJeomKirmizi.Background = Global.KirmiziRenk;
            btnGamJeomMavi.Background = Global.MaviRenk;
            btnGamJeomKirmizi.Background = Global.KirmiziRenk;
            btnDeukJeomMavi.Content = Global.MaviRenk;
            lblMaviIsim.Content = Global.MaviAd;
            lblKirmiziIsim.Content = Global.KirmiziAd;
            lblKirmiziSkor.Foreground = Global.SkorRenk;
            lblMaviSkor.Foreground = Global.SkorRenk;
            try
            {
                ImageSource imageSource = new BitmapImage(new Uri(Global.KirmiziUlkeBayrak));
                imgBayrakKirmizi.Source = imageSource;
            }
            catch (Exception)
            {


            }
            try
            {
                ImageSource imageSource = new BitmapImage(new Uri(Global.MaviUlkeBayrak));
                imgBayrakMavi.Source = imageSource;
            }
            catch (Exception)
            {


            }
        }

        private void imgBayrakKirmizi_MouseEnter(object sender, MouseEventArgs e)
        {


        }

        private void imgBayrakMavi_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void LabelClick(object sender, MouseEventArgs e)
        {

        }

        private void LabelClick(object sender, MouseButtonEventArgs e)
        {
            frmTextDegistir frm = new frmTextDegistir((Label)sender);
            frm.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (DuzenleModu)
            {
                Global.KalanSure += new TimeSpan(0, 0, 1);
                string output = string.Format("{0}:{1:00}",
         (int)Global.KalanSure.TotalMinutes, // <== Note the casting to int.
         Global.KalanSure.Seconds);
                lblSayac.Content = output;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (DuzenleModu)
            {
                Global.KalanSure -= new TimeSpan(0, 0, 1);
                string output = string.Format("{0}:{1:00}",
        (int)Global.KalanSure.TotalMinutes, // <== Note the casting to int.
        Global.KalanSure.Seconds);
                lblSayac.Content = output;
            }
        }

        private void btnGamJeomMavi_Click(object sender, RoutedEventArgs e)
        {
            Global.GamJeumMavi();

        }

        private void btnGamJeomKirmizi_Click(object sender, RoutedEventArgs e)
        {
            Global.GamJeumKirmizi();
        }

        private void btnDeukJeomMavi_Click(object sender, RoutedEventArgs e)
        {
            Global.DeukJeumMavi();
        }

        private void btnDeukJeomKirmizi_Click(object sender, RoutedEventArgs e)
        {
            Global.DeukJeumKirmizi();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            db.Kayitlar.InsertOnSubmit(new Kayitlar
            {
                macid = Global.MacId,
                tarih = DateTime.Now,
                islem = Global.KayitBaslik + "Skor düzeltme ekranı açıldı"

            });
            db.SubmitChanges();
            frmPuanDuzelt frm = new frmPuanDuzelt();
            frm.ShowDialog();
        }

        private void btnCihazTest_Click(object sender, RoutedEventArgs e)
        {

            Global.TestModu = true;
            testfrm = new FrmCihazTest();
            testfrm.ShowDialog();
            Global.TestModu = false;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            DegerSifirla();
            btnSureyiDurdur.IsEnabled = false;
            btnMaciBitir.IsEnabled = true;
            btnRaundBaslat.IsEnabled = true;
            btnScoreDuzeltme.IsEnabled = true;
            btnSayacArttir.Visibility = Visibility.Visible;
            btnSayacDusur.Visibility = Visibility.Visible;

            btnRastgeleMac.IsEnabled = false;
            var Mac = new Maclar
            {
                kisi1 = Global.KirmiziAd,
                kisi2 = Global.MaviAd,
                tarih = DateTime.Now

            };

            Global.db.Maclar.InsertOnSubmit(Mac);
            try
            {
                Global.db.SubmitChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                db.SubmitChanges();
            }

            Global.MacId = Mac.Id;
            db.Kayitlar.InsertOnSubmit(new Kayitlar
            {
                macid = Global.MacId,
                tarih = DateTime.Now,
                islem = Global.KayitBaslik + "Yeni maç oluşturuldu"

            });
            db.SubmitChanges();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            btnSureyiDurdur.IsEnabled = true;
            btnScoreDuzeltme.IsEnabled = false;
            SureyiBaslat = false;
            btnSureyiDurdur.Content = "Süreyi Durdur";
            if (Global.SureArtan == false)
            {
                Global.HedefSure = DateTime.Now.Add(Global.KalanSure);
            }
            Global.TimerIslemYap = true;
            btnRaundBaslat.IsEnabled = false;
            btnSayacArttir.Visibility = Visibility.Hidden;
            btnSayacDusur.Visibility = Visibility.Hidden;
            db.Kayitlar.InsertOnSubmit(new Kayitlar
            {
                macid = Global.MacId,
                tarih = DateTime.Now,
                islem = Global.KayitBaslik + "Raund başlatıldı"

            });
            db.SubmitChanges();
        }
        bool SureyiBaslat = false;
        databaseDataContext db = Global.db;
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (SureyiBaslat)
            {
                Global.TimerIslemYap = true;
                pnlCezalar.IsEnabled = false;
                btnScoreDuzeltme.IsEnabled = false;
                SureyiBaslat = false;
                btnSayacArttir.Visibility = Visibility.Hidden;
                btnSayacDusur.Visibility = Visibility.Hidden;
                btnSureyiDurdur.Content = "Süreyi Durdur";
                if (Global.SureArtan == false)
                {
                    Global.HedefSure = DateTime.Now.Add(Global.KalanSure);
                }
                else
                {

                }
                db.Kayitlar.InsertOnSubmit(new Kayitlar
                {
                    macid = Global.MacId,
                    tarih = DateTime.Now,
                    islem = Global.KayitBaslik + "Süre başlatıldı"

                });
                db.SubmitChanges();

            }
            else
            {
                btnScoreDuzeltme.IsEnabled = true;
                btnSayacArttir.Visibility = Visibility.Visible;
                btnSayacDusur.Visibility = Visibility.Visible;
                SureyiBaslat = true;
                Global.TimerIslemYap = false;
                pnlCezalar.IsEnabled = true;
                btnSureyiDurdur.Content = "Süreyi Başlat";
                db.Kayitlar.InsertOnSubmit(new Kayitlar
                {
                    macid = Global.MacId,
                    tarih = DateTime.Now,
                    islem = Global.KayitBaslik + "Süre durduruldu"

                });
                db.SubmitChanges();
            }

        }

        private void btnMaciBitir_Click(object sender, RoutedEventArgs e)
        {
            frmMacBitir frm = new frmMacBitir();
            frm.ShowDialog();
            db.Kayitlar.InsertOnSubmit(new Kayitlar
            {
                macid = Global.MacId,
                tarih = DateTime.Now,
                islem = Global.KayitBaslik + "Maç bitir ekranı açıldı"

            });
            MacBitti();
            db.SubmitChanges();
            //  DegerSifirla();
            if (frm.Bitti)
            {
                if (frm.Kazanan)
                {
                    frmMacBitti frm2 = new frmMacBitti(Global.KirmiziAd, Global.KirmiziUlke, Global.KirmiziUlkeBayrak, Global.KirmiziRenk.Clone());
                    frm2.ShowDialog();
                }
                else
                {
                    frmMacBitti frm2 = new frmMacBitti(Global.MaviAd, Global.MaviUlke, Global.MaviUlkeBayrak, Global.MaviRenk.Clone());
                    frm2.ShowDialog();
                }
            }


        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            frmSkorBoard frm = new frmSkorBoard();
            frm.Show();
        }

        private void btnMusabakaOzeti_Click(object sender, RoutedEventArgs e)
        {
            frmMacKayitlari frm = new frmMacKayitlari();
            frm.ShowDialog();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            frmGecmisKayitlar frm = new frmGecmisKayitlar();
            frm.ShowDialog();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            frmSporcu frm = new frmSporcu();
            frm.ShowDialog();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            var Kisiler = Global.db.Sporcular;
            if (Kisiler.Count() <= 1)
            {
                MessageBox.Show("Rastgele maç oluşturabilmek için sistemde kayıtlı en az iki kişi olması gerekli ! ");
                return;
            }
            Random Rnd = new Random();
            string Kisi1 = "";
            string Kisi2 = "";
            var Id1 = Rnd.Next(Kisiler.Count());

            Kisi1 = Kisiler.ToList()[Id1].ad;

            while (true)
            {
                var Id2 = Rnd.Next(Kisiler.Count());
                if (Id2 == Id1)
                {
                    continue;
                }
                Kisi2 = Kisiler.ToList()[Id2].ad;
                break;
            }
            Global.KirmiziAd = Kisi1;
            Global.MaviAd = Kisi2;
            lblKirmiziIsim.Content = Global.KirmiziAd;
            lblMaviIsim.Content = Global.MaviAd;
        }

        private void imgBayrakKirmizi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void imgBayrakMavi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void imgBayrakKirmizi_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void imgBayrakMavi_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {

        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Tag = "1. Kişi için bayrak seçimi yapınız";
                op.ShowDialog();
                if (!string.IsNullOrEmpty(op.FileName))
                {

                    ImageSource imageSource = new BitmapImage(new Uri(op.FileName));
                    imgBayrakKirmizi.Source = imageSource;
                    Global.KirmiziUlkeBayrak = op.FileName;
                }
            }
            catch (Exception)
            {


            }
        }

        private void Label_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Tag = "2. Kişi için bayrak seçimi yapınız";
                op.ShowDialog();
                if (!string.IsNullOrEmpty(op.FileName))
                {

                    ImageSource imageSource = new BitmapImage(new Uri(op.FileName));

                    imgBayrakMavi.Source = imageSource;
                    Global.MaviUlkeBayrak = op.FileName;
                }
            }
            catch (Exception)
            {


            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Player1.Dispose();
                Player2.Dispose();
                Player3.Dispose();
                Playergs.Dispose();
                fileStream1.Dispose();
                fileStream2.Dispose();
                fileStream3.Dispose();
                fileStreamgs.Dispose();
            }
            catch (Exception)
            {

               
            }
            Application.Current.Shutdown();
        }
    }
}
