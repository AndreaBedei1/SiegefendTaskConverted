using System.Collections.Generic;

namespace OOP21_task_cSharp.Bedei
{
    /// <summary>
    /// Representation of a group of Enemy objects.
    /// </summary>
    public interface IWave
    {
        /// <summary>
        /// A list containing all the enemies in the wave.
        /// </summary>
        List<IEnemy> Wave { get; }
    }
}
