using DataAccess;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelBooking.Models;
namespace HotelBooking.Controllers
{
    public class HotelController : ApiController
    {
        BookingDBEntities entity = new BookingDBEntities();
        Hotel HotelInventory = new Hotel();
        [HttpGet]
        public IEnumerable<Hotel> GetHotel()
        {
            return entity.Hotels.ToList();
        }

        [HttpPut]
        public void PutValues(Setters item)
        {
            
                if (item.type == "booked")
                {

                    entity.Hotels.Find(item.id).IsBooked = "1";
                    entity.SaveChanges();
                }
                else
                {
                    entity.Hotels.Find(item.id).IsSaved = "1";
                    entity.SaveChanges();
                }
            
        }


        [HttpPost]
        public void Insertion([FromBody]Hotel hotel)
        {
          
                entity.Hotels.Add(hotel);
                entity.SaveChanges();
            

        }

    }
}



