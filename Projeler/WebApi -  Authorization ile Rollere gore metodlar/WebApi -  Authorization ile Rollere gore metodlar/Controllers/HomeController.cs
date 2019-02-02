using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi____Authorization_ile_Rollere_gore_metodlar.App_Classes;

namespace WebApi____Authorization_ile_Rollere_gore_metodlar.Controllers
{
    public class HomeController : ApiController
    {
       
        [HttpGet]
       [ResponseType(typeof(HttpResponseMessage))]
        [APIAuthorize(Roles ="A")]
        public IHttpActionResult Getir(int id)
        {
            if (id == 3)
            {
                return Ok("Başarılı");
            }
            else
            {
             return   NotFound();
            }
          
        }
    }
}
