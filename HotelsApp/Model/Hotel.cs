using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace HotelsApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public  class Hotel  : BaseModel
    {
        public Hotel()
        {
            
        }

        public int Hotel_No { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string HotelUrl { get; set; }

        public string Rating { get; set; }


        /// <summary>
        /// Serialize this object to json format
        /// </summary>
        /// <returns></returns>
        public string SerializerJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Hotel DeserializeJson(string json)
        {
            Hotel item = JsonConvert.DeserializeObject<Hotel>(json);
            return item;
        }

        /// <summary>
        /// Get object as stringContent in json format and in encoding =UTF8 
        /// </summary>
        /// <returns></returns>
        public StringContent GetContentString()
        {
            return new StringContent(this.SerializerJson(), Encoding.UTF8, "ApplicationJson");
        }


        public override string ToString()
        {
            return $"Hotel_No: {Hotel_No}, Name: {Name}, Address: {Address}, HotelUrl: {HotelUrl}, Rating: {Rating}";
        }
    }
}
