using Model.Library;
using Newtonsoft.Json;
using Proxy.Library.ServiceViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Library
{
    public class API_UserProxy : IUserProxy
    {
        public User Login(LoginServiceViewModel lvm)
        {
            
            StringContent content = new StringContent(JsonConvert.SerializeObject(lvm),Encoding.UTF8,"application/json");
            //questo sopra è strano, perchè ho inserito il formato encoding.utf, sennò non leggeva la stringa json
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/API.Library/api/User/");
// scrivo qui. 


            var response = client.PostAsync($"Login", content).Result;

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = response.Content.ReadAsStringAsync().Result;
                var user = JsonConvert.DeserializeObject<User>(jsonContent);
                return user;
            }
            else
            {

                throw new NotImplementedException();
            }

        }


        public async Task<User> LoginAsync(LoginServiceViewModel lvm)
        {
            //var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:44392/API.Library/api/User/");
            //httpWebRequest.ContentType = "login";
            //httpWebRequest.Method = "POST";

            //var stremWriter = new StreamWriter(httpWebRequest.GetRequestStream());

            //stremWriter.Write(JsonConvert.SerializeObject(lvm));

            ////using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            ////{
            ////    string json = "{\"user\":\"test\"," +
            ////                  "\"password\":\"bla\"}";

            ////    streamWriter.Write(json);
            ////}

            //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //var streamReader = new StreamReader(httpResponse.GetResponseStream());
            ////{
            //   var result = streamReader.ReadToEnd();
            //}

            //var serializedLVM = JsonConvert.SerializeObject(lvm);

            StringContent content = new StringContent(JsonConvert.SerializeObject(lvm));
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44392/api/User/");


            var response = await client.PostAsync($"Login", content);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = response.ToString();
                var user = JsonConvert.DeserializeObject<User>(jsonContent);
                return user;
            }
            else
            {

                throw new NotImplementedException();
            }

        }


    }
}
 


