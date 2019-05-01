using final_with_test.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;


namespace final_with_test.Controllers
{
    public class CompaniesController : ApiController
    {
        // modify the type of the db field
        private IStoreAppContext db = new StoreAppContext();

        // add these contructors
        public CompaniesController() { }

        public CompaniesController(IStoreAppContext context)
        {
            db = context;
        }

        // GET: api/Product
        public IQueryable<Company> GetProducts()
        {
            return db.Company;
            //db.Users.SqlQuery()
        }

        // GET: api/Product/5
        [ResponseType(typeof(Company))]
        public IHttpActionResult GetProduct(string id)
        {
            Company product = db.Company.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Product/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(string id, Company product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Cemail)
            {
                return BadRequest();
            }

            //db.Entry(product).State = EntityState.Modified;
            db.MarkAsModified(product);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Product
        [ResponseType(typeof(Company))]
        public IHttpActionResult PostProduct(Company product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Company.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.Cemail }, product);
        }

        // DELETE: api/Product/5
        [ResponseType(typeof(Company))]
        public IHttpActionResult DeleteProduct(string id)
        {
            Company product = db.Company.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Company.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(string id)
        {
            return db.Company.Count(e => e.Cemail == id) > 0;
        }

    }
}
