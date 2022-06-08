using ETApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ETWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITravelAgency" in both code and config file together.
    [ServiceContract]
    public interface ITravelAgency
    {
        [OperationContract]
        List<TravelAgencyDto> GetTravelAgency();

        [OperationContract]
        string PostTravelAgency(TravelAgencyDto travelAgencyDto);

        [OperationContract]
        string PutTravelAgency(TravelAgencyDto travelAgencyDto);

        [OperationContract]
        string DeleteTravelAgency(int id);
        [OperationContract]
        TravelAgencyDto GetTravelAgencyById(int id);

        [OperationContract]
        string Message();
    }
}
