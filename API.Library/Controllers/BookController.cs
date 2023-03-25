using BusinessLogic.Library;
using BusinessLogic.Library.ViewModels;
using Model.Library;
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
        public Book Get(int id)
        {
           Book book = lbl.SearchBooks().Where(b => b.BookId == id).Select(e => e).First();

            return book;
        }
        [HttpGet]
        [Route("api/Book/SearchBooks")]
        public List<Book> SearchBooks()
        {
           return lbl.SearchBooks();
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

        [HttpPost]
        [Route("api/Book/SearchBook")]

        public List<SearchingBookViewModel> SearchBookWithAvailabilityInfos([FromBody] BookViewModelDTO bvmDTO)
        {
            var bvm = new BookViewModel(bvmDTO.Title, bvmDTO.AuthorName, bvmDTO.AuthorSurname, bvmDTO.PublishingHouse);
            return lbl.SearchBookWithAvailabilityInfos(bvm);

        }

        [HttpPost]
        [Route("api/Book/DeleteBook")]
        public bool DeleteBook([FromBody] BookViewModelDTO bvmDTO)
        {
            var bvm = new BookViewModel(bvmDTO.Title, bvmDTO.AuthorName, bvmDTO.AuthorSurname, bvmDTO.PublishingHouse);
            return lbl.DeleteBook(bvm);
        }

        [HttpPost]
        [Route("api/Book/UpdateBook")]
        public void UpdateBook(UpdateBookDTO bookDTO)
        {
            lbl.UpdateBook(bookDTO.Id, bookDTO.Book);
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
