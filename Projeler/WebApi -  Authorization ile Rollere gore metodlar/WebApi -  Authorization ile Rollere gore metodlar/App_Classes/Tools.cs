using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi____Authorization_ile_Rollere_gore_metodlar.App_Classes
{
    public static class Tools
    {

        public static Kullanici GetUserByName(string name)
        {
            if (name != "")
            {

                var liste = CTX.kullanici();
                var user = liste.FirstOrDefault(x => x.Ad == name);
                return user;
            }
            return null;
        }
    }
}