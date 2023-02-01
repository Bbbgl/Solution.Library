using BusinessLogic.Library;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Options
{
    public class ModificaDiUnLibro : IOptionSelected
    {
        public User User { get; set; }
        public LibraryBusinessLogic LibraryBusinessLogic { get; set; }


        public ModificaDiUnLibro(User currentUser, LibraryBusinessLogic lbl)
        {
            this.User = currentUser;
            this.LibraryBusinessLogic = lbl;

        }
        public void Doing()
        {
            //var lbl = new LibraryBusinessLogic();
            var mapper = new MapperBook();
            //Console.WriteLine("Id libro da modificare");
            //var id = Console.ReadLine();
            Console.WriteLine("inserire titolo del libro");
            var title = Console.ReadLine();
            Console.WriteLine("inserire nome autore");
            var authorName = Console.ReadLine();
            Console.WriteLine("inserire cognome autore");
            var authorSurname = Console.ReadLine();
            Console.WriteLine("inserire casa editrice");
            var publishingHouse = Console.ReadLine();
            Console.WriteLine("inserisci quantità");
            var quantity = Console.ReadLine();

            var bookToModifyViewModel = new ModifyingBookViewModel(title, authorName, authorSurname, publishingHouse/*,Int32.Parse(quantity)*/);

           var bookToModify = mapper.MapperModifyingBVMtoBOOK(bookToModifyViewModel);// e qui ricavo l'id

            Console.WriteLine("inserire nuovo titolo del libro");
            var newTitle = Console.ReadLine();
            Console.WriteLine("inserire nuovo nome autore");
            var newAuthorName = Console.ReadLine();
            Console.WriteLine("inserire  nuovo cognome autore");
            var newAuthorSurname = Console.ReadLine();
            Console.WriteLine("inserire nuovo casa editrice");
            var newPublishingHouse = Console.ReadLine();
            Console.WriteLine("inserisci nuova quantità");
            var newQuantity = Console.ReadLine();
            //var queryId = book_list.Where(b => b.Title == title).Select(e => e.BookId).Take(1).ToList();
            
            var bookWithNewValuesViewModel = new AddingBookViewModel(newTitle,newAuthorName,newAuthorSurname,newPublishingHouse, Int16.Parse(newQuantity));

            //var libro = new Book(queryId[0], title, authorName, authorSurname, casaEditrice, Int16.Parse(quantity));
            var bookWithNewValues = mapper.MapperAddingBVMtoBOOK(bookWithNewValuesViewModel);

            this.LibraryBusinessLogic.UpdateBook(bookToModify.BookId, bookWithNewValues);
        }
    }
}
