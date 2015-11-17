using WebApiSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Diagnostics;

namespace WebApiSample.Controllers
{
    public class WebApiSampleContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }

    public class PersonsController : ApiController
    {
        Person[] persons = new Person[] 
        { 
            new Person { Phone = "4259431698", Name = "Gilberto" },
            new Person { Phone = "4259431697", Name = "Jon" },
            new Person { Phone = "4259431696", Name = "Satya" }
        };

        public IEnumerable<Person> GetAllProducts()
        {
            using (var db = new WebApiSampleContext())
            {
                return db.Persons.ToArray();
            }
        }

        public IHttpActionResult GetProduct(string id)
        {
            using (var db = new WebApiSampleContext())
            {
                var query = from p in db.Persons
                            where p.Phone == id
                            select p;

                if (query.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(query.ToArray());
            }
        }

        // POST api/persons
        public void Post([FromBody]Person value)
        {
            Debug.WriteLine(value);

            using (var db = new WebApiSampleContext())
            {
                db.Persons.Add(value);
                db.SaveChanges();
            }
        }

        // PUT api/persons/5
        public void Put(string id, [FromBody]Person newValue)
        {
            using (var db = new WebApiSampleContext())
            {
                Person value = (from p in db.Persons
                               where p.Phone == id
                               select p).FirstOrDefault();

                if (value == null)
                {
                    // TODO: Resturn an error.
                    return;
                }

                value.Name = newValue.Name;

                db.SaveChanges();
            }
        }

        // DELETE api/persons/5
        public void Delete(string id)
        {
            using (var db = new WebApiSampleContext())
            {
                Person value = (from p in db.Persons
                                where p.Phone == id
                                select p).FirstOrDefault();

                if (value == null)
                {
                    // TODO: Resturn an error.
                    return;
                }

                db.Persons.Remove(value);
                db.SaveChanges();
            }
        }


    }
}
