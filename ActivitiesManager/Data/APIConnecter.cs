using ActivitiesManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ActivitiesManager.Data
{
    public class APIConnecter : IApiConnection
    {
        private readonly string _url;

        public APIConnecter()
        {
            _url =@"https://localhost:44362/api/todolist/";
        }
        private void ConsoleLog(string action,object status)
        {
            Console.WriteLine("DT: " + DateTime.Now.ToString() + " | Action: "+ action + " | Status Code: " + status);
        }
        public async Task DeleteAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(_url + id))
                {
                    ConsoleLog("DELETE", response.StatusCode);
                   
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            
        }

        public async Task<object> Get(int? id)
        {
            string apiResponse = string.Empty;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_url + id.ToString()))
                {
                    ConsoleLog("GET", response.StatusCode);
                    
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        apiResponse = await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        return response.StatusCode.ToString();
                    }
                    
                }
            }
            return apiResponse;
        }

        public async Task<object> Get()
        {
            string apiResponse = string.Empty;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_url))
                {
                    ConsoleLog("GET", response.StatusCode);

                    apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return apiResponse;
        }

        public int Patch(object obj)
        {
            throw new NotImplementedException();
        }

        public async Task<object> Post(object obj)
        {
            string apiResponse = string.Empty;
            //TodoItem receivedTodoItem = new TodoItem();
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.PostAsync(_url, (HttpContent)obj))
                {
                    ConsoleLog("POST", response.StatusCode);

                    apiResponse = await response.Content.ReadAsStringAsync();
                    
                }
            }
            return apiResponse;
        }

        public async Task Put(int id, HttpContent obj)
        {
            using (var httpClient = new HttpClient())
            {
                
                //httpClient.DefaultRequestHeaders.
                using (var response = await httpClient.PutAsync(_url + id.ToString(), obj))
                {
                    ConsoleLog("PUT", response.StatusCode);

                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
        }
    }
}
