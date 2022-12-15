using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZozoEngine
{
    public struct RectangleEnumerator : IEnumerator<Vector2Int>
    {
        private readonly Rectangle _rectangle;
        private Vector2Int _current;

        /// <summary>
        /// Creates a new enumerator that iterates over all points inside the given rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle to enumerate.</param>
        /// <returns>An enumerator that iterates over all points inside the given rectangle.</returns>
        public RectangleEnumerator(Rectangle rectangle)
        {
            _rectangle = rectangle;
            _current = default;
            Reset();
        }

        /// <summary>
        /// The current point the enumerator is iterating over.
        /// </summary>
        public Vector2Int Current => _current;

        /// <summary>
        /// The current point the enumerator is iterating over.
        /// </summary>
        object IEnumerator.Current => Current;

        /// <summary>
        /// Advances the enumerator to the next point inside the rectangle.
        /// </summary>
        /// <returns>True if the enumerator still has points to iterate over.</returns>
        public bool MoveNext()
        {
            _current.x++;

            if (_current.x > _rectangle.Maximum.x)
            {
                _current.x = _rectangle.Minimum.x;
                _current.y++;
            }

            return _current.y <= _rectangle.Maximum.y;
        }

        /// <summary>
        /// Resets the enumerator to the first point inside the rectangle.
        /// </summary>
        public void Reset()
        {
            _current = _rectangle.Minimum + new Vector2Int(-1, 0);
        }

        public void Dispose()
        {
        }
    }
}