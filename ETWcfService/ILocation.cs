using ETApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ETWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILocation" in both code and config file together.
    [ServiceContract]
    public interface ILocation
    {
        [OperationContract]
        List<LocationDto> GetLocation();

        [OperationContract]
        string PostLocation(LocationDto locationDto);

        [OperationContract]
        string PutLocation(LocationDto locationDto);

        [OperationContract]
        string DeleteLocation(int id);
        [OperationContract]
        LocationDto GetLocationById(int id);

        [OperationContract]
        string Message();
    }
}
