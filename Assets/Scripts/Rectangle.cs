using UnityEngine;

namespace ZozoEngine
{
    /// <summary>
    /// Represents a two dimensional four sided polygon where equal opposites sides.
    /// </summary>
    public readonly struct Rectangle
    {
        /// <summary>
        /// Create a new rectangle for the given start and end positions.
        /// </summary>
        /// <param name="start">The start position of the rectangle.</param>
        /// <param name="end">The end size of the rectangle.</param>
        public Rectangle(Vector2Int start, Vector2Int end)
        {
            Minimum = Vector2Int.Min(start, end);
            Maximum = Vector2Int.Max(start, end);
        }

        /// <summary>
        /// The minimum (bottom left) position of the rectangle.
        /// </summary>
        public Vector2Int Minimum { get; }

        /// <summary>
        /// The maximum (top right) position of the rectangle.
        /// </summary>
        public Vector2Int Maximum { get; }

        /// <summary>
        /// Gets an enumerator that iterates over all positions inside a rectangle.
        /// </summary>
        /// <returns>An enumerator that iterates over all positions inside a rectangle.</returns>
        public RectangleEnumerator GetEnumerator() => new(this);
    }
}