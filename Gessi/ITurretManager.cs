namespace OOP21_task_cSharp.Gessi
{
    /// <summary>
    /// Handles upgrades and selling of turrets.
    /// </summary>
    public interface ITurretManager
    {
        /// <summary>
        /// The <see cref="ITurret"/> associated with the <see cref="ITurretController"/>.
        /// </summary>
        ITurret Turret { get; }

        /// <summary>
        /// The current level of the <see cref="ITurret"/>.
        /// </summary>
        int CurrentUpgradeLevel { get; }

        /// <summary>
        /// The cost of the last performed upgrade or the initial cost of the turret.
        /// </summary>
        int CurrentUpgradePrice { get; }

        /// <summary>
        /// The cost of the next upgrade.
        /// </summary>
        int NextUpgradePrice { get; }

        /// <summary>
        /// Return the <see cref="ITurret"/> with the upgraded statistics.
        /// </summary>
        ITurret NextUpgrade { get; }

        /// <summary>
        /// Checks whether the upgrade can be purchased or not.
        /// </summary>
        bool CanPurchaseUpgrade { get; }

        /// <summary>
        /// Sells the turret and returns the amount of money gained from the selling.
        /// </summary>
        /// <returns>the amount of money received from the selling</returns>
        int Sell();
    }
}