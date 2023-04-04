using Model.Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

//•	Reservation rappresenta la prenotazione di un libro. E’ un’associativa tra libro ed utente, 
//    ed è caratterizzata da:
//o Id numero intero univoco
//o	UserId che ha richiesto quella prenotazione
//o	BookId richiesto
//o	StartDate data che identifica l’inizio della prenotazione
//o	EndDate data che identifica la fine della prenotazione (*)
//NB: Il libro è da considerarsi non più disponibile ad altre prenotazioni nel momento in 
//    cui esiste un numero di prenotazioni uguale alla quantità di copie in biblioteca aventi
//    tutte un EndDate maggiore rispetto al momento in cui si fa richiesta.
//    All’atto della restituzione, il sistema dovrà farsi carico di aggiornare l’EndDate della
//    prenotazione con la data della restituzione stessa

namespace Model.Library
{
    [DataContract]
    public class Reservation
    {

        //public Book book;
        //public User user;
        [DataMember]
       public int ResId { get; set; }
        [DataMember] 
        public User User { get; set; } // foreign key
        [DataMember] 
        public Book Book { get; set; } // foreign key

        //serve BOokDAO e UserDAO



        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }

        //public DateTime EndDate
        //{
        //    get { return endDate; }
        //    set
        //    {
        //        endDate = StartDate.AddDays(30);
        //    }
        //}
        public Reservation (int resId, User user, Book book, DateTime startDate, DateTime endDate)
        {
            this.ResId = resId;
            this.User = user;
            this.Book = book;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }
        //public Reservation(User user,Book book)
        //{
        //    UserId = user.UserId;
        //    BookId=book.BookId;
            
        //}

        



    }

    public class BookToReturnDTO
    {
        public int UserID { get; set; }
        public int BookID { get; set; }

        public BookToReturnDTO (int userID, int bookID)
        {
            UserID = userID;
            BookID = bookID;
        }
    }

    public class ReservationHistoryDTO
    {
        public int? UserID { get; set; }
        public int? BookID { get; set; }

        public ReservationStatusDTO? ReservationStatus { get; set; }

        public ReservationHistoryDTO(int? userID, int? bookID, ReservationStatusDTO? reservationStatus)
        {
            UserID = userID;
            BookID = bookID;
            ReservationStatus = reservationStatus;
        }
    }

    public class BookToReserveDTO
    {
        public int UserID { get; set; }
        public int BookID { get; set; }

        public BookToReserveDTO(int userID, int bookID)
        {
            UserID = userID;
            BookID = bookID;
        }
    }
    public struct ReservationStatusDTO
{
    public string Status { get; set; }

    public ReservationStatusDTO(string status)
    {
        this.Status = status;
    }
}
}
