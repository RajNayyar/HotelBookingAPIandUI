using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelBooking.Models;
using DataAccess;
using Newtonsoft.Json.Linq;
using HotelBooking.Markups;

namespace HotelBooking.Controllers
{
    public class ActivityController : ApiController
    {
        BookingDBEntities1 entity = new BookingDBEntities1();
        [HttpGet]
        public IEnumerable<Activity> GetCar()
        {
            IEnumerable<Activity> Activitys = entity.Activities.ToList();
            IMarkup markup = new ActivityStrategy();
            foreach (Activity act in Activitys)
            {
                act.Price = markup.GetMarkup(act.Price);
            }
            return Activitys;
        }

        [HttpPut]
        public void PutValues(Setters item)
        {
            
                if (item.type == "Booked")
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
