using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using AdminCorridorSystem.Models;
using System.Diagnostics;

namespace AdminCorridorSystem
{
    public class SendRequests
    {
        static void Main()
        {

        }


        public static async Task<string> RunRequest(string typeOfReq, string apiEnd, FormUrlEncodedContent body)
        {
            string baseURL = "http://193.10.30.154/DeveloperAPI/api/";

            if (typeOfReq == "GET")
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        var response = await client.GetAsync(baseURL + apiEnd);

                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var stringResponse = await response.Content.ReadAsStringAsync();
                            return stringResponse;
                        }
                        else
                        {
                            return "ERROR";
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        return null;
                    }
                }
                
            }

            else if (typeOfReq == "POST")
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        var response = await client.PostAsync(baseURL + apiEnd, body);

                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var stringResponse = await response.Content.ReadAsStringAsync();
                            return stringResponse;
                        }
                        else
                        {
                            return "ERROR";
                        }
                    }
                    catch (OperationCanceledException) 
                    {
                        return null;
                    }
                }
                
            }

            else
            {
                return null;
            }

            return null;
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://193.10.30.154/api/");
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    HttpResponseMessage response = null;

            //    if (typeOfReq == "GET")
            //    {
            //        // HTTP GET
            //        response = await client.GetAsync(apiEnd);
            //        if (response.IsSuccessStatusCode)
            //        {
            //            var res = await response.Content.ReadAsAsync<Users>();
            //            Console.WriteLine(res);
            //        }
            //    }

            //    else if (typeOfReq == "POST")
            //    {
            //        // HTTP POST
            //        //List<string> Attributes = reqBody;
            //        //List<string> Values = reqBody;
            //        var postBody = new Users() { UserName = "pelleS1111", Password = "Testee1234", Grant_type = "password" };
            //        response = await client.PostAsJsonAsync("Token", postBody);
            //        var content = await response.Content.ReadAsStringAsync();
            //        return content;
            //        if (response.IsSuccessStatusCode)
            //        {
            //            // Get the URI of the created resource.
            //            //Uri gizmoUrl = response.Headers.Location;
            //            Console.WriteLine(response);
            //        }
            //    }
            //    else if (typeOfReq == "PUT")
            //    {
            //        // HTTP PUT
            //        var putBody = 80;   // Update price
            //        response = await client.PutAsJsonAsync("Put", putBody);
            //    }
            //    else if (typeOfReq == "DELETE")
            //    {
            //        // HTTP DELETE
            //        response = await client.DeleteAsync("Delete");
            //    }
            //    return null;
            //}
        }
    }
}