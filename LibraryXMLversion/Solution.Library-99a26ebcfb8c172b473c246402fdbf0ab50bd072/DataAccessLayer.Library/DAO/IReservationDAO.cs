using Model.Library;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Library
{
//    •	Visualizzare lo storico delle prenotazioni:
//    questa ricerca può essere effettuata filtrando per Utente(Username) (solo admin)
//    e/o Libro(Anagrafica) e/o Stato Prenotazione(Attiva/Non Attiva).
//Le informazioni da mostrare sono:
//titolo del libro – nome utente – data di inizio prestito – data di fine prestito – info su stato prenotazione(attiva/non attiva)

    public interface IReservationDAO
    {
        List<Reservation> Read();//sarebbe get reservation

        void Create(Book book, User user);

        void Update(Reservation reservation, int reservation_id);
    }
}
