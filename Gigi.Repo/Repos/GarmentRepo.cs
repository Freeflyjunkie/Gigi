using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gigi.Domain;
using Gigi.Repo.EF;
using Gigi.Repo.Repos.Generic;
using Gigi.Repo.Repos.Interfaces;

namespace Gigi.Repo.Repos
{
    public class GarmentRepo : GenericRepo<Garment>, IGarmentRepo
    {
        private readonly GigiContext _gigiContext;
        public GarmentRepo(GigiContext context) : base(context)
        {
            _gigiContext = context;
        }

        public Garment GetGarmentById(int garmentId)
        {
            return _gigiContext.Garments
                .Include("GarmentType").Include("GarmentToGarmentSizes").Include("GarmentToGarmentSizes.GarmentSize")
                .Where(g => g.GarmentId == garmentId)
                .ToList()
                .SingleOrDefault();
            //return _gigiContext.Garments.ToList().FirstOrDefault();
        }
    }
}
