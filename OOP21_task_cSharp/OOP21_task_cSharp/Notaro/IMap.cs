using System.Collections.Generic;

namespace OOP21_task_cSharp.Notaro
{
    /// <summary>
    /// Represents the game map. The map is made as a structure of logical matrix of tiles.
    /// </summary>
    interface IMap
    {
        /// <summary>
        /// The map has a field that contains the links between every GridPosition and its Tile. This property returns it.
        /// </summary>
        public Dictionary<GridPosition, ITile> Tiles { get; }
        /// <summary>
        /// The map has a property for its size, which is the number of tiles of each side.
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// The map has a property that describes the tile from which the enemies movement starts.
        /// </summary>
        public GridPosition StartTile { get; set; }
        /// <summary>
        /// The map has also a property that denotes which is the tile that represents the end of the enemies movement.
        /// </summary>
        public GridPosition EndTile { get; set; }
        /// <summary>
        /// This method helps getting a Tile from a GridPosition.
        /// </summary>
        /// <param name="position">Is the Position in the grid of the interested Tile.</param>
        /// <returns>the tile from the given grid position.</returns>
        ITile GetTileFromGridPosition(GridPosition position);
    }
}