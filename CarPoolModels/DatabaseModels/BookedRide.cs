using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolModels.Models
{
    public class BookedRide
    {
        [NotNull]
        [Required]
        [Key]
        public Guid BookingId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }

        public int BookedSeats { get; set; }

        public Guid OfferedRideId { get; set; }
        public OfferedRide OfferedRide { get; set; }

        [ForeignKey("RideTakenBy")]
        public Guid? UserId { get; set; }
        public User User { get; set; }

        //public OfferedRide OfferedRide { get; set; }
        //public User User { get; set; }




    }
}
