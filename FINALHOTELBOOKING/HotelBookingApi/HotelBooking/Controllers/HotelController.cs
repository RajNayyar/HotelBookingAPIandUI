using DataAccess;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelBooking.Models;
using HotelBooking.Markups;
namespace HotelBooking.Controllers
{
    public class HotelController : ApiController
    {
        BookingDBEntities1 entity = new BookingDBEntities1();
        Hotel HotelInventory = new Hotel();
        [HttpGet]
        public IEnumerable<Hotel> GetHotel()
        {
            IEnumerable<Hotel> hotels = entity.Hotels.ToList();
            IMarkup markup = new HotelStrategy();
            foreach (Hotel hotel in hotels)
            {
                hotel.Price = markup.GetMarkup(hotel.Price);
            }
            return hotels;
        }

        [HttpPut]
        public void PutValues(Setters item)
        {
            
                if (item.type == "Booked")
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



