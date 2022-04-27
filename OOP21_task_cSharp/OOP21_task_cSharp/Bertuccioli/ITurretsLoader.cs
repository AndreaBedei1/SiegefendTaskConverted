using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegefendCSProj
{
    public interface ITurretsLoader
    {
        IDictionary<int, ITurret> GetTurrets();
    }
}
