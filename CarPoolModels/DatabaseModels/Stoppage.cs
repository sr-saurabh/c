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

        //[Display(Name = "Location")]
        //public virtual int LocationId { get; set; }


        //[ForeignKey("LocationId")]
        //public virtual Location Locations { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }


        [Display(Name = "OfferedRide")]
        public virtual Guid OfferedRideId { get; set; }


        [ForeignKey("OfferedRideId")]
        public virtual OfferedRide OfferedRides { get; set; }
    }
}
