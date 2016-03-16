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
    public static class HotelFacade
    {

        const string serverUrl = "http://localhost.fiddler:5000";

        public static async Task<List<Hotel>> GetHotelsAsync()
        {
           // const string ServerUrl = "http://localhost:5001";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response =  await client.GetAsync("api/Hotels");

                    if (response.IsSuccessStatusCode)
                    {
                        //var hotelList = response.Content.ReadAsAsync<List<Hotel>>().Result;
                        var hotelList =  JsonConvert.DeserializeObject<List<Hotel>>( await response.Content.ReadAsStringAsync());
                        return hotelList;
                    }

                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }

        public static async Task CreateHotel(Hotel hotel)
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
                var response = await client.PostAsync(posturl,content);


                if (response.IsSuccessStatusCode)
                {
                   await new MessageDialog("OK Hotel saved").ShowAsync();
                }
                else
                {
                   await new MessageDialog("Not OK !" + response.StatusCode.ToString()).ShowAsync();
                }
            }

        }

        public static async Task DeleteHotel(Hotel hotel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    string deleteUrl = "api/hotels/" + hotel.Hotel_No;
                    var response = await client.DeleteAsync(deleteUrl);
                    if (response.IsSuccessStatusCode)
                    {
                       await new MessageDialog("OK, the" + hotel.Name + "is deleted ").ShowAsync();
                    }
                    else
                    {
                       await new MessageDialog("Not OK !" + response.StatusCode.ToString()).ShowAsync();
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
