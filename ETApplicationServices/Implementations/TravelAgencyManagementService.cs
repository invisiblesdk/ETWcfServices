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
    public class TravelAgencyManagementService
    {
        public List<TravelAgencyDto> Get()
        {
            List<TravelAgencyDto> agenciesDto = new List<TravelAgencyDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.TravelAgencyReposiotry.Get())
                {
                    agenciesDto.Add(new TravelAgencyDto
                    {
                        Id = item.Id,
                        AgencyName = item.AgencyName,
                        PlanePrice = item.PlanePrice,
                        TrainPrice = item.TrainPrice,
                        BusPrice = item.BusPrice,
                        OtherPrice = item.OtherPrice
                        
                    });
                }
            }

            return agenciesDto;
        }
        public TravelAgencyDto GetById(int id)
        {
            TravelAgencyDto travelAgencyDto = new TravelAgencyDto();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                TravelAgency travelAgency = unitOfWork.TravelAgencyReposiotry.GetByID(id);
                travelAgencyDto = new TravelAgencyDto
                {
                    Id = travelAgency.Id,
                    AgencyName = travelAgency.AgencyName,
                    PlanePrice = travelAgency.PlanePrice,
                    TrainPrice = travelAgency.TrainPrice,
                    BusPrice = travelAgency.BusPrice,
                    OtherPrice = travelAgency.OtherPrice
                };
            }

            return travelAgencyDto;
        }
        public bool Save(TravelAgencyDto agencyDto)
        {
            TravelAgency agency = new TravelAgency
            {
                Id = agencyDto.Id,
                AgencyName = agencyDto.AgencyName,
                PlanePrice = agencyDto.PlanePrice,
                TrainPrice = agencyDto.TrainPrice,
                BusPrice = agencyDto.BusPrice,
                OtherPrice= agencyDto.OtherPrice
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (agencyDto.Id == 0)
                        unitOfWork.TravelAgencyReposiotry.Insert(agency);
                    else
                        unitOfWork.TravelAgencyReposiotry.Update(agency);
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
                    TravelAgency location = unitOfWork.TravelAgencyReposiotry.GetByID(id);
                    unitOfWork.TravelAgencyReposiotry.Delete(location);
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
