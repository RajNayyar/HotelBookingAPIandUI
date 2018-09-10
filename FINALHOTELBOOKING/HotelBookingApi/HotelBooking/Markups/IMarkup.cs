using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Markups
{
    interface IMarkup
    {
        int GetMarkup(int fare);
    }
}
