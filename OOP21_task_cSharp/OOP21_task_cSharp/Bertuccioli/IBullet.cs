using OOP21_task_cSharp.Bedei;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_task_cSharp.Bertuccioli
{
    /// <summary>
    /// Interface that represents a bullet.
    /// </summary>
    public interface IBullet
    {
        /// <summary>
        /// Returns the id of the bullet.
        /// </summary>
        /// <returns>the id of the bullet</returns>
        int GetID();

        /// <summary>
        /// Returns the speed of the bullet.
        /// </summary>
        /// <returns>the speed of the bullet</returns>
        double GetSpeed();

        /// <summary>
        /// Returns the bullet's position.
        /// </summary>
        /// <returns>the bullet's position</returns>
        Position GetPosition();

        /// <summary>
        /// Returns the target's position.
        /// </summary>
        /// <returns>the target's position</returns>
        Position GetTargetPosition();

        /// <summary>
        /// Returns the bullet's damage.
        /// </summary>
        /// <returns>the bullet's damage</returns>
        double GetDamage();

        /// <summary>
        /// Returns the target of the bullet.
        /// @return the target of the bullet
        /// </summary>
        IEnemy GetTarget();

        /// <summary>
        /// Moves the bullet to the given coordinate.
        /// </summary>
        /// <param name="x">the new x coordinate</param>
        /// <param name="y">the new y coordinate</param>
        void Move(double x, double y);
    }
}
