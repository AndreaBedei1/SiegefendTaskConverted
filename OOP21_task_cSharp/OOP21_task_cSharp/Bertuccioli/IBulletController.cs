using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_task_cSharp.Bertuccioli
{
    /// <summary>
    /// Manages the BulletView.
    /// </summary>
    public interface IBulletController : IController
    {
        /// <summary>
        /// Adds a bullet that can be shown in the view.
        /// </summary>
        /// <param name="bullet">the bullet that we want to add</param>
        void AddBullet(IBullet bullet);

        /// <summary>
        /// Removes a certain bullet from the view.
        /// </summary>
        /// <param name="bulletManager">the manager of the bullet</param>
        void RemoveBullet(BulletManager bulletManager);

        /// <summary>
        /// Returns an iterator of all bullets currently active.
        /// </summary>
        /// <returns>an iterator of bullets</returns>
        IEnumerator<IBullet> GetBulletsIterator();
    }
}
