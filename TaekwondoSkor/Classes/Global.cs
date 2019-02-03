using HidLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TaekwondoSkor.Classes
{
    public delegate void Degisti(int Skor,int Adet);

    public static class Global
    {
        public static databaseDataContext db = new databaseDataContext();
        public delegate void GamJeom(int GamjeomSayisi);
        public static event GamJeom KirmiziGamJeomEvent;
        public static event GamJeom MaviGamJeomEvent;
       
        public static int MacId { get; set; }
        public static event Degisti KirmiziSkorDegistiEvent;
        public static event Degisti MaviSkorDegistiEvent;
        public static event Degisti RaundDegistiEvent;
        public static string BilgiAlani1 { get; set; }
        public static string BilgiAlani2 { get; set; }
        public static string BilgiAlani3 { get; set; }
        public static string BilgiAlani4 { get; set; }
        public static TimeSpan RaundSuresi { get; set; }
        public static int RaundSayisi { get; set; }
        public static Brush KirmiziRenk { get; set; }
        public static Brush MaviRenk { get; set; }
        private static int _KirmiziSkor;
        private static int _MaviSkor;
        private static int _Raund;
        public static int MaviGamJeom { get; set; }
        public static int  KirmiziGamJeom { get; set; }
        public static Brush SkorRenk { get; set; }
        public static int KirmiziSkor
        {
            get { return _KirmiziSkor; }
            set
            {
                if (MacBitti2)
                {
                    return;
                }
                int SkorPuan = value - _KirmiziSkor;
                if (value != 0)
                {

                    db.Kayitlar.InsertOnSubmit(new Kayitlar
                    {
                        macid = Global.MacId,
                        tarih = DateTime.Now,
                        islem = Global.KayitBaslik + "Kişi 1 |  +" + (value - _KirmiziSkor).ToString() + "P  Skor: " + KirmiziSkor.ToString() + " - " + MaviSkor.ToString()

                    });

                    db.SubmitChanges();
                }

                _KirmiziSkor = value;
                KirmiziSkorDegistiEvent(_KirmiziSkor,SkorPuan);

            }
        }
        public static int MaviSkor
        {
            get { return _MaviSkor; }
            set
            {
                if (MacBitti2)
                {
                    return;
                }
                int SkorPuan = value - _MaviSkor;
                if (value != 0)
                {
                    db.Kayitlar.InsertOnSubmit(new Kayitlar
                    {
                        macid = Global.MacId,
                        tarih = DateTime.Now,
                        islem = Global.KayitBaslik + "Kişi 2 |  +" + (value - _MaviSkor).ToString() + "P Skor: " + KirmiziSkor.ToString() + " - " + MaviSkor.ToString()

                    });

                    db.SubmitChanges();
                }

                _MaviSkor = value;
                MaviSkorDegistiEvent(_MaviSkor,SkorPuan);
            }
        }
        public static int Raund { get { return _Raund; } set { _Raund = value; RaundDegistiEvent(_Raund,0); } }
        public static string ErkekBayan { get; set; }
        public static string Kg { get; set; }
        public static string Yas { get; set; }
        public static string KirmiziUlke { get; set; }
        public static string MaviUlke { get; set; }
        public static string KirmiziUlkeBayrak { get; set; }
        public static string MaviUlkeBayrak { get; set; }
        public static TimeSpan KalanSure { get; set; }
        public static TimeSpan TimeoutKalanSure { get; set; }
        public static TimeSpan AraSuresi { get; set; }
        public static bool SureArtan { get; set; }
        public static int VucutPuani { get; set; }
        public static int KafaPuani { get; set; }
        public static bool MaxPuan { get; set; }
        public static int MaxPuanSayi { get; set; }
        public static bool OnikiFarkPuani { get; set; }
        public static bool TimeOutSureArtan { get; set; }
        public static string KirmiziAd { get; set; }
        public static string MaviAd { get; set; }
        public static string Baslik { get; set; }
        public static bool TestModu { get; set; }
        public static bool TimerIslemYap { get; set; }
        public static DateTime HedefSure { get; set; }
        public static bool  MacBitti { get; set; }
        public static bool MacBitti2 { get; set; }
        public static bool SesEfekti { get; set; }
        public static string KayitBaslik
        {
            get
            {
                string output = string.Format("{0}:{1:00}", (int)Global.KalanSure.TotalMinutes, // <== Note the casting to int.
        Global.KalanSure.Seconds);
                return "Raund: " + Raund.ToString() + " - " + output.ToString() + " ";
            }
        }
        private static HidDevice _device;
        public static HidDevice Cihaz { get { return _device; } set { _device = value; } }
        public static bool CihazBaglandi { get; set; }

        public static void GamJeumKirmizi()
        {
            KirmiziGamJeom++;
            KirmiziGamJeomEvent(KirmiziGamJeom);
            MaviSkor += 1;
            db.Kayitlar.InsertOnSubmit(new Kayitlar
            {
                macid = Global.MacId,
                tarih = DateTime.Now,
                islem = Global.KayitBaslik + "Gam Jeom Kişi 1  Skor: " + KirmiziSkor.ToString() + " - " + MaviSkor.ToString()

            });
            db.SubmitChanges();
            if (KirmiziGamJeom>=10)
            {
                frmMacBitti frm = new frmMacBitti(Global.MaviAd, Global.MaviUlke, Global.MaviUlkeBayrak, Global.MaviRenk.Clone());
                frm.ShowDialog();
            }
        }
        public static void DeukJeumKirmizi()
        {
        
            KirmiziSkor += 1;
            db.Kayitlar.InsertOnSubmit(new Kayitlar
            {
                macid = Global.MacId,
                tarih = DateTime.Now,
                islem = Global.KayitBaslik + "Deuk Jeom Kişi 1  Skor: " + KirmiziSkor.ToString() + " - " + MaviSkor.ToString()

            });
            db.SubmitChanges();
        }
        public static void GamJeumMavi()
        {
            MaviGamJeom++;
           MaviGamJeomEvent(MaviGamJeom);
            KirmiziSkor += 1;
            db.Kayitlar.InsertOnSubmit(new Kayitlar
            {
                macid = Global.MacId,
                tarih = DateTime.Now,
                islem = Global.KayitBaslik + "Gam Jeom Kişi 2  Skor: " + KirmiziSkor.ToString() + " - " + MaviSkor.ToString()

            });
            db.SubmitChanges();
            if (MaviGamJeom>=10)
            {
                frmMacBitti frm = new frmMacBitti(Global.KirmiziAd, Global.KirmiziUlke, Global.KirmiziUlkeBayrak, Global.KirmiziRenk.Clone());
                frm.ShowDialog();
            }
        }
        public static void DeukJeumMavi()
        {
            MaviSkor += 1;
            db.Kayitlar.InsertOnSubmit(new Kayitlar
            {
                macid = Global.MacId,
                tarih = DateTime.Now,
                islem = Global.KayitBaslik + "Deuk Jeom Kişi 2  Skor: " + KirmiziSkor.ToString() + " - " + MaviSkor.ToString()

            });
            db.SubmitChanges();
        }
    }
}
