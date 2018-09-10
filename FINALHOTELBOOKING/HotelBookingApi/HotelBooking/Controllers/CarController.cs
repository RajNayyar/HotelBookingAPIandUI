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
    public class CarController : ApiController
    {
        BookingDBEntities1 entity = new BookingDBEntities1();
        Car CarInventory = new Car();
        [HttpGet]
        public IEnumerable<Car> GetCar()
        {
            IEnumerable<Car> Cars = entity.Cars.ToList();
            IMarkup markup = new CarStrategy();
            foreach (Car car in Cars)
            {
                car.Price = markup.GetMarkup(car.Price);
            }
            return Cars;
        }

        [HttpPut]
        public void PutValues(Setters item)
        {
            
                if (item.type == "Booked")
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
