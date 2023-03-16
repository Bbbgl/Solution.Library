
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
    //•	Restituzione del libro: un utente può formalizzare la restituzione di un libro.
    //Nel caso dovesse dichiarare la restituzione di un libro per il quale non sono memorizzate
    //sue prenotazioni attive(EndDate maggiore della data di restituzione),
    //il sistema dovrà restituire il seguente messaggio di errore: “Il libro XXXXX non risulta
    //essere attualmente in prestito.”
     public class RestituzioneDiUnLibro : IOptionSelected
     {
        public User User { get; set; }
        public WCFBookProxy BookProxy { get; set; }


        public RestituzioneDiUnLibro(User currentUser, WCFBookProxy bookProxy)
        {
            this.User = currentUser;
            this.BookProxy = bookProxy;

        }
        public void Doing()// potrei fare un'altra interfaccia per le opt. riguardandi le reservations...
         {
             //IUserDAO userDAO = new UserDAO();
             //IBookDAO bookDAO = new BookDAO();
             //IReservationDAO reservationDAO = new ReservationDAO();



             //var lbl = new LibraryBusinessLogic(userDAO,bookDAO,reservationDAO);
             //sta cosa sopra non va bene, dovrei istanziare tutto una volta sola

             Console.WriteLine("inserire titolo del libro");
             var title = Console.ReadLine();
             Console.WriteLine("inserire nome autore");
             var authorName = Console.ReadLine();
             Console.WriteLine("inserire cognome autore");
             var authorSurname = Console.ReadLine();
             Console.WriteLine("inserire casa editrice");
             var publishingHouse = Console.ReadLine();

             var bookToReturnServiceViewModel = new ReturningBookServiceViewModel(title, authorName, authorSurname, publishingHouse);
            var bookToReturnViewModel = Mapper.MapperReturningBSVMtoRBVM(bookToReturnServiceViewModel);
             var bookToReturn = Mapper.MapperReturningBVMtoBOOK(bookToReturnViewModel);

            var reservationProxy = new WCFReservationProxy();
             var restitution = reservationProxy.BookReturn(bookToReturn.BookId, this.User.UserId);
             if (restitution.FlagResult ==0) Console.WriteLine("Libro restituito");
             else Console.WriteLine("il libro non risulta essere attualmente in prestito");
         }
     }
}
