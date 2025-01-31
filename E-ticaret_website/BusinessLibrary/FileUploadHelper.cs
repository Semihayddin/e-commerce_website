using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLibrary
{
    public static class FileUploadHelper
    {
        public static string ToFileUploadKaydet(this object o, string KlasorYol, string DosyaYol)
        {
            string ExistFolder = "";
            for (int i = 1; i < KlasorYol.Split('/').Length - 1; i++)
            {
                ExistFolder += "/" + KlasorYol.Split('/')[i] + "/";
                if (!Directory.Exists(HttpContext.Current.Server.MapPath(ExistFolder)))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(ExistFolder));
                }
            }

            HttpPostedFileBase Fu = (o as HttpPostedFileBase);
            String FileName = Guid.NewGuid().ToString();
            String FileNameExtension = "";
            try
            {
                if (Fu != null)
                {
                    FileNameExtension = System.IO.Path.GetExtension(Fu.FileName);
                    Fu.SaveAs(HttpContext.Current.Server.MapPath(KlasorYol) + FileName + FileNameExtension);
                    return KlasorYol + FileName + FileNameExtension;
                }
                else
                {
                    return DosyaYol;
                }
            }
            catch
            {
                FileName = "";
                FileNameExtension = "";
                return DosyaYol;
            }
        }

        public static string ToFileUploadKaydetV2(this object o, string KlasorYol, string DosyaYol)
        {
            HttpPostedFile Fu = (o as HttpPostedFile);
            String FileName = "";
            String FileNameExtension = "";
            try
            {
                FileName = Guid.NewGuid().ToString().Substring(0, 6) + System.IO.Path.GetFileNameWithoutExtension(Fu.FileName);


                if (Fu != null)
                {
                    FileNameExtension = System.IO.Path.GetExtension(Fu.FileName);
                    Fu.SaveAs(HttpContext.Current.Server.MapPath(KlasorYol) + FileName + FileNameExtension);
                    return KlasorYol + FileName + FileNameExtension;
                }
                else
                {
                    return DosyaYol;
                }
            }
            catch
            {
                FileName = "";
                FileNameExtension = "";
                return DosyaYol;
            }
        }
    }
}
