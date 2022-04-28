using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_task_cSharp.Bertuccioli
{
    /// <summary>
    /// Represents the shop where the <see cref="IPlayer"/> can buy defenses.
    /// </summary>
    class Shop : IShop
    {
        private readonly IDictionary<int, ITurret> _turrets;

        /// <summary>
        /// Creates a new shop object with the given turrets, prices and the player.
        /// </summary>
        /// <param name="turretsLoader">an instance of <see cref="ITurretsLoader"/></param>
        public Shop(ITurretsLoader turretsLoader) => _turrets = turretsLoader.GetTurrets();

        public IList<ITurret> GetAvailableTurrets() => new List<ITurret>(_turrets.Values);

        public bool CanBuy(int tid, IPlayer p)
        {
            CheckNull(p, "player");
            _turrets.TryGetValue(tid, out ITurret? t);
            return t != null && p.GetMoney() >= t.GetPrice();
        }

        public bool CanBuy(ITurret t, IPlayer p)
        {
            CheckNull(t, "turret");
            CheckNull(p, "player");
            _turrets.TryGetValue(t.GetID(), out ITurret? turret);
            return t.Equals(turret) && CanBuy(t.GetID(), p);        // A check is put in place to verify that not any Turret with a specific
        }                                                           // ID can be bought off the shop just because the ID matched one in the Map.

        private void CheckNull(object param, string paramName)
        {
            if (param == null)
            {
                throw new NullReferenceException("Null value for parameter " + paramName + " is not valid");
            }
        }
    }
}
