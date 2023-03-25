using Model.Library;
using Newtonsoft.Json;
using Proxy.Library.SOAPLibrary;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Library
{


    public class API_ReservationProxy : IReservationProxy
    {
        public string path = "http://localhost/API.Library/api/Reservation/";
        public ReservationResult BookReturn(int bookId, int userId)
        {
            var bookDTO = new BookToReturnDTO(userId, bookId);
            StringContent content = new StringContent(JsonConvert.SerializeObject(bookDTO), Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(path);

            var response = client.PostAsync($"BookReturn", content).Result;
            if (response.IsSuccessStatusCode)
            { 
                string jsonContent = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<ReservationResult>(jsonContent);
            }
            else
            {

                throw new NotImplementedException();
            }

        }

    

    public List<ReservationViewModel> GetReservationHistory(int? bookId, int? userId, ReservationStatus? reservationStatus)
        {
            var list = new List<ReservationViewModel>();
            var reservationStatusDTO = new ReservationStatusDTO(reservationStatus?.Status);
            var reservationHistoryDTO = new ReservationHistoryDTO(userId, bookId, reservationStatusDTO);
            StringContent content = new StringContent(JsonConvert.SerializeObject(reservationHistoryDTO), Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(path);

            var response = client.PostAsync($"ReservationHistory", content).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonContent = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<ReservationViewModel>>(jsonContent);
            }
            else
            {

                throw new NotImplementedException();
            }
            return list;

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
