using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETData.Entity
{
    public class TravelAgency : BaseEntity
    {
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
        public virtual ICollection<Route> Routes { get; set; }
    }
}
