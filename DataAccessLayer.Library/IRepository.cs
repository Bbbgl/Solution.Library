using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Library
{
    public interface IRepository
    {
        //CRUD methods USER
        List<User> ReadUsers();


        //CRUD methods BOOK
        List<Book> ReadBooks();

        void CreateBook(Book book);

        void UpdateBook(Book book, int id_book);

        void UpdateIdsBook(int id_book);

        void DeleteBook(int id_book);

        //CRUD methods RESERVATION
        List<Reservation> ReadReservations();//sarebbe get reservation

        //List<Reservation> GetReservationHistory(int? bookId, int? userId, ReservationStatus? reservationStatus);
        void CreateReservation(Book book, User user);
        void UpdateReservation(Reservation reservation, int reservation_id);
    }
}
