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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RouteFinder" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RouteFinder.svc or RouteFinder.svc.cs at the Solution Explorer and start debugging.
    public class RouteFinder : IRouteFinder
    {
        private RouteManagementService service = new RouteManagementService();
		private LocationManagementService serviceLocation = new LocationManagementService();
		public int FindRoute(LocationDto location1, LocationDto location2)
        {
			List<LocationDto> locations = serviceLocation.Get();
			List<RouteDto> routes = service.Get();

			int cost = Dijkstra(GetPerfectGraphPrice(locations, routes), locations.IndexOf(location1), locations.Count)[locations.IndexOf(location2)];

			return cost;

        }
		private int[,] GetPerfectGraphPrice(List<LocationDto> locationDtos,List<RouteDto> routes)
        {
			int size = locationDtos.Count();
			int[,] graph = new int[size, size];			
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					List<RouteDto> temp = new List<RouteDto>();
					temp = routes.FindAll(r => r.StartingLocation.Id == locationDtos[i].Id
					&& r.EndLocation.Id == locationDtos[j].Id).OrderBy(o => o.Price).ToList();
                    if (temp.Count != 0)
                    {
						graph[i, j] = temp.First().Price;
                    }
                    else
                    {
						graph[i, j] = 0;

					}

				}
			}
			return graph;           
		}
		private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
		{
			int min = int.MaxValue;
			int minIndex = 0;

			for (int v = 0; v < verticesCount; ++v)
			{
				if (shortestPathTreeSet[v] == false && distance[v] <= min)
				{
					min = distance[v];
					minIndex = v;
				}
			}

			return minIndex;
		}

		public static int[] Dijkstra(int[,] graph, int source, int verticesCount)
		{
			int[] distance = new int[verticesCount];
			bool[] shortestPathTreeSet = new bool[verticesCount];

			for (int i = 0; i < verticesCount; ++i)
			{
				distance[i] = int.MaxValue;
				shortestPathTreeSet[i] = false;
			}

			distance[source] = 0;

			for (int count = 0; count < verticesCount - 1; ++count)
			{
				int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
				shortestPathTreeSet[u] = true;

				for (int v = 0; v < verticesCount; ++v)
					if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
					{
						distance[v] = distance[u] + graph[u, v];
                        
					}
			}
			return distance;
			
		}
	}
}
