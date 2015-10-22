using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WSHotelAPP;

namespace ConsoleHotelApp1
{
    class Program
    {
        private static void Main(string[] args)
        {


            const string serverUrl = "http://localhost.fiddler:5000";

            var handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;


            //using (var client = new HttpClient(handler))
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("Api/Hotels").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var hotels = response.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;

                        foreach (var hotel in hotels)
                        {
                            Console.WriteLine(hotel.ToString());
                        }
                        Console.ReadLine();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        var MyNewHotel = new Hotel()
            {
                Hotel_No = 991,
                Address = "Fiddlerhotel 1",
                Name = "Fiddler hotel",
                Rating="",
                HotelUrl="fiddlerhotel.com",
                Room = new List<Room>()
            };

            string json = JsonConvert.SerializeObject(MyNewHotel);
            Console.WriteLine("json file : " + json);

            //string json2 = "{"+"\"Hotel_No\":1" + ",\"Name\":\"FiddlerHotel\"" + ",\"Address\":\"My Address\"" +"}" ;

            string json3 = "{\"Hotel_No\":448,\"Name\":\"FiddlerHotel1\",\"Address\":\"Fiddler Road 1\",\"HotelUrl\":null,\"Rating\":\"*****\",\"Room\":null}";

            string jsonClean = json3.Replace("\\", "");

            Console.WriteLine("json CLEAN  file : " +  jsonClean);

            //StreamReader sr = new StreamReader(json2,System.Text.Encoding.UTF8);

            StringContent MyContent = new StringContent(json,System.Text.Encoding.UTF8,"application/json");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
               
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    //var response = client.PostAsJsonAsync("Api/Hotels", MyContent).Result;
                    var response = client.PostAsync("Api/Hotels", MyContent ).Result;

                    var r = response.Content;

                    Console.WriteLine("response : " + response.StatusCode);

                  
                }
                catch (Exception)
                {
                    throw;
                }
            }





                Console.ReadLine();
            }










            //const string serverUrl = "http://localhost:5000";
            //var handler = new HttpClientHandler();
            //handler.UseDefaultCredentials = true;

            //using (var client = new HttpClient(handler))
            //{
            //    client.BaseAddress = new Uri(serverUrl);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(
            //        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //    try
            //    {
            //        var response = client.GetAsync("api/Hotels").Result;

            //        if (response.IsSuccessStatusCode)
            //        {
            //            var hotels = response.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;


            //            foreach (var hotel in hotels)
            //            {
            //                Console.WriteLine(hotel.ToString());
            //            }

            //            Console.ReadLine();
            //        }


            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }


            //}
        //}

    }
}
