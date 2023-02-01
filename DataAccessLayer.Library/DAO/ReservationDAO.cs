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
    public class ReservationDAO : IReservationDAO
    {
        public const string path = "C:\\Users\\federico.babbini\\Desktop\\Database.xml";


        public void Create(Book book, User user)
        {
            
            //prova con LINQ
            var xDoc = XDocument.Load(path);
            var count = xDoc.Descendants("Reservation").Count();
            var newRes = new XElement("Reservation");
            newRes.SetAttributeValue("ReservationId", count++.ToString());
            newRes.SetAttributeValue("BookId", book.BookId.ToString());


            newRes.SetAttributeValue("UserId", user.UserId.ToString());
            newRes.SetAttributeValue("StartDate", (DateTime.Now).ToString());
            newRes.SetAttributeValue("EndDate", ((DateTime.Now).AddDays(30)).ToString());

            xDoc.Root.Element("Reservations").Add(newRes);
            xDoc.Save(path);


        }

        public List<Reservation> Read()
        {
            var userDAO = new UserDAO();
            var bookDAO = new BookDAO();
            var userList = userDAO.Read();
            var bookList = bookDAO.Read();  //CAMBIASTACOSA
            

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList resNodes = xmlDoc.SelectNodes("//Library/Reservations/Reservation");
            var reservationList = new List<Reservation>();
            
            foreach (XmlNode resNode in resNodes)
            {
                // TODO : inserisci anche id e role in user constructor, pensa a come fare
                // per tradurre una stringa in un enum
                // posso usare anche elementi (invece che attributi come sotto), nella reservation ad esempio ha senso usare elementi,
                // perchè ci sono elementi con attributi
                var resIdDB = Int32.Parse(resNode.Attributes["ReservationId"].Value);
                var bookIdDB = Int32.Parse(resNode.Attributes["BookId"].Value);
                var userIdDB = Int32.Parse(resNode.Attributes["UserId"].Value);
                var startDateDB = DateTime.Parse(resNode.Attributes["StartDate"].Value);
                var endDateDB = DateTime.Parse(resNode.Attributes["EndDate"].Value);


                //ar endDateDB = startDateDB.AddDays(30);
                // gli id degli users iniziano da 1 e non da zero, quindi devo decrementare
                var reservation = new Reservation(resIdDB, userList[--userIdDB], bookList[bookIdDB], startDateDB,endDateDB);
                reservationList.Add(reservation);
            }

            return reservationList;
        }

        public void Update(Reservation reservation, int reservation_id)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList resNodes = xmlDoc.SelectNodes("//Library/Reservations/Reservation");

            // resNodes[reservation_id].Attributes["ReservationId"].Value = reservation.ResId.ToString(); non serve aggiornare l'id tanto è lo stesso
            //resNodes[reservation_id].Attributes["AuthorName"].Value = book.AuthorName;
            //resNodes[reservation_id].Attributes["AuthorSurname"].Value = book.AuthorSurname;
            //resNodes[reservation_id].Attributes["Publisher"].Value = book.PublishingHouse;

            // si aggiorna solo EndDate ??
            var newTime = DateTime.Now;
            resNodes[reservation_id].Attributes["EndDate"].Value = newTime.ToString();
            //DateTime.Parse(resNodes[reservation_id].Attributes["EndDate"].Value = reservation.EndDate;


            

            xmlDoc.Save(path);
        }
    }
}
