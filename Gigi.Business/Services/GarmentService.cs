using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gigi.Business.Services.Interfaces;
using Gigi.Domain;
using Gigi.Repo.Units.Interfaces;

namespace Gigi.Business.Services
{
    public class GarmentService : IGarmentService
    {
        private readonly IGarmentUnit _garmentUnit;

        public GarmentService(IGarmentUnit garmentUnit)
        {
            _garmentUnit = garmentUnit;
        }

        public Garment GetGarmentById(int garmentId)
        {
            return _garmentUnit.GarmentRepo.GetGarmentById(garmentId);
        }
    }
}
