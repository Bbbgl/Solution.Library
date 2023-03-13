using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // posso inserire un altro costruttore senza id e quanrtity?


    }

   
}

