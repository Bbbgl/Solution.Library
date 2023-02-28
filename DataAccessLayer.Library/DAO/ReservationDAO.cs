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
    public class ReservationDAO : IReservationDAO
    {
        public const string path = "C:\\Users\\federico.babbini\\Desktop\\Database.xml";


        public void Create(Book book, User user)
        {

            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"CreateReservation";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //SqlParameter p1 = new SqlParameter("BookId", System.Data.SqlDbType.Int);
                    //p1.Value = numBooks++;
                    //cmd.Parameters.Add(p1);
                    cmd.Parameters.AddWithValue("@ReservationId", this.Read().Last().ResId + 1);
                    cmd.Parameters.AddWithValue("@UserId", user.UserId);
                    cmd.Parameters.AddWithValue("@BookId", book.BookId);
                    cmd.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@EndDate", DateTime.Now.AddDays(30));

                    cmd.ExecuteNonQuery();

                }
                conn.Close();




                //prova con LINQ
                //     var xDoc = XDocument.Load(path);
                // var count = xDoc.Descendants("Reservation").Count();
                // var newRes = new XElement("Reservation");
                // newRes.SetAttributeValue("ReservationId", count++.ToString());
                // newRes.SetAttributeValue("BookId", book.BookId.ToString());


                // newRes.SetAttributeValue("UserId", user.UserId.ToString());
                // newRes.SetAttributeValue("StartDate", (DateTime.Now).ToString());
                // newRes.SetAttributeValue("EndDate", ((DateTime.Now).AddDays(30)).ToString());
                //// newRes.SetAttributeValue("EndDate", null);
                // xDoc.Root.Element("Reservations").Add(newRes);
                // xDoc.Save(path);

            }
        }

        public void Delete(int reservationId)
        {
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DeleteReservation";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                  cmd.Parameters.AddWithValue(@"ReservationId",reservationId);



                    cmd.ExecuteNonQuery();

                }
                conn.Close();
            }
;
        }

        public List<Reservation> Read()
        {
            var userDAO = new UserDAO();
            var bookDAO = new BookDAO();
            var userList = userDAO.Read();
            var bookList = bookDAO.Read();  //CAMBIASTACOSA

            var reservationList = new List<Reservation>();

            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * FROM Reservations ";


                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var reservationId = Int32.Parse(reader["ReservationId"].ToString());
                        var bookId = Int32.Parse(reader["BookId"].ToString());
                        var userId = Int32.Parse(reader["UserId"].ToString());
                        var startDate = DateTime.Parse(reader["StartDate"].ToString());
                        var endDate = DateTime.Parse(reader["EndDate"].ToString());
                        //var provaDebug = bookList.Where(b => b.BookId == bookId).First();


                        var res = new Reservation(reservationId,userList[--userId],bookList.Where(b=>b.BookId==bookId).First(), startDate, endDate);
                        reservationList.Add(res);
                    }

                }




            //    XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load(path);
            //XmlNodeList resNodes = xmlDoc.SelectNodes("//Library/Reservations/Reservation");
            //var reservationList = new List<Reservation>();
            
            //foreach (XmlNode resNode in resNodes)
            //{
            //    // TODO : inserisci anche id e role in user constructor, pensa a come fare
            //    // per tradurre una stringa in un enum
            //    // posso usare anche elementi (invece che attributi come sotto), nella reservation ad esempio ha senso usare elementi,
            //    // perchè ci sono elementi con attributi
            //    var resIdDB = Int32.Parse(resNode.Attributes["ReservationId"].Value);
            //    var bookIdDB = Int32.Parse(resNode.Attributes["BookId"].Value);
            //    var userIdDB = Int32.Parse(resNode.Attributes["UserId"].Value);
            //    var startDateDB = DateTime.Parse(resNode.Attributes["StartDate"].Value);
            //    var endDateDB = DateTime.Parse(resNode.Attributes["EndDate"].Value);


            //    //ar endDateDB = startDateDB.AddDays(30);
            //    // gli id degli users iniziano da 1 e non da zero, quindi devo decrementare
            //    var reservation = new Reservation(resIdDB, userList[--userIdDB], bookList[bookIdDB], startDateDB,endDateDB);
            //    reservationList.Add(reservation);
            }

            return reservationList;
        }

        public void Update(Reservation reservation, int reservation_id)
        {

            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UpdateReservation";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(@"ReservationId", reservation_id);
                    cmd.Parameters.AddWithValue(@"EndDate",DateTime.Now);   

                    cmd.ExecuteNonQuery();

                }
                conn.Close();
            }







            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load(path);
            //XmlNodeList resNodes = xmlDoc.SelectNodes("//Library/Reservations/Reservation");

            //// resNodes[reservation_id].Attributes["ReservationId"].Value = reservation.ResId.ToString(); non serve aggiornare l'id tanto è lo stesso
            ////resNodes[reservation_id].Attributes["AuthorName"].Value = book.AuthorName;
            ////resNodes[reservation_id].Attributes["AuthorSurname"].Value = book.AuthorSurname;
            ////resNodes[reservation_id].Attributes["Publisher"].Value = book.PublishingHouse;

            //// si aggiorna solo EndDate ??
            //var newTime = DateTime.Now;
            //resNodes[reservation_id].Attributes["EndDate"].Value = newTime.ToString();
            ////DateTime.Parse(resNodes[reservation_id].Attributes["EndDate"].Value = reservation.EndDate;




            //xmlDoc.Save(path);
        }
    }
}
