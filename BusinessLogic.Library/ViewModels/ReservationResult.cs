using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Library.ViewModels
{
    public class ReservationResult
    {
        //public Book book;
        //public User user;
        int Id { get; set; }
        public User User { get; set; } // foreign key
        public Book Book { get; set; } // foreign key

        public int FlagResult { get; set; }

        //serve BOokDAO e UserDAO



        DateTime StartDate { get; set; }

        private DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = StartDate.AddDays(30);
            }
        }
        public ReservationResult(User user, Book book, int flagResult)
        {
            this.User = user;
            this.Book = book;
            this.FlagResult = flagResult;
        }
        //public Reservation(User user,Book book)
        //{
        //    UserId = user.UserId;
        //    BookId=book.BookId;

        //}





    }
}

