using OOP21_task_cSharp.Notaro;
using System.Collections.Generic;

namespace OOP21_task_cSharp.Gessi
{
    /// <summary>
    /// Manages the TurretView.
    /// </summary>
    public interface ITurretController
    {
        /// <summary>
        /// Check if a turret is selected in the shop.
        /// </summary>
        /// <returns>true if any turret is selected, false otherwise</returns>
        bool IsTurretSelected();

        /// <summary>
        /// Returns the turret placed at the given position.
        /// </summary>
        /// <param name="gpos">the given <see cref="GridPosition"/></param>
        /// <returns>the turret, otherwise null</returns>
        ITurret? GetTurretAt(GridPosition gpos);

        /// <summary>
        /// Tries to buy and place a turret.
        /// </summary>
        /// <param name="gpos">the position where we want to place the turret</param>
        void AddSelectedTurret(GridPosition gpos);

        /// <summary>
        /// Checks if there is a turret in the tile indicated by the position.
        /// </summary>
        /// <param name="gpos">the position of the tile</param>
        /// <returns>true if the tile is empty, false otherwise</returns>
        bool IsTileEmpty(GridPosition gpos);

        /// <summary>
        /// Returns an iterator of turrets.
        /// </summary>
        /// <returns>an iterator of turrets</returns>
        IEnumerator<KeyValuePair<GridPosition, ITurret>> GetTurretsEnumerator();

        /// <summary>
        /// Method used when a bullet is created.
        /// Used to inform the controller of all bullets.
        /// </summary>
        /// <param name="bullet">the bullet created</param>
        void BulletCreated(IBullet bullet);

    }
}