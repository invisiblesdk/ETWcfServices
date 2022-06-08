using ETApplicationServices.DTOs;
using ETApplicationServices.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ETWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Location" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Location.svc or Location.svc.cs at the Solution Explorer and start debugging.
    public class Location : ILocation
    {
        private LocationManagementService service = new LocationManagementService();

        public string DeleteLocation(int id)
        {
            if (!service.Delete(id))
                return "Location is not deleted";

            return "Location is deleted";
        }
        public List<LocationDto> GetLocation()
        {
            return service.Get();
        }

        public LocationDto GetLocationById(int id)
        {
           return service.GetById(id);
        }

        public string Message()
        {
            return "Still returns nothing cus idk";
        }

        public string PostLocation(LocationDto locationDto)
        {
            if (!service.Save(locationDto))
                return "Location is not inserted";

            return "Location is inserted";
        }

        public string PutLocation(LocationDto locationDto)
        {
            if (!service.Save(locationDto))
                return "Location is not updated";

            return "Location is updated";
        }
    }
}
