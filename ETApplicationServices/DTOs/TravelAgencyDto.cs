using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETApplicationServices.DTOs
{
    public class TravelAgencyDto
    {
        public int Id { get; set; }
        public string AgencyName { get; set; }
        public double PlanePrice { get; set; }
        public double TrainPrice { get; set; }
        public double BusPrice { get; set; }
        public double OtherPrice { get; set; }
        public bool Validate()
        {
            return !String.IsNullOrEmpty(AgencyName) 
                && (PlanePrice > 0.0 
                || TrainPrice > 0.0 
                || BusPrice >0.0);
        }
    }
}
