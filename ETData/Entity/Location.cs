using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETData.Entity
{
    public class Location : BaseEntity
    {
        [Required]
        [MaxLength(25, ErrorMessage = "Name must be 25 characters or less")]
        public string Name { get; set; }
        public string Country { get; set; }
        [Required]
        [Range(0.0, 10.0)]
        public double TravelRating { get; set; }

    }
}
