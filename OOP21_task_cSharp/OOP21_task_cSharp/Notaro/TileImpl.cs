namespace OOP21_task_cSharp.Notaro
{
    /// <summary>
    /// Class representing the implementation a Map's Tile.
    /// </summary>
    class TileImpl : ITile
    {
        private TileType _tileType; // Type of the tile (grass, water, path...).
        private Direction? _tileDirection;  // Field to be passed to the enemy for its movement.

        public TileType TileType { get => _tileType; set => _tileType = value; }
        public Direction? TileDirection { get => _tileDirection; set => _tileDirection = value; }

        /// <summary>
        /// Constructor for the creation of a Tile.
        /// </summary>
        /// <param name="tileType">Is the type that describes the tile.</param>
        public TileImpl(TileType tileType)
        {
            TileType = tileType;
            TileDirection = null;
        }

        public bool CanContainTurret() => TileType == TileType.Grass;
    }
}