namespace OOP21_task_cSharp.Notaro
{
    /// <summary>
    /// Describes the various and different types of a Tile in the Map.
    /// </summary>
    enum TileType
    {
        /// <summary>
        /// This type denotes that the Tile is the beginning of the path, that is the
        /// tile from which the enemies will appear.
        /// </summary>
        StartPath,
        /// <summary>
        /// This type denotes that the Tile composes the path.
        /// </summary>
        Path, 
        /// <summary>
        /// This type denotes that the Tile represents the end of the path, that is 
        /// the tile in which the enemies will disappear.
        /// </summary>
        EndPath,
        /// <summary>
        /// This type denotes that on the Tile there is grass, so you can place a Turret on it.
        /// </summary>
        Grass,
        /// <summary>
        /// This type denotes that the Tile is made of water, so you cannot place a Turret on it.
        /// </summary>
        Water
    }
}