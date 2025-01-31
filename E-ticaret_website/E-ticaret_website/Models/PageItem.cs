using EntityFrameworkLibrary;
using ElektronikMagazaWebsite.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ElektronikMagazaWebsite.ViewModel.AdminKategoriListe;

namespace ElektronikMagazaWebsite.Models
{
    public class PageItem
    {
        public List<vmAdminKategoriler> AdminDropDownKategoriler = new List<vmAdminKategoriler>();
        


        public List<Kullanicilar> kullanicilar = new List<Kullanicilar>();
        public Kullanicilar kullanici = new Kullanicilar();

        public List<Kategoriler> kategoriler = new List<Kategoriler>();
        public Kategoriler kategori = new Kategoriler();

        public List<Urunler> urunler = new List<Urunler>();
        public Urunler urun = new Urunler();

    
        public SepetModel Sepet { get; set; } = new SepetModel();
        

    }
}