using UnityEngine;

namespace ZozoEngine
{
    /// <summary>
    /// Holds data for a single position on a map.
    /// </summary>
    public struct Cell
    {
        /// <summary>
        /// Creates a new cell for the given position.
        /// </summary>
        /// <param name="position">The position of the cell.</param>
        public Cell(Vector2Int position)
        {
            Position = position;
            IsWalkable = false;
            IsTransparent = false;
        }

        /// <summary>
        /// The position of the cell.
        /// </summary>
        public Vector2Int Position { get; }

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