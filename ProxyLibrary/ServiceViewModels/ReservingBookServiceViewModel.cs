using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Library.ServiceViewModels
{
    [DataContract]
    public class ReservingBookServiceViewModel
    {
        [DataMember] public string Title { get; set; }
        [DataMember] public string AuthorName { get; set; }
        [DataMember] public string AuthorSurname { get; set; }
        [DataMember] public string PublishingHouse { get; set; }
        

        public ReservingBookServiceViewModel(string title, string authorName, string authorSurname,
            string publishingHouse)
        {

            this.Title = title;
            this.AuthorName = authorName;
            this.AuthorSurname = authorSurname;
            this.PublishingHouse = publishingHouse;
            

        }
    }
}
