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
        /// Gets an enumerator that iterates over all points inside a rectangle.
        /// </summary>
        /// <returns>An enumerator that iterates over all points inside a rectangle.</returns>
        public RectangleEnumerator GetEnumerator() => new(this);
    }
}