using ETApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ETWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRoute" in both code and config file together.
    [ServiceContract]
    public interface IRoute
    {
        [OperationContract]
        List<RouteDto> GetRoute();

        [OperationContract]
        string PostRoute(RouteDto routeDto);

        [OperationContract]
        string PutRoute(RouteDto routeDto);

        [OperationContract]
        string DeleteRoute(int id);
        [OperationContract]
        RouteDto GetRouteById(int id);

        [OperationContract]
        string Message();
    }
}
