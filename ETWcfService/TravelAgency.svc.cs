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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TravelAgency" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TravelAgency.svc or TravelAgency.svc.cs at the Solution Explorer and start debugging.
    public class TravelAgency : ITravelAgency
    {
        private TravelAgencyManagementService service = new TravelAgencyManagementService();
        public string DeleteTravelAgency(int id)
        {
            if (!service.Delete(id))
                return "Agency is not deleted";

            return "Agency is deleted";
        }

        public List<TravelAgencyDto> GetTravelAgency()
        {
            return service.Get();
        }

        public TravelAgencyDto GetTravelAgencyById(int id)
        {
            return service.GetById(id);
        }

        public string Message()
        {
            return "Still returns nothing cus idk";
        }

        public string PostTravelAgency(TravelAgencyDto travelAgencyDto)
        {
            if (!service.Save(travelAgencyDto))
                return "Agency is not inserted";

            return "Agency is inserted";
        }

        public string PutTravelAgency(TravelAgencyDto travelAgencyDto)
        {
            if (!service.Save(travelAgencyDto))
                return "Agency is not updated";

            return "Agency is updated";
        }
    }
}
