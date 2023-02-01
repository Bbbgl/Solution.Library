using Model.Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DataAccessLayer.Library
{
   
   public class BookDAO:IBookDAO
    {
        //public IBookDAO bookDAO;
        //public BookDAO(IBookDAO bookDAO)
        //{
        //    this.bookDAO = bookDAO;
        //}

        public const string path = "C:\\Users\\federico.babbini\\Desktop\\OOP\\ReadXmlCsharp\\Database.xml";
        public void Create(Book book)
        {

            //prova con LINQ
            var xDoc = XDocument.Load(path);
            var count = xDoc.Descendants("Book").Count();
            var newBook = new XElement("Book");
            newBook.SetAttributeValue("BookId", count++.ToString());
            newBook.SetAttributeValue("Title", book.Title);
            
            
            newBook.SetAttributeValue("AuthorName", book.AuthorName);
            newBook.SetAttributeValue("AuthorSurname", book.AuthorSurname);
            newBook.SetAttributeValue("Publisher", book.PublishingHouse);
            newBook.SetAttributeValue("Quantity",book.Quantity.ToString()); 

            xDoc.Root.Element("Books").Add(newBook);
            xDoc.Save("C:\\Users\\federico.babbini\\Desktop\\OOP\\ReadXmlCsharp\\Database.xml");


            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load("C:\\Users\\federico.babbini\\Desktop\\OOP\\ReadXmlCsharp\\Database.xml");

            //XmlNodeList bookNodes = xmlDoc.SelectNodes("//Library/Books/Book");
            //bookNodes.lastChild.Attributes["BookId"].Value = count++.ToString;

            //XmlNode bookNode = xmlDoc.SelectSingleNode("//Library/Books");
            //XmlElement newBookNode = xmlDoc.CreateElement("Book", null);
            //newBookNode.SetAttribute("BookId", Count++.ToString());
            //newBookNode.SetAttribute("Title", book.Title);
            //newBookNode.SetAttribute("AuthorName", book.AuthorName);
            //newBookNode.SetAttribute("AuthorSurname", book.AuthorSurname);
            //newBookNode.SetAttribute("Publisher", book.PublishingHouse);
            //newBookNode.SetAttribute("Quantity", book.Quantity.ToString());
            //bookNode.AppendChild(newBookNode);
            //xmlDoc.Save("C:\\Users\\federico.babbini\\Desktop\\OOP\\ReadXmlCsharp\\Database.xml");

        }

        public List<Book> Read()
        {
            XmlDocument xmlDoc = new XmlDocument();
            // c'è anche XDocument
            xmlDoc.Load("C:\\Users\\federico.babbini\\Desktop\\OOP\\ReadXmlCsharp\\Database.xml");
            XmlNodeList bookNodes = xmlDoc.SelectNodes("//Library/Books/Book");
            var bookList = new List<Book>();
            foreach (XmlNode bookNode in bookNodes)
            {
                var bookIdDB = bookNode.Attributes["BookId"].Value;
                var titleDB = bookNode.Attributes["Title"];
                var authorNameDB = bookNode.Attributes["AuthorName"];
                var authorSurnameDB = bookNode.Attributes["AuthorSurname"];
                var publisherDB = bookNode.Attributes["Publisher"];
                var quantityDB = bookNode.Attributes["Quantity"].Value;
                //int quantityDBtoInt;
                //try
                //{
                //    quantityDBtoInt = Convert.ToInt32(quantityDB);
                   
                //}catch (Exception e)
                //{
                //    quantityDBtoInt = 0;
                //}
                var book = new Book(Int32.Parse(bookIdDB),titleDB.Value, authorNameDB.Value, authorSurnameDB.Value,
                    publisherDB.Value, Int32.Parse(quantityDB));
                bookList.Add(book);


            }
            
            

            return bookList;
        }

        

        public void Update(Book book,int id_book)
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("C:\\Users\\federico.babbini\\Desktop\\OOP\\ReadXmlCsharp\\Database.xml");
            XmlNodeList bookNodes = xmlDoc.SelectNodes("//Library/Books/Book");

            bookNodes[id_book].Attributes["Title"].Value = book.Title;
            bookNodes[id_book].Attributes["AuthorName"].Value = book.AuthorName;
            bookNodes[id_book].Attributes["AuthorSurname"].Value = book.AuthorSurname;
            bookNodes[id_book].Attributes["Publisher"].Value = book.PublishingHouse;
            bookNodes[id_book].Attributes["Quantity"].Value = book.Quantity.ToString();
            //for(int i = 0; i < bookNodes.Count; i++) {
            //    if (bookNodes[i].Attributes["Title"].Value == book.Title)
            //    {
            //        Console.WriteLine("il libro è già presente");//forse non deve stare qui
            //        bookNodes[i].Attributes["Quantity"].Value = book.Quantity.ToString();
            //        Console.WriteLine("quantità aggiornata");//forse non deve stare qui
            //        break;
            //    }


            //}

            xmlDoc.Save("C:\\Users\\federico.babbini\\Desktop\\OOP\\ReadXmlCsharp\\Database.xml");

            

        }

        public void UpdateIds (int id_book)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("C:\\Users\\federico.babbini\\Desktop\\OOP\\ReadXmlCsharp\\Database.xml");
            XmlNodeList bookNodes = xmlDoc.SelectNodes("//Library/Books/Book");

            var librosel = bookNodes[id_book];
            var count = 0;
            foreach(XmlNode bookNode in bookNodes)
            {
                bookNode.Attributes["BookId"].Value = count++.ToString();
            }
            xmlDoc.Save("C:\\Users\\federico.babbini\\Desktop\\OOP\\ReadXmlCsharp\\Database.xml");

        }

        public void Delete (int id_book)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("C:\\Users\\federico.babbini\\Desktop\\OOP\\ReadXmlCsharp\\Database.xml");
            XmlNodeList bookNodes = xmlDoc.SelectNodes("//Library/Books/Book");
            
            bookNodes[id_book].ParentNode.RemoveChild(bookNodes[id_book]);//così si elimina proprio la riga

            

            

            //var bookNode = xmlDoc.SelectSingleNode("//Library/Books");
            //for(var i = id_book; i< bookNodes.Count; i++) { 
            //bookNode.ChildNodes[i].Attributes["BookId"].Value= (i-1).ToString();

            //}

            xmlDoc.Save("C:\\Users\\federico.babbini\\Desktop\\OOP\\ReadXmlCsharp\\Database.xml");
        }
    }
}
