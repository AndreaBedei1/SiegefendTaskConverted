using OOP21_task_cSharp.Bedei;

namespace OOP21_task_cSharp.Gessi
{
    /// <summary>
    /// Represents a turret that can be placed on the map.
    /// </summary>
    public interface ITurret
    {
        /// <summary>
        /// The ID of the turret.
        /// </summary>
        int ID { get; protected set; }

        /// <summary>
        /// The <see cref="Position"/> of the turret.
        /// </summary>
        Position Position { get; set; }

        /// <summary>
        /// The range of the turret.
        /// </summary>
        double Range { get; protected set; }

        /// <summary>
        /// The angle of the turret.
        /// </summary>
        double Angle { get; set; }

        /// <summary>
        /// The state of the turret.
        /// </summary>
        bool State { get; set; }

        /// <summary>
        /// Creates a new bullet that attacks the targeted enemy.
        /// </summary>
        /// <returns>an instance of <see cref="IBullet"/></returns>
        IBullet? CreateBullet();

        /// <summary>
        /// Returns the fire rate of the turret which is the speed at which the turret fires bullets (specified in bullets/second).
        /// </summary>
        double FireRate { get; protected set; }

        /// <summary>
        /// The target of the turret.
        /// </summary>
        IEnemy? Target { get; set; }

        /// <summary>
        /// The price of the turret.
        /// </summary>
        int Price { get; protected set; }

        /// <summary>
        /// Creates a clone of the turret.
        /// </summary>
        /// <returns>the cloned <see cref="ITurret"/></returns>
        ITurret GetClone();
    }
}