using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Library.ViewModels
{
    [DataContract]
    public class UsernameViewModel
    {
        [DataMember] public string Userame { get; set; }

        public UsernameViewModel(string userame)
        {
            this.Userame = userame;
        }   
    }
}
