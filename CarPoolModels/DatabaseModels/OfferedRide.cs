using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarPoolModels.Models
{
    public class OfferedRide
    {
        public Guid OfferedRideId { get; set; }

        public string Source { get; set; }
        public string Destination { get; set; }

        public DateOnly Date { get; set; }

        public int TotalSeats { get; set; }

        public int AvailableSeats { get; set; }

        public int Time { get; set; }
        //public string Time { get; set; }
        public int Price { get; set; }


        //[Display(Name = "RideOfferedBy")]
        [ForeignKey("UserId")]
        public Guid? UserId { get; set; }
        public User User { get; set; }

        public ICollection<Stoppage> Stoppages{ get; set; }
        public ICollection<BookedRide> BookedRids { get; set; }
        //public User User { get; set; } 

    }
}
