using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02_EntityFrameworkCore.Classes
{
    public class Event
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int MaxAttendees { get; set; }

        // Organizer
        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; }

        // Internal tracking
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
    }
}
