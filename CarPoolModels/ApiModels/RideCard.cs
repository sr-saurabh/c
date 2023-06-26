using CarPoolModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolModels.ApiModels
{
    public class RideCard
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateOnly Date { get; set;}
        public int Price { get; set;}
        public int Seats { get; set;}
        public int Time { get; set;}

    }
}
