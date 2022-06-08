using ETData.Context;
using ETData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETRepository.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private ETContextDB context = new ETContextDB();
        private GenericRepository<Location> locationRepository;
        private GenericRepository<Route> routeReposiotry;
        private GenericRepository<TravelAgency> travelAgencyReposiotry;

        public GenericRepository<Location> LocationRepository
        {
            get
            {

                if (this.locationRepository == null)
                {
                    this.locationRepository = new GenericRepository<Location>(context);
                }
                return locationRepository;
            }
        }

        public GenericRepository<Route> RouteReposiotry
        {
            get
            {
                if (this.routeReposiotry == null)
                {
                    this.routeReposiotry = new GenericRepository<Route>(context);
                }
                return routeReposiotry;
            }
        }

        public GenericRepository<TravelAgency> TravelAgencyReposiotry
        {
            get
            {
                if (this.travelAgencyReposiotry == null)
                {
                    this.travelAgencyReposiotry = new GenericRepository<TravelAgency>(context);
                }
                return travelAgencyReposiotry;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

