using Model.Library;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

//•	Book rappresenta il libro in biblioteca ed è caratterizzato da:
//o BookId numero intero univoco
//o	Title stringa
//o	AuthorName stringa
//o	AuthorSurname stringa
//o	PublishingHouse stringa
//o	Quantity  intero positivo (NB. Rappresenta solamente il numero globale di copie in biblioteca,
//NON il numero di copie disponibili al netto delle prenotazioni attive)



namespace Model.Library
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public int BookId { get; set; }
        [DataMember] public string Title { get; set; }
        [DataMember] public string AuthorName { get; set; }
        [DataMember]
        public string AuthorSurname { get; set; }
        [DataMember]
        public string PublishingHouse { get; set; }
        [DataMember]
        public int Quantity { get; set; }

        public Book (int id,string title, string authorName, string authorSurname, string publishingHouse, int quantity)
        {
            this.BookId = id;
            this.Title = title;
            this.AuthorName = authorName;
            this.AuthorSurname = authorSurname;
            this.PublishingHouse = publishingHouse;
            this.Quantity = quantity;
        }
        public Book() { }

        // posso inserire un altro costruttore senza id e quanrtity?


    }
    public class UpdateBookDTO
    {
        public int Id { get; set; }
        public Book Book { get; set; }

        public UpdateBookDTO(int id, Book book)
        {
            Id = id;
            Book = book;
        }   
        public UpdateBookDTO() { }
    }

    public class BookViewModelDTO
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string PublishingHouse { get; set; }

        public BookViewModelDTO(string title, string authorName, string authorSurname, string publishingHouse)
        {
            Title = title;
            AuthorName = authorName;
            AuthorSurname = authorSurname;
            PublishingHouse = publishingHouse;
        }
    }


    public class AWConnection : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }


}

