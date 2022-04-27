using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_task_cSharp.Bertuccioli
{
    class Shop : IShop
    {
        private readonly IDictionary<int, ITurret> _turrets;

        public Shop(ITurretsLoader turretsLoader) => _turrets = turretsLoader.GetTurrets();
        public IList<ITurret> GetAvailableTurrets() => new List<ITurret>(_turrets.Values);

        public bool CanBuy(int tid, IPlayer p)
        {
            CheckNull(p, "player");
            _turrets.TryGetValue(tid, out ITurret t);
            return t != null && p.GetMoney() >= t.GetPrice();
        }

        public bool CanBuy(ITurret t, IPlayer p)
        {
            CheckNull(t, "turret");
            CheckNull(p, "player");
            _turrets.TryGetValue(t.GetID(), out ITurret turret);
            return t.Equals(turret) && CanBuy(t.GetID(), p);
        }

        private void CheckNull(object param, string paramName)
        {
            if (param == null)
            {
                throw new NullReferenceException("Null value for parameter " + paramName + " is not valid");
            }
        }
    }
}
