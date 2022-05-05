using System;

namespace OOP21_task_cSharp.Notaro
{
    /// <summary>
    /// Represents a pair of integer coordinates on a grid (row and column).
    /// </summary>
    public class GridPosition
    {
        public int Row { get; set; }
        public int Column { get; set; }

        /// <summary>
        /// Basic constructor.
        /// </summary>
        /// <param name="row">The coordinate as row in the grid.</param>
        /// <param name="column">The coordinate as column in the grid.</param>
        public GridPosition(int row, int column)
        {
            Row = row;
            Column = column;
        }

        /// <summary>
        /// Creates a new instance of <see cref="GridPosition"/> from another instance of GridPosition.
        /// </summary>
        /// <param name="gpos">the instance of GridPosition to copy</param>
        public GridPosition(GridPosition gpos) : this(gpos.Row, gpos.Column) { }

        /// <summary>
        /// Sets new values for both the column and row of the position.
        /// </summary>
        /// <param name="row">The new value for the row.</param>
        /// <param name="column">The new value for the column.</param>
        public void SetCoordinates(int row, int column)
        {
            Row = row;
            Column = column;
        }

        // Standard methods to compare grid positions.
        public override bool Equals(object? obj)
        {
            if (this == obj) 
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }
            return obj is GridPosition position &&
                   Row == position.Row &&
                   Column == position.Column;
        }
        public override int GetHashCode() => HashCode.Combine(Row, Column);
        public override string ToString() => @"GridPosition [column = {Column}, row = {Row}]";
    }
}
