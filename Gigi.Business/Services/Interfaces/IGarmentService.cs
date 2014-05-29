using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gigi.Domain;

namespace Gigi.Business.Services.Interfaces
{
    public interface IGarmentService
    {
        Garment GetGarmentById(Int32 garmentId);
    }
}
