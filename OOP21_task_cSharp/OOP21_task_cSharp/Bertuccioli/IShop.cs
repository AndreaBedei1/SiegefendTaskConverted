using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_task_cSharp.Bertuccioli
{
    interface IShop
    {
        IList<ITurret> GetAvailableTurrets();

        bool CanBuy(int tid, IPlayer p);

        bool CanBuy(ITurret t, IPlayer p);
    }
}
