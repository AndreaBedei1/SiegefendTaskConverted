using OOP21_task_cSharp.Bedei;

namespace OOP21_task_cSharp.Gessi
{
    /// <summary>
    /// Interface that represents a bullet.
    /// </summary>
    public interface IBullet
    {
        /// <summary>
        /// The id of the bullet.
        /// </summary>
        int ID { get; protected set; }

        /// <summary>
        /// The speed of the bullet.
        /// </summary>
        double Speed { get; protected set; }

        /// <summary>
        /// The bullet's position.
        /// </summary>
        Position Position { get; set; }

        /// <summary>
        /// The target's position.
        /// </summary>
        Position TargetPosition { get; }

        /// <summary>
        /// The bullet's damage.
        /// </summary>
        double Damage { get; protected set; }

        /// <summary>
        /// The target of the bullet.
        /// </summary>
        IEnemy Target { get; protected set; }

        /// <summary>
        /// Moves the bullet to the given coordinate.
        /// </summary>
        /// <param name="x">the new x coordinate</param>
        /// <param name="y">the new y coordinate</param>
        void Move(double x, double y);
    }
}
