using OOP21_task_cSharp.Notaro;
using System.Collections.Generic;

namespace OOP21_task_cSharp.Bedei
{
    public class LevelImpl : ILevel
    {
        public List<IWave> Waves { get; }

        public int LevelId { get; }

        public int NumberOfWaves => Waves.Count;

        public IMap Map { get; }

        /// <summary>
        /// Creation of a level.
        /// </summary>
        /// <param name="waves">Are the waves in the level.</param>
        /// <param name="levelID">Is the Level ID.</param>
        public LevelImpl(List<IWave> waves, int levelID, IMap map)
        {
            Waves = waves;
            LevelId = levelID;
            Map = map;
        }
    }
}
