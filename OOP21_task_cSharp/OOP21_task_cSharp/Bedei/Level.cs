using System.Collections.Generic;

namespace OOP21_task_cSharp.Bedei
{
    public class LevelImpl : ILevel
    {
        private readonly List<IWave> _waves;
        private readonly int _levelID;
        public List<IWave> Waves => _waves;

        public int LevelId => _levelID;

        public int NumberOfWaves => _waves.Count;

        /// <summary>
        /// Creation of a level.
        /// </summary>
        /// <param name="waves">Are the waves in the level.</param>
        /// <param name="levelID">Is the Level ID.</param>
        public LevelImpl(List<IWave> waves, int levelID)
        {
            _waves = waves;
            _levelID = levelID;
        }
    }
}
