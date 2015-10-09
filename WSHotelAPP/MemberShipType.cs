namespace WSHotelAPP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberShipType")]
    public partial class MemberShipType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GuestRating { get; set; }

        public int Discount { get; set; }

        public int SumBookings { get; set; }
    }
}
