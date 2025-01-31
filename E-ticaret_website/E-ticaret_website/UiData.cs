using EntityFrameworkLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElektronikMagazaWebsite
{
    public class UiData
    {
        public static List<Kategoriler> GetKategoriler(int katUstId=0)
        {
            ElektronikMagazaDBEntities db = new ElektronikMagazaDBEntities();
            {
                var item = db.Kategoriler.Where(w => w.KatUstID == katUstId).ToList();

                return item;
            }

        }
        public static List<Urunler> GetUrunler()
        {
            ElektronikMagazaDBEntities db = new ElektronikMagazaDBEntities();
            {
                var item = db.Urunler.ToList();

                return item;
            }

        }
        
    }
}