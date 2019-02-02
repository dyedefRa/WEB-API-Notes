using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi____Authorization_ile_Rollere_gore_metodlar.App_Classes
{
    public class Kullanici
    {
        public int ID { get; set; }
        public string ApiKey { get; set; }
        public string Ad { get; set; }
        public string Rol { get; set; }
    }
}