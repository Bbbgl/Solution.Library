using Proxy.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;

namespace Web.Library.Controllers
{
    public class BookController : Controller
    {
        // 
        // GET: /Book/ 

        public ActionResult Index()
        {
            var apiBook = new API_BookProxy();
            var listBooks = apiBook.ReadBooks();
            ViewData["BookList"] = listBooks;
            return View();
           
        }

    
    }
}