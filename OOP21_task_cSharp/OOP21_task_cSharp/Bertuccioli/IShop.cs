using OOP21_task_cSharp.Gessi;
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
    interface IShop
    {
        /// <summary>
        /// Returns a list containing all the turrets that can be bought.
        /// </summary>
        /// <returns>a list of <see cref="ITurret"/> objects</returns>
        IList<ITurret> GetAvailableTurrets();

        /// <summary>
        /// </summary>
        /// Checks whether the {@link Turret} with the given id can be bought in the shop and if the given {@link Player} has enough money to buy it.
        /// <param name="tid">the id of the turret</param>
        /// <param name="p">the player</param>
        /// <returns>true if the turret is available to be bought and the player has enough money, false otherwise</returns>
        bool CanBuy(int tid, IPlayer p);

        /// <summary>
        /// </summary>
        /// Checks whether the {@link Turret} can be bought in the shop and if the given {@link Player} has enough money to buy it.
        /// <param name="t">the turret to buy</param>
        /// <param name="p">the player</param>
        /// <returns> true if the turret is available to be bought and the player has enough money, false otherwise</returns>
        bool CanBuy(ITurret t, IPlayer p);
    }
}
