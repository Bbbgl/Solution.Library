using Model.Library;
using Newtonsoft.Json;
using Proxy.Library.ServiceViewModels;
using Proxy.Library.SOAPLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Library
{
    public class API_BookProxy : IBookProxy
    {
        public void AddBook(AddingBookServiceViewModel bsvm)
        {
            var serializedBook = JsonConvert.SerializeObject(bsvm);

            StringContent content = new StringContent(serializedBook);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:44392/API.Library/api/");

            var response = client.PostAsync($"Book", content).Result;
            if (response.IsSuccessStatusCode)
            { //.Result = deprecated 
                //ci sono metodi migliori per gestire l'async
                string    jsonContent = response.Content.ReadAsStringAsync().Result; 
            }
            else { 
            
            // controlla l'eccezione
            }
              
            }

        public bool DeleteBook(BookViewModel bvm)
        {
            throw new NotImplementedException();
        }

        public List<SearchingBookViewModel> SearchBookWithAvailabilityInfos(BookViewModel bvm)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(int bookId, Book bookWithNewValues)
        {
            throw new NotImplementedException();
        }
    }
}
