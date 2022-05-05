using OOP21_task_cSharp.Gessi;

namespace OOP21_task_cSharp.Bertuccioli
{
    /// <summary>
    /// Interface of bullet Manager.
    /// </summary>
    public interface IBulletManager
    {
        /// <summary>
        /// Returns the <see cref="IBullet"/> associated with the bullet manager.
        /// </summary>
        IBullet Bullet { get; }

        /// <summary>
        /// Eliminates the <see cref="IBullet"/> associated with this instance.
        /// </summary>
        void Eliminate();
    }

}
