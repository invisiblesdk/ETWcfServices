using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETWebsite.Utils
{
    public class LoadData
    {
        public static SelectList LoadAgencyData()
        {
            using (TravelAgencyReference.TravelAgencyClient service = new TravelAgencyReference.TravelAgencyClient())
            {
                return new SelectList(service.GetTravelAgency(), "Id", "AgencyName");
            }
        }
        public static SelectList LoadLocationData()
        {
            using (LocationReference.LocationClient service = new LocationReference.LocationClient())
            {
                return new SelectList(service.GetLocation(), "Id", "Name");
            }
        }
    }
}