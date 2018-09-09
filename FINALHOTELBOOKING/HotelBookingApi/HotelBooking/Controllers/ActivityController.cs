using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelBooking.Models;
using DataAccess;
using Newtonsoft.Json.Linq;

namespace HotelBooking.Controllers
{
    public class ActivityController : ApiController
    {
        BookingDBEntities entity = new BookingDBEntities();
        [HttpGet]
        public IEnumerable<Activity> GetCar()
        {
            return entity.Activities.ToList();
        }

        [HttpPut]
        public void PutValues(Setters item)
        {
            
                if (item.type == "booked")
                {

                    entity.Activities.Find(item.id).IsBooked = "1";
                    entity.SaveChanges();
                }
                else
                {
                    entity.Activities.Find(item.id).IsSaved = "1";
                    entity.SaveChanges();
                }
            

        }

        [HttpPost]
        public void PostCar([FromBody]JObject x)
        {
            entity.Activities.Add(x.ToObject<Activity>());
            entity.SaveChanges();
        }
    }
}
