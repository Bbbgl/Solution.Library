using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//•	User rappresenta l’utente del sistema, ed è caratterizzato da:
//o UserId numero intero univoco
//o	Username stringa
//o	Password stringa
//o	Role, rappresentante il tipo di utenza (tipo consigliato: Enum)
//I Role previsti sono due: Amministratore ed Utilizzatore

namespace Model.Library
{



    public class User
    {


        public int UserId { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        //public eRole Role { get; set; } LAVORO CON LE STRINGHE (+ semplice, poi in caso cambio)
        public string Role { get; set; }
        public User(int id, string username, string password,string role)
        {
            this.UserId = id;
            this.Username = username;
            this.Password = password;
            this.Role = role;




        }

        //public enum eRole
        //{
        //    Amministratore,
        //    Utilizzatore
        //}
    }
}



