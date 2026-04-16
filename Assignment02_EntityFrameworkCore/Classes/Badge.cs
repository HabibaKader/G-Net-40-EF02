using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02_EntityFrameworkCore.Classes
{
    public class Badge
    {
        public int Id { get; set; }

        public string UniqueNumber { get; set; }

        public DateTime IssuedAt { get; set; }

        public string Tier { get; set; } // standard / VIP

        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; }
    }
}
