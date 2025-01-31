using EntityFrameworkLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElektronikMagazaWebsite.ViewModel
{
    public class AdminSiparisler
    {
        public AdminSiparisler() { }    

        public string Aranan { get; set; }
        public int tutar1 { get; set; }
        public int tutar2 { get; set; }
        public DateTime tarih1 { get; set; }
        public DateTime tarih2 { get; set; }
        public List<SiparisKart> Liste { get; set; }= new List<SiparisKart>();
        public List<SiparisHareket> hareketListe { get; set; }= new List<SiparisHareket>();
        public List<Kullanicilar> kullanicilar { get; set; }= new List<Kullanicilar>();

    }
}