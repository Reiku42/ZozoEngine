using System.Collections;
using System.Collections.Generic;

namespace ZozoEngine
{
    /// <summary>
    /// Iterates through all of the cells in a map. It starts at the origin (0,0)
    /// then moves along the x axis before moving along the y axis. 
    /// </summary>
    public struct MapEnumerator : IEnumerator<Cell>
    {
        private readonly Map _map;
        private int _x;
        private int _y;

        /// <summary>
        /// Creates a new enumerator for the given map with cells to iterate over.
        /// </summary>
        /// <param name="map">The map with cells to iterate over.</param>
        public MapEnumerator(Map map)
        {
            _map = map;
            _x = 0;
            _y = 0;
            Reset();
        }

        /// <summary>
        /// The current cell the enumerator is iterating over.
        /// </summary>
        public Cell Current => _map.GetCell(_x, _y);

        /// <summary>
        /// The current cell the enumerator is iterating over.
        /// </summary>
        object IEnumerator.Current => Current;

        /// <summary>
        /// Advances the enumerator to the next cell in the map.
        /// </summary>
        /// <returns>True if the enumerator still has cells to iterate over.</returns>
        public bool MoveNext()
        {
            _x++;

            // ReSharper disable once InvertIf
            if (_x >= _map.Width)
            {
                _x = 0;
                _y++;
            }

            return _y < _map.Height;
        }

        /// <summary>
        /// Resets the enumerator to the origin cell of the map.
        /// </summary>
        public void Reset()
        {
            _x = -1;
            _y = 0;
        }

        public void Dispose()
        {
        }
    }
}