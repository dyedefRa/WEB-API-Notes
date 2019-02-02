using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Programming.DAL;

namespace Programming.WebApi.App_Classes
{//Authorize olayini yapıyoruz..
    public class GuvenlikFilter : DelegatingHandler
    {
        //Autohorize ile ısrateledıgımız metodlar buraya dusecek
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //Yukarıdada queryString i yakalıyoruz buradan
            //var queryString = request.RequestUri.ParseQueryString();
            //var apiKey = queryString["apiKey"];

            //headerdan almak için
            var apiKey = request.Headers.GetValues("apiKey").FirstOrDefault();
            apiKeyeUserVer(apiKey);
            return base.SendAsync(request, cancellationToken);
            //Gelen verıyı alttakı metoda atıyorz
        }

        public void apiKeyeUserVer(string apiKey)
        {
            ProgrammingDB ctx = new ProgrammingDB();
          //Uyuyormu dıye baktık eger uyuyorsa
          //Current user a verıyı attık
           var kullanici= ctx.kullanicilar.FirstOrDefault(x => x.ID.ToString() ==apiKey);
            if (kullanici != null)
            {
                var principal = new ClaimsPrincipal(new GenericIdentity(kullanici.kullaniciAdi, "APIKey"));
                HttpContext.Current.User = principal;

            }
           
            //Eger current user doluysa auterize dır dıyıp devam edıyor program
            
        }
    }
}