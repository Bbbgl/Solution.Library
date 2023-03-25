
using Model.Library;
using Proxy.Library;
using Proxy.Library.ServiceViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Options
{
    public class VisualizzazioneStoricoPrenotazioniAdmin : IOptionSelected
    {
        //        •	Visualizzare lo storico delle prenotazioni:
        //        questa ricerca può essere effettuata filtrando per Utente(Username) (solo admin)
        //        e/o Libro(Anagrafica) e/o Stato Prenotazione(Attiva/Non Attiva).
        //Le informazioni da mostrare sono:
        //titolo del libro – nome utente – data di inizio prestito – data di fine prestito –
        //info su stato prenotazione(attiva/non attiva)

        public User User { get; set; }
        public IBookProxy BookProxy { get; set; }


        public VisualizzazioneStoricoPrenotazioniAdmin(User currentUser, IBookProxy bookProxy)
        {
            this.User = currentUser;
            this.BookProxy = bookProxy;

        }
        // l'admin credo possa vedere le prenotazioni di tutti gli utenti
        
        public void Doing()
        {
            Console.WriteLine("Inserisci username");
            var usernameForFilter = Console.ReadLine();

            int? userForFilteringId=0;
            //if(usernameForFilter != "") { 
            var usernameServiceViewModel = new UsernameServiceViewModel(usernameForFilter);

            var usersFilterList = Mapper.MapperUsernameVMtoUserList(Mapper.MapperUSVMtoUVM(usernameServiceViewModel));
            if (usersFilterList.Count == 0) Console.WriteLine("l'utente non esiste!!");
            // se la lista utenti è uguale 1 significa che è stato inserito un utente specifico
            if (usersFilterList.Count == 1) userForFilteringId = usersFilterList[0].UserId;




            // userForFilteringId = userForFiltering.UserId;

            // }


            List<int?> bookForFilteringId = new List<int?>();
            Console.WriteLine("inserisci libro");
            Console.WriteLine("inserire titolo del libro");
            var title = Console.ReadLine();
            Console.WriteLine("inserire nome autore");
            var authorName = Console.ReadLine();
            Console.WriteLine("inserire cognome autore");
            var authorSurname = Console.ReadLine();
            Console.WriteLine("inserire casa editrice");
            var publishingHouse = Console.ReadLine();
            //DEVO GESTIRE IL FILTRO SE L'UTENTE NON INSERISCE IL LIBRO


            
            
            var bookServiceViewModel=new BookServiceViewModel(title, authorName, authorSurname, publishingHouse);
            
            //var bookFilterList = this.LibraryBusinessLogic.SearchBookWithAvailabilityInfos(bookViewModel);  
            
            var booksFilterList = Mapper.MapperBVMtoBOOKforGetReservationsHistory(Mapper.MapperBSVMtoBVM(bookServiceViewModel));


            if (booksFilterList.Count.Equals(this.BookProxy.ReadBooks())) bookForFilteringId[0] = 0;
            else
            {
                foreach (var book in booksFilterList)
                {
                    bookForFilteringId.Add(book.BookId);
                }


             }           

            Console.WriteLine("inserisci stato prenotazione (attiva/non attiva)");
            var statoPrenotazione = Console.ReadLine();

            var serviceReservationStatus = new ServiceReservationStatus(statoPrenotazione);

            //var reservationStatusForFiltering = mapper.MapperReservationStatusToReservation(reservationStatus);
            var serviceResult = new List<ReservationServiceViewModel>();
            var result = Mapper.MapperListRSVMtoListRVM(serviceResult);
            var reservationProxy = new API_ReservationProxy();
            for (int i = 0; i < bookForFilteringId.Count; i++)
            {
               
                
                
                var newList = reservationProxy.GetReservationHistory(bookForFilteringId[i], userForFilteringId, Mapper.MapperSRStoRS(serviceReservationStatus));
                
                
                
                // da rivedere sta cosa, forse è da fare un mapper tra una lista resServiceVM a resVM
                
                result.AddRange(newList);
            }


            //foreach (var user in usersFilterList)
            //{
            //    foreach (var book in booksFilterList)
            //    {
                   
            //        result = this.LibraryBusinessLogic.GetReservationHistory(book.BookId, user.UserId, reservationStatus);
            //    }
            //}


            // var result = this.LibraryBusinessLogic.GetReservationHistory(bookForFilteringId, userForFilteringId, reservationStatus);

            foreach (var reservation in result)
            {
                if (reservation.ReservationFlag == 0)
                    Console.WriteLine($" l'utente {reservation.Username} ha prenotato il libro {reservation.BookTitle} fino al giorno {reservation.EndDate}");// meetti i giorni
                else Console.WriteLine($" l'utente {reservation.Username} ha prenotato il libro {reservation.BookTitle} e lo ha restituito il giorno {reservation.EndDate}");


            }
        }
    }
}
