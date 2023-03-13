using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Library.ViewModels
{
    [DataContract]
    public class SearchingBookViewModel
    {
        [DataMember] public int BookId { get; set; }
        [DataMember] public string Title { get; set; }
        [DataMember] public string AuthorName { get; set; }
        [DataMember] public string AuthorSurname { get; set; }
        [DataMember] public string PublishingHouse { get; set; }
        [DataMember] public int Quantity { get; set; }

        [DataMember] public bool Avaiability { get; set; }
        [DataMember] public DateTime? FirstAvailability { get; set; }

public SearchingBookViewModel(int bookId, string title, string authorName, string authorSurname, string publishingHouse, int quantity, bool avaiability, DateTime? firstAvailability)
        {
            BookId = bookId;
            Title = title;
            AuthorName = authorName;
            AuthorSurname = authorSurname;
            PublishingHouse = publishingHouse;
            Quantity = quantity;
            Avaiability = avaiability;
            FirstAvailability = firstAvailability;
        }
    }

    
}
