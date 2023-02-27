using Model.Library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Library
{
    
    
    
    public class Repository: IRepository
    {
        public IUserDAO UserDAO { get; set; }
        public IBookDAO BookDAO { get; set; }
        public IReservationDAO ReservationDAO { get; set; }

        public Repository(IUserDAO userDAO, IBookDAO bookDAO, IReservationDAO reservationDAO)
        {
            this.UserDAO = userDAO;
            this.BookDAO = bookDAO;
            this.ReservationDAO = reservationDAO;
        }

        // CRUD methods for User
        public List<User> ReadUsers()
        {
            return this.UserDAO.Read();
        }

        // CRUD methods for Book
        public List<Book> ReadBooks()
        {
            return this.BookDAO.Read();
        }

        public void CreateBook(Book book)
        {
            this.BookDAO.Create(book);
        }

        public void UpdateBook(Book book, int id_book)
        {
            this.BookDAO.Update(book,id_book);
        }

        public void UpdateIdsBook(int id_book)
        {
            this.BookDAO.UpdateIds(id_book);
        }

        public void DeleteBook(int id_book)
        {
           this.BookDAO.Delete(id_book);
        }

        public List<Reservation> ReadReservations()
        {
            return this.ReservationDAO.Read();
        }
        

        public void CreateReservation(Book book, User user)
        {
            this.ReservationDAO.Create(book,user);
        }

        public void UpdateReservation(Reservation reservation, int reservation_id)
        {
            this.ReservationDAO.Update(reservation,reservation_id);
        }

        public void DeleteReservation(int reservationId)
        {
            this.ReservationDAO.Delete(reservationId);
        }

        public static string ApplicationName
        {
            get;
            set;
        }
        public static int ConnectionTimeout
        {
            get;
            set;
        }


    }
}
