using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_task_cSharp.Bertuccioli
{
    public interface ITurretsLoader
    {
        IDictionary<int, ITurret> GetTurrets();
    }
}
