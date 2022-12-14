using UnityEngine;

namespace ZozoEngine
{
    /// <summary>
    /// Represents a two dimensional four sided polygon where equal opposites sides.
    /// </summary>
    public readonly struct Rectangle
    {
        /// <summary>
        /// Create a new rectangle for the given position and size.
        /// </summary>
        /// <param name="position">The position of the rectangle.</param>
        /// <param name="size">The size of the rectangle.</param>
        public Rectangle(Vector2Int position, Vector2Int size)
        {
            var delta = position + size;

            Minimum = Vector2Int.Min(position, delta);
            Maximum = Vector2Int.Max(position, delta);
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