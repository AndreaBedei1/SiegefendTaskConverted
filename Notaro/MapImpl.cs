using System.Collections.Generic;

namespace OOP21_task_cSharp.Notaro
{
    /// <summary>
    /// This class represents a simple map logic with its grid structure. It's the implementation of the interface IMap.
    /// </summary>
    public class MapImpl : IMap
    {
        private int _size;  // Is the number of tiles that form a side of the grid.
        private readonly Dictionary<GridPosition, ITile> _tiles;    // Contains the links between all the grid positions and the correspondent tiles.
        private GridPosition _startTile, _endTile;  // Tiles useful to create and destroy enemies.

        public int Size { get => _size; set => _size = value; }
        public Dictionary<GridPosition, ITile> Tiles => _tiles;
        public GridPosition StartTile { get => _startTile; set => _startTile = value; }
        public GridPosition EndTile { get => _endTile; set => _endTile = value; }

        /// <summary>
        /// Simple constructor.
        /// </summary>
        public MapImpl()
        {
            _tiles = new Dictionary<GridPosition, ITile>();
        }

        public ITile GetTileFromGridPosition(GridPosition position) => Tiles[position];
    }
}