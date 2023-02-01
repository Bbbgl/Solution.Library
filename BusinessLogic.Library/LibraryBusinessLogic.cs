using BusinessLogic.Library.ViewModels;
using DataAccessLayer.Library;
using Model.Library;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Library
{
    public class LibraryBusinessLogic : ILibraryBusinessLogic
    {
        //•	Login: Dovrà essere valutata l’esistenza o meno dello User sulla base dei dati
        //specificati dall’utente (Username, Password)

       public IRepository Repository { get; set; }  

        public LibraryBusinessLogic (IRepository repository)
        {
            this.Repository = repository;
        }

        public User Login(LoginViewModel lvm)
        {
            //query id e query role
            
            //UserDAO user_db = new UserDAO();
            var listaUtentiDalDb =Repository.ReadUsers();

            var queryUser = listaUtentiDalDb.Where(u=> u.Username == lvm.Username &&
            u.Password == lvm.Password).Select(e=> new User(e.UserId,e.Username,e.Password,e.Role) ).ToList();


            if (queryUser.Count() == 0)
            {
                var user = new User(0, null, null, null);
                return user;
            }
            else
            {

                return queryUser[0];
            }
        }

        public bool LoginUserCheck(string username, string password, List<User> userList)
        {

            var check = true;
            for (int i = 0; i < userList.Count(); i++)
            {
                if ((username.Equals(userList[i].Username)) && (password.Equals(userList[i].Password)))
                {
                    check = true;
                    break;
                }
                else check = false;
            }
            return check;
        }// prova LINQ


        public bool AdminCheck(string username, List<User> userList)
        {
            var userIndex = 0;
            for (int i = 0; i < userList.Count(); i++)
            {
                if (username.Equals(userList[i].Username)) { userIndex = i; break; }// metto solo username ora, perchè non ci sono utenti con stesso username
            }
            if (userList[userIndex].Role.Equals("Admin")) return true;
            else return false;
        }


        public void AddBook(Book book)
        {
            //var book_db = new BookDAO();
            //var bookList = book_db.Read();
            
            var bookList = Repository.ReadBooks();
            bool libroIsPresent = false;

            // devo trovare l'id del libro inserito, che è l'unico parametro non noto all'utente
            var book_id = 0;
            for (var i = 0; i < bookList.Count(); i++)
            {
                //se presente
                if (((book.Title).Equals(bookList[i].Title)) && ((book.AuthorSurname).Equals(bookList[i].AuthorSurname)))//AGGIUNGI GLI ALTRI
                {

                    book_id = i;
                    libroIsPresent = true;



                    //    libroIsPresent = true;
                    break;
                }
                else {
                    libroIsPresent = false;

                }
                //else { libroIsPresent = false; }





            }
            if (libroIsPresent) { this.Repository.UpdateBook(book, book_id); }
            else { this.Repository.CreateBook(book); }
            //guardare se il libro è presente--> se si aggiungere quantità(update BookDAo)
            //altrimenti aggiungere libro (create bookDAO)
        }

        public void UpdateBook(int bookId, Book bookWithNewValues)
        {
            //var book_db = new BookDAO();
            this.Repository.UpdateBook(bookWithNewValues, bookId);

        }

        public List<Book> SearchBook(Book book)
        {
            //var book_db = new BookDAO();
            //var bookList = book_db.Read();
            // mancano gli altri parametri di ricerca.
            // se non inserisce nessun parametro mostrare tutti i libri, come????FATTO

            var bookList = this.Repository.ReadBooks();

            var queryTitle =  bookList.Where(b => (b.Title == (book.Title)))
                 .Select(e => e);
                
            return queryTitle.ToList();
            


        }

        public List<BookViewModel> SearchBookWithAvailabilityInfos(Book book)
        {
            var bookWithAvaiabilityInfosList = new List<BookViewModel>();

            //var book_db = new BookDAO();
            var bookList = this.Repository.ReadBooks();

            var filteredBookByQuantity = bookList.Where(b => b.Quantity > 0)
                 .Select(e => e).ToList();

            if(!string.IsNullOrEmpty(book.Title))
            {
                filteredBookByQuantity = filteredBookByQuantity.Where(x => x.Title == book.Title).ToList();
            }
            if (!string.IsNullOrEmpty(book.AuthorName))
            {
                filteredBookByQuantity = filteredBookByQuantity.Where(x => x.AuthorName == book.AuthorName).ToList();
            }
            if (!string.IsNullOrEmpty(book.AuthorSurname))
            {
                filteredBookByQuantity = filteredBookByQuantity.Where(x => x.AuthorSurname == book.AuthorSurname).ToList();
            }
            if (!string.IsNullOrEmpty(book.PublishingHouse))
            {
                filteredBookByQuantity = filteredBookByQuantity.Where(x => x.PublishingHouse == book.PublishingHouse).ToList();
            }
            foreach(var books in filteredBookByQuantity)
            {
                var bvm = new BookViewModel(books.Title, books.AuthorName, books.AuthorSurname, books.PublishingHouse,true);
                bookWithAvaiabilityInfosList.Add(bvm);
            }
            return bookWithAvaiabilityInfosList;


            //if (book.Title == "" && book.AuthorName == "" && book.AuthorSurname == ""
            //    && book.PublishingHouse == "")
            //{
            //    var queryQuantity = bookList.Where(b => b.Quantity > 0)
            //     .Select(e => e).ToList();

            //    for (var i = 0; i < queryQuantity.Count; i++)
            //    {
            //        var bookViewModelWithAvaiabilityInfo = new BookViewModel(queryQuantity[i].Title
            //        , queryQuantity[i].AuthorName, queryQuantity[i].AuthorSurname,
            //        queryQuantity[i].PublishingHouse, true);
            //        bookWithAvaiabilityInfosList.Add(bookViewModelWithAvaiabilityInfo);
            //    }
            //}
            //else
            //{

            //    //var book_db = new BookDAO();
            //    //var bookList = book_db.Read();
            //    var queryAvaiableBooks = bookList.Where(b => (b.Title == (book.Title)) && b.Quantity > 0)
            //         .Select(e => e).ToList();
            //    for (var i = 0; i < queryAvaiableBooks.Count; i++)
            //    {
            //        var bookViewModelWithAvaiabilityInfo = new BookViewModel(queryAvaiableBooks[i].Title
            //            , queryAvaiableBooks[i].AuthorName, queryAvaiableBooks[i].AuthorSurname,
            //            queryAvaiableBooks[i].PublishingHouse, true);
            //        bookWithAvaiabilityInfosList.Add(bookViewModelWithAvaiabilityInfo);
            //    }
            //}
            //return bookWithAvaiabilityInfosList;







        }

        public void ReserveBook(int bookId, int userId)
        {
            //IBookDAO bookDAO = new BookDAO();
            //IUserDAO userDAO = new UserDAO();
            var bookList = this.Repository.ReadBooks();
            var userList = this.Repository.ReadUsers();

            //IReservationDAO reservationDAO = new ReservationDAO();

            if (bookList[bookId].Quantity > 0) {
                this.Repository.CreateReservation(bookList[bookId], userList[--userId]);// userId è decrementato perchè sul db parte da 1 (invece che da 0)
            
            }
                //bookDAO.Update(bookList[bookId].BookId); // DOVREI AGGIORNARE LA QUANTITA
        
        }

        public void DeleteBook(Book book)
        {
          //var book_db = new BookDAO();
            var bookList = this.Repository.ReadBooks();
            // dai parametri passati nel book ricavo l'id di quel book
            var queryId = bookList.Where(b => b.Title == book.Title && b.AuthorName == book.AuthorName
             && b.AuthorSurname==book.AuthorSurname && b.PublishingHouse==book.PublishingHouse).Select(e => e.BookId).ToList();

            this.Repository.DeleteBook(queryId[0]);
            this.Repository.UpdateIdsBook(queryId[0]);
            

        }

        public BookViewModel SearchBookWithAvailabilityInfos2(Book book)
        {
            if(book.Quantity > 0)
            {
                var bookAvailable = new BookViewModel(book.BookId, book.Title,
                    book.AuthorName, book.AuthorSurname, book.PublishingHouse, book.Quantity, true);
                return bookAvailable;
            }else
            {
                var bookNotAvailable = new BookViewModel(book.BookId, book.Title,
                    book.AuthorName, book.AuthorSurname, book.PublishingHouse, book.Quantity, false);
                return bookNotAvailable;
            }

            
        }

        public ReservationResult ReserveBookPROVA(int bookId, int userId)
        {
            //Un utente NON può richiedere il prestito di un libro di cui ha già una prenotazione attiva.
            // TODO CONTROLLARE SE UTENTE HA GIA PRENOTATO LIBROVV
            //AGGIORNA QUANTITA
            //IBookDAO bookDAO = new BookDAO();
            //IUserDAO userDAO = new UserDAO();
            //var bookList = bookDAO.Read();
            //var userList = userDAO.Read();

            //IReservationDAO reservationDAO = new ReservationDAO();

            var bookList = this.Repository.ReadBooks();
            var userList = this.Repository.ReadUsers();

            var reservationList = this.Repository.ReadReservations();

            var queryReservedBookByUser = reservationList.Where(r =>
            r.User.UserId == userId // ottengo tutte le prenotazioni di questo utente

            && r.Book.BookId == bookId// ottengo tutte le prenotazioni di questo utente per questo libro

            && r.EndDate > DateTime.Now // vedo se le prenotazioni di questo utente per questo libro sono scadute

            ).Select(e => e).ToList();
            //var reservationResult = new ReservationResult( userList[userId],bookList[bookId],false);


            if ((bookList[bookId].Quantity > 0)&&  // vedo se questo libro ha quantità >0

                (queryReservedBookByUser.Count == 0))//questo utente non ha prenotazioni attive per questo libro
            {
                // calcolo quante prenotazioni attive ha quel libro
                var queryBookReservations = reservationList.Where(r =>
                r.Book.BookId == bookId// reservation di questo libro IL PROBLEMA QUI é CHE STE RESERVATION RIMANGONO SEMPRE QUINDI DEVO CONTROLLARE ENDTIME
                && r.EndDate < DateTime.Now// se l'end date non è oggi allora prenotazione attiva
                ).Select(e => e).ToList();

                // se il numero di prenotazioni attive è minore della quantità del libro
                if (queryBookReservations.Count < bookList[bookId].Quantity)
                {
                    // prenotazione success


                    this.Repository.CreateReservation(bookList[bookId], userList[--userId]);// userId è decrementato perchè sul db parte da 1 (invece che da 0)
                    var reservationResult = new ReservationResult(userList[userId], bookList[bookId], 0);
                    // decrementare quantita di questo libro NOOOOOOOOOOO



                    return reservationResult;

                }
                else
                {
                    var reservationResult = new ReservationResult(userList[userId], bookList[bookId], 1);// il libro non è disponibile
                    return reservationResult;
                }
            }
            else
            {
                var reservationResult = new ReservationResult(userList[userId], bookList[bookId], 2);// l'utente ha già prenotato il libro
                return reservationResult;
            }
        }


        public ReservationResult BookReturn(int bookId, int userId)
        {
            //IBookDAO bookDAO = new BookDAO();
            //IUserDAO userDAO = new UserDAO();
            //var bookList = bookDAO.Read();
            //var userList = userDAO.Read();

            //IReservationDAO reservationDAO = new ReservationDAO();
            //var reservationList = reservationDAO.Read();

            var bookList = this.Repository.ReadBooks();
            var userList = this.Repository.ReadUsers();

            var reservationList = this.Repository.ReadReservations();


            // controllo se il lbro è effettivamente prenotato dall'utente in questione
            var queryBookToReturn = reservationList.Where(r =>
            r.Book.BookId == bookId // seleziono tutte le res per questo libro
            && r.User.UserId== userId // seleziono tutte le res per questo libro fatte da questo utente
            && r.EndDate>DateTime.Now // seleziono tutte le res per questo libro fatte da questo utente che sono attualmente attive

            ).Select(e => e).ToList();

            
             if (queryBookToReturn.Count > 0)// questo utente ha questo libro attualmente in prestito
            {
                var reservationResult = new ReservationResult(userList[userId], bookList[bookId], 0);
                // questo sotto potrei farlo con un mapper
                var reservationToUpdate = new Reservation(queryBookToReturn[0].ResId, queryBookToReturn[0].User,
                    queryBookToReturn[0].Book, queryBookToReturn[0].StartDate, DateTime.Now);

                this.Repository.UpdateReservation(reservationToUpdate,reservationToUpdate.ResId);

                return reservationResult;
            }

             else
            {
                var reservationResult = new ReservationResult(userList[userId], bookList[bookId], 1);
                return reservationResult;
            }
            // si restutisce un libro, quindi si deve modificare il valore della quantity del libro (+1) e cancellare la reservation
        }

        public List<ReservationViewModel> GetReservationHistory(int? bookId, int? userId, ReservationStatus? reservationStatus)
        {
            var reservationList = this.Repository.ReadReservations();

            var resultList = new List<ReservationViewModel>();


            if (userId != 0)
            {
                reservationList = reservationList.Where(r => r.User.UserId == userId).Select(e => e).ToList();
            }
            if(bookId != 0)
            {
                reservationList = reservationList.Where(r => r.Book.BookId == bookId).Select(e => e).ToList();

            }
            if (reservationStatus.Value.Status.Equals("attiva"))//resstatus è sempre diverso da null,anche quando non ci metto niente-->faccio soltanto if restatus equals attiva o non attiva
            {


                reservationList = reservationList.Where(r => r.EndDate > DateTime.Now).Select(e => e).ToList();
            }
            else if (reservationStatus.Value.Status.Equals("non attiva"))
            {
                reservationList = reservationList.Where(r => r.EndDate < DateTime.Now).Select(e => e).ToList();

            }
        //else niente
            

            foreach (var reservation in reservationList)
            {
                if (reservation.EndDate > DateTime.Now)// la prenotazione è attiva
                {
                    var rvm = new ReservationViewModel(reservation.Book.Title, reservation.User.Username, reservation.StartDate, reservation.EndDate, 0);
                    resultList.Add(rvm);

                }
                else if (reservation.EndDate < DateTime.Now)//prenotazione non attiva
                {
                    var rvm = new ReservationViewModel(reservation.Book.Title, reservation.User.Username, reservation.StartDate, reservation.EndDate, 1);
                    resultList.Add(rvm);
                }
            }return resultList;

            //if (reservationStatus.Value.Equals("attiva"))
            //{
            //    reservationList = reservationList.Where(r => r.EndDate < DateTime.Now).Select(e => e).ToList();

            //}




        }
    }







           




    }

