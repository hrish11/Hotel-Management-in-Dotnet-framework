using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSEntityLayer
{
    public class BookingDetails
    {
        public string BookingID { get; set; }

        public string RoomID { get; set; }

        public string UserID { get; set; }

        public DateTime BookedFromDate { get; set; }

        public DateTime BookedToDate { get; set; }

        public int NoOfAdults { get; set; }

        public int NoOfChildren { get; set; }

        public int BookingAmount { get; set; }

    }
}
