using ETApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETWebsite.ViewModel
{
    public class LocationVM
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Location name")]
        [MaxLength(25, ErrorMessage = "Name must be 25 characters or less")]
        public string Name { get; set; }

        [Display(Name = "Located in")]
        public string Country { get; set; }
        [Required]
        [Display(Name ="Location Rating")]
        [Range(0.0,10.0)]
        public double Rating { get; set; }
        public LocationVM() { }
        public LocationVM(LocationDto locationDto)
        {
            Id = locationDto.Id;
            Name = locationDto.Name;
            Country = locationDto.Country;
            Rating = locationDto.TravelRating;
        }
    }
}