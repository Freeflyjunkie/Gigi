using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gigi.Domain;

namespace Gigi.Repo.Repos.Interfaces
{
    public interface IGarmentRepo
    {
        Garment GetGarmentById(Int32 garmentId);
    }
}
