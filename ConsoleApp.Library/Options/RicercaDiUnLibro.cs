﻿
using Model.Library;
using Proxy.Library;
using Proxy.Library.ServiceViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Options
{
     public class RicercaDiUnLibro : IOptionSelected

     {
        public User User { get; set; }
        public IBookProxy BookProxy { get; set; }


        public RicercaDiUnLibro(User currentUser, IBookProxy bookProxy)
        {
            this.User = currentUser;
            this.BookProxy = bookProxy;

        }
        public void Doing()
         {
             //var lbl = this.OptionSelected.


             Console.WriteLine("Titolo");
             var bookTitleToSearch = Console.ReadLine();
             Console.WriteLine("Nome Autore");
             var bookAuthorNameToSearch = Console.ReadLine();
             Console.WriteLine("Cognome Autore");
             var bookAuthorSurnameToSearch = Console.ReadLine();// se non metto nulla...
             Console.WriteLine("Casa Editrice");
             var bookPublishingHouseToSearch = Console.ReadLine();

             var bookToSearchServiceViewModel = new BookServiceViewModel(bookTitleToSearch, bookAuthorNameToSearch,
                 bookAuthorSurnameToSearch, bookPublishingHouseToSearch);

             // non serve se facessi MapperBook STATIC

            var bookToSearchViewModel = Mapper.MapperBSVMtoBVM(bookToSearchServiceViewModel);
             // posso provare qui a creare la lbl, oppure usarla come parametro

             var bookAvailableList = this.BookProxy.SearchBookWithAvailabilityInfos(bookToSearchViewModel);

             //TODO : se il libro inserito non esiste if (bookAvailableList == null) Console.WriteLine("il libro non esiste");


                 foreach (var books in bookAvailableList)
                 {
                     Console.WriteLine($"Libro : {books.Title} {books.AuthorName} " +
                         $"{books.AuthorSurname} {books.PublishingHouse}");

                     if (books.Avaiability == true) Console.WriteLine("il libro è disponibile");
                     else Console.WriteLine($"libro non disponibile, sarà disponibile in data {books.FirstAvailability} ");
                 }



             //deve essere una lista di tutti i libri con il titolo inserito, ok
             //id e quantity sono sconosciuti all'utente
             //var query = book_list.Where(b => b.Title == bookTitleToSearch || 
             //b.AuthorName == bookAuthorNameToSearch ||
             //b.AuthorSurname==bookAuthorSurnameToSearch ||
             //b.PublishingHouse == bookPublishingHouseToSearch).Select(e => new  { 
             //     e.BookId,
             //    e.Title,
             //    e.AuthorName,
             //    e.AuthorSurname,
             //    e.PublishingHouse,
             //    e.Quantity
             //}).ToList();

             //var listAvaiableBooks = new List<BookViewModel>();
             //for (int i = 0; i < query.Count; i++)
             //{
             //    var book = new Book(query[i].BookId, query[i].Title, query[i].AuthorName,
             //        query[i].AuthorSurname, query[i].PublishingHouse, query[i].Quantity);

             //    listAvaiableBooks.Add(libraryBusinessLogic.SearchBookWithAvailabilityInfos2(book));

             //    //List<BookViewModel> foundAvaiableBooks = libraryBusinessLogic.SearchBookWithAvailabilityInfos(book); 
             //}

             // DA RISOLVERE : se due libri hanno lo stesso titolo, ma le altre
             // credenziali diverse,anche se inserisco tutte le credenziali,
             // cmq si mostrano entrambi i libri, invece che soltanto uno
                 //foreach (var books in listAvaiableBooks)
                 //{
                 //    Console.WriteLine(books.Title + " " +
                 //        books.AuthorName + " " +
                 //        books.AuthorSurname + " " +
                 //        books.PublishingHouse + " " +
                 //        books.Quantity.ToString() + " "

                 //        );
                 //    if (books.Avaiability == true)
                 //    {
                 //        Console.WriteLine("il libro è disponibile");
                 //    }else
                 //{
                 //    Console.WriteLine("il libro non è disponibile");
                 //}
                 //}
             }
         }
}

