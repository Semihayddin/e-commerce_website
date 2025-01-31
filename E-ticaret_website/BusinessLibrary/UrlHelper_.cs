using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace BusinessLibrary
{
    public static class UrlHelper_
    {
        public static string GetZiyaretciUrl(string type, string url = "", int? refID = 0, int? refID2 = 0)
        {
            string result = "";

            url = url == null ? "none" : (url.Trim() == "" ? "none" : url);
            url = FriendlyURLTitle(url);

            if (type == ZiyaretciUrlType.AltKategori)
            {
                result = "/sayfa/" + url + "-" + refID;
            }
            else if (type == ZiyaretciUrlType.UrunList)
            {
                result = "/UrunList/" + url + "-" + refID + "_" + refID2;
            }
            else if (type == ZiyaretciUrlType.UrunListDetay)
            {
                result = "/UrunListDetay/" + url + "-" + refID;
            }
            else if (type == ZiyaretciUrlType.Anasayfa)
            {
                result = "/home";
            }
            else
                result = url;

            return result;
        }

        public static string FriendlyURLTitle(string incomingText)
        {

            if (incomingText != null)
            {
                incomingText = incomingText.Replace("ş", "s");
                incomingText = incomingText.Replace("Ş", "s");
                incomingText = incomingText.Replace("İ", "i");
                incomingText = incomingText.Replace("I", "i");
                incomingText = incomingText.Replace("ı", "i");
                incomingText = incomingText.Replace("ö", "o");
                incomingText = incomingText.Replace("Ö", "o");
                incomingText = incomingText.Replace("ü", "u");
                incomingText = incomingText.Replace("Ü", "u");
                incomingText = incomingText.Replace("Ç", "c");
                incomingText = incomingText.Replace("ç", "c");
                incomingText = incomingText.Replace("ğ", "g");
                incomingText = incomingText.Replace("Ğ", "g");
                incomingText = incomingText.Replace(" ", "-");
                incomingText = incomingText.Replace("---", "-");
                incomingText = incomingText.Replace("?", "");
                incomingText = incomingText.Replace("/", "");
                incomingText = incomingText.Replace(".", "");
                incomingText = incomingText.Replace("'", "");
                incomingText = incomingText.Replace("#", "");
                incomingText = incomingText.Replace("%", "");
                incomingText = incomingText.Replace("&", "");
                incomingText = incomingText.Replace("*", "");
                incomingText = incomingText.Replace("!", "");
                incomingText = incomingText.Replace("@", "");
                incomingText = incomingText.Replace("+", "");
                incomingText = incomingText.ToLower();
                incomingText = incomingText.Trim();
                // tüm harfleri küçült
                string encodedUrl = (incomingText ?? "").ToLower();
                // & ile " " yer değiştirme
                encodedUrl = Regex.Replace(encodedUrl, @"\&+", "and");
                // " " karakterlerini silme
                encodedUrl = encodedUrl.Replace("'", "");
                // geçersiz karakterleri sil
                encodedUrl = Regex.Replace(encodedUrl, @"[^a-z0-9]", "-");
                // tekrar edenleri sil
                encodedUrl = Regex.Replace(encodedUrl, @"-+", "-");
                // karakterlerin arasına tire koy
                encodedUrl = encodedUrl.Trim('-');
                return encodedUrl;
            }
            else
            {
                return "";
            }
        }
    }

    public static class ZiyaretciUrlType
    {
        public static string AltKategori { get { return "AltKategori"; } set { } }
        public static string UrunList { get { return "UrunList"; } set { } }
        public static string UrunListDetay { get { return "UrunListDetay"; } set { } }
        public static string Anasayfa { get { return "Anasayfa"; } set { } }
        public static string KVKK { get { return "KVKK"; } set { } }
        public static string Diger { get { return "Diger"; } set { } }
    }
}
