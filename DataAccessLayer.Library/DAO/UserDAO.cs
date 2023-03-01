using Model.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static DataAccessLayer.Library.DBConnection;
using static Model.Library.User;

namespace DataAccessLayer.Library
{
    public class UserDAO : IUserDAO
    {
        public const string path = "C:\\Users\\federico.babbini\\Desktop\\Database.xml";
        //•	Verificare i dati di login inseriti 
        public List<User> Read()
        {
            
            List<User> userList = new List<User>();
            // INIZIO PROVA CON SQL
                     
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * FROM Users";
                    

                    SqlDataReader reader = cmd.ExecuteReader();
                   while (reader.Read())
                    {
                        var userId = Int32.Parse(reader["UserId"].ToString());
                        var userRole = reader["Role"].ToString();
                        var userUsername = reader["Username"].ToString();
                        var userPassword = reader["Password"].ToString();

                 
                        User u = new User(userId, userUsername, userPassword, userRole);
                        userList.Add(u);    
                    }

                }
                conn.Close();
            }
            
            return userList;
            





            //    XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load(path);
            //XmlNodeList userNodes = xmlDoc.SelectNodes("//Library/Users/User");
            //var userList = new List<User>();
            //foreach(XmlNode userNode in userNodes)
            //{
            //    // TODO : inserisci anche id e role in user constructor, pensa a come fare
            //    // per tradurre una stringa in un enum
            //    // posso usare anche elementi (invece che attributi come sotto), nella reservation ad esempio ha senso usare elementi,
            //    // perchè ci sono elementi con attributi
            //    var UserIdDB = userNode.Attributes["UserId"].Value;
            //    var usernameDB = userNode.Attributes["Username"];
            //    var passwordDB = userNode.Attributes["Password"];
            //    var roleDB = userNode.Attributes["Role"];
            //    var user = new User (Int32.Parse(UserIdDB),usernameDB.Value , passwordDB.Value, roleDB.Value );
            //    userList.Add(user);
            //}

            //return userList;




            //dati-- oggetti,  legge dati restituisce listuser
        }

        //public UserDAO()
        //{
        //    Read();
        //}

        


        

        //public eRole Rolecheck(string role)
        //{
        //    if (role == "Admin")
        //    {
        //        return eRole.Amministratore;
        //    }else
        //    {
        //        return eRole.Utilizzatore;
        //    }
        //}



    }
}
