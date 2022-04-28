using OOP21_task_cSharp.Bedei;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_task_cSharp.Bertuccioli
{
    public interface ITurret
    {
        /// <summary>
        /// Returns the ID of the turret.
        /// </summary>
        /// <returns>the ID of the turret</returns>
        int GetID();

        /// <summary>
        /// </summary>
        /// Returns the {@link Position} of the turret.
        /// <returns>the position of the turret</returns>
        Position GetPosition();

        /// <summary>
        /// Sets a new position for the turret.
        /// </summary>
        /// <param name="p">the new position</param>
        void SetPosition(Position p);

        /// <summary>
        /// Returns the range of the turret. <br />
        /// The turret can only target enemies whose distance from the tower is less than its range.
        /// </summary>
        /// <returns>the range of the turret</returns>
        double GetRange();

        /// <summary>
        /// Returns the angle of the turret.
        /// </summary>
        /// <returns>the angle</returns>
        double GetAngle();
 
        /// <summary>
        /// Sets the angle of the turret.
        /// </summary>
        /// <param name="angle">the angle</param>
        void SetAngle(double angle);

        /// <summary>
        /// Sets the state of the turret.
        /// </summary>
        /// <param name="state">the new state of the turret</param>
        void SetState(bool state);

        /// <summary>
        /// </summary>
        /// Checks whether the turret is attacking an <see cref="IEnemy"/> or not.
        /// <returns>true if it's attack an enemy, false otherwise</returns>
        bool IsAttacking();

        /// <summary>
        /// Creates a new bullet that attacks the targeted enemy.
        /// </summary>
        /// <returns>an instance of <see cref="IBullet"/></returns>
        IBullet CreateBullet();

        /// <summary>
        /// Returns the speed at which the turret fires bullets (specified in bullets/second).
        /// </summary>
        /// <returns>the fire rate of the turret</returns>
        double GetFireRate();

        /// <summary>
        /// Returns the target of the turret.
        /// </summary>
        /// <returns>an <see cref="IEnemy"/> if present, null otherwise</returns>
        IEnemy? GetTarget();

        /// <summary>
        /// Sets the target of the turret.
        /// </summary>
        /// <param name="target">the target</param>
        void SetTarget(IEnemy target);

        /// <summary>
        /// Returns the price of the turret.
        /// </summary>
        /// <returns>the price of the turret</returns>
        int GetPrice();

        /// <summary>
        /// Creates a clone of the turret.
        /// </summary>
        /// <returns>the cloned <see cref="ITurret"/></returns>
        ITurret GetClone();
    }
}
