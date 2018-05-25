using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebApi.Contexto;
using WebApi.Models;

namespace WebApi.Controllers
{
    [EnableCors(origins:"http://cmsrio.azurewebsites.net/api/Hospital",headers:"*",methods:"*")]
    public class HospitalController : ApiController
    {
        private ContextDB db = new ContextDB();

        // GET: api/Hospital
        public IList<Hospital> GetHospitais()
        {
            return db.Hospitais.ToList();
        }

        // GET: api/Hospital/5
        [ResponseType(typeof(Hospital))]
        public async Task<IHttpActionResult> GetHospital(int id)
        {
            Hospital hospital = await db.Hospitais.FindAsync(id);
            if (hospital == null)
            {
                return NotFound();
            }

            return Ok(hospital);
        }

        // PUT: api/Hospital/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHospital(int id, Hospital hospital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hospital.IDHospital)
            {
                return BadRequest();
            }

            db.Entry(hospital).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalExists(id))
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

        // POST: api/Hospital
        [ResponseType(typeof(Hospital))]
        public async Task<IHttpActionResult> PostHospital(Hospital hospital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hospitais.Add(hospital);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = hospital.IDHospital }, hospital);
        }

        // DELETE: api/Hospital/5
        [ResponseType(typeof(Hospital))]
        public async Task<IHttpActionResult> DeleteHospital(int id)
        {
            Hospital hospital = await db.Hospitais.FindAsync(id);
            if (hospital == null)
            {
                return NotFound();
            }

            db.Hospitais.Remove(hospital);
            await db.SaveChangesAsync();

            return Ok(hospital);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HospitalExists(int id)
        {
            return db.Hospitais.Count(e => e.IDHospital == id) > 0;
        }
    }
}