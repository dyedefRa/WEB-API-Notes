using Proj.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Proj.WebAppi.Security
{
    public class APIKeyHandler:DelegatingHandler
    {
        Repository<Products> pro = new Repository<Products>();


        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
           
            var queryString = request.RequestUri.ParseQueryString();
            var apiKey = queryString["apiKey"];
            var merhaba = queryString["merhabas"];
            var product = pro.GetByID(Convert.ToInt32(apiKey));
            if (product!=null)
            {
                var principal = new ClaimsPrincipal(new GenericIdentity(product.ProductName, "APIKey"));
            }
           
            return base.SendAsync(request, cancellationToken);
        }
    }
}