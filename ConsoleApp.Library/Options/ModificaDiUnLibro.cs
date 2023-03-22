
using Model.Library;
using Proxy.Library;
using Proxy.Library.ServiceViewModels;
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
        public IBookProxy BookProxy { get; set; }


        public ModificaDiUnLibro(User currentUser, IBookProxy bookProxy)
        {
            this.User = currentUser;
            this.BookProxy = bookProxy;

        }
        public void Doing()
        {
            //var lbl = new LibraryBusinessLogic();
         
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
            //Console.WriteLine("inserisci quantità");
            //var quantity = Console.ReadLine();

            var bookToModifyServiceViewModel = new ModifyingBookServiceViewModel(title, authorName, authorSurname, publishingHouse);
            
           
            
            var bookToModify = Mapper.MapperMBSVMtoBOOK(bookToModifyServiceViewModel);

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
            
            var bookWithNewValuesServiceViewModel = new AddingBookServiceViewModel(newTitle,newAuthorName,newAuthorSurname,newPublishingHouse, Int16.Parse(newQuantity));
            var bookWithNewValuesViewModel = Mapper.MapperAddingBSVMtoAddingBVM(bookWithNewValuesServiceViewModel);
            //var libro = new Book(queryId[0], title, authorName, authorSurname, casaEditrice, Int16.Parse(quantity));
            var bookWithNewValues = Mapper.MapperABVMtoBOOK(bookWithNewValuesViewModel);

            this.BookProxy.UpdateBook(bookToModify.BookId, bookWithNewValues);
        }
    }
}
