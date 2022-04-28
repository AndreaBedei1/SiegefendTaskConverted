namespace OOP21_task_cSharp.Notaro
{
    /// <summary>
    /// Represents a single tile on the Map.
    /// </summary>
    interface ITile
    {
        /// <summary>
        /// Every tile has a propery that describes its type (grass, path, water...).
        /// </summary>
        public TileType TileType { get; set; }
        /// <summary>
        /// Every tile has a property that denotes the Direction of movement. If there is none, it can contain a null value.
        /// </summary>
        public Direction? TileDirection { get; set; }
        /// <summary>
        /// This method denotes whether a Turret can be placed on the current tile.
        /// </summary>
        /// <returns></returns>
        bool CanContainTurret();
    }
}
