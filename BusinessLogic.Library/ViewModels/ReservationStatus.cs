using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Library.ViewModels
{
    public struct ReservationStatus
    {
        public string Status { get; set; }

        public ReservationStatus(string status)
        {
            this.Status = status;
        }
    }
}
