using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gigi.Repo.Repos.Interfaces;

namespace Gigi.Repo.Units.Interfaces
{
    public interface IGarmentUnit
    {
        void Save();
        IGarmentRepo GarmentRepo { get; }
    }
}
