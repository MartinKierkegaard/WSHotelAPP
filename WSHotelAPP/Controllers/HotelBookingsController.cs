using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace WSHotelAPP.Controllers
{
    public class HotelBookingsController : ApiController
    {

        private HotelContext db = new HotelContext();

        // GET: api/HotelBookings/5
        //[ResponseType(typeof(List<Room>))]
        public IQueryable<Room> GetRoom(int id)
        {
            //Hotel hotel = db.Hotel.Find(id);

            //var list = new List<Room>();

            var list = from r in db.Room
                       where r.Hotel_No == id && r.Types == "S"
                       select r;

            //    db.Room.Select(x => x.Hotel_No == id).ToList();
            //if (room == null)
            //{
            //    return NotFound();
            //}

            return list;
        }


    }
}