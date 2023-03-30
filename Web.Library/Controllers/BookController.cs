using Proxy.Library;
using Proxy.Library.ServiceViewModels;
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

        // GET: Books/Create
        public ActionResult Create()
        {
            //var apiBook = new API_BookProxy();
            //var listBooks = apiBook.AddBook();
            //ViewData["BookList"] = listBooks;
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,AuthorName,AuthorSurname,PublishingHouse,Quantity")] AddingBookServiceViewModel book)
        {
            if (ModelState.IsValid)
            {
                var apiBook = new API_BookProxy();
                apiBook.AddBook(book);
            
            //    db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }


    }
}