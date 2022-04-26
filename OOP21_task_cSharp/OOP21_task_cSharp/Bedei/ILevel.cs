using System.Collections.Generic;

namespace OOP21_task_cSharp.Bedei
{
    /// <summary>
    /// Represents a level of play.
    /// </summary>
    public interface ILevel
    {
        /// <summary>
        /// Returns a list containing all the waves of enemies in the level.
        /// </summary>
        public List<IWave> Waves { get; }

        /// <summary>
        /// Simple getter for the field that contains the Level ID.
        /// </summary>
        public int LevelId { get; }

        /// <summary>
        /// The number of Wave.
        /// </summary>
        public int NumberOfWaves { get; }
    }
}
