using ETApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETWebsite.ViewModel
{
    public class RouteVM
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "RouteName must be 25 characters or less")]
        [Display(Name ="Route name")]
        public string RouteName { get; set; }
        [Required]
        [MaxLength(6, ErrorMessage = "RouteModeOfTravel must be 6 characters or less")]
        [Display(Name = "Travel vehicle")]
        public string RouteModeOfTravel { get; set; } 
        [Required]
        [Display(Name = "Travel time")]
        public int TravelTimeMinutes { get; set; }
        [Required]
        [Display(Name = "Provided by")]
        public int AgencyId { get; set; }
        public TravelAgencyVM AgencyVM { get; set; }
        [Required]
        [Display(Name = "Price")]
        public int Price { get; set; }
        [Required]
        [Display(Name = "Distance in KM")]
        public int Distance { get; set; }
        [Required]
        [Display(Name = "Starting point")]
        public int StartingLocationId { get; set; }
        public LocationVM StartingLocationVM { get; set; }
        [Required]
        [Display(Name = "Destination")]
        public int EndLocationId { get; set; }
        public LocationVM EndLocationVM { get; set; }
        public RouteVM() { }
        public RouteVM(RouteDto routeDto)
        {
            Id = routeDto.Id;
            RouteName = routeDto.RouteName;
            RouteModeOfTravel = routeDto.RouteModeOfTravel;
            TravelTimeMinutes = routeDto.TravelTimeMinutes;
            AgencyVM = new TravelAgencyVM(routeDto.Agency);
            Price = routeDto.Price;
            Distance = routeDto.Distance;
            StartingLocationVM = new LocationVM (routeDto.StartingLocation);
            EndLocationVM = new LocationVM(routeDto.EndLocation);
            
        }
    }
}