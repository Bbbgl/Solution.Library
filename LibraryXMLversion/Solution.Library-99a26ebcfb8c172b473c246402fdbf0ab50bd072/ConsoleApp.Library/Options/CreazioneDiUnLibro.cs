using BusinessLogic.Library;
using ConsoleApp.Library.Options;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library
{
    public class CreazioneDiUnLibro : IOptionSelected
    {
        public User User { get; set; }
        public LibraryBusinessLogic LibraryBusinessLogic { get; set; }


        public CreazioneDiUnLibro(User currentUser, LibraryBusinessLogic lbl)
        {
            this.User = currentUser;
            this.LibraryBusinessLogic = lbl;

        }
        public void Doing()
        {
            //var lbl = new LibraryBusinessLogic();
            var mapper = new MapperBook();

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

            var addingBvm = new AddingBookViewModel(title, authorName, authorSurname, publishingHouse, Int16.Parse(quantity));
            // var queryId = book_list.Where(b => b.Title == title).Select(e => e.BookId).Take(1).ToList();

            var bookToAdd = mapper.MapperAddingBVMtoBOOK(addingBvm);
            //var id_book = book_list.Count();
            //var libro = new Book(id_book++, title, authorName, authorSurname, publishingHouse, Int16.Parse(quantity));
           this.LibraryBusinessLogic.AddBook(bookToAdd);// se il libro è presente deve essere aggiornata la quantità

        }
    }
}
