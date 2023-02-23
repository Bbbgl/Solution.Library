using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library
{
    public class AdminMenu : IMenu
    {
        public void Show() => Console.WriteLine("Menù:\n" +
                    " 1- Creazione di un libro. " +
                "\n 2- Modifica di un libro \n" +
                " 3-Cancellazione di un libro\n" +
                "4-Ricerca di un libro\n" +
                "5-Prenotazione di un libro\n" +
                "6-Restituzione di un libro\n" +
                "7-Visualizzazione Storico Prenotazioni\n" +
                "8-Uscita dal gestionale");


    }
}
