using ETApplicationServices.DTOs;
using ETData.Entity;
using ETRepository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETApplicationServices.Implementations
{
    public class RouteManagementService
    {
        public List<RouteDto> Get()
        {
            List<RouteDto> routesDto = new List<RouteDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.RouteReposiotry.Get())
                {
                    var agency = unitOfWork.TravelAgencyReposiotry.GetByID(item.AgencyId);
                    var startLoc = unitOfWork.LocationRepository.GetByID(item.StartingLocationId);
                    var endLoc = unitOfWork.LocationRepository.GetByID(item.EndLocationId);
                    routesDto.Add(new RouteDto
                    {
                        Id = item.Id,
                        RouteName = item.RouteName,
                        RouteModeOfTravel = item.RouteModeOfTravel,
                        TravelTimeMinutes = item.TravelTimeMinutes,
                        Distance = item.DistanceKM,
                        Agency = new TravelAgencyDto
                        {
                            Id = item.AgencyId,
                            AgencyName = agency.AgencyName,
                            PlanePrice = agency.PlanePrice,
                            TrainPrice = agency.TrainPrice,
                            BusPrice = agency.BusPrice,
                            OtherPrice = agency.OtherPrice
                        },
                        Price = item.Price,
                        StartingLocation = new LocationDto
                        {
                            Id = item.StartingLocationId,
                            Name = startLoc.Name,
                            Country = startLoc.Country,
                            TravelRating = startLoc.TravelRating
                        },
                        EndLocation = new LocationDto
                        {
                            Id = item.EndLocationId,
                            Name= endLoc.Name,
                            Country= endLoc.Country,
                            TravelRating= endLoc.TravelRating
                        }


                    });
                }
            }

            return routesDto;
        }
        public RouteDto GetById(int id)
        {
            RouteDto routeDto = new RouteDto();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Route route = unitOfWork.RouteReposiotry.GetByID(id);
                var agency = unitOfWork.TravelAgencyReposiotry.GetByID(route.AgencyId);
                var startLoc = unitOfWork.LocationRepository.GetByID(route.StartingLocationId);
                var endLoc = unitOfWork.LocationRepository.GetByID(route.EndLocationId);
                routeDto = new RouteDto
                {
                    Id = route.Id,
                    RouteName = route.RouteName,
                    RouteModeOfTravel = route.RouteModeOfTravel,
                    TravelTimeMinutes = route.TravelTimeMinutes,
                    Distance = route.DistanceKM,
                    Agency = new TravelAgencyDto
                    {
                        Id = route.AgencyId,
                        AgencyName = agency.AgencyName,
                        PlanePrice = agency.PlanePrice,
                        TrainPrice = agency.TrainPrice,
                        BusPrice = agency.BusPrice,
                        OtherPrice = agency.OtherPrice
                    },
                    Price = route.Price,
                    StartingLocation = new LocationDto
                    {
                        Id = route.StartingLocationId,
                        Name = startLoc.Name,
                        Country = startLoc.Country,
                        TravelRating = startLoc.TravelRating
                    },
                    EndLocation = new LocationDto
                    {
                        Id = route.EndLocationId,
                        Name = endLoc.Name,
                        Country = endLoc.Country,
                        TravelRating = endLoc.TravelRating
                    }


                };
            }

            return routeDto;
        }
        public bool Save(RouteDto routesDto)
        {
            Route route = new Route
            {
                Id = routesDto.Id,
                RouteName = routesDto.RouteName,
                RouteModeOfTravel = routesDto.RouteModeOfTravel,
                TravelTimeMinutes = routesDto.TravelTimeMinutes,
                AgencyId = routesDto.Agency.Id,
                Price = routesDto.Price,
                DistanceKM = routesDto.Distance,
                StartingLocationId = routesDto.StartingLocation.Id,
                EndLocationId = routesDto.EndLocation.Id


            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (routesDto.Id == 0)
                        unitOfWork.RouteReposiotry.Insert(route);
                    else
                        unitOfWork.RouteReposiotry.Update(route);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Route route = unitOfWork.RouteReposiotry.GetByID(id);
                    unitOfWork.RouteReposiotry.Delete(route);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

