using final_with_test.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

using System.Data.SqlClient;
using System.Linq;

namespace final_with_test.Controllers
{
    public class UsersController : ApiController
    {
        // modify the type of the db field
        private IStoreAppContext db = new StoreAppContext();

        // add these contructors
        public UsersController() { }

        public UsersController(IStoreAppContext context)
        {
            db = context;
        }

        //SqlConnection cn = new SqlConnection(@"Server=DESKTOP-C7J5RLQ; DataBase=UserManagement; Integrated Security=true;");
        //SqlCommand cmd;
        //SqlDataReader dr;
        //Users user;
        //public HttpResponseMessage GetProducts()
        //{
        //    try
        //    {
        //        user = new Users();
        //        cmd = new SqlCommand("Select * from Users", cn);
        //        cn.Open();
        //        dr = cmd.ExecuteReader();
        //        if (dr.Read())
        //        {
        //            user.Uemail = dr[0].ToString();
        //        }
        //        dr.Close();
        //        cn.Close();
        //        return Request.CreateResponse(HttpStatusCode.OK, user);
        //    }
        //    catch (Exception e)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e); // send eror response
        //    }

        //}


        // GET: api/Product
        public IQueryable<Users> GetProducts()
        {

            return db.Users;
            //db.Users.SqlQuery()
        }

        // GET: api/Product/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult GetProduct(string id)
        {
            Users product = db.Users.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // PUT: api/Product/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(string id, Users product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Uemail)
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
        [ResponseType(typeof(Users))]
        public IHttpActionResult PostProduct(Users product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.Uemail }, product);
        }

        // DELETE: api/Product/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult DeleteProduct(string id)
        {
            Users product = db.Users.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Users.Remove(product);
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
            return db.Users.Count(e => e.Uemail == id) > 0;
        }

    }
}
