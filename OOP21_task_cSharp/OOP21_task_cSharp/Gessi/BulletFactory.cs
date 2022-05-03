using OOP21_task_cSharp.Bedei;

namespace OOP21_task_cSharp.Gessi
{
    /// <summary>
    /// Creates instances of the <see cref="IBullet"/> interface.
    /// </summary>
    public class BulletFactory : IBulletFactory
    {
        /// <summary>
        /// Creates a new <see cref="IBullet"/> instance with an initial position, target and other parameters.
        /// </summary>
        /// <param name="id">the id of the bullet (normally the id of the turret which fires it)</param>
        /// <param name="speed">the speed of the bullet</param>
        /// <param name="startPosition">the initial position of the bullet</param>
        /// <param name="damage">the damage of the bullet</param>
        /// <param name="enemyTarget">the target of the bullet</param>
        /// <returns>an <see cref="IBullet"/> instance</returns>
        public IBullet CreateBullet(int id, double speed, Position startPosition, double damage, IEnemy enemyTarget)
        {
            return new Bullet(id, speed, startPosition, damage, enemyTarget);
        }
    }
}
