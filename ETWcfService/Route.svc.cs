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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Route" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Route.svc or Route.svc.cs at the Solution Explorer and start debugging.
    public class Route : IRoute
    {
        private RouteManagementService service = new RouteManagementService();
        public string DeleteRoute(int id)
        {
            if (!service.Delete(id))
                return "Route is not deleted";

            return "Route is deleted";
        }

        public List<RouteDto> GetRoute()
        {
            return service.Get();
        }

        public RouteDto GetRouteById(int id)
        {
           return service.GetById(id);
        }

        public string Message()
        {
            return "Still returns nothing cus idk";
        }

        public string PostRoute(RouteDto routeDto)
        {
            if (!service.Save(routeDto))
                return "Route is not inserted";

            return "Route is inserted";
        }

        public string PutRoute(RouteDto routeDto)
        {
            if (!service.Save(routeDto))
                return "Route is not updated";

            return "Route is updated";
        }
    }
}
