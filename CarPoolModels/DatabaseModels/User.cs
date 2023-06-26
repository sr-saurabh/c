using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarPoolModels.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public string UserName { get; set; }
        public string Image { get; set; }
        public ICollection<OfferedRide> OfferedRides { get; set; }
        public ICollection<BookedRide> BookedRides { get; set; }

    }
}
