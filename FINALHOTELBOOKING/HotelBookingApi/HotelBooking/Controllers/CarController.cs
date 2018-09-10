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
    public class CarController : ApiController
    {
        BookingDBEntities entity = new BookingDBEntities();
        Car CarInventory = new Car();
        [HttpGet]
        public IEnumerable<Car> GetCar()
        {
            return entity.Cars.ToList();
        }

        [HttpPut]
        public void PutValues(Setters item)
        {
            
                if (item.type == "booked")
                {

                    entity.Cars.Find(item.id).IsBooked = "1";
                    entity.SaveChanges();
                }
                else
                {
                    entity.Cars.Find(item.id).IsSaved = "1";
                    entity.SaveChanges();
                }
            

        }

        [HttpPost]
        
        public void PostCar([FromBody]JObject x)
        {
            entity.Cars.Add(x.ToObject<Car>());
            entity.SaveChanges();
        }
    }
}
