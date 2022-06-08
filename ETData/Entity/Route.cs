using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETData.Entity
{
    public class Route : BaseEntity
    {
        [Required]
        [MaxLength(25, ErrorMessage = "RouteName must be 25 characters or less")]
        public string RouteName { get; set; }

        [Required]
        [MaxLength(6, ErrorMessage = "RouteModeOfTravel must be 6 characters or less")]
        public string RouteModeOfTravel { get; set; }


        [Required]
        public int TravelTimeMinutes { get; set; }

        public int AgencyId { get; set; }
        public TravelAgency Agency { get; set; }

        [Required]
        public int Price { get; set; }
        [Required]
        public int DistanceKM { get; set; }
        public int StartingLocationId { get; set; }
        public Location StartingLocation { get; set; }
        public int EndLocationId { get; set; }
        public Location EndLocation { get; set; }

    }
}
