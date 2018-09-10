using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Markups
{
    public class ActivityStrategy:IMarkup
    {
        public int GetMarkup(int fare)
        {
            return (fare + 20);
        }
    }
}