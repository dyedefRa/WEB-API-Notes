using Proj.DAL;
using Proj.WebAppi.Attributes;
using Proj.WebAppi.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Proj.WebAppi.Controllers
{
    [ApiExceptionATT]
    public class ProductController : ApiController
    {
        Repository<Products> urunlerim = new Repository<Products>();

        
        //public HttpResponseMessage Post(Products temp)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var deger = urunlerim.Ekle(temp);
        //        return Request.CreateResponse(HttpStatusCode.Created, deger);
        //    }
        //    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        //}

            //[ResponseType(typeof(Products))]
        public IHttpActionResult Post(Products temp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model validation Hatası");
            }
            var deger = urunlerim.Ekle(temp);
            return CreatedAtRoute("DefaultApi", new { id = deger.ProductId }, deger);
        }

     
        [Authorize]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var deger = urunlerim.GetByID(id);
                if (deger == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");

                }
                return Request.CreateResponse(HttpStatusCode.OK, deger);

            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;

                throw new HttpResponseException(errorResponse);
            }
        }

     
        public HttpResponseMessage Put(Products temp)
        {
            if (ModelState.IsValid)
            {
                var deger = urunlerim.Guncelle(temp);
                return Request.CreateResponse(HttpStatusCode.OK, deger);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }



        //public HttpResponseMessage Get()
        //{
        //    return Request.CreateResponse(HttpStatusCode.OK, urunlerim.Listele());
        //}
        
            [APIAuthorize(Roles ="A,U")]
        public IHttpActionResult Get()
        {
            var deger = urunlerim.Listele();
            return Ok(deger);
        }

        public HttpResponseMessage Delete(int id)
        {
            if (urunlerim.GetByID(id)==null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Sılme işlemi olumsuz. Kayıt bulunamadı");

            }


            return Request.CreateResponse(HttpStatusCode.NoContent);

        }
        public int KAYDET()
        {
            return urunlerim.KAYDET();
        }
    }
}
