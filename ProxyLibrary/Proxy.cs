
using Model.Library;
using Proxy.Library.ServiceViewModels;
using Proxy.Library.SOAPLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Library
{ // 3 interfacce una per entità user book reserv...

    

    public interface IBookProxy
    {
        void AddBook(AddingBookServiceViewModel bsvm);

        // List<Book> SearchBook(Book book);

        List<SearchingBookViewModel> SearchBookWithAvailabilityInfos(BookViewModel bvm);



        void UpdateBook(int bookId, Book bookWithNewValues);


        bool DeleteBook(BookViewModel bvm);
    }


    public interface IUserProxy 
    {
        User Login(LoginServiceViewModel lvm);
    }

    public interface IReservationProxy
    {
        ReservationResult ReserveBookPROVA(int bookId, int userId);
        void ReserveBook(int bookId, int userId);

        ReservationResult BookReturn(int bookId, int userId);

        List<ReservationViewModel> GetReservationHistory(int? bookId, int? userId, ReservationStatus? reservationStatus);

    }

}
