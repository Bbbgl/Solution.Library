using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Library.ServiceViewModels
{
    [DataContract]
    public class UsernameServiceViewModel
    {
        [DataMember] public string Userame { get; set; }

        public UsernameServiceViewModel(string userame)
        {
            this.Userame = userame;
        }   
    }
}
