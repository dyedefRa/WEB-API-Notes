using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;


namespace WebApi____Authorization_ile_Rollere_gore_metodlar.App_Classes
{
    public class APIKeyLoginleme : DelegatingHandler
    {
        //Apikey ile login yapıp yapmama

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var queryString = request.RequestUri.ParseQueryString();
            var apiKey = queryString["apiKey"];
            //var apiKey = request.Headers.GetValues("apiKey").FirstOrDefault();
           
            var list = CTX.kullanici();
            var kullanici = list.FirstOrDefault(x => x.ApiKey == apiKey);
            if (kullanici != null)
            {
                var principal = new ClaimsPrincipal(new GenericIdentity(kullanici.Ad, "APIKey"));
                HttpContext.Current.User = principal;

            }


            return base.SendAsync(request, cancellationToken);

        }
    }
}