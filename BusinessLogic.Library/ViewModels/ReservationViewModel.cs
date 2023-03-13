using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Library.ViewModels
{
    [DataContract]
    public class ReservationViewModel
    {
        [DataMember] public string BookTitle { get; set; }
        [DataMember] public string Username {get; set; }

        [DataMember] public DateTime StartDate { get; set; }
        [DataMember] public DateTime EndDate { get; set; }
        [DataMember] public int ReservationFlag { get; set; }


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
