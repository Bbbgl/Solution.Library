using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library
{
    public class UserMenu : IMenu
    {
        public void Show() => Console.WriteLine("Menu:\n" +
                    "1-Ricerca di un libro\n" +
                    "2-Prenotazione di un libro\n" +
                    "3-Restituzione di un libro\n" +
                    "4-Visualizzazione Storico Prenotazioni\n" +
                    "5-Uscita dal gestionale");


    }
}
