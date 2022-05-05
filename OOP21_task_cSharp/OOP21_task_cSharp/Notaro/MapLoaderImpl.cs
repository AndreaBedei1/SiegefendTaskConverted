using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OOP21_task_cSharp.Notaro
{
    /// <summary>
    /// This is a class of utility that reads a matrix from file which represents the Map structure. 
    /// After that, it can fill correctly the map implementation field that links every GridPosition
    /// to the correspondent Tile.
    /// </summary>
    public class MapLoaderImpl : IMapLoader
    {
        private IMap _map;
        private Dictionary<int, TileType> _numbersToTypesConverter;
        private int _mapRows;   // When reading will be over, it will contain the map size.
        private bool _isSetStart, _isSetEnd;    // Boolean variables to check the given map integrity (has start tile and end tile).

        public IMap Map => _map;

        /// <summary>
        /// Simple constructor that initializes the fields.
        /// </summary>
        /// <param name="levelId">Denotes, according to the Level, which map file has to be loaded.</param>
        public MapLoaderImpl(int levelId)
        {
            _map = new MapImpl();
            _numbersToTypesConverter = new Dictionary<int, TileType>();
            _mapRows = 0;
            CreatesLink();
            ReadMapStructureFromFile(levelId);  // Method that reads map structure from file and create the correspondent map.
            FindMovementPath(); // Method that fills the field Direction in every tile.
        }

        // Method that links every integer number with the correspondent tile type.
        private void CreatesLink()
        {
            _numbersToTypesConverter.Add(0, TileType.Grass);
            _numbersToTypesConverter.Add(1, TileType.Path);
            _numbersToTypesConverter.Add(2, TileType.Water);
            _numbersToTypesConverter.Add(3, TileType.StartPath);
            _numbersToTypesConverter.Add(4, TileType.EndPath);
        }
        // This method is the file effective reader.
        private void ReadMapStructureFromFile(int fileNumber)
        {
            try
            {
                string? dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string file = dir + @"..\..\..\..\Notaro\mapLevel"+fileNumber+".txt";

                using (StreamReader sr = new StreamReader(file))
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Read(line);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            _map.Size = _mapRows;
            if (!_isSetStart || !_isSetEnd) // If the file .txt has no 3 or 4 (start or end tile).
            {       
                throw new Exception("Given matrix has no start or end tile!");
            }

            long numberOfPathTiles = _map.Tiles.Values.AsEnumerable().Count(x => x.TileType == TileType.Path);
            if (numberOfPathTiles == 0)
            {
                throw new Exception("Given matrix has no path!");
            }
        }
        // Method that works on every row read from file to obtain the effective values and convert them into tiles.
        private void Read(string line)
        {
            string[] arrayRead = line.Split(" ");
            int column = 0;
            List<string> lineRead = new List<string>(arrayRead);
            foreach (string element in lineRead)
            {
                int value = int.Parse(element);
                if (value > 4)
                {
                    throw new Exception("Incorrect number read in map file!");  // Check number read consistency.
                }
                if (value == 3)
                {
                    _map.StartTile = new GridPosition(_mapRows, column);
                    _isSetStart = true;
                } else if (value == 4)
                {
                    _map.EndTile = new GridPosition(_mapRows, column);
                    _isSetEnd = true;
                }
                _map.Tiles.Add(new GridPosition(_mapRows, column), new TileImpl(_numbersToTypesConverter[value]));
                column++;
            }
            _mapRows++;
        }
        // Method that, by observing the path, fills the field Direction of every tiles in the path.
        private void FindMovementPath()
        {
            GridPosition currentTile = _map.StartTile;  // This algorithm starts from the start of the path.
            HashSet<GridPosition> tilesAlreadyChecked = new HashSet<GridPosition>();    // Contains the tiles already checked, so that we can ignore them.
            Direction? lastDirection = null;    // It saves the last direction set, so we can have the direction also for the very last tile of the path.

            // For every tile of the path we check its neighbors to find which one is path. Then, by a simple compare we can set up the field direction of every path tile.
            while (!currentTile.Equals(_map.EndTile))
            {
                foreach(var neighbor in FindNeighbors(currentTile))
                {
                    // For every neighbor tile that has not been already checked we check if its type is Path.
                    if (!tilesAlreadyChecked.Contains(neighbor.Key) && IsPath(neighbor.Key))
                    {
                        // We found the next tile. So we have to set the direction of the current tile and update the list of already checked tiles.
                        _map.Tiles[currentTile].TileDirection = neighbor.Value;
                        tilesAlreadyChecked.Add(currentTile);
                        currentTile = neighbor.Key;
                        lastDirection = neighbor.Value;
                        break;
                    }
                }
            }
            _map.Tiles[_map.EndTile].TileDirection = lastDirection; // Also the very last tile direction is set.
        }
        // Method that calculates the neighbors of a given grid position and fill a map with the corresponding direction.
        private Dictionary<GridPosition, Direction> FindNeighbors(GridPosition currentTile)
        {
            int row = currentTile.Row;
            int column = currentTile.Column;
            Dictionary<GridPosition, Direction> result = new Dictionary<GridPosition, Direction>();
            result.Add(new GridPosition(row - 1, column), Direction.Up);
            result.Add(new GridPosition(row, column + 1), Direction.Right);
            result.Add(new GridPosition(row + 1, column), Direction.Down);
            result.Add(new GridPosition(row, column - 1), Direction.Left);
            return result;
        }
        // Method that checks if a given grid position is acceptable (if is into matrix size limits) and if it corresponds to a path tile.
        private bool IsPath(GridPosition tile)
        {
            int row = tile.Row;
            int column = tile.Column;

            // If given grid position isn't into the map's size limits.
            if (row < 0 || column < 0 || row >= _map.Size || column >= _map.Size)
            {
                return false;
            }
            else
            {
                // Checks if its type is path.
                TileType type = _map.Tiles[tile].TileType;
                return (type != TileType.Water && type != TileType.Grass);
            }
        }
    }
}