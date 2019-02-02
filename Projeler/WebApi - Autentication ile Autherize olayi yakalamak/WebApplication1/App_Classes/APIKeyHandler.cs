using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication1.App_Classes
{
    public class APIKeyHandler:DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //Authorize attributeye sahip olan metodlar için eger authorize olayı yoksa buraya dusecek.
            //WebApiConfigte MessageHandler listine bu ApıKeyHangler i eklememiz gerek.

            //URLDEN GIRILEN QUERYSTRINGLERI ALALIM
            //buradaki apiKey i => localhost../api/home?apiKey=135 olarak atıyorz
            //ve asaagıda apikKey =135 oluyor
            var queryString = request.RequestUri.ParseQueryString();
            var apiKey = queryString["apiKey"];

            //Bu APIKey e ait bir user var mi ?
            //--var User= ctx.user.FirstOrDeafult(x => x.userapiID == apiKey);

            //Burada sistemi kullanan User a (CurrentUser'a) yukarıdakı userı atamalıyız.Tabi apikeye ait boyle bır user varsa
            //if (User != null)
            //{


            //var principal = new ClaimsPrincipal(new GenericIdentity(User.Name, "APIKey"));
            //HttpContext.Current.User = principal;

            //}

            return base.SendAsync(request, cancellationToken);
        }
        //Header için (fiddler ile attık)
        //var apiKey=requset.Headers.GetValues("apiKey").FirstOrDefault();

    }
}