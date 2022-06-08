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
    public class LocationManagementService
    {
        public List<LocationDto> Get()
        {
            List<LocationDto> locationsDto = new List<LocationDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.LocationRepository.Get())
                {
                    locationsDto.Add(new LocationDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Country = item.Country,
                        TravelRating = item.TravelRating
                    });
                }
            }

            return locationsDto;
        }
        public LocationDto GetById(int id)
        {
            LocationDto locationDto = new LocationDto();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Location location = unitOfWork.LocationRepository.GetByID(id);
                locationDto = new LocationDto
                {
                    Id=location.Id,
                    Name = location.Name,
                    Country = location.Country,
                    TravelRating=location.TravelRating
                };
            }

            return locationDto;
        }

        public bool Save(LocationDto locationsDto)
        {
            Location location = new Location
            {
                Id = locationsDto.Id,
                Name = locationsDto.Name,
                Country = locationsDto.Country,
                TravelRating = locationsDto.TravelRating
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (locationsDto.Id == 0)
                        unitOfWork.LocationRepository.Insert(location);
                    else
                        unitOfWork.LocationRepository.Update(location);
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
                    Location location = unitOfWork.LocationRepository.GetByID(id);
                    unitOfWork.LocationRepository.Delete(location);
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
