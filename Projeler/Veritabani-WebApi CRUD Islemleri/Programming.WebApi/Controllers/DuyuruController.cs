using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Repository;
using Programming.DAL;
using System.Web.Http.Description;

namespace Programming.WebApi.Controllers
{
    
    public class DuyuruController : ApiController
    {
        //HttpResponseMessage donen metodlar => Reques.CreateResponse(HttpStatsucCode.OK ) döner

        //IHttpActionResult ile NotFound() dersin OK() Dersin

            //IKISIDE AYNI ISLEVDE
        private readonly Repository<duyurular> repoDuyurular = new Repository<duyurular>();
        private readonly Repository<kullanicilar> repoKullanicilar = new Repository<kullanicilar>();

        //BU METODLARDA NE DONDUGUNU BILMIYORUZ O YUZDEN
        [ResponseType(typeof(IEnumerable<duyurular>))]

        public IHttpActionResult Get()
        {
            return Ok(repoDuyurular.GETALL());
        }

        [ResponseType(typeof(duyurular))]
        public IHttpActionResult GetByID(int id)
        {
            var deger = repoDuyurular.GET(id);
            if (deger == null)
            {
                return NotFound();
            }
            return Ok(deger);
        }
        //BAD REQUEST Validation hatası
        [ResponseType(typeof(duyurular))]
        public IHttpActionResult Post(duyurular temp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Validation hatasi");
            }
            var deger = repoDuyurular.INSERT(temp);
            return Ok(deger);
        }
        public IHttpActionResult Put(duyurular temp)
        {
            var deger = repoDuyurular.GET(temp.ID);
            if (deger == null)
            {
                return NotFound();
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest("Validate hatasi");
            }
            repoDuyurular.UPDATE(temp);
            var created = repoDuyurular.GetONE(x => x.Tarih == temp.Tarih);

            return CreatedAtRoute("DefaultApi", new { id = created.ID }, created);
        }
        public HttpResponseMessage Delete(int id)
        {
            var deger = repoDuyurular.GET(id);
            if (deger == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Böyle bir kayıt bulunamadı");

            }
            repoDuyurular.DELETE(deger.ID);
            return Request.CreateResponse(HttpStatusCode.OK, "Kayıt başarıyla silindi");
        }
    }
}
