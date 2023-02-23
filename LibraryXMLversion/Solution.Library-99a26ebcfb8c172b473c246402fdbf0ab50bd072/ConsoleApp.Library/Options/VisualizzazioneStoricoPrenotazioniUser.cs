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
    public class VisualizzazioneStoricoPrenotazioniUser : IOptionSelected
    {
        public User User { get; set; }
        public LibraryBusinessLogic LibraryBusinessLogic { get; set; }


        public VisualizzazioneStoricoPrenotazioniUser(User currentUser, LibraryBusinessLogic lbl)
        {
            this.User = currentUser;
            this.LibraryBusinessLogic = lbl;

        }
        public void Doing()
        {
            var mapper = new MapperBook(); // probabilmente lo dovrò passare nel costruttore e toglierlo senza istanziarlo ogni volta
            //Console.WriteLine("Inserisci username");
            //var usernameForFilter = Console.ReadLine();

            //int? userForFilteringId = 0;
            //if (usernameForFilter != "")
            //{
            //    var usernameViewModel = new UsernameViewModel(usernameForFilter);

            //    var userForFiltering = mapper.MapperUsernameVMtoUser(usernameViewModel);
            //    //TODO try { } se l'utente inserito non esiste c'è un eccezione
            //    userForFilteringId = userForFiltering.UserId;

            //}
            var userId = this.User.UserId;


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
            var bookForFilteringId = 0;
            if (title != "")
            { // anche gli altri parametri

                var bookViewModel = new BookViewModel(title, authorName, authorSurname, publishingHouse);
                var bookForFiltering = mapper.MapperBVMtoBOOKforGetReservationsHistory(bookViewModel);
                bookForFilteringId = bookForFiltering.BookId;
            }
            Console.WriteLine("inserisci stato prenotazione (attiva/non attiva");
            var statoPrenotazione = Console.ReadLine();

            var reservationStatus = new ReservationStatus(statoPrenotazione);

            //var reservationStatusForFiltering = mapper.MapperReservationStatusToReservation(reservationStatus);


            var result = this.LibraryBusinessLogic.GetReservationHistory(bookForFilteringId, userId, reservationStatus);

            foreach (var reservation in result)
            {
                if (reservation.ReservationFlag == 0)
                    Console.WriteLine($" l'utente {reservation.Username} ha prenotato il libro {reservation.BookTitle} fino al giorno {reservation.EndDate}");// meetti i giorni
                else Console.WriteLine($" l'utente {reservation.Username} ha prenotato il libro {reservation.BookTitle} e lo ha restituito il giorno {reservation.EndDate}");


            }
        }
    }
}

