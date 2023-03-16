
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
    public class PrenotazioneDiUnLibro: IOptionSelected
    {
        public User User { get; set; }
        public WCFBookProxy BookProxy { get; set; }


        public PrenotazioneDiUnLibro(User currentUser, WCFBookProxy bookProxy)
        {
            this.User = currentUser;
            this.BookProxy = bookProxy;

        }
        public void Doing()// potrei fare un'altra interfaccia per le opt. riguardandi le reservations...
        {

            //IUserDAO userDAO = new UserDAO();
            //IBookDAO bookDAO = new BookDAO();
            //IReservationDAO reservationDAO = new ReservationDAO();



            //var lbl = new LibraryBusinessLogic(userDAO, bookDAO, reservationDAO);
            //sta cosa sopra non va bene, dovrei istanziare tutto una volta sola

            

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

            var bookToReserveServiceViewModel = new ReservingBookServiceViewModel(title,authorName,authorSurname,publishingHouse);// posso mettere sempre BookViewModel perchè tanto si inseriscono sempre quelle 4 cose
            var bookToReserveViewModel = Mapper.MapperRBSVMtoRBVM(bookToReserveServiceViewModel);
            
            var bookToReserve = Mapper.MapperReservingBVMtoBOOK(bookToReserveViewModel);//lo devo fare dopo

            // lbl.ReserveBook(bookToReserve.BookId, currentUser.UserId );
            var reservationProxy = new WCFReservationProxy();
            var reservation = reservationProxy.ReserveBookPROVA(bookToReserve.BookId, this.User.UserId);

            if (reservation.FlagResult == 0)
            {

                Console.WriteLine("Prenotazione andata a buon fine");
                //QUI SI DECREMENTA LA QUANTITA
                //var bookWithNewQuantity = new Book(bookToReserve.BookId, bookToReserve.Title,
                //    bookToReserve.AuthorName, bookToReserve.AuthorSurname,
                //    bookToReserve.PublishingHouse, --bookToReserve.Quantity);

                //this.LibraryBusinessLogic.UpdateBook(bookToReserve.BookId, bookWithNewQuantity);

            }
            else if (reservation.FlagResult == 1) Console.WriteLine("Prenotazione non consentita, libro non disponibile");
            else if (reservation.FlagResult == 2) Console.WriteLine("Prenotazione non consentita, hai già prenotato questo libro");
            
            

            //var queryId = book_list.Where(b => b.Title == title).Select(e => e.BookId).Take(1).ToList();
            //var queryQuantity = book_list.Where(b => b.Title == bookTitleToSearch).Select(e => e.Quantity).Take(1).ToList();

            // FAI CLASSE RESERVINGBOOKVIEWMODEL
            //var bookToReserve = 

            //var book = new Book(queryId[0], bookTitleToSearch, bookAuthorNameToSearch,
            //    bookAuthorSurnameToSearch
            //    , bookPublishingHouseToSearch, queryQuantity[0]);
            ////var foundAvaiableBooks = libraryBusinessLogic.SearchBookWithAvailabilityInfos(book);
            //libraryBusinessLogic.ReserveBook(book.BookId, currentUser.UserId);
        }

        
    }
}
