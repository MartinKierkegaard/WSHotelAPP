using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace WSHotelAPP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hotel")]
    public partial class Hotel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hotel()
        {
            Room = new HashSet<Room>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Hotel_No { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string HotelUrl { get; set; }

        [StringLength(5)]
        public string Rating { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Room> Room { get; set; }

        public override string ToString()
        {
            return $"Hotel_No: {Hotel_No}, Name: {Name}, Address: {Address}, HotelUrl: {HotelUrl}, Rating: {Rating}";
        }

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
            Hotel hotel = JsonConvert.DeserializeObject<Hotel>(json);
            return hotel;
        }

        /// <summary>
        /// Get object as stringContent in json format and in encoding =UTF8 
        /// </summary>
        /// <returns></returns>
        public StringContent GetContentString()
        {
            return new StringContent(this.SerializerJson(),Encoding.UTF8,"Application/json");
        }

    }
}
