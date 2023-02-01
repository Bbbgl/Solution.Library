using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Library.ViewModels
{
    public class ReservationViewModel
    {
        public string BookTitle { get; set; }
        public string Username {get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ReservationFlag { get; set; }


        public ReservationViewModel (string bookTitle, string username, DateTime startDate, DateTime endDate,
            int reservationFlag)
        {
            this.BookTitle= bookTitle;
            this.Username= username;
            this.StartDate= startDate;
            this.EndDate= endDate;
            this.ReservationFlag= reservationFlag;
        }
    }
}
