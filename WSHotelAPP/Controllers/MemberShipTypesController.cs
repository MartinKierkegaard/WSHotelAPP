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
    public class MemberShipTypesController : ApiController
    {
        private HotelContext db = new HotelContext();

        // GET: api/MemberShipTypes
        public IQueryable<MemberShipType> GetMemberShipType()
        {
            return db.MemberShipType;
        }

        // GET: api/MemberShipTypes/5
        [ResponseType(typeof(MemberShipType))]
        public IHttpActionResult GetMemberShipType(int id)
        {
            MemberShipType memberShipType = db.MemberShipType.Find(id);
            if (memberShipType == null)
            {
                return NotFound();
            }

            return Ok(memberShipType);
        }

        // PUT: api/MemberShipTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMemberShipType(int id, MemberShipType memberShipType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != memberShipType.GuestRating)
            {
                return BadRequest();
            }

            db.Entry(memberShipType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberShipTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MemberShipTypes
        [ResponseType(typeof(MemberShipType))]
        public IHttpActionResult PostMemberShipType(MemberShipType memberShipType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MemberShipType.Add(memberShipType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MemberShipTypeExists(memberShipType.GuestRating))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = memberShipType.GuestRating }, memberShipType);
        }

        // DELETE: api/MemberShipTypes/5
        [ResponseType(typeof(MemberShipType))]
        public IHttpActionResult DeleteMemberShipType(int id)
        {
            MemberShipType memberShipType = db.MemberShipType.Find(id);
            if (memberShipType == null)
            {
                return NotFound();
            }

            db.MemberShipType.Remove(memberShipType);
            db.SaveChanges();

            return Ok(memberShipType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MemberShipTypeExists(int id)
        {
            return db.MemberShipType.Count(e => e.GuestRating == id) > 0;
        }
    }
}