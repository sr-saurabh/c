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
    public class Stoppage
    {
        [NotNull]
        [Required]
        [Key] public int StoppageId { get; set; }

        public int StoppageNo { get; set; }

        public int LocationId { get; set; }
        public Location Locations { get; set; }

        //[ForeignKey("OfferedRideId")]
        public  Guid OfferedRideId { get; set; }
        public OfferedRide OfferedRides { get; set; }
    }
}
