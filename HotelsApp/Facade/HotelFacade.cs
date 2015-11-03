using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using HotelsApp.Model;
using Newtonsoft.Json;


namespace HotelsApp.Facade
{
    public class HotelFacade
    {

        const string serverUrl = "http://localhost.fiddler:5000";

        public static List<Hotel> GetHotels()
        {
           // const string ServerUrl = "http://localhost:5001";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Hotels").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var hotelList = response.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;
                        return hotelList.ToList();
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }

        public void CreateHotel(Hotel hotel)
        {
            //Create a Http post
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string posturl = "api/hotels";
                var response = client.PostAsync(posturl, hotel.GetContentString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    new MessageDialog("OK").ShowAsync();
                }
                else
                {
                    new MessageDialog("Not OK !" +response.StatusCode.ToString() ).ShowAsync();
                }
            }

        }
    }
}
