using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZozoEngine
{
    /// <summary>
    /// Iterates over all of the cells along a line in a map.
    /// </summary>
    public struct MapLineEnumerator : IEnumerator<Cell>
    {
        private readonly Map _map;
        private readonly Vector2Int _start;
        private readonly Vector2Int _end;

        private readonly int _dx;
        private readonly int _dy;

        private readonly int _sx;
        private readonly int _sy;

        private int _err;

        private Vector2Int _current;
        private bool _isReset;

        /// <summary>
        /// Creates a new enumerator that iterates over the cells along a line in the given map.
        /// </summary>
        /// <param name="map">The map to enumerate.</param>
        /// <param name="start">The start position of the line.</param>
        /// <param name="end">The end position of the line.</param>
        /// <returns>An enumerator that will iterate over every cell along a line int he map.</returns>
        public MapLineEnumerator(Map map, Vector2Int start, Vector2Int end)
        {
            _map = map;

            _start = map.ClampToBounds(start);
            _end = map.ClampToBounds(end);

            _dx = Mathf.Abs(_end.x - _start.x);
            _dy = Mathf.Abs(_end.y - _start.y);

            _sx = _start.x < _end.x ? 1 : -1;
            _sy = _start.y < _end.y ? 1 : -1;

            _err = default;
            _current = default;
            _isReset = default;
            
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
        /// Gets an enumerator that iterates over every cell along the line in the map.
        /// </summary>
        /// <returns></returns>
        public MapLineEnumerator GetEnumerator() => this;

        /// <summary>
        /// Advances the enumerator to the next cell along the line in the map.
        /// </summary>
        /// <returns>True if the enumerator still has cells along the line to iterate over.</returns>
        public bool MoveNext()
        {
            if (_isReset)
            {
                _isReset = false;
                return true;
            }

            if (_current.x == _end.x && _current.y == _end.y)
            {
                return false;
            }

            var e2 = 2 * _err;

            if (e2 > -_dy)
            {
                _err -= _dy;
                _current.x += _sx;
            }

            // ReSharper disable once InvertIf
            if (e2 < _dx)
            {
                _err += _dx;
                _current.y += _sy;
            }

            return true;
        }

        public void Reset()
        {
            _err = _dx - _dy; 

            _current = _start;
            _isReset = true;
        }

        public void Dispose()
        {
        }
    }
}