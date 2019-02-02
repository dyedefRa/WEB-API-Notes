using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Programming.DAL;

namespace Programming.WebApi.Controllers
{
    public class UserController : ApiController
    {
        //SCAFFOLDIN KULLANDIM 2.WEB API CONTROLLERI BUNU YAPAN

        private ProgrammingDB db = new ProgrammingDB();

        // GET: api/User
        public IQueryable<kullanicilar> Getkullanicilar()
        {
            return db.kullanicilar;
        }

        // GET: api/User/5
        [ResponseType(typeof(kullanicilar))]
        public IHttpActionResult Getkullanicilar(int id)
        {
            kullanicilar kullanicilar = db.kullanicilar.Find(id);
            if (kullanicilar == null)
            {
                return NotFound();
            }

            return Ok(kullanicilar);
        }

        // PUT: api/User/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putkullanicilar(int id, kullanicilar kullanicilar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kullanicilar.ID)
            {
                return BadRequest();
            }

            db.Entry(kullanicilar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!kullanicilarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/User
        [ResponseType(typeof(kullanicilar))]
        public IHttpActionResult Postkullanicilar(kullanicilar kullanicilar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.kullanicilar.Add(kullanicilar);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kullanicilar.ID }, kullanicilar);
        }

        // DELETE: api/User/5
        [ResponseType(typeof(kullanicilar))]
        public IHttpActionResult Deletekullanicilar(int id)
        {
            kullanicilar kullanicilar = db.kullanicilar.Find(id);
            if (kullanicilar == null)
            {
                return NotFound();
            }

            db.kullanicilar.Remove(kullanicilar);
            db.SaveChanges();

            return Ok(kullanicilar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool kullanicilarExists(int id)
        {
            return db.kullanicilar.Count(e => e.ID == id) > 0;
        }
    }
}