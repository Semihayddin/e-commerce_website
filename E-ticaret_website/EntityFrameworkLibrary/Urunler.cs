//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Urunler
    {
        public int UrunID { get; set; }
        public Nullable<int> katid { get; set; }
        public string UrunAdi { get; set; }
        public string UrunAciklama { get; set; }
        public string UrunAltAciklama { get; set; }
        public decimal UrunFiyat { get; set; }
        public string UrunResimUrl1 { get; set; }
        public string UrunResimUrl2 { get; set; }
        public string UrunResimUrl3 { get; set; }
        public Nullable<bool> UrunPopuler { get; set; }
        public Nullable<bool> UrunYeni { get; set; }
    }
}
