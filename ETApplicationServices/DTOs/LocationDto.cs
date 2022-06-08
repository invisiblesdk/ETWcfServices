using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETApplicationServices.DTOs
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public double TravelRating { get; set; }

        public bool Validate()
        {
            return !String.IsNullOrEmpty(Name) && Name.Length <= 25 && TravelRating > 0.0 && TravelRating <= 10.0;
        }
    }
}
