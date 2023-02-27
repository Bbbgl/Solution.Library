using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Library.ViewModels
{
    public class SearchingBookViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string PublishingHouse { get; set; }
        public int Quantity { get; set; }

        public bool Avaiability { get; set; }
        public DateTime? FirstAvailability { get; set; }

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
