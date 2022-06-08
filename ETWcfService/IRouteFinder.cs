using ETApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ETWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRouteFinder" in both code and config file together.
    [ServiceContract]
    public interface IRouteFinder
    {
        [OperationContract]
        int FindRoute(LocationDto location1, LocationDto location2);
    }
}
