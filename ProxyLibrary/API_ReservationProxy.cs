using Proxy.Library.SOAPLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Library
{
    internal class API_ReservationProxy : IReservationProxy
    {
        public ReservationResult BookReturn(int bookId, int userId)
        {
            throw new NotImplementedException();
        }

        public List<ReservationViewModel> GetReservationHistory(int? bookId, int? userId, ReservationStatus? reservationStatus)
        {
            throw new NotImplementedException();
        }

        public void ReserveBook(int bookId, int userId)
        {
            throw new NotImplementedException();
        }

        public ReservationResult ReserveBookPROVA(int bookId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
