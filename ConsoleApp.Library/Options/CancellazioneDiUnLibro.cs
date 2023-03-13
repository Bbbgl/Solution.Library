using BusinessLogic.Library;
using BusinessLogic.Library.ViewModels;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Options
{
    public class CancellazioneDiUnLibro : IOptionSelected
    {
        public User User { get; set; }
        public LibraryBusinessLogic LibraryBusinessLogic { get; set; }


        public CancellazioneDiUnLibro(User currentUser, LibraryBusinessLogic lbl)
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

            var bvm = new BookViewModel(title, authorName, authorSurname, publishingHouse);

            //var queryId = book_list.Where(b => b.Title == title).Select(e => e.BookId).ToList();

            //var libro = new Book(queryId[0], title, authorName, authorSurname, casaEditrice, Int16.Parse(quantity));

            //attenzione ai duplicati, metti tutti i campi per cercare il libro
            var bookDeletedCheck = this.LibraryBusinessLogic.DeleteBook(bvm);
            if (bookDeletedCheck == false)
            {
                var book = mapper.MapperBVMtoBOOK(bvm);
                var reservationStatus = new ReservationStatus("attiva");
                var reservationOfThisBook = this.LibraryBusinessLogic.GetReservationHistory(book.BookId, this.User.UserId, reservationStatus);

                foreach (var reservation in reservationOfThisBook)
                {
                    //if (reservation.ReservationFlag == 0)
                    Console.WriteLine("cancellazione non consentita\n");
                    Console.WriteLine($" l'utente {reservation.Username} ha prenotato il libro {reservation.BookTitle} fino al giorno {reservation.EndDate}");// meetti i giorni
                    //else Console.WriteLine($" l'utente {reservation.Username} ha prenotato il libro {reservation.BookTitle} e lo ha restituito il giorno {reservation.EndDate}");


                }

            }
            else Console.WriteLine("cancellazione andata a buon fine");

            

          
            //var book = mapper.MapperBVMtoBOOK(bvm);


        }
    }
}
