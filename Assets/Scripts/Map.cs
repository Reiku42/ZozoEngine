using System.Collections.Generic;
using UnityEngine;

namespace ZozoEngine
{
    /// <summary>
    /// Map represents a rectangular grid of cells.
    /// </summary>
    public sealed class Map
    {
        private readonly Cell[,] _cells;

        /// <summary>
        /// Creates a new map with the given size.
        /// </summary>
        /// <param name="size">The width and height of the map.</param>
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
        public ref Cell this[Vector2Int position] => ref GetCell(position);

        /// <summary>
        /// The size of the map.
        /// </summary>
        public Vector2Int Size { get; }

        /// <summary>
        /// Gets the cell at the given position.
        /// </summary>
        /// <param name="position">The position of the cell to get.</param>
        /// <returns>The cell at the given position</returns>
        public ref Cell GetCell(Vector2Int position)
        {
            return ref _cells[position.x, position.y];
        }

        /// <summary>
        /// Checks if the given position is within the bounds of the map.
        /// </summary>
        /// <param name="position">The position to check.</param>
        /// <returns>True if the position is within the bounds of the map.</returns>
        public bool IsInBounds(Vector2Int position)
        {
            if (position.x < 0)
            {
                return false;
            }

            if (position.x >= Size.x)
            {
                return false;
            }

            if (position.y < 0)
            {
                return false;
            }

            if (position.y >= Size.y)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if the cell at the given position can be walked through by a character.
        /// </summary>
        /// <param name="position">The position of the cell to check.</param>
        /// <returns>True if a character can walk through the cell at the given position.</returns>
        public bool IsWalkable(Vector2Int position)
        {
            return _cells[position.x, position.y].IsWalkable;
        }

        /// <summary>
        /// Checks if the cell at the given position can be seen through by a character.
        /// </summary>
        /// <param name="position">The position of the cell to check.</param>
        /// <returns>True if a character can see through the cell at the given position.</returns>
        public bool IsTransparent(Vector2Int position)
        {
            return _cells[position.x, position.y].IsTransparent;
        }

        /// <summary>
        /// Enumerates all cells in the map.
        /// </summary>
        /// <returns>An enumerator that will iterate over every cell in the map.</returns>
        public MapEnumerator GetAllCells()
        {
            return new MapEnumerator(this);
        }

        /// <summary>
        /// Enumerates the cells along a line in the map.
        /// </summary>
        /// <param name="start">The start position of the line.</param>
        /// <param name="end">The end position of the line.</param>
        /// <returns>An enumerator that will iterate over every cell along a line int he map.</returns>
        public IEnumerable<Cell> GetLine(Vector2Int start, Vector2Int end)
        {
            var originX = Mathf.Clamp(start.x, 0, Size.x - 1);
            var originY = Mathf.Clamp(start.y, 0, Size.y - 1);

            var destinationX = Mathf.Clamp(end.x, 0, Size.x - 1);
            var destinationY = Mathf.Clamp(end.y, 0, Size.y - 1);

            var dx = Mathf.Abs(end.x - start.x);
            var dy = Mathf.Abs(end.y - start.y);

            var sx = start.x < end.x ? 1 : -1;
            var sy = start.y < end.y ? 1 : -1;

            var err = dx - dy;

            while (true)
            {
                var current = new Vector2Int(originX, originY);
                yield return GetCell(current);

                if (originX == destinationX && originY == destinationY)
                {
                    break;
                }

                var e2 = 2 * err;

                if (e2 > -dy)
                {
                    err -= dy;
                    originX += sx;
                }

                // ReSharper disable once InvertIf
                if (e2 < dx)
                {
                    err += dx;
                    originY += sy;
                }
            }
        }
    }
}