using DataAccess;
using HotelBooking.Markups;
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
        BookingDBEntities1 entity = new BookingDBEntities1();
        [HttpGet]
        public IEnumerable<Flight> GetCar()
        {
            IEnumerable<Flight> Flights = entity.Flights.ToList();
            IMarkup markup = new AirStrategy();
            foreach (Flight flight in Flights)
            {
                flight.Price = markup.GetMarkup(flight.Price);
            }
            return Flights;
        }

        [HttpPut]
        public void PutValues(Setters item)
        {
           
                if (item.type == "Booked")
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
