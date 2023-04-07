using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Library.ServiceViewModels
{
    [DataContract]
    public class LoginServiceViewModel
    {
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }

        //public eRole Role { get; set; } LAVORO CON LE STRINGHE (+ semplice, poi in caso cambio)

        public LoginServiceViewModel(string username, string password)
        {

            this.Username = username;
            this.Password = password;

        }

        public LoginServiceViewModel() { }
    }
}
