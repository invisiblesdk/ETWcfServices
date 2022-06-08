using ETApplicationServices.DTOs;
using ETWebsite.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETWebsite.Controllers
{
    public class TravelAgencyController : Controller
    {
        // GET: TravelAgency
        public ActionResult Index()
        {
            List<TravelAgencyVM> travelAgencyVMs = new List<TravelAgencyVM>();
            using (TravelAgencyReference.TravelAgencyClient service = new TravelAgencyReference.TravelAgencyClient())
            {
                foreach (var item in service.GetTravelAgency())
                {
                    travelAgencyVMs.Add(new TravelAgencyVM(item));
                }
            }
            return View(travelAgencyVMs);
        }

        // GET: TravelAgency/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TravelAgency/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TravelAgency/Create
        [HttpPost]
        public ActionResult Create(TravelAgencyVM agencyVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TravelAgencyReference.TravelAgencyClient service = new TravelAgencyReference.TravelAgencyClient())
                    {
                        TravelAgencyDto agencyDto = new TravelAgencyDto
                        {
                           AgencyName = agencyVM.AgencyName,
                           PlanePrice = agencyVM.PlanePrice,
                           BusPrice = agencyVM.BusPrice,
                           TrainPrice = agencyVM.TrainPrice,
                           OtherPrice = agencyVM.OtherPrice
                           
                        };
                        service.PostTravelAgency(agencyDto);
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

        // GET: TravelAgency/Edit/5
        public ActionResult Edit(int id)
        {
            TravelAgencyVM travelAgencyVM = new TravelAgencyVM();
            using (TravelAgencyReference.TravelAgencyClient service = new TravelAgencyReference.TravelAgencyClient())
            {
                var travelAgencyDto = service.GetTravelAgencyById(id);
                travelAgencyVM = new TravelAgencyVM(travelAgencyDto);
            }

            return View(travelAgencyVM);
        }

        // POST: TravelAgency/Edit/5
        [HttpPost]
        public ActionResult Edit(TravelAgencyVM agencyVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TravelAgencyReference.TravelAgencyClient service = new TravelAgencyReference.TravelAgencyClient())
                    {
                        TravelAgencyDto travelAgencyDto = new TravelAgencyDto
                        {
                           Id = agencyVM.Id,
                           AgencyName = agencyVM.AgencyName,
                           PlanePrice = agencyVM.PlanePrice,
                           TrainPrice = agencyVM.TrainPrice,
                           BusPrice = agencyVM.BusPrice,
                           OtherPrice = agencyVM.OtherPrice
                        };
                        service.PostTravelAgency(travelAgencyDto);
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

        // GET: TravelAgency/Delete/5
        public ActionResult Delete(int id)
        {
            TravelAgencyVM travelAgencyVM = new TravelAgencyVM();

            using (TravelAgencyReference.TravelAgencyClient service = new TravelAgencyReference.TravelAgencyClient())
            {
                TravelAgencyDto travelAgencyDto =
                service.GetTravelAgencyById(id);

                travelAgencyVM = new TravelAgencyVM(travelAgencyDto);
            }
            return View(travelAgencyVM);
        }

        // POST: TravelAgency/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (TravelAgencyReference.TravelAgencyClient service = new TravelAgencyReference.TravelAgencyClient())
            {
                service.DeleteTravelAgency(id);
            }
            return RedirectToAction("Index");
        }
    }
}
