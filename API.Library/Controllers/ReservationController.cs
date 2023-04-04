using BusinessLogic.Library;
using BusinessLogic.Library.ViewModels;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Library.Controllers
{
    public class ReservationController : ApiController
    {
        public static LibraryBusinessLogic lbl = new LibraryBusinessLogic();
        // GET: api/Reservation
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Reservation/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Reservation
        public void Post([FromBody]string value)
        {
        }

        [HttpPost]
        [Route("api/Reservation/BookReturn")]
        public ReservationResult BookReturn([FromBody] BookToReturnDTO bookDTO)
        {
            return lbl.BookReturn(bookDTO.BookID, bookDTO.UserID);
        }

        [HttpPost]
        [Route("api/Reservation/BookReserve")]
        public ReservationResult ReserveBookPROVA([FromBody] BookToReserveDTO bookDTO)
        {
            return lbl.ReserveBookPROVA(bookDTO.BookID, bookDTO.UserID);
        }

        [HttpPost]
        [Route("api/Reservation/ReservationHistory")]
        public List<ReservationViewModel> GetReservationHistory([FromBody] ReservationHistoryDTO reservationHistoryDTO)
        {
            var reservationStatus = new ReservationStatus(reservationHistoryDTO.ReservationStatus?.Status);
            return lbl.GetReservationHistory(reservationHistoryDTO.BookID, reservationHistoryDTO.UserID, reservationStatus);
        }

        // PUT: api/Reservation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Reservation/5
        public void Delete(int id)
        {
        }
    }
}
