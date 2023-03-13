using BusinessLogic.Library.ViewModels;
using ConsoleApp.Library.Options;
using DataAccessLayer.Library;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Library
{

    public class MapperBook
        //FALLO STATICO
    {// ci metto la bookList per riconoscere il libro? senno come faccio a ricavare l'id e la quanrity?
        public Book MapperBVMtoBOOK (BookViewModel bvm)
        {
            var bookList = new BookDAO().Read();
            var Id = 0;
            // c'è un problema, se voglio cambiare ad esempio solo la casa editrice, non so come ricercare un libro, faccio ricerca per titolo?
            // messa così mi modifica solo la quantità
            var queryId = bookList.Where(b => b.Title == bvm.Title && b.AuthorName == bvm.AuthorName
         && b.AuthorSurname == bvm.AuthorSurname && b.PublishingHouse == bvm.PublishingHouse).Select(e => e.BookId).ToList();
            Id = queryId[0];//la ricerca di un libro da modificare può lanciare un'eccezione,need try-catch
            var queryQuantity = bookList.Where(b => b.Title == bvm.Title && b.AuthorName == bvm.AuthorName
            && b.AuthorSurname == bvm.AuthorSurname && b.PublishingHouse == bvm.PublishingHouse).Select(e => e.Quantity).ToList();
            var quantity = queryQuantity[0];

            var book = new Book(Id, bvm.Title, bvm.AuthorName, bvm.AuthorSurname, bvm.PublishingHouse, quantity);
            return book;

        }

        public BookViewModel MapperBVMtoBOOK (Book book)
        {
            var bvm = new BookViewModel(book.Title,book.AuthorName,
                book.AuthorSurname,book.PublishingHouse);

            return bvm;

        }

        public Book MapperAddingBVMtoBOOK( AddingBookViewModel addingBVM)
        {
            var book = new Book(0, addingBVM.Title, addingBVM.AuthorName, addingBVM.AuthorSurname, addingBVM.PublishingHouse, addingBVM.Quantity);
            return book;
        }
        public Book MapperModifyingBVMtoBOOK (ModifyingBookViewModel modifyingBVM)
        {
            var book_db = new BookDAO();
            var bookList = book_db.Read();
            var Id = 0;
            // c'è un problema, se voglio cambiare ad esempio solo la casa editrice, non so come ricercare un libro, faccio ricerca per titolo?
            // messa così mi modifica solo la quantità
                var queryId = bookList.Where(b => b.Title == modifyingBVM.Title && b.AuthorName == modifyingBVM.AuthorName
             && b.AuthorSurname == modifyingBVM.AuthorSurname && b.PublishingHouse == modifyingBVM.PublishingHouse).Select(e => e.BookId).ToList();
            Id= queryId[0];//la ricerca di un libro da modificare può lanciare un'eccezione,need try-catch
            var queryQuantity = bookList.Where(b => b.Title == modifyingBVM.Title && b.AuthorName == modifyingBVM.AuthorName
            && b.AuthorSurname == modifyingBVM.AuthorSurname && b.PublishingHouse == modifyingBVM.PublishingHouse).Select(e => e.Quantity).ToList();
            var quantity = queryQuantity[0];


            var book = new Book(Id, modifyingBVM.Title, modifyingBVM.AuthorName, modifyingBVM.AuthorSurname, modifyingBVM.PublishingHouse, quantity);
            return book;
        }

        public Book MapperReservingBVMtoBOOK (ReservingBookViewModel reservingBVM)
        {
            var book_db = new BookDAO();
            var bookList = book_db.Read();
            var Id = 0;
            var quantity = 0;

            var queryId = bookList.Where(b => b.Title == reservingBVM.Title && b.AuthorName == reservingBVM.AuthorName
             && b.AuthorSurname == reservingBVM.AuthorSurname && b.PublishingHouse == reservingBVM.PublishingHouse).Select(e => e.BookId).ToList();
           
            // devo gestire se il libro non esiste
            Id = queryId[0];
            
            var queryQuantity= bookList.Where(b => b.Title == reservingBVM.Title && b.AuthorName == reservingBVM.AuthorName
             && b.AuthorSurname == reservingBVM.AuthorSurname && b.PublishingHouse == reservingBVM.PublishingHouse).Select(e => e.Quantity).ToList();
            quantity = queryQuantity[0];

            var book = new Book(Id, reservingBVM.Title, reservingBVM.AuthorName,
                reservingBVM.AuthorSurname, reservingBVM.PublishingHouse, quantity);
            return book;

        }

        public Book MapperReturningBVMtoBOOK(ReturningBookViewModel returningBVM)
        {
            var book_db = new BookDAO();
            var bookList = book_db.Read();
            var Id = 0;
            var quantity = 0;

            var queryId = bookList.Where(b => b.Title == returningBVM.Title && b.AuthorName == returningBVM.AuthorName
             && b.AuthorSurname == returningBVM.AuthorSurname && b.PublishingHouse == returningBVM.PublishingHouse).Select(e => e.BookId).ToList();
            Id = queryId[0];

            var queryQuantity = bookList.Where(b => b.Title == returningBVM.Title && b.AuthorName == returningBVM.AuthorName
             && b.AuthorSurname == returningBVM.AuthorSurname && b.PublishingHouse == returningBVM.PublishingHouse).Select(e => e.Quantity).ToList();
            quantity = queryQuantity[0];

            var book = new Book(Id, returningBVM.Title, returningBVM.AuthorName,
                returningBVM.AuthorSurname, returningBVM.PublishingHouse, quantity);
            return book;
        }

        public List<User> MapperUsernameVMtoUserList(UsernameViewModel uvm)
        {
            var userDAO = new UserDAO();
            var userList = userDAO.Read();
            var filteredUserList = new List<User>();

            foreach (var user in userList)
            {
                if (!string.IsNullOrEmpty(uvm.Userame))
                {
                    userList = userList.Where(u => u.Username == uvm.Userame).ToList();

                }
            }

            return userList;
           
        }

        public List<Book> MapperBVMtoBOOKforGetReservationsHistory(BookViewModel bvm)
        {

            var book_db = new BookDAO();
            var bookList = book_db.Read();
            //var Id = 0;
            //var quantity = 0;

            if (!string.IsNullOrEmpty(bvm.Title))
            {
                bookList = bookList.Where(b=>b.Title == bvm.Title).ToList();
            }
            if (!string.IsNullOrEmpty(bvm.AuthorName))
            {
                bookList = bookList.Where(b=>b.AuthorName == bvm.AuthorName).ToList();
            }
            if (!string.IsNullOrEmpty(bvm.AuthorSurname))
            {
                bookList = bookList.Where(b=>b.AuthorSurname == bvm.AuthorSurname).ToList();
            }
            if (!string.IsNullOrEmpty(bvm.PublishingHouse))
            {
                bookList = bookList.Where(b => b.PublishingHouse == bvm.PublishingHouse).ToList();
            }
            return bookList;

            //da gestire ricerca per filtri
            //var queryId = bookList.Where(b => b.Title == bvm.Title && b.AuthorName == bvm.AuthorName
            // && b.AuthorSurname == bvm.AuthorSurname && b.PublishingHouse == bvm.PublishingHouse).Select(e => e.BookId).ToList();

            //// devo gestire se il libro non esiste
            //Id = queryId[0];

            //var queryQuantity = bookList.Where(b => b.Title == bvm.Title && b.AuthorName == bvm.AuthorName
            // && b.AuthorSurname == bvm.AuthorSurname && b.PublishingHouse == bvm.PublishingHouse).Select(e => e.Quantity).ToList();
            //quantity = queryQuantity[0];

            //var book = new Book(Id, bvm.Title, bvm.AuthorName, bvm.AuthorSurname, bvm.PublishingHouse, quantity);
            //return book;
        }
       
        }

        //public Reservation MapperReservationStatusToReservation(ReservationStatus reservationStatus)
        //{
        //    var reservationDAO = new ReservationDAO();
        //    var reservationList = reservationDAO.Read();

        //    if (reservationStatus.Status.Equals("attiva"))
        //    {
        //        reservationList = reservat
        //    }
        //}
    
}
