using ElektronikMagazaWebsite.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Script.Serialization;

namespace ElektronikMagazaWebsite
{
    public class Kullanici
    {
        public static kullaniciModel getKullanici
        {
            get
            {
                var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
                IEnumerable<Claim> claims = identity.Claims;
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                kullaniciModel kul = serializer.Deserialize<kullaniciModel>(claims.Where(w => w.Type == ClaimTypes.UserData).FirstOrDefault().Value);
                return kul;
            }
        }
    }
}