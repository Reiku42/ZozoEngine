using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZozoEngine
{
    public struct RectangleEnumerator : IEnumerator<Vector2Int>
    {
        private readonly Rectangle _rectangle;
        private Vector2Int _current;

        public RectangleEnumerator(Rectangle rectangle)
        {
            _rectangle = rectangle;
            _current = default;
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
        /// Advances the enumerator to the next position inside the rectangle.
        /// </summary>
        /// <returns>True if the enumerator still has positions to iterate over.</returns>
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

        public void Reset()
        {
            _current = _rectangle.Minimum + new Vector2Int(-1, 0);
        }

        public void Dispose()
        {
        }
    }
}