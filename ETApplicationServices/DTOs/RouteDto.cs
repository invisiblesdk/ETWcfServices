using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETApplicationServices.DTOs
{
    public class RouteDto
    {
        public int Id { get; set; }
        public string RouteName { get; set; }
        public string RouteModeOfTravel { get; set; }
        public int TravelTimeMinutes { get; set; }
        public TravelAgencyDto Agency { get; set; }
        public int Price { get; set; }
        public int Distance { get; set; }
        public LocationDto StartingLocation { get; set; }
        public LocationDto EndLocation { get; set; }
    }
}
