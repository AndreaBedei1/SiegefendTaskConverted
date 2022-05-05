using OOP21_task_cSharp.Bedei;
using System;

namespace OOP21_task_cSharp.Gessi
{
    /// <summary>
    /// Implementation of a bullet that follows a target.
    /// </summary>
    public class Bullet : IBullet
    {
        /// <summary>
        /// Creates a new instance of Bullet.
        /// </summary>
        /// <param name="id">the id of the bullet</param>
        /// <param name="speed">the speed of the bullet</param>
        /// <param name="position">the initial position of the bullet</param>
        /// <param name="damage">the damage of the bullet</param>
        /// <param name="target">the target of the bullet</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Bullet(int id, double speed, Position position, double damage, IEnemy target)
        {
            ID = id;
            Speed = speed;
            Position = new Position(position);
            Damage = damage;

            if(target == null)
            {
                throw new ArgumentNullException("Target must not be null!");
            }
            else
            {
                Target = target;
            }
        }
        public int ID { get; set; }

        public double Speed { get; set; }

        public Position Position { get; set; }

        public Position TargetPosition { get => Target.Position; }

        public double Damage { get; set; }

        public IEnemy Target { get; set; }

        public void Move(double x, double y)
        {
            Position.SetCoordinates(x, y);
        }
    }
}
