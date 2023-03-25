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
using static System.Net.WebRequestMethods;

namespace Proxy.Library
{
    public class API_BookProxy : IBookProxy
    {
        public string path = "http://localhost/API.Library/api/Book/";
        public void AddBook(AddingBookServiceViewModel bsvm)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(bsvm), Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/API.Library/api/Book/");

            var response = client.PostAsync($"CreateBook", content).Result;
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
            bool deleteCheck=false;
            var bvmDTO = new BookViewModelDTO(bvm.Title, bvm.AuthorName, bvm.AuthorSurname, bvm.PublishingHouse);
            var serializedBVM = JsonConvert.SerializeObject(bvmDTO);

            StringContent content = new StringContent((serializedBVM),Encoding.UTF8,"application/json");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/API.Library/api/Book/");
            var response = client.PostAsync($"DeleteBook", content).Result;
            if (response.IsSuccessStatusCode)
            { //.Result = deprecated 
                //ci sono metodi migliori per gestire l'async
                string jsonContent = response.Content.ReadAsStringAsync().Result;
                deleteCheck = JsonConvert.DeserializeObject<bool>(jsonContent);
            }
            else
            {

                // controlla l'eccezione
                
            }
            return deleteCheck;
        }

        public List<Book> ReadBooks()
        {
            var list = new List<Book>();
            

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(path);

            var response = client.GetAsync($"SearchBooks").Result;
            if (response.IsSuccessStatusCode)
            { //.Result = deprecated 
                //ci sono metodi migliori per gestire l'async
                string jsonContent = response.Content.ReadAsStringAsync().Result;

                list = JsonConvert.DeserializeObject<List<Book>>(jsonContent);
            }
            else
            {

                // controlla l'eccezione
            }
            return list;


        }
    

        public List<SearchingBookViewModel> SearchBookWithAvailabilityInfos(BookViewModel bvm)
        {
            var list = new List<SearchingBookViewModel>();
            var bvmDTO = new BookViewModelDTO(bvm.Title, bvm.AuthorName, bvm.AuthorSurname, bvm.PublishingHouse);
            StringContent content = new StringContent(JsonConvert.SerializeObject(bvmDTO), Encoding.UTF8, "application/json");


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(path);

            var response = client.PostAsync($"SearchBook", content).Result;
            if (response.IsSuccessStatusCode)
            { //.Result = deprecated 
                //ci sono metodi migliori per gestire l'async
                string jsonContent = response.Content.ReadAsStringAsync().Result;

                list = JsonConvert.DeserializeObject<List<SearchingBookViewModel>>(jsonContent);
            }
            else
            {

                // controlla l'eccezione
            }
            return list;
        

        }

    

        public void UpdateBook(int bookId, Book bookWithNewValues)
        {//DTO oggetti per contenere insieme l'insieme di dati che deve viaggiare verso un api (data transfer object)
         // dovrò fare una classe di tipo book con due libri
         // ( nel caso fosse necessario di passare due libri). Serve per fare come una classe per il json
         //struttura json con le sue proprietà


            var bookDTO = new UpdateBookDTO(bookId, bookWithNewValues);
            StringContent content = new StringContent(JsonConvert.SerializeObject(bookDTO), Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(path);

            var response = client.PostAsync($"UpdateBook", content).Result;
            if (response.IsSuccessStatusCode)
            { //.Result = deprecated 
                //ci sono metodi migliori per gestire l'async
                string jsonContent = response.Content.ReadAsStringAsync().Result;

              // qua che dovrei gestire??
            }
            else
            {

                // controlla l'eccezione
            }
            


        }
    }
}
