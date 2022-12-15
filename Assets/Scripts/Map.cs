using UnityEngine;

namespace ZozoEngine
{
    /// <summary>
    /// Represents a rectangular grid of cells.
    /// </summary>
    public sealed class Map
    {
        private readonly Cell[,] _cells;

        /// <summary>
        /// Creates a new map with the given size.
        /// </summary>
        /// <param name="size">The size of the map.</param>
        public Map(Vector2Int size)
        {
            var minimum = Vector2Int.zero;
            var maximum = size - Vector2Int.one;
            Bounds = new Rectangle(minimum, maximum);

            _cells = new Cell[size.x, size.y];

            for (var y = 0; y < size.y; y++)
            {
                for (var x = 0; x < size.x; x++)
                {
                    var position = new Vector2Int(x, y);
                    _cells[x, y] = new Cell(position);
                }
            }
        }

        /// <summary>
        /// Gets the cell at the given position.
        /// </summary>
        /// <param name="position">The position of the cell to get.</param>
        public ref Cell this[Vector2Int position] => ref _cells[position.x, position.y];

        /// <summary>
        /// The bounds of the map.
        /// </summary>
        public Rectangle Bounds { get; }

        /// <summary>
        /// Checks if a character is capable of walking through the cell at the given position.
        /// </summary>
        /// <param name="position">The position of the cell to check.</param>
        /// <returns>True if a character is capable of walking through the cell.</returns>
        public bool IsWalkable(Vector2Int position)
        {
            return _cells[position.x, position.y].IsWalkable;
        }

        /// <summary>
        /// Checks if a character has a clear line-of-sight through the cell at the given position.
        /// </summary>
        /// <param name="position">The position of the cell to check.</param>
        /// <returns>True if a character has a clear line-of-sight through the cell.</returns>
        public bool IsTransparent(Vector2Int position)
        {
            return _cells[position.x, position.y].IsTransparent;
        }
    }
}