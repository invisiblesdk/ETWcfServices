using ETApplicationServices.DTOs;
using ETWebsite.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETWebsite.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            List<LocationVM> locationVM = new List<LocationVM>();
            using (LocationReference.LocationClient service = new LocationReference.LocationClient())
            {
                foreach (var item in service.GetLocation())
                {
                    locationVM.Add(new LocationVM(item));
                }
            }
            return View(locationVM);
        }
        public ActionResult Create()
        {
           

            return View();
        }
        [HttpPost]
        public ActionResult Create(LocationVM locationVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (LocationReference.LocationClient service = new LocationReference.LocationClient())
                    {
                        LocationDto locationDto = new LocationDto
                        {
                            Name = locationVM.Name,
                            Country = locationVM.Country,
                            TravelRating = locationVM.Rating
                        };
                        service.PostLocation(locationDto);
                    }

                    return RedirectToAction("Index");
                }
                return View();

            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            LocationVM locationVM = new LocationVM();
            using (LocationReference.LocationClient service = new LocationReference.LocationClient())
            {
                var locationDto = service.GetLocationById(id);
                locationVM = new LocationVM(locationDto);
            }

            return View(locationVM);
        }
        [HttpPost]
        public ActionResult Edit(LocationVM locationVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (LocationReference.LocationClient service = new LocationReference.LocationClient())
                    {
                        LocationDto locationDto = new LocationDto
                        {
                            Id = locationVM.Id,
                            Name = locationVM.Name,
                            Country = locationVM.Country,
                            TravelRating = locationVM.Rating
                        };
                        service.PostLocation(locationDto);
                    }

                    return RedirectToAction("Index");
                }
                return View();

            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            LocationVM locationVM = new LocationVM();

            using (LocationReference.LocationClient service = new LocationReference.LocationClient())
            {
                LocationDto movieDto =
                service.GetLocationById(id);

                locationVM = new LocationVM(movieDto);
            }
            return View(locationVM);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (LocationReference.LocationClient service = new LocationReference.LocationClient())
            {
                service.DeleteLocation(id);
            }
            return RedirectToAction("Index");
        }
    }
}