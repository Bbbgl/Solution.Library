using DataAccessLayer.Library;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Library
{
    [DataContract]
    public class BookViewModel 
    {
        [DataMember]
        public int BookId { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]

        public string AuthorName { get; set; }
        [DataMember]
        public string AuthorSurname { get; set; }
        [DataMember]
        public string PublishingHouse { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public bool Avaiability { get; set; }

        //in realtà non lo uso questo sotto

        // dobvrebbe esserci una classe searchbookviewmodel che utilizza i 4 parametri che uso
        // con il metodo searchBook, pensaci. Adesso sto lavorando con due costruttori

        public BookViewModel(int id, string title, string authorName, string authorSurname,
            string publishingHouse, int quantity,bool avaiability)
        {
            this.BookId = id;
            this.Title = title;
            this.AuthorName = authorName;
            this.AuthorSurname = authorSurname;
            this.PublishingHouse = publishingHouse;
            this.Quantity = quantity;
            this.Avaiability = avaiability;
        }

        public BookViewModel(string title, string authorName, string authorSurname, string publishingHouse)
        {
            this.Title = title;
            this.AuthorName = authorName;
            this.AuthorSurname = authorSurname;
            this.PublishingHouse = publishingHouse;
        }

        public BookViewModel(string title, string authorName, string authorSurname, string publishingHouse, bool avaiability) : this(title, authorName, authorSurname, publishingHouse)
        {
            this.Avaiability = avaiability;
        }
    }
}

