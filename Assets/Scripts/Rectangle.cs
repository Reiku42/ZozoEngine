using UnityEngine;

namespace ZozoEngine
{
    /// <summary>
    /// Represents a two dimensional four sided polygon where opposites sides have equal length.
    /// </summary>
    public readonly struct Rectangle
    {
        /// <summary>
        /// Creates a new rectangle for the given points.
        /// </summary>
        /// <param name="a">The first point of the rectangle.</param>
        /// <param name="b">The second point of the rectangle.</param>
        public Rectangle(Vector2Int a, Vector2Int b)
        {
            Minimum = Vector2Int.Min(a, b);
            Maximum = Vector2Int.Max(a, b);
        }

        /// <summary>
        /// The minimum (bottom left) point of the rectangle.
        /// </summary>
        public Vector2Int Minimum { get; }

        /// <summary>
        /// The maximum (top right) point of the rectangle.
        /// </summary>
        public Vector2Int Maximum { get; }

        /// <summary>
        /// Checks if the given point is inside the rectangle.
        /// </summary>
        /// <param name="point">The point to check.</param>
        /// <returns>True if the point is inside the rectangle.</returns>
        public bool Contains(Vector2Int point)
        {
            return point.x >= Minimum.x && point.x < Maximum.x && point.y >= Minimum.y && point.y < Maximum.y;
        }

        /// <summary>
        /// Clamps the given point so it is inside the rectangle.
        /// </summary>
        /// <param name="point">The point to clamp.</param>
        /// <returns>The point clamped to the inside of the rectangle.</returns>
        public Vector2Int Clamp(Vector2Int point)
        {
            var x = Mathf.Clamp(point.x, 0, Maximum.x);
            var y = Mathf.Clamp(point.y, 0, Maximum.y);
            return new Vector2Int(x, y);
        }

        /// <summary>
        /// Gets an enumerator that iterates over all points inside a rectangle.
        /// </summary>
        /// <returns>An enumerator that iterates over all points inside a rectangle.</returns>
        public RectangleEnumerator GetEnumerator() => new(this);
    }
}