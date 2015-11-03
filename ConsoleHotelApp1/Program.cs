using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using WinHttp;
using WSHotelAPP;

namespace ConsoleHotelApp1
{
    class Program
    {
        private static void Main(string[] args)
        {

            const string serverUrl = "http://localhost.fiddler:5000";


            var hotellist = new List<Hotel>();
            var roomlist = new List<Room>();
         //   Console.ReadLine( );

            Hotel aNewHotel = new Hotel()
            {
                Hotel_No = 345,Name = "Big Hotel",Address = "MyWay 1",Rating = "*"
            };

            string jsonaNewHotel = aNewHotel.SerializerJson();
            Console.WriteLine(jsonaNewHotel);


            Hotel deserializeHotel = Hotel.DeserializeJson(jsonaNewHotel);

            Console.WriteLine(deserializeHotel.ToString());



            Console.ReadLine();
            ////GetAHotel
            //Hotel selectedHotel = GetAHotel(serverUrl,3);
            //Console.WriteLine("After WebserviceCall");
            //Console.WriteLine(selectedHotel);

            

            //Exercise1
            //int selectHotel = 3;
            //Excercise1(serverUrl, selectHotel);           

            //Exercise 2
            //Exercise2(serverUrl, hotellist);

            //Exercise 3
            //3.Select(HTTP Get) all hotels and all of them located in roskilde should be put into a list of hotels using LINQ
            //Exercise3(serverUrl, hotellist, roomlist);

            //Excercise4
            //Exercise4(serverUrl);

            //Exercise5
            //Exercise5(serverUrl);

            //Exercise6
            //int deleteHotelNo = 1002;
            //DeleteHotel(serverUrl, deleteHotelNo);

            //Exercise7
            //int hotelNo = 4;
            //int roomNo = 300;
            // exercise7(hotelNo, roomNo, serverUrl);

            //Exercise 8
            //8) Update all hotels in roskilde increase the price of a single 
            //room with 20 %, show the prices before and after the update
          //  Exercise8(serverUrl, hotellist, roomlist);





            Console.ReadLine();


            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(serverUrl);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    try
            //    {
            //        var response =  client.GetAsync("Api/Hotels").Result;

            //        if (response.IsSuccessStatusCode)
            //        {
            //var hotels = response.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;

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

            //var MyNewHotel = new Hotel()
            //{
            //    Hotel_No = 1005,
            //    Address = "Fiddlerhotel 1",
            //    Name = "Fiddler hotel",
            //    Rating = "",
            //    HotelUrl = "fiddlerhotel.com",
            //    Room = new List<Room>() 
            //};


            //string json = JsonConvert.SerializeObject(MyNewHotel);
            //Console.WriteLine("json file : " + json);
            //StringContent MyContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(serverUrl);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    try
            //    {
            //        var response = client.PostAsync("Api/Hotels", MyContent).Result;
            //        var r = response.Content;
            //        Console.WriteLine("response : " + response.StatusCode);
            //    }
            //    catch (Exception)
            //    {
            //        throw;
            //    }
            //}

            //int changeHotelNo = 1005;

            //var ChangeMyNewHotel = new Hotel()
            //{
            //    Hotel_No = changeHotelNo,
            //    Address = "Fiddlerhotel update",
            //    Name = "Fiddler hotel",
            //    Rating = "*",
            //    HotelUrl = "fiddlerhotel.com",
            //    Room = new List<Room>()
            //};

            //string jsonC = JsonConvert.SerializeObject(ChangeMyNewHotel);

            //StringContent content = new StringContent(jsonC, System.Text.Encoding.UTF8, "application/json");

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(serverUrl);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    try
            //    {
            //        //var response = client.PostAsJsonAsync("Api/Hotels", MyContent).Result;
            //        var response = client.PutAsync("Api/Hotels/" + changeHotelNo, content).Result;

            //        var r = response.Content;
            //        Console.WriteLine("response : " + response.StatusCode);
            //    }
            //    catch (Exception)
            //    {
            //        throw;
            //    }
            //}


            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(serverUrl);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    try
            //    {
            //        //var response = client.PostAsJsonAsync("Api/Hotels", MyContent).Result;
            //        var response = client.DeleteAsync("Api/Hotels/" + 1005).Result;

            //        var r = response.Content;
            //        Console.WriteLine("response : " + response.StatusCode);
            //    }
            //    catch (Exception)
            //    {
            //        throw;
            //    }
            //}



            //Console.ReadLine();
        }

        private static void exercise7(int hotelNo, int roomNo, string serverUrl)
        {
            Console.WriteLine("7) Insert a new Room on Hotel number 4");

            //First we create the new room object
            Room myNewRoom = new Room()
            {
                Hotel_No = hotelNo,
                Price = 250.0,
                Room_No = roomNo,
                Types = "S"
            };
            CreateRoom(serverUrl, myNewRoom);
        }

        private static void CreateRoom(string serverUrl, Room myNewRoom)
        {
            string roomJson = JsonConvert.SerializeObject(myNewRoom);

          
            StringContent content = new StringContent(roomJson, Encoding.UTF8, "application/json");

            //Create a Http post
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string posturl = "api/rooms";
                var response = client.PostAsync(posturl, content).Result;
                Console.WriteLine("Post async " + posturl);
                Console.WriteLine("Status code " + response.StatusCode);
            }
        }

        private static void DeleteHotel(string serverUrl, int deleteHotelNo)
        {
            Console.WriteLine("Exercise6");
            Console.WriteLine(" 6) Delete(HTTP Delete) the Hotel number 200");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string deleteUrl = "api/hotels/" + deleteHotelNo;
                    var response = client.DeleteAsync(deleteUrl).Result;

                    Console.WriteLine("Delete Async " + deleteUrl);
                    Console.WriteLine(response.StatusCode);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Succcesfull delete");
                    }
                    else
                    {
                        Console.WriteLine("Someting went wrong, hotel not deleted");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// method to get a specific hotel
        /// </summary>
        /// <param name="serverUrl"></param>
        /// <param name="selectHotelNo"></param>
        /// <returns></returns>

        /// <summary>
        /// method to get a specific hotel
        /// </summary>
        /// <param name="serverUrl"></param>
        /// <param name="selectHotelNo"></param>
        /// <returns></returns>
        private static Hotel GetHotel(string serverUrl, int selectHotelNo)
        {
            var hotel = new Hotel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string urlString = "api/hotels/" + selectHotelNo;
                var response = client.GetAsync(urlString).Result;
                Console.WriteLine("GetAsync : " + urlString);
                Console.WriteLine("Status code : " + response.StatusCode);
                if (response.IsSuccessStatusCode)
                {
                     hotel = response.Content.ReadAsAsync<Hotel>().Result;
                    Console.WriteLine("hotel : " + hotel.ToString());
                }
            }
            return hotel;
        }

        private static void Excercise1(string serverUrl, int selectHotel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string urlString = "api/hotels/" + selectHotel;
                var response = client.GetAsync(urlString).Result;
                Console.WriteLine("GetAsync : " + urlString);
                Console.WriteLine("Status code : " + response.StatusCode);
                if (response.IsSuccessStatusCode)
                {
                    var hotel = response.Content.ReadAsAsync<Hotel>().Result;
                    Console.WriteLine("hotel : " + hotel.ToString());
                }
            }
        }


        private static Hotel GetAHotel(string serverUrl, int selectHotel)
        {
            var selectedHotel = new Hotel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string urlString = "api/hotels/" + selectHotel;
                var response = client.GetAsync(urlString).Result;
                Console.WriteLine("GetAsync : " + urlString);
                Console.WriteLine("Status code : " + response.StatusCode);
                if (response.IsSuccessStatusCode)
                {
                    var hotelJson = response.Content.ReadAsStringAsync().Result;
                    selectedHotel = JsonConvert.DeserializeObject<Hotel>(hotelJson);
                    Console.WriteLine(hotelJson);
                    Console.WriteLine();
                    //Console.WriteLine("hotel : " + hotel.ToString());
                }
            }
            return selectedHotel;
        }


        private static void Exercise5(string serverUrl)
        {
            Console.WriteLine("Exercise 5");
            Console.WriteLine("Insert (HTTP Post) a new hotel fx number 200");

            int myNewHotelNo = 2000;
            //First we create the new hotel object
            var myNewHotel = new Hotel()
            {
                Hotel_No = myNewHotelNo,
                Address = "Fiddlerhotel 1",
                Name = "Fiddler hotel",
                Rating = "***",
                HotelUrl = "fiddlerhotel.com",
                Room = new List<Room>()
            };

            //The we need to serialize it
            string newHoteljson = JsonConvert.SerializeObject(myNewHotel);

            //Create the content we will send in the Http post request 
            var content = new StringContent(newHoteljson, Encoding.UTF8, "application/json");


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.PostAsync("api/hotels", content).Result;
                Console.WriteLine("PostAsync");
                Console.WriteLine("Status code " + response.StatusCode);

                if (response.IsSuccessStatusCode)
                {
                    //Success , Now we can get the hotel by a Http post
                    var responseHotel = client.GetAsync("api/hotels/" + myNewHotelNo).Result;
                    Console.WriteLine("GetAsync");
                    Console.WriteLine("Status code " + response.StatusCode);

                    if (responseHotel.IsSuccessStatusCode)
                    {
                        var hotel200 = responseHotel.Content.ReadAsAsync<Hotel>().Result;
                        Console.WriteLine(hotel200.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Update (HTTP Put) hotel number 3, change the name of the hotel. 
        /// You have to create a new Hotel Object with the data and then use this object 
        /// when you create your content string. 
        /// </summary>
        /// <param name="serverUrl"></param>
        private static void Exercise4(string serverUrl)
        {
            var hotel3 = new Hotel();
            int hotelno = 3;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));

                //First thing to do is to get the hotel number 3 into my hotel3 variable by a http Get request
                var hotelResponse = client.GetAsync("api/hotels/" + hotelno).Result;

                if (hotelResponse.IsSuccessStatusCode)
                {
                    hotel3 = hotelResponse.Content.ReadAsAsync<Hotel>().Result;
                    Console.WriteLine(hotel3.ToString());
                }

                //Now change the name and address of the hotel3
                hotel3.Name = "Great Hotel";
                hotel3.Address = "Great Hotel Road 1";

                //we have to serialize the hotel3 object into json format
                string jsonHotel3 = JsonConvert.SerializeObject(hotel3);

                //Create the content we want to send with the Http put request
                StringContent content = new StringContent(jsonHotel3, Encoding.UTF8, "Application/json");

                //Using a Http Put Request we can update the Hotel number 3
                var updateResponse = client.PutAsync("api/hotels/" + hotelno, content).Result;
                Console.WriteLine("status code : " + updateResponse.StatusCode);
            }
        }

        private static void Exercise2(string serverUrl, List<Hotel> hotellist, List<Room> roomlist)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/hotels").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var hotels = response.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;

                        var roskildeHotels = hotels.Where(x => x.Address.Contains("Roskilde")).ToList();

                        hotellist.AddRange(roskildeHotels);

                        Console.WriteLine("Hotels in roskilde");
                        foreach (var rh in roskildeHotels)
                        {
                            Console.WriteLine(rh.ToString());
                        }

                        var roomresponse = client.GetAsync("api/rooms").Result;

                        if (roomresponse.IsSuccessStatusCode)
                        {
                            var rooms = roomresponse.Content.ReadAsAsync<IEnumerable<Room>>().Result;

                            var roskildeRoom = from r in rooms
                                join h in hotellist on r.Hotel_No equals h.Hotel_No
                                select r;

                            roomlist.AddRange(roskildeRoom.OrderBy(x => x.Hotel_No).ToList());

                            foreach (var rr in roomlist)
                            {
                                Console.WriteLine(rr.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("response error status code: " + response.StatusCode);
                        }
                    }
                    else
                    {
                        Console.WriteLine("response error status code: " + response.StatusCode);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Solution exercise 1 
        /// </summary>
        /// <param name="serverUrl"></param>
        /// <param name="hotellist"></param>
        private static void Exercise3(string serverUrl, List<Hotel> hotellist)
        {

            Console.WriteLine("1.Select(HTTP Get) hotel number 3 and put it into an List of type Hotel(List<Hotel>)");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    var response = client.GetAsync("Api/Hotels/3").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var hotel = response.Content.ReadAsAsync<Hotel>().Result;

                        hotellist.Add(hotel);

                        Console.ReadLine();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private static void Exercise8(string serverUrl, List<Hotel> hotellist, List<Room> roomlist)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/hotels").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var hotels = response.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;

                        var roskildeHotels = hotels.Where(x => x.Address.Contains("Roskilde")).ToList();

                        hotellist.AddRange(roskildeHotels);

                        Console.WriteLine("Hotels in roskilde");
                        foreach (var rh in roskildeHotels)
                        {
                            Console.WriteLine(rh.ToString());
                        }

                        var roomresponse = client.GetAsync("api/rooms").Result;

                        if (roomresponse.IsSuccessStatusCode)
                        {
                            var rooms = roomresponse.Content.ReadAsAsync<IEnumerable<Room>>().Result;

                            var roskildeRoom = from r in rooms
                                join h in hotellist on r.Hotel_No equals h.Hotel_No
                                where r.Types == "S"
                                select new Room()
                                {
                                    Hotel_No = r.Hotel_No,
                                    Price = r.Price,
                                    Room_No = r.Room_No,
                                    Types = r.Types
                                };

                            roomlist.AddRange(roskildeRoom.OrderBy(x => x.Hotel_No).ToList());

                            Console.WriteLine("Will update som many rooms: " + roomlist.Count);

                            foreach (var room in roomlist)
                            {
                                try
                                {
                                    Console.WriteLine("Room Price before : "+room.ToString() );
                                    //increase 20%
                                    room.Price *= 1.2;
                                    string roomJson = JsonConvert.SerializeObject(room);
                                    StringContent content = new StringContent(roomJson, Encoding.UTF8, "application/json");
                                    string putRoom = "api/rooms/" + room.Room_No;
                                    var roomResponse = client.PutAsync(putRoom, content).Result;
                                    Console.WriteLine("StatusCode " + roomResponse.StatusCode);
                                    Console.WriteLine(room.ToString());
                                    if (response.IsSuccessStatusCode)
                                    {
                                        Console.WriteLine("Succes: updated the room no: "+ room.Room_No );
                                        Console.WriteLine("Room price after "+ room.Price);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Upps something went wrong for room no: "+room.Room_No);
                                    }
                                }
                                catch (Exception)
                                {
                                    
                                    throw;
                                }

                               
                            }
                        }
                        else
                        {
                            Console.WriteLine("response error status code: " + response.StatusCode);
                        }
                    }
                    else
                    {
                        Console.WriteLine("response error status code: " + response.StatusCode);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
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
