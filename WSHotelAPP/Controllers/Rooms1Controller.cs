using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WSHotelAPP;

namespace WSHotelAPP.Controllers
{
    public class Rooms1Controller : ApiController
    {
        private HotelContext db = new HotelContext();

        // GET: api/Rooms1
        public IQueryable<Room> GetRoom()
        {
            return db.Room;
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoomExists(int id)
        {
            return db.Room.Count(e => e.Room_No == id) > 0;
        }
    }
}