using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElektronikMagazaWebsite.ViewModel
{
    public class ChartModel
    {
        public int KategoriID { get; set; }    
        public string KategoriAdi { get; set; }    
        public decimal TopTutar { get; set; }    
    }
    public class ChartSatisModel
    {
        public int kulID { get; set; }
        public string kulAdi { get; set; }
        public decimal TopTutar { get; set; }
    }
}