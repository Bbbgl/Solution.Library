using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Library.ServiceViewModels
{
    [DataContract]
    public struct ServiceReservationStatus
    {
        [DataMember] public string Status { get; set; }

        public ServiceReservationStatus(string status)
        {
            this.Status = status;
        }
    }
}
