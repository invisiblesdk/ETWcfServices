using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETWebsite.ViewModel
{
    public class FinderVM
    {
        public LocationVM startLocation { get; set; }
        public LocationVM endLocation { get; set; }
        public int LowestCost { get; set; }
    }
}