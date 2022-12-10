using UnityEngine;

namespace ZozoEngine
{
    /// <summary>
    /// Cell holds data for a single spot on a map.
    /// </summary>
    public struct Cell
    {
        /// <summary>
        /// Creates a new cell for the given position.
        /// </summary>
        /// <param name="x">The x position of the cell.</param>
        /// <param name="y">The y position of the cell.</param>
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            IsWalkable = false;
            IsTransparent = false;
        }

        /// <summary>
        /// Creates a new cell for the given position.
        /// </summary>
        /// <param name="position">The position of the cell.</param>
        public Cell(Vector2Int position)
            : this(position.x, position.y)
        {
        }

        /// <summary>
        /// The x position of the cell.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// The y position of the cell.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// The position of the cell.
        /// </summary>
        public Vector2Int Position => new(X, Y);

        /// <summary>
        /// True if a character is capable of walking through this cell.
        /// </summary>
        public bool IsWalkable { get; set; }

        /// <summary>
        /// True if a character has a clear line-of-sight through this cell.
        /// </summary>
        public bool IsTransparent { get; set; }
    }
}