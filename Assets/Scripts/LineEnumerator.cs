using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZozoEngine
{
    /// <summary>
    /// Iterates over all the positions along a line using Bresenham's line algorithm.
    /// </summary>
    public struct LineEnumerator : IEnumerator<Vector2Int>
    {
        private readonly Line _line;
        private readonly int _dx;
        private readonly int _dy;
        private readonly int _sx;
        private readonly int _sy;
        private int _err;
        private Vector2Int _current;
        private bool _isReset;

        /// <summary>
        /// Creates a new enumerator that iterates over all positions along the line.
        /// </summary>
        /// <param name="line">The line to enumerate.</param>
        /// <returns>An enumerator that will iterate over all positions along the line.</returns>
        public LineEnumerator(Line line)
        {
            _line = line;
            _dx = Mathf.Abs(_line.End.x - _line.Start.x);
            _dy = Mathf.Abs(_line.End.y - _line.Start.y);
            _sx = _line.Start.x < _line.End.x ? 1 : -1;
            _sy = _line.Start.y < _line.End.y ? 1 : -1;

            _err = default;
            _current = default;
            _isReset = default;

            Reset();
        }

        /// <summary>
        /// The current position the enumerator is iterating over.
        /// </summary>
        public Vector2Int Current => _current;

        /// <summary>
        /// The current position the enumerator is iterating over.
        /// </summary>
        object IEnumerator.Current => Current;

        /// <summary>
        /// Advances the enumerator to the next position along the line.
        /// </summary>
        /// <returns>True if the enumerator still has positions to iterate over.</returns>
        public bool MoveNext()
        {
            if (_isReset)
            {
                _isReset = false;
                return true;
            }

            if (_current.x == _line.End.x && _current.y == _line.End.y)
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
            _current = _line.Start;
            _isReset = true;
        }

        public void Dispose()
        {
        }
    }
}