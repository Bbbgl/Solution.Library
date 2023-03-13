using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Library.ViewModels
{
    [DataContract]
    public struct ReservationStatus
    {
        [DataMember] public string Status { get; set; }

        public ReservationStatus(string status)
        {
            this.Status = status;
        }
    }
}
