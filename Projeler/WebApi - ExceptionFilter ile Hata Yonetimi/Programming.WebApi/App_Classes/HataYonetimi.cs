using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Programming.WebApi.App_Classes
{
    public class HataYonetimi : ExceptionFilterAttribute
    {
        //@@@@@@@@@@@@@@@@@@@@@@@@@
        //Bu attributeyle hatanın nedenını yollabılıyoruz
        //Herhangi bir hata anında buraya girecek
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpResponseMessage errorResponse = new HttpResponseMessage
(System.Net.HttpStatusCode.NotImplemented);
            errorResponse.ReasonPhrase = actionExecutedContext.Exception.Message;

            actionExecutedContext.Response = errorResponse;
        }
    }
}