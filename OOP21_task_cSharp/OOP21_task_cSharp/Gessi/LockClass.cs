using System.Threading;

namespace OOP21_task_cSharp.Gessi
{
    /// <summary>
    /// Class which contains semaphores shared by other classes.
    /// </summary>
    public class LockClass
    {
        private static readonly Semaphore ENEMY_SEMAPHORE = new Semaphore(1, 1);
        private static readonly Semaphore TURRET_SEMAPHORE = new Semaphore(1, 1);
        private static readonly Semaphore BULLET_SEMAPHORE = new Semaphore(1, 1);
        private LockClass() { }

        /// <summary>
        /// Returns the enemies' semaphore.
        /// </summary>
        /// <returns>the enemies' semaphore</returns>
        public static Semaphore GetEnemySemaphore()
        {
            return ENEMY_SEMAPHORE;
        }

        /// <summary>
        /// Returns the turrets' semaphore.
        /// </summary>
        /// <returns>the turrets' semaphore</returns>
        public static Semaphore GetTurretSemaphore()
        {
            return TURRET_SEMAPHORE;
        }

        /// <summary>
        /// Returns the bullets' semaphore.
        /// </summary>
        /// <returns>the bullets' semaphore</returns>
        public static Semaphore GetBulletSemaphore()
        {
            return BULLET_SEMAPHORE;
        }
    }
}