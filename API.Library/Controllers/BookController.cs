using BusinessLogic.Library;
using BusinessLogic.Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Library.Controllers
{
    public class BookController : ApiController
    {

        public static LibraryBusinessLogic lbl = new LibraryBusinessLogic();
        // GET: api/Book
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Book/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Book
        public void Post([FromBody]string value)
        {
            
        }

        [HttpPost]
        [Route("api/Book/CreateBook")]

       public void AddBook([FromBody] AddingBookViewModel BVM)

        {
            lbl.AddBook(BVM);

        }

        // PUT: api/Book/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Book/5
        public void Delete(int id)
        {
        }
    }
}
