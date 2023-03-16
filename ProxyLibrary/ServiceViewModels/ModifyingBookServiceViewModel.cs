using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Library.ServiceViewModels
{
    [DataContract]
    public class ModifyingBookServiceViewModel
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember] public string AuthorName { get; set; }
        [DataMember] public string AuthorSurname { get; set; }
        [DataMember] public string PublishingHouse { get; set; }
        //public int Quantity { get; set; }

        public ModifyingBookServiceViewModel(string title, string authorName, string authorSurname,
            string publishingHouse) //, int quantity)
        {

            this.Title = title;
            this.AuthorName = authorName;
            this.AuthorSurname = authorSurname;
            this.PublishingHouse = publishingHouse;
            //this.Quantity = quantity;
            ///inutile?

        }

    }
}
