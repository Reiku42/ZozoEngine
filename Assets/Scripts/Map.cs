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
            Size = size;

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
        /// The size of the map.
        /// </summary>
        public Vector2Int Size { get; }

        /// <summary>
        /// Gets an enumerator that iterates over all cells in the map.
        /// </summary>
        /// <returns>An enumerator that iterates over all cells in the map</returns>
        public MapEnumerator GetEnumerator() => new(this);

        /// <summary>
        /// Checks if the given position is within the bounds of the map.
        /// </summary>
        /// <param name="position">The position to check.</param>
        /// <returns>True if the position is within the bounds of the map.</returns>
        public bool IsInBounds(Vector2Int position)
        {
            return position.x >= 0 && position.x < Size.x && position.y >= 0 && position.y < Size.y;
        }

        /// <summary>
        /// Clamps the given position so it is contained within the bounds of the map.
        /// </summary>
        /// <param name="position">The position to clamp.</param>
        /// <returns>The position clamped to the bounds of the map.</returns>
        public Vector2Int ClampToBounds(Vector2Int position)
        {
            var x = Mathf.Clamp(position.x, 0, Size.x - 1);
            var y = Mathf.Clamp(position.y, 0, Size.y - 1);
            return new Vector2Int(x, y);
        }

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