using UnityEngine;

namespace ZozoEngine
{
    /// <summary>
    /// Represents a two dimensional line segment bounded by two points.
    /// </summary>
    public readonly struct Line
    {
        /// <summary>
        /// Creates a new line for the given points.
        /// </summary>
        /// <param name="start">The start point of the line.</param>
        /// <param name="end">The end point of the line.</param>
        public Line(Vector2Int start, Vector2Int end)
        {
            Start = start;
            End = end;
        }

        /// <summary>
        /// The start point of the line.
        /// </summary>
        public Vector2Int Start { get; }

        /// <summary>
        /// The end point of the line.
        /// </summary>
        public Vector2Int End { get; }

        /// <summary>
        /// Calculates the slope of the line.
        /// </summary>
        public float CalculateSlope()
        {
            var delta = End - Start;
            return delta.y / (float)delta.x;
        }

        /// <summary>
        /// Gets an enumerator that iterates over all point along a line.
        /// </summary>
        /// <returns>An enumerator that iterates over all points along a line.</returns>
        public LineEnumerator GetEnumerator() => new(this);
    }
}