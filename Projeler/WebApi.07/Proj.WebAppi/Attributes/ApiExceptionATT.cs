using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Proj.WebAppi.Attributes
{   //System.Web.Http.Filters kütüphanesini ekledik.
    //ExceptionFilterAttribute clasından miras aldım.
    public class ApiExceptionATT:ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //Burada HttpStatusCode ' lardan bir hata kodu yollamamız gerekiyor. 
            //Aynı zamanda da hatanın nedeni belirtmek gerek.

            HttpResponseMessage gidecekHata = new HttpResponseMessage(System.Net.HttpStatusCode.NotImplemented);
            //gidecekHata adında bir HttpResponseMessage oluşturdum. Ve hata kodumu NotImplemented yaptım. Herhangi bir hata olabilir sonuçta . Belirli bir hata kodu vermemek gerek.


            //Şimdi hatamızın nedenini almakta

            gidecekHata.ReasonPhrase = actionExecutedContext.Exception.Message;
            base.OnException(actionExecutedContext);
        }
    }
}