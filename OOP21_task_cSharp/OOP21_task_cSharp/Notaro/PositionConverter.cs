using OOP21_task_cSharp.Bedei;

namespace OOP21_task_cSharp.Notaro
{
    /// <summary>
    /// Class for converting from Position to GridPosition and vice versa.
    /// </summary>
    public class PositionConverter
    {
        public int TileSize { get; }    // Property fundamental for the conversion process.

        /// <summary>
        /// Creates a new instance of the class with a certain Tile size, attribute useful for the conversion.
        /// </summary>
        /// <param name="tileSize">Is the size of a tile on the Map.</param>
        public PositionConverter(int tileSize)
        {
            TileSize = tileSize;
        }

        /// <summary>
        /// Converts a GridPosition to a Position.
        /// </summary>
        /// <param name="gridPosition">The GridPosition to convert.</param>
        /// <returns>the corresponding Position.</returns>
        public Position ConvertToPosition(GridPosition gridPosition)
        {
            return new Position(gridPosition.Column * TileSize, gridPosition.Row * TileSize);
        }
        /// <summary>
        /// Converts a Position to a GridPosition.
        /// </summary>
        /// <param name="position">The Position to convert.</param>
        /// <returns>the corresponding GridPosition.</returns>
        public GridPosition ConvertToGridPosition(Position position)
        {
            return new GridPosition((int)(position.Y / TileSize), (int)(position.X / TileSize));
        }
    }
}