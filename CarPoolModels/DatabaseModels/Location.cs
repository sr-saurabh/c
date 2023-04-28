﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolModels.Models
{
    public class Location
    {
        [NotNull]
        [Required]
        [Key]
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public ICollection<Stoppage> Stoppage { get; set; }
    }

}
