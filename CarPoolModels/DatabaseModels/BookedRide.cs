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
        public string BookedFrom { get; set; }
        public string BookedTo { get; set; }

        public DateTime Date { get; set; }

        public int BookedSeats { get; set; }
        public int Time { get; set; }
        public int Price { get; set; }

        [ForeignKey("UserId")]
        public Guid RideTakenBy { get; set; }

        [ForeignKey("UserId")]
        public  Guid RideOfferedBy { get; set; }
    }
}
