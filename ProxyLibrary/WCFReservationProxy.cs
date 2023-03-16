
using Proxy.Library.SOAPLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Library
{
    public class WCFReservationProxy //: IReservationProxy
    {
        public static ServiceLibraryClient slc = new ServiceLibraryClient();
        public ReservationResult BookReturn(int bookId, int userId)
        {
            return slc.BookReturn(bookId, userId);
        }

        public List<ReservationViewModel> GetReservationHistory(int? bookId, int? userId, ReservationStatus? reservationStatus)
        {
            return slc.GetReservationHistory(bookId, userId, reservationStatus);
        }

        public void ReserveBook(int bookId, int userId)
        {
            slc.ReserveBook(bookId, userId);
        }

        public ReservationResult ReserveBookPROVA(int bookId, int userId)
        {
            return slc.ReserveBookPROVA(bookId, userId);
        }
    }
}
