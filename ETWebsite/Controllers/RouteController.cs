using ETApplicationServices.DTOs;
using ETWebsite.Utils;
using ETWebsite.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETWebsite.Controllers
{
    public class RouteController : Controller
    {
        // GET: Route
        public ActionResult Index()
        {
            List<RouteVM> routeVMs = new List<RouteVM>();
            using (RouteReference.RouteClient service = new RouteReference.RouteClient())
            {
                foreach (var item in service.GetRoute())
                {
                    routeVMs.Add(new RouteVM(item));
                }
            }
            return View(routeVMs);
        }

        // GET: Route/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Route/Create
        public ActionResult Create()
        {
            ViewBag.Agencies = LoadData.LoadAgencyData();
            ViewBag.Locations = LoadData.LoadLocationData();
            return View();
        }

        // POST: Route/Create
        [HttpPost]
        public ActionResult Create(RouteVM routeVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RouteReference.RouteClient service = new RouteReference.RouteClient())
                    {
                        TravelAgencyDto travelAgencyDto = new TravelAgencyDto();
                        LocationDto locationDtoStart = new LocationDto();
                        LocationDto locationDtoEnd = new LocationDto();
                        using (TravelAgencyReference.TravelAgencyClient serviceAgency = new TravelAgencyReference.TravelAgencyClient())
                        {
                            travelAgencyDto = serviceAgency.GetTravelAgencyById(routeVM.AgencyId);
                        }
                        using (LocationReference.LocationClient serviceLoca = new LocationReference.LocationClient())
                        {
                            locationDtoStart = serviceLoca.GetLocationById(routeVM.StartingLocationId);
                            locationDtoEnd = serviceLoca.GetLocationById(routeVM.EndLocationId);
                        }
                        RouteDto routeDto = new RouteDto
                        {
                            RouteName = routeVM.RouteName,
                            RouteModeOfTravel = routeVM.RouteModeOfTravel,
                            TravelTimeMinutes = routeVM.TravelTimeMinutes,                            
                            Agency = travelAgencyDto,
                            Price = routeVM.Price,
                            Distance = routeVM.Distance,
                            StartingLocation = locationDtoStart,
                            EndLocation = locationDtoEnd
                        };
                        if (routeDto.RouteModeOfTravel.ToLower() == "bus")
                        {
                            routeDto.Price = (int)Math.Ceiling(routeDto.Agency.BusPrice * routeDto.Distance);
                        }
                        else if (routeDto.RouteModeOfTravel.ToLower() == "train")
                        {
                            routeDto.Price = (int)Math.Ceiling(routeDto.Agency.TrainPrice * routeDto.Distance);
                        }
                        else if (routeDto.RouteModeOfTravel.ToLower() == "plane")
                        {
                            routeDto.Price = (int)Math.Ceiling(routeDto.Agency.PlanePrice * routeDto.Distance);
                        }
                        else
                        {
                            routeDto.Price = (int)Math.Ceiling(routeDto.Agency.OtherPrice * routeDto.Distance);
                        }
                        service.PostRoute(routeDto);
                    }

                    return RedirectToAction("Index");
                }
                ViewBag.Agencies = LoadData.LoadAgencyData();
                ViewBag.Locations = LoadData.LoadLocationData();
                return View();

            }
            catch
            {
                ViewBag.Agencies = LoadData.LoadAgencyData();
                ViewBag.Locations = LoadData.LoadLocationData();
                return View();
            }
        }

        // GET: Route/Edit/5
        public ActionResult Edit(int id)
        {
            RouteVM routeVM = new RouteVM();
            using (RouteReference.RouteClient service = new RouteReference.RouteClient())
            {
                var routeDto = service.GetRouteById(id);
                routeVM = new RouteVM(routeDto);
            }
            ViewBag.Agencies = LoadData.LoadAgencyData();
            ViewBag.Locations = LoadData.LoadLocationData();
            return View(routeVM);
        }

        // POST: Route/Edit/5
        [HttpPost]
        public ActionResult Edit(RouteVM routeVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RouteReference.RouteClient service = new RouteReference.RouteClient())
                    {
                        TravelAgencyDto travelAgencyDto = new TravelAgencyDto();
                        LocationDto locationDtoStart = new LocationDto();
                        LocationDto locationDtoEnd = new LocationDto();
                        using (TravelAgencyReference.TravelAgencyClient serviceAgency = new TravelAgencyReference.TravelAgencyClient())
                        {
                            travelAgencyDto = serviceAgency.GetTravelAgencyById(routeVM.AgencyId);
                        }
                        using (LocationReference.LocationClient serviceLoca = new LocationReference.LocationClient())
                        {
                            locationDtoStart = serviceLoca.GetLocationById(routeVM.StartingLocationId);
                            locationDtoEnd = serviceLoca.GetLocationById(routeVM.EndLocationId);
                        }
                        RouteDto routeDto = new RouteDto
                        {
                            Id = routeVM.Id,
                            RouteName = routeVM.RouteName,
                            RouteModeOfTravel = routeVM.RouteModeOfTravel,
                            TravelTimeMinutes = routeVM.TravelTimeMinutes,
                            Agency = travelAgencyDto,
                            Price = routeVM.Price,
                            Distance = routeVM.Distance,
                            StartingLocation = locationDtoStart,
                            EndLocation = locationDtoEnd
                        };
                        if (routeDto.RouteModeOfTravel.ToLower() == "bus")
                        {
                            routeDto.Price = (int)Math.Ceiling(routeDto.Agency.BusPrice * routeDto.Distance);
                        }
                        else if (routeDto.RouteModeOfTravel.ToLower() == "train")
                        {
                            routeDto.Price = (int)Math.Ceiling(routeDto.Agency.TrainPrice * routeDto.Distance);
                        }
                        else if (routeDto.RouteModeOfTravel.ToLower() == "plane")
                        {
                            routeDto.Price = (int)Math.Ceiling(routeDto.Agency.PlanePrice * routeDto.Distance);
                        }
                        else
                        {
                            routeDto.Price = (int)Math.Ceiling(routeDto.Agency.OtherPrice * routeDto.Distance);
                        }
                        service.PostRoute(routeDto);
                        return RedirectToAction("Index");
                    }

                }
                ViewBag.Agencies = LoadData.LoadAgencyData();
                ViewBag.Locations = LoadData.LoadLocationData();
                return View();
            }
            catch
            {
                ViewBag.Agencies = LoadData.LoadAgencyData();
                ViewBag.Locations = LoadData.LoadLocationData();
                return View();
            }
        }

        // GET: Route/Delete/5
        public ActionResult Delete(int id)
        {
            RouteVM routeVM = new RouteVM();

            using (RouteReference.RouteClient service = new RouteReference.RouteClient())
            {
                RouteDto routeDto =
                service.GetRouteById(id);

                routeVM = new RouteVM(routeDto);
            }
            return View(routeVM);
        }

        // POST: Route/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (RouteReference.RouteClient service = new RouteReference.RouteClient())
            {
                service.DeleteRoute(id);
            }
            return RedirectToAction("Index");
        }
    }
}
