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
        /// <param name="width">The width of the map.</param>
        /// <param name="height">The height of the map.</param>
        public Map(int width, int height)
        {
            Width = width;
            Height = height;

            _cells = new Cell[width, height];

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    _cells[x, y] = new Cell(x, y);
                }
            }
        }

        /// <summary>
        /// Creates a new map with the given size.
        /// </summary>
        /// <param name="size">The width and height of the map.</param>
        public Map(Vector2Int size)
            : this(size.x, size.y)
        {
        }

        /// <summary>
        /// Gets the cell at the given position.
        /// </summary>
        /// <param name="x">The x position of the cell to get.</param>
        /// <param name="y">The y position of the cell to get.</param>
        public ref Cell this[int x, int y] => ref _cells[x, y];

        /// <summary>
        /// Gets the cell at the given position.
        /// </summary>
        /// <param name="position">The position of the cell to get.</param>
        public ref Cell this[Vector2Int position] => ref this[position.x, position.y];

        /// <summary>
        /// The width of the map.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// The height of the map.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// The size of the map.
        /// </summary>
        public Vector2Int Size => new(Width, Height);

        /// <summary>
        /// Gets the cell at the given position.
        /// </summary>
        /// <param name="x">The x position of the cell to get.</param>
        /// <param name="y">The y position of the cell to get.</param>
        /// <returns>The cell at the given position</returns>
        public ref Cell GetCell(int x, int y)
        {
            return ref _cells[x, y];
        }

        /// <summary>
        /// Gets the cell at the given position.
        /// </summary>
        /// <param name="position">The position of the cell to get.</param>
        /// <returns>The cell at the given position</returns>
        public ref Cell GetCell(Vector2Int position)
        {
            return ref GetCell(position.x, position.y);
        }

        /// <summary>
        /// Checks if the given position is within the bounds of the map.
        /// </summary>
        /// <param name="x">The x position to check.</param>
        /// <param name="y">The y position to check.</param>
        /// <returns>True if the position is within the bounds of the map.</returns>
        public bool IsInBounds(int x, int y)
        {
            if (x < 0)
            {
                return false;
            }

            if (x >= Width)
            {
                return false;
            }

            if (y < 0)
            {
                return false;
            }

            if (y >= Height)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if the given position is within the bounds of the map.
        /// </summary>
        /// <param name="position">The position to check.</param>
        /// <returns>True if the position is within the bounds of the map.</returns>
        public bool IsInBounds(Vector2Int position)
        {
            return IsInBounds(position.x, position.y);
        }

        /// <summary>
        /// Checks if the cell at the given position can be walked through by a character.
        /// </summary>
        /// <param name="x">The x position of the cell to check.</param>
        /// <param name="y">The y position of the cell to check.</param>
        /// <returns>True if a character can walk through the cell at the given position.</returns>
        public bool IsWalkable(int x, int y)
        {
            return _cells[x, y].IsWalkable;
        }

        /// <summary>
        /// Checks if the cell at the given position can be walked through by a character.
        /// </summary>
        /// <param name="position">The position of the cell to check.</param>
        /// <returns>True if a character can walk through the cell at the given position.</returns>
        public bool IsWalkable(Vector2Int position)
        {
            return IsWalkable(position.x, position.y);
        }

        /// <summary>
        /// Checks if the cell at the given position can be seen through by a character.
        /// </summary>
        /// <param name="x">The x position of the cell to check.</param>
        /// <param name="y">The y position of the cell to check.</param>
        /// <returns>True if a character can see through the cell at the given position.</returns>
        public bool IsTransparent(int x, int y)
        {
            return _cells[x, y].IsTransparent;
        }

        /// <summary>
        /// Checks if the cell at the given position can be seen through by a character.
        /// </summary>
        /// <param name="position">The position of the cell to check.</param>
        /// <returns>True if a character can see through the cell at the given position.</returns>
        public bool IsTransparent(Vector2Int position)
        {
            return IsTransparent(position.x, position.y);
        }

        /// <summary>
        /// Enumerates all cells in the map.
        /// </summary>
        /// <returns>An enumerator that will iterate over every cell in the map.</returns>
        public MapEnumerator GetAllCells()
        {
            return new MapEnumerator(this);
        }
    }
}