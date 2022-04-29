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
        /// The total number of Wave in the Level.
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
        /// Checks if there is a next ave in the level.
        /// </summary>
        public bool NextWave { get; }

        /// <summary>
        /// riggers the spawning of a new Enemy, using the informations in the current Wave.
        /// </summary>
        public IEnemy? CurrentEnemy { get; }

        /// <summary>
        /// Checks if there is a following Wave in the Level.
        /// </summary>
        public bool NextEnemy { get; }
    }
}
