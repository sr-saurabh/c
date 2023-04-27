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

        public string OfferingFrom { get; set; }

        public string OfferingTo { get; set; }

        public DateTime OfferingDate { get; set; }

        public int TotalSeats { get; set; }

        public int AvailableSeats { get; set; }

        public int Time { get; set; }
        //public string Time { get; set; }
        public int Price { get; set; }


        //[ForeignKey("OfferedBy")]
        public Guid? OfferedBy { get; set; }
        public User Users { get; set; }

        //[Display(Name = "User")]
        //public virtual Guid? OfferedBy { get; set; }
        //[ForeignKey("OfferedBy")]
        //public virtual User Users { get; set; }


    }
}
