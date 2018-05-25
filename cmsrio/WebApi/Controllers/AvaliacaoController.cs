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
using System.Web.Http.Description;
using WebApi.Contexto;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class AvaliacaoController : ApiController
    {
        private ContextDB db = new ContextDB();

        // GET: api/Avaliacao
        public IList<Avaliacao> GetAvaliacoes()
        {
            return db.Avaliacoes.ToList();
        }

        // GET: api/Avaliacao/5
        [ResponseType(typeof(Avaliacao))]
        public async Task<IHttpActionResult> GetAvaliacao(int id)
        {
            Avaliacao avaliacao = await db.Avaliacoes.FindAsync(id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            return Ok(avaliacao);
        }

        // PUT: api/Avaliacao/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAvaliacao(int id, Avaliacao avaliacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != avaliacao.IDAvaliacao)
            {
                return BadRequest();
            }

            db.Entry(avaliacao).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvaliacaoExists(id))
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

        // POST: api/Avaliacao
        [ResponseType(typeof(Avaliacao))]
        public async Task<IHttpActionResult> PostAvaliacao(Avaliacao avaliacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Avaliacoes.Add(avaliacao);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = avaliacao.IDAvaliacao }, avaliacao);
        }

        // DELETE: api/Avaliacao/5
        [ResponseType(typeof(Avaliacao))]
        public async Task<IHttpActionResult> DeleteAvaliacao(int id)
        {
            Avaliacao avaliacao = await db.Avaliacoes.FindAsync(id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            db.Avaliacoes.Remove(avaliacao);
            await db.SaveChangesAsync();

            return Ok(avaliacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AvaliacaoExists(int id)
        {
            return db.Avaliacoes.Count(e => e.IDAvaliacao == id) > 0;
        }
    }
}