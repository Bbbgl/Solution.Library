using Model.Library;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using static DataAccessLayer.Library.DBConnection;

namespace DataAccessLayer.Library
{
   
   public class BookDAO:IBookDAO
    {
        

        public const string path = "C:\\Users\\federico.babbini\\Desktop\\Database.xml";
        public void Create(Book book)
        {

            // INIZIO PROVA CON SQL

            var numBooks = this.Read().Count;// problema!!! L'id deve essere deciso in sql,
                                             // se cancello un libro si sballa la conta, provo a mettere l'id non come variabile della storeproc


            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"CreateBook";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //SqlParameter p1 = new SqlParameter("BookId", System.Data.SqlDbType.Int);
                    //p1.Value = numBooks++;
                    //cmd.Parameters.Add(p1);

                    SqlParameter p2 = new SqlParameter("Title", System.Data.SqlDbType.NVarChar, 100);
                    p2.Value = book.Title;
                    cmd.Parameters.Add(p2);

                    SqlParameter p3 = new SqlParameter("AuthorName", System.Data.SqlDbType.NVarChar, 100);
                    p3.Value = book.AuthorName;
                    cmd.Parameters.Add(p3);

                    SqlParameter p4 = new SqlParameter("AuthorSurname", System.Data.SqlDbType.NVarChar, 100);
                    p4.Value = book.AuthorSurname;
                    cmd.Parameters.Add(p4);

                    SqlParameter p5 = new SqlParameter("Publisher", System.Data.SqlDbType.NVarChar, 100);
                    p5.Value = book.PublishingHouse;
                    cmd.Parameters.Add(p5);

                    SqlParameter p6 = new SqlParameter("Quantity", System.Data.SqlDbType.Int);
                    p6.Value = book.Quantity;
                    cmd.Parameters.Add(p6);

                    cmd.ExecuteNonQuery();

                }
                //conn.Close();
            }


         }           //------------XML-------------------
                     //        var xDoc = XDocument.Load(path);
                     //var count = xDoc.Descendants("Book").Count();
                     //var newBook = new XElement("Book");
                     //newBook.SetAttributeValue("BookId", count++.ToString());
                     //newBook.SetAttributeValue("Title", book.Title);


        //newBook.SetAttributeValue("AuthorName", book.AuthorName);
        //newBook.SetAttributeValue("AuthorSurname", book.AuthorSurname);
        //newBook.SetAttributeValue("Publisher", book.PublishingHouse);
        //newBook.SetAttributeValue("Quantity",book.Quantity.ToString()); 

        //xDoc.Root.Element("Books").Add(newBook);
        //xDoc.Save(path);


        public List<Book> Read()
        {
            var bookList = new List<Book>();
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * FROM Books";


                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var bookId = Int32.Parse(reader["BookId"].ToString());
                        var bookTitle = reader["Title"].ToString();
                        var bookAuthorName = reader["AuthorName"].ToString();
                        var bookAuthorSurame = reader["AuthorSurname"].ToString();
                        var bookPublisher = reader["Publisher"].ToString();
                        var bookQuantity = Int32.Parse(reader["Quantity"].ToString());


                        Book b = new Book(bookId, bookTitle, bookAuthorName,
                            bookAuthorSurame, bookPublisher, bookQuantity);
                        bookList.Add(b);
                    }

                }
                //conn.Close();
            }
            return bookList;
        }














        //    XmlDocument xmlDoc = new XmlDocument();
        //    // c'è anche XDocument
        //    xmlDoc.Load(path);
        //    XmlNodeList bookNodes = xmlDoc.SelectNodes("//Library/Books/Book");
        //    var bookList = new List<Book>();
        //    foreach (XmlNode bookNode in bookNodes)
        //    {
        //        var bookIdDB = bookNode.Attributes["BookId"].Value;
        //        var titleDB = bookNode.Attributes["Title"];
        //        var authorNameDB = bookNode.Attributes["AuthorName"];
        //        var authorSurnameDB = bookNode.Attributes["AuthorSurname"];
        //        var publisherDB = bookNode.Attributes["Publisher"];
        //        var quantityDB = bookNode.Attributes["Quantity"].Value;
        //        //int quantityDBtoInt;
        //        //try
        //        //{
        //        //    quantityDBtoInt = Convert.ToInt32(quantityDB);

        //        //}catch (Exception e)
        //        //{
        //        //    quantityDBtoInt = 0;
        //        //}
        //        var book = new Book(Int32.Parse(bookIdDB),titleDB.Value, authorNameDB.Value, authorSurnameDB.Value,
        //            publisherDB.Value, Int32.Parse(quantityDB));
        //        bookList.Add(book);


        //    }



        //    return bookList;
        //}



        public void Update(Book book, int id_book)// l'id si puà tranquillamente togliere
        {
            using(SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UpdateBook";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("BookId", System.Data.SqlDbType.Int);
                    p1.Value = id_book;
                    cmd.Parameters.Add(p1);

                    SqlParameter p2 = new SqlParameter("Title", System.Data.SqlDbType.NVarChar, 100);
                    p2.Value = book.Title;
                    cmd.Parameters.Add(p2);

                    SqlParameter p3 = new SqlParameter("AuthorName", System.Data.SqlDbType.NVarChar, 100);
                    p3.Value = book.AuthorName;
                    cmd.Parameters.Add(p3);

                    SqlParameter p4 = new SqlParameter("AuthorSurname", System.Data.SqlDbType.NVarChar, 100);
                    p4.Value = book.AuthorSurname;
                    cmd.Parameters.Add(p4);

                    SqlParameter p5 = new SqlParameter("Publisher", System.Data.SqlDbType.NVarChar, 100);
                    p5.Value = book.PublishingHouse;
                    cmd.Parameters.Add(p5);

                    SqlParameter p6 = new SqlParameter("Quantity", System.Data.SqlDbType.Int);
                    p6.Value = book.Quantity;
                    cmd.Parameters.Add(p6);

                    cmd.ExecuteNonQuery();

                }
                conn.Close();
            }








            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load(path);
            //XmlNodeList bookNodes = xmlDoc.SelectNodes("//Library/Books/Book");

            //bookNodes[id_book].Attributes["Title"].Value = book.Title;
            //bookNodes[id_book].Attributes["AuthorName"].Value = book.AuthorName;
            //bookNodes[id_book].Attributes["AuthorSurname"].Value = book.AuthorSurname;
            //bookNodes[id_book].Attributes["Publisher"].Value = book.PublishingHouse;
            //var quantity = Int32.Parse(bookNodes[id_book].Attributes["Quantity"].Value);
            //bookNodes[id_book].Attributes["Quantity"].Value = (quantity + book.Quantity).ToString();
            //for(int i = 0; i < bookNodes.Count; i++) {
            //    if (bookNodes[i].Attributes["Title"].Value == book.Title)
            //    {
            //        Console.WriteLine("il libro è già presente");//forse non deve stare qui
            //        bookNodes[i].Attributes["Quantity"].Value = book.Quantity.ToString();
            //        Console.WriteLine("quantità aggiornata");//forse non deve stare qui
            //        break;
            //    }


            //}

            //xmlDoc.Save(path);

        }

        public void UpdateIds (int id_book)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList bookNodes = xmlDoc.SelectNodes("//Library/Books/Book");

            var librosel = bookNodes[id_book];
            var count = 0;
            foreach(XmlNode bookNode in bookNodes)
            {
                bookNode.Attributes["BookId"].Value = count++.ToString();
            }
            xmlDoc.Save(path);

        }

        public void Delete (int id_book)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList bookNodes = xmlDoc.SelectNodes("//Library/Books/Book");
            
            bookNodes[id_book].ParentNode.RemoveChild(bookNodes[id_book]);//così si elimina proprio la riga

            

            

            //var bookNode = xmlDoc.SelectSingleNode("//Library/Books");
            //for(var i = id_book; i< bookNodes.Count; i++) { 
            //bookNode.ChildNodes[i].Attributes["BookId"].Value= (i-1).ToString();

            //}

            xmlDoc.Save(path);
        }
    }
}
