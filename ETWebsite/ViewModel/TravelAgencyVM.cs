using ETApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETWebsite.ViewModel
{
    public class TravelAgencyVM
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25, ErrorMessage = "AgencyName must be 25 characters or less")]
        public string AgencyName { get; set; }
        [Required]
        public double PlanePrice { get; set; }
        [Required]
        public double TrainPrice { get; set; }
        [Required]
        public double BusPrice { get; set; }
        [Required]
        public double OtherPrice { get; set; }
        public TravelAgencyVM() { }
        public TravelAgencyVM(TravelAgencyDto travelAgencyDto) {
            Id = travelAgencyDto.Id;
            AgencyName = travelAgencyDto.AgencyName;
            PlanePrice = travelAgencyDto.PlanePrice;
            TrainPrice = travelAgencyDto.TrainPrice;
            BusPrice = travelAgencyDto.BusPrice;
            OtherPrice = travelAgencyDto.OtherPrice;

        }
    }
}