using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi____Authorization_ile_Rollere_gore_metodlar.App_Classes
{
    public static class CTX
    {
        //DATABASE LE UGRASMAYAK DIYE YALANDAN DB YAPTIK
        public static  List<Kullanici> kullanici()
        {
            var deger = new List<Kullanici>();
            deger.Add(new Kullanici { Ad = "Mahmud", ApiKey = "190", ID = 1, Rol = "U" });
            deger.Add(new Kullanici { Ad = "Ali", ApiKey = "150", ID = 1, Rol = "U,A" });
            deger.Add(new Kullanici { Ad = "Baki", ApiKey = "1", ID = 1, Rol = "A" });
            deger.Add(new Kullanici { Ad = "Serçe", ApiKey = "155", ID = 1, Rol = "U" });
            return deger;
        }
    }
}