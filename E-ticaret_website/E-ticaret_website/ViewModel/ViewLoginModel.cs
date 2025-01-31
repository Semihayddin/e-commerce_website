using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElektronikMagazaWebsite.ViewModel
{
    public class ViewLoginModel
    {
        // GET: ViewLoginModel
        public string KullaniciAdi { get; set; }
        public string Eposta { get; set; }
        public string KullaniciSifre { get; set; }
    }

    public class kullaniciModel
    {
        public int grupId { get; set; }
        public int kulId { get; set; }
        public string kulAdi { get; set; }
       


    }
}