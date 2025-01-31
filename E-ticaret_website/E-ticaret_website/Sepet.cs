using ElektronikMagazaWebsite.ViewModel;
using System.Web;

namespace ElektronikMagazaWebsite
{
    public static class SepetLib
    {

        internal static void setSepet(SepetModel sepet)
        {
            HttpContext.Current.Session.Remove("sepet");
            HttpContext.Current.Session.Add("sepet", sepet);
        }
        internal static void SepetiTemizle()
        {
            HttpContext.Current.Session.Remove("sepet");
        }
        public static SepetModel getSepet()
        {


            if (HttpContext.Current.Session["sepet"] != null)
            {

                return (SepetModel)HttpContext.Current.Session["sepet"];
            }
            else
            {
                return new SepetModel();
            }
        }

    }
}