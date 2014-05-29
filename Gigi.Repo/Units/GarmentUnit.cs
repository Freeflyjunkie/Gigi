using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gigi.Repo.EF;
using Gigi.Repo.Repos;
using Gigi.Repo.Repos.Interfaces;
using Gigi.Repo.Units.Interfaces;

namespace Gigi.Repo.Units
{
    public class GarmentUnit : IGarmentUnit, IDisposable
    {
        private readonly GigiContext _gigiContext;
        private readonly IGarmentRepo _garmentRepo;
        private bool _disposed = false;

        public GarmentUnit(GigiContext context)
        {
            _gigiContext = context;
        }

        public void Save()
        {
            _gigiContext.SaveChanges();
        }

        public IGarmentRepo GarmentRepo
        {
            get { return _garmentRepo ?? new GarmentRepo(_gigiContext); }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _gigiContext.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
