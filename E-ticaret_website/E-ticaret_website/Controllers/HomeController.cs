using EntityFrameworkLibrary;
using ElektronikMagazaWebsite.Models;
using ElektronikMagazaWebsite.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;

namespace ElektronikMagazaWebsite.Controllers
{
   
    public class HomeController : Controller
    {

        //[Authorize(Roles = "1")]

        public ActionResult Index()
        {


            PageItem item = new PageItem();
            ElektronikMagazaDBEntities db = new ElektronikMagazaDBEntities();
            {
                ViewBag.kategoriler = db.Kategoriler.ToList();
                item.kategoriler = db.Kategoriler.ToList();


            }
            return View(item);
        }
        [Route("iletisim")]
        public ActionResult Iletisim()
        {
            PageItem item = new PageItem();

            return View(item);
        }
        [Route("kategoriler/{KategoriAdi}-{id}")]
        public ActionResult Kategoriler(int id)
        {

            PageItem item = new PageItem();
            ElektronikMagazaDBEntities db = new ElektronikMagazaDBEntities();
            {
                //ViewBag.Kategoriler = db.Kategoriler.ToList();

                if (id > 0)
                    item.kategori = db.Kategoriler.Where(x => x.KategoriID == id).FirstOrDefault();
                else
                    item.kategori.KategoriID = 0;

                item.urunler = db.Urunler.Where(x => x.katid == id).ToList();
            }
            return View(item);
        }
        [Route("urun-detayi/{UrunAdi}-{id}")]
        public ActionResult Urunler(int id)
        {

            PageItem item = new PageItem();
            ElektronikMagazaDBEntities db = new ElektronikMagazaDBEntities();
            {

                if (id > 0)
                {
                    item.urun = db.Urunler.Where(x => x.UrunID == id).FirstOrDefault();
                    item.kategori = db.Kategoriler.Where(x => x.KategoriID == item.urun.katid).FirstOrDefault();
                }
                else
                {
                    return RedirectToAction("Index");
                }



            }
            return View(item);
        }

        #region Sepet İşlemleri

        [Route("sepet")]
        public ActionResult Sepet()
        {
            ElektronikMagazaDBEntities db = new ElektronikMagazaDBEntities();
            {
                PageItem item = new PageItem();



                var spt = SepetLib.getSepet();

                foreach (var st in spt.Satirlar)
                {
                    var urun = db.Urunler.Where(w => w.UrunID == st.UrunId).FirstOrDefault();
                    st.Fiyat = urun.UrunFiyat;

                }



                SepetLib.setSepet(spt);

                item.Sepet = SepetLib.getSepet();

                return View(item);
            }
        }


        [Route("sepeteekle/{id}")]
        public JsonResult SepeteEkle(int id)
        {
            var spt = SepetLib.getSepet();




            var ktrl = spt.Satirlar.Where(x => x.UrunId == id).FirstOrDefault();
            if (ktrl != null)
            {
                ktrl.Miktar++;
            }
            else
            {
                ElektronikMagazaDBEntities db = new ElektronikMagazaDBEntities();

                var dburun = db.Urunler.Where(x => x.UrunID == id).FirstOrDefault();


                if (dburun != null)
                {
                    spt.Satirlar.Add(new ViewModel.SepetSatirModel
                    {
                        UrunId = id,
                        UrunAdi = dburun.UrunAdi,
                        UrunBirim = "",

                        Fiyat = dburun.UrunFiyat,
                        UrunResimUrl1 = dburun.UrunResimUrl1,
                        Miktar = 1
                    });
                }

            }
            SepetLib.setSepet(spt);



            return Json(new { basarili = true, urunmiktar = 1 }, JsonRequestBehavior.AllowGet);
        }

        [Route("sepettencikar/{id}")]
        public JsonResult SepettenCikar(int id)
        {
            var spt = SepetLib.getSepet();

            var ktrl = spt.Satirlar.Where(x => x.UrunId == id).FirstOrDefault();
            if (ktrl != null)
            {
                if (ktrl.Miktar > 1)
                {
                    ktrl.Miktar--;
                }
                else
                {
                    spt.Satirlar.Remove(ktrl);
                }


            }

            else
            {
                ElektronikMagazaDBEntities db = new ElektronikMagazaDBEntities();
                var dburun = db.Urunler.Where(x => x.UrunID == id).FirstOrDefault();
                if (dburun != null)
                {
                    spt.Satirlar.Add(new ViewModel.SepetSatirModel
                    {
                        UrunId = id,
                        UrunAdi = dburun.UrunAdi,
                        UrunBirim = "",
                        Fiyat = dburun.UrunFiyat,
                        UrunResimUrl1 = dburun.UrunResimUrl1,
                        Miktar = 1
                    });
                }

            }
            SepetLib.setSepet(spt);



            return Json(new { basarili = true, urunmiktar = 1 }, JsonRequestBehavior.AllowGet);
        }

        [Route("sepettensil/{id}")]
        public JsonResult SepettenSil(int id)
        {
            var spt = SepetLib.getSepet();

            var ktrl = spt.Satirlar.Where(x => x.UrunId == id).FirstOrDefault();
            if (ktrl != null)
            {
                spt.Satirlar.Remove(ktrl);
            }

            SepetLib.setSepet(spt);



            return Json(new { basarili = true, urunmiktar = 1 }, JsonRequestBehavior.AllowGet);
        }

        [Route("SepetKaydet")]
        public JsonResult SepetKaydet()
        {
            var kul = Kullanici.getKullanici;
            var sepetkart = SepetLib.getSepet();

            if (sepetkart.Satirlar.Count <= 0)
            {
                // kaydetmeyecek
                return Json(new { SipId = 0, basarili = false, mesaj = "Sepet Boş Kayıt Edilemez." });
            }
            else
            {
                try
                {
                    ElektronikMagazaDBEntities db = new ElektronikMagazaDBEntities();
                    var sipKart = db.SiparisKart.Add(new SiparisKart
                    {
                        SiparisKartTutar = sepetkart.OdenecekTutar,
                        kulID = kul.kulId,
                        kulAdi = (kul.kulAdi == null) ? "100" : kul.kulAdi,
                        SiparisKartTarih = DateTime.Now,
                    });
                    db.SaveChanges();

                    foreach (var st in sepetkart.Satirlar)
                    {
                        db.SiparisHareket.Add(new SiparisHareket
                        {
                            siparisKartID = sipKart.SiparisKartID,
                            SipHarTarih = sipKart.SiparisKartTarih,
                            SipHarFiyat = st.Fiyat,
                            SipHarTutar = st.Tutar,
                            SipHarMiktar = st.Miktar,
                            SipHarUrunAdi = st.UrunAdi,
                            SipHarUrunID = st.UrunId,

                        });

                    }
                    db.SaveChanges();

                    SepetLib.SepetiTemizle();

                    return Json(new { SipId = sepetkart.SiparisKartID, basarili = true, mesaj = "Sepet Başarı İle Kaydedildi" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception exp)
                {

                    return Json(new { SipId = 0, basarili = false, mesaj = exp.ToString() });
                }

            }
        }






        #endregion
    }
}