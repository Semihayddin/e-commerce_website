using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElektronikMagazaWebsite.ViewModel
{
    public class SepetModel
    {
        public SepetModel() { }

        public int SiparisKartID { get; set; }
        public int MusteriId { get; set; }
        public string MusteriAdi { get; set; }
        public DateTime SiparisKartTarih { get; set; }
        public List<SepetSatirModel> Satirlar { get; set; } = new List<SepetSatirModel>();

        public decimal OdenecekTutar => Satirlar.Sum(s => s.Tutar);
        public decimal toplamsepetMiktar => Satirlar.Sum(s => s.Miktar);
    }

    public class SepetSatirModel
    {

        public SepetSatirModel() { }
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public string UrunBirim { get; set; }
        public int Miktar { get; set; }
        public decimal Fiyat { get; set; }
        public string UrunResimUrl1 { get; set; }

        public decimal Tutar => (Miktar * Fiyat);

    }
}