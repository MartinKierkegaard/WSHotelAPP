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

        public static async  Task<List<Hotel>> GetHotels()
        {
           // const string ServerUrl = "http://localhost:5001";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response =  client.GetAsync("api/Hotels").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        //var hotelList = response.Content.ReadAsAsync<List<Hotel>>().Result;
                        var hotelList =  JsonConvert.DeserializeObject<List<Hotel>>( response.Content.ReadAsStringAsync().Result);
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

                string json = JsonConvert.SerializeObject (hotel);

                StringContent content = new StringContent(json,Encoding.UTF8,"application/json");

                // var response = client.PostAsync(posturl, hotel.GetContentString()).Result;
                var response = client.PostAsync(posturl,content).Result;


                if (response.IsSuccessStatusCode)
                {
                    new MessageDialog("OK Hotel saved").ShowAsync();
                }
                else
                {
                    new MessageDialog("Not OK !" +response.StatusCode.ToString() ).ShowAsync();
                }
            }

        }

        public void DeleteHotel(Hotel hotel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    string deleteUrl = "api/hotels/" + hotel.Hotel_No;
                    var response = client.DeleteAsync(deleteUrl).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        new MessageDialog("OK, the" + hotel.Name + "is deleted ").ShowAsync();
                    }
                    else
                    {
                        new MessageDialog("Not OK !" + response.StatusCode.ToString()).ShowAsync();
                    }
                }
                catch (Exception e)
                {

                    new MessageDialog("Ups something went wrong" + e.Message);
                }
                
            }
        }
    }
}
