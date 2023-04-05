using Model.Library;
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

        //public static API_BookProxy apiBook = new API_BookProxy();
        public static Mapper Mapper = new Mapper();//non posso registrarlo in unity.container perchè non ho l'interfaccia, e questo mapper contiene solo metodi statici
        // 
        // GET: /Book/ 
        readonly IBookProxy apiBook;

        //inject dependency
        public BookController(IBookProxy bookProxy)
        {
            this.apiBook = bookProxy;
        }
        public ActionResult Index()
        {
            //var apiBook = new API_BookProxy();
            var listBooks = apiBook.ReadBooks();
            ViewData["BookList"] = listBooks;
            return View();
           
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            
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
                //var apiBook = new API_BookProxy();
                apiBook.AddBook(book);
            
            //    db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        //// GET: Book/Details
        //public ActionResult Details()
        //{

        //    return View();
        //}

        public ActionResult Details([Bind(Include = "Title,AuthorName,AuthorSurname,PublishingHouse")]BookServiceViewModel bsvm)
        {
            var bookToSearchViewModel = Mapper.MapperBSVMtoBVM(bsvm);
            if (ModelState.IsValid)
            {
                var bookList = apiBook.SearchBookWithAvailabilityInfos(bookToSearchViewModel);
                ViewData["BookList"] = bookList;
                return View();
            }

            return RedirectToAction("Index");


        }

        // GET: Book/Edit
        public ActionResult Edit(int? id)
        {
            var bookToModify = apiBook.ReadBooks().Where(b=>b.BookId==id).ToList();
            ViewData["BookToModify"] = bookToModify[0];
            return View();
        }
        // POST: Book/Edit



        //public ActionResult Edit([Bind(Include = "Title,AuthorName,AuthorSurname,PublishingHouse,Quantity")] ModifyingBookServiceViewModel bookToModify,[Bind(Include = "Title,AuthorName,AuthorSurname,PublishingHouse,Quantity")] AddingBookServiceViewModel bookWithNewValuesSVM)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id,[Bind(Include = "Title,AuthorName,AuthorSurname,PublishingHouse,Quantity")] AddingBookServiceViewModel bookWithNewValuesServiceViewModel)
        {

            var bookToModify = apiBook.ReadBooks().Where(b => b.BookId == id).ToList();
            
            var bookWithNewValuesViewModel = Mapper.MapperAddingBSVMtoAddingBVM(bookWithNewValuesServiceViewModel);
            //var libro = new Book(queryId[0], title, authorName, authorSurname, casaEditrice, Int16.Parse(quantity));
            var bookWithNewValues = Mapper.MapperABVMtoBOOK(bookWithNewValuesViewModel);
            apiBook.UpdateBook(bookToModify[0].BookId, bookWithNewValues);
            return RedirectToAction("Index");
        }

    }
}