using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZozoEngine
{
    /// <summary>
    /// Iterates over all of the cells in a map. This enumerator starts at the origin (0, 0)
    /// of the map, first moving along the x axis before moving along the y axis. 
    /// </summary>
    public struct MapEnumerator : IEnumerator<Cell>
    {
        private readonly Map _map;
        private Vector2Int _current;

        /// <summary>
        /// Creates a new enumerator that iterates over all cells in the given map.
        /// </summary>
        /// <param name="map">The map to enumerate.</param>
        public MapEnumerator(Map map)
        {
            _map = map;

            _current = default;

            Reset();
        }

        /// <summary>
        /// The current cell the enumerator is iterating over.
        /// </summary>
        public Cell Current => _map.GetCell(_current);

        /// <summary>
        /// The current cell the enumerator is iterating over.
        /// </summary>
        object IEnumerator.Current => Current;

        /// <summary>
        /// Gets an enumerator that iterates over every cell in the map.
        /// </summary>
        /// <returns>An enumerator that iterates over every cell in the map.</returns>
        public MapEnumerator GetEnumerator() => this;
        
        /// <summary>
        /// Advances the enumerator to the next cell in the map.
        /// </summary>
        /// <returns>True if the enumerator still has cells to iterate over.</returns>
        public bool MoveNext()
        {
            _current.x++;

            // ReSharper disable once InvertIf
            if (_current.x >= _map.Size.x)
            {
                _current.x = 0;
                _current.y++;
            }

            return _current.y < _map.Size.y;
        }

        /// <summary>
        /// Resets the enumerator to the origin cell of the map.
        /// </summary>
        public void Reset()
        {
            _current = new Vector2Int(-1, 0);
        }

        public void Dispose()
        {
        }
    }
}