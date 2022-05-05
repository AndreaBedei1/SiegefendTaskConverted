using OOP21_task_cSharp.Gessi;
using System.Collections.Generic;

namespace OOP21_task_cSharp.Bertuccioli
{
    /// <summary>
    /// Loads the turrets.
    /// </summary>
    public interface ITurretsLoader
    {
        /// <summary>
        /// Returns a list containing the turrets that can be bought in the shop.
        /// </summary>
        /// <returns>a dictionary of turrets</returns>
        IDictionary<int, ITurret> GetTurrets();
    }
}
