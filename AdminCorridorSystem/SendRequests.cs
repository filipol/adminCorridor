using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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


        public static async Task<String> RunRequest(string typeOfReq, string apiEnd, List<String> reqBody)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://193.10.30.154/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = null;

                if (typeOfReq == "GET")
                {
                    // HTTP GET
                    response = await client.GetAsync(apiEnd);
                    if (response.IsSuccessStatusCode)
                    {
                        var res = await response.Content.ReadAsAsync<Users>();
                        Console.WriteLine(res);
                    }
                }

                else if (typeOfReq == "POST")
                {
                    // HTTP POST
                    //List<string> Attributes = reqBody;
                    //List<string> Values = reqBody;
                    var postBody = new Users() { UserName = "pelleS1111", Password = "Testee1234", Grant_type = "password" };
                    response = await client.PostAsJsonAsync("Token", postBody);
                    var content = await response.Content.ReadAsStringAsync();
                    return content;
                    if (response.IsSuccessStatusCode)
                    {
                        // Get the URI of the created resource.
                        //Uri gizmoUrl = response.Headers.Location;
                        Console.WriteLine(response);
                    }
                }
                else if (typeOfReq == "PUT")
                {
                    // HTTP PUT
                    var putBody = 80;   // Update price
                    response = await client.PutAsJsonAsync("Put", putBody);
                }
                else if (typeOfReq == "DELETE")
                {
                    // HTTP DELETE
                    response = await client.DeleteAsync("Delete");
                }
                return null;
            }
        }
    }
}