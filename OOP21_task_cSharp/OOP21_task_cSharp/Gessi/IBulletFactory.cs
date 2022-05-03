using OOP21_task_cSharp.Bedei;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_task_cSharp.Gessi
{
    /// <summary>
    /// Creates instances of the IBullet interface.
    /// </summary>
    public interface IBulletFactory
    {
        /// <summary>
        /// Creates a new IBullet instance with an initial position, target and other parameters.
        /// </summary>
        /// <param name="id">the id of the bullet</param>
        /// <param name="speed">the speed of the bullet</param>
        /// <param name="startPosition">the initial position of the bullet</param>
        /// <param name="damage">the damage of the bullet</param>
        /// <param name="enemyTarget">the target of the bullet</param>
        /// <returns>an IBullet instance</returns>
        IBullet CreateBullet(int id, double speed, Position startPosition, double damage, IEnemy enemyTarget);
    }
}
