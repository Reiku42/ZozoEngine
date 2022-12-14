using UnityEngine;

namespace ZozoEngine
{
    /// <summary>
    /// Represents a two dimensional line segment bounded by a start and end position.
    /// </summary>
    public readonly struct Line
    {
        /// <summary>
        /// Creates a new line for the given start and end position.
        /// </summary>
        /// <param name="start">The start position of the line.</param>
        /// <param name="end">The end position of the line.</param>
        public Line(Vector2Int start, Vector2Int end)
        {
            Start = start;
            End = end;
        }

        /// <summary>
        /// The start position of the line.
        /// </summary>
        public Vector2Int Start { get; }

        /// <summary>
        /// The end position of the line.
        /// </summary>
        public Vector2Int End { get; }

        /// <summary>
        /// Calculates the slope of the line given the start and end positions.
        /// </summary>
        public float CalculateSlope()
        {
            var delta = End - Start;
            return delta.y / (float)delta.x;
        }

        /// <summary>
        /// Gets an enumerator that iterates over all positions along a line.
        /// </summary>
        /// <returns>An enumerator that iterates over all positions along a line.</returns>
        public LineEnumerator GetEnumerator() => new(this);
    }
}