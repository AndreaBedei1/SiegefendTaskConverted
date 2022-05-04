using System.Collections.Generic;

namespace OOP21_task_cSharp.Gessi
{
    /// <summary>
    /// Disclaimer: I didn't originally write this interface, but now I'm going to write it because I need it and I'm going to do it by simply transcribing the code from Java to C#.
    /// Interface for managing the shop.
    /// </summary>
    public interface IShopController
    {
        /// <summary>
        /// Returns the associated <see cref="IPlayerController"/>.
        /// </summary>
        /// <returns>the associated <see cref="IPlayerController"/></returns>
        IPlayerController GetPlayerManager();

        /// <summary>
        /// Returns a list of <see cref="ITurret"/> that can be bought from the shop.
        /// </summary>
        /// <returns>a list of turrets</returns>
        List<ITurret> GetTurretList();

        /// <summary>
        /// Deselects the currently selected turret. Does nothing if no turret is selected.
        /// </summary>
        void DeselectTurret();

        /// <summary>
        /// Sets an <see cref="ITurret"/> as selected.
        /// </summary>
        /// <param name="t">a turret</param>
        /// <returns>true if the turret was set as selected, false otherwise</returns>
        bool TrySetSelectedTurret(ITurret t);

        /// <summary>
        /// Returns the selected <see cref="ITurret"/>.
        /// </summary>
        /// <returns>an ITurret</returns>
        ITurret? GetSelectedTurret();

        /// <summary>
        /// Verifies whether an ITurret can be bought.
        /// </summary>
        /// <param name="t">a turret</param>
        /// <returns>true if the turret can be bought, false otherwise</returns>
        bool CanBuy(ITurret t);

        /// <summary>
        /// Attempts to buy a turret. The method also decreases the money count of the player if the purchase is successful.
        /// </summary>
        /// <returns>an <see cref="ITurret"/> if a turret is selected and the player has enough money to buy it, null otherwise</returns>
        ITurret? Buy();
    }
}
