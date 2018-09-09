using DataAccess;
using HotelBooking.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelBooking.Controllers
{
    public class FlightController : ApiController
    {
        BookingDBEntities entity = new BookingDBEntities();
        [HttpGet]
        public IEnumerable<Flight> GetCar()
        {
            return entity.Flights.ToList();
        }

        [HttpPut]
        public void PutValues(Setters item)
        {
           
                if (item.type == "booked")
                {

                    entity.Flights.Find(item.id).IsBooked = "1";
                    entity.SaveChanges();
                }
                else
                {
                    entity.Flights.Find(item.id).IsSaved = "1";
                    entity.SaveChanges();
                }
            

        }

        [HttpPost]
        public void PostCar([FromBody]JObject x)
        {
            entity.Flights.Add(x.ToObject<Flight>());
            entity.SaveChanges();
        }
    }
}
