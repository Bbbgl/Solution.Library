using BusinessLogic.Library.ViewModels;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLogic.Library
{
    //ma non è meglio separare tutte ste responsabilità? Come fatto qui,
    //dovrei creare una classe che implementa tutti questi metodi,
    //se invece facessi una classe per metodo? ES. una classe login, una classe add book, ecc...



    public interface ILibraryBusinessLogic
    {

        // FORSE C'é DA CAMBIARE TUTTI I PARAMETRI DA BOOK A BVM
        //da controlare il login
        User Login(LoginViewModel lvm); //prendi user da UserDAO e verifica

        void AddBook(Book book);

        List<Book> SearchBook(Book book);
        // sotto metti come paramentro searchbookviewmodel
        List<BookViewModel> SearchBookWithAvailabilityInfos(Book book); //uguale al book ma senza quantità(?)
        BookViewModel SearchBookWithAvailabilityInfos2(Book book); //uguale al book ma senza quantità(?)

        void UpdateBook(int bookId, Book bookWithNewValues);// perchè devo passare un oggetto book, non posso passare solo le stringhe che mi servono?

        void DeleteBook(Book book); //ricalcolare tutti gli id, sovrascriverli
        //CHIAMALA deletebyID e passa ID nel DAO. Posso fare una ricerca dell'id nel delete o filtrare tutto escludendo l'id
        // l'id non è noto all'admin, sul documento c'è scritto di inserire tutta l'anagrafica


        //User GetUserByUserName(string userName);!!!!<---------- fatto con il mapper

        ReservationResult ReserveBookPROVA(int bookId, int userId);
        void ReserveBook(int bookId, int userId);

        ReservationResult BookReturn(int bookId, int userId);

        List<ReservationViewModel> GetReservationHistory(int? bookId, int? userId, ReservationStatus? reservationStatus);

       // List<ReservationViewModel> GetReservationHistorySQL(int? bookId, int? userId, ReservationStatus? reservationStatus);
    }
}
