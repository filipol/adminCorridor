using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using AdminCorridorSystem.Models;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace AdminCorridorSystem
{
    public class SendRequests
    {
        static void Main()
        {

        }


        public static async Task<string> RunRequest(string typeOfReq, string apiEnd, FormUrlEncodedContent body)
        {

            var baseURL = new Uri("http://193.10.30.154/DeveloperAPI/api/");

            if (typeOfReq == "GET")
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        if (HttpContext.Current.Request.Cookies != null && client.DefaultRequestHeaders.Authorization == null)
                        {
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Request.Cookies["AccessToken"].Value);
                        }
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
            else if (typeOfReq == "DELETE")
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        if (HttpContext.Current.Request.Cookies != null && client.DefaultRequestHeaders.Authorization == null)
                        {
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Request.Cookies["AccessToken"].Value);
                        }
                        var response = await client.DeleteAsync(baseURL + apiEnd);
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            return response.StatusCode.ToString();
                        }
                        else
                        {
                            return "ERROR";
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        return "ERROR";
                    }
                }
                    

            }
            else if (typeOfReq == "PUT")
            {
                using (var client = new HttpClient())
                {

                    if (HttpContext.Current.Request.Cookies != null && client.DefaultRequestHeaders.Authorization == null)
                    {
                        var test = HttpContext.Current.Request.Cookies["AccessToken"].Value;
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Request.Cookies["AccessToken"].Value);
                    }
                    try
                    {
                        var response = await client.PutAsync(baseURL + apiEnd, body);

                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var stringResponse = response.Content.ReadAsStringAsync();
                            return stringResponse.ToString();
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
                if (apiEnd == "Token")
                {
                    try
                    {
                        using (var client = new HttpClient())
                        {
                            var response = await client.PostAsync(baseURL + apiEnd, body);

                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                var stringResponse = response.Content.ReadAsStringAsync().Result;

                                var token = (JObject)JsonConvert.DeserializeObject(stringResponse);
                                var tok = token.First.First.Value<string>();
                                HttpContext.Current.Response.Cookies.Set(new HttpCookie("AccessToken")
                                {
                                    Value = tok,
                                    HttpOnly = true,

                                });

                                return stringResponse.ToString();
                            }
                            else
                            {
                                return "ERROR";
                            }
                        }

                    }
                    catch (OperationCanceledException)
                    {
                        return null;
                    }
                }
                else
                {
                    using (var client = new HttpClient())
                    {

                        if (HttpContext.Current.Request.Cookies != null && client.DefaultRequestHeaders.Authorization == null)
                        {
                            var test = HttpContext.Current.Request.Cookies["AccessToken"].Value;
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Request.Cookies["AccessToken"].Value);
                        }
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
            }

            else
            {
                return null;
            }

        }
    }
}