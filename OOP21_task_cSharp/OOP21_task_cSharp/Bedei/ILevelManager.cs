using OOP21_task_cSharp.Notaro;
using System.Collections.Generic;

namespace OOP21_task_cSharp.Bedei
{
    public interface ILevelManager
    {
        /// <summary>
        /// A list containing all the waves in the level.
        /// </summary>
        public List<IWave> Waves { get; }

        /// <summary>
        /// The map.
        /// </summary>
        public IMap Map { get; }

        /// <summary>
        /// The total number of Waves in the Level.
        /// </summary>
        public int TotalWaves { get; }

        /// <summary>
        /// The Level currently being played.
        /// </summary>
        public ILevel CurrentLevel { get; }

        /// <summary>
        /// The current Wave that is being played.
        /// </summary>
        public IWave? CurrentWave { get; }

        /// <summary>
        /// Checks if there is a next wave in the level.
        /// </summary>
        public bool NextWave { get; }

        /// <summary>
        /// Triggers the spawning of a new Enemy, using the informations in the current Wave.
        /// </summary>
        public IEnemy? CurrentEnemy { get; }

        /// <summary>
        /// Checks if there is a following Wave in the Level.
        /// </summary>
        public bool NextEnemy { get; }
    }
}
