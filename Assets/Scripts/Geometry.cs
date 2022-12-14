using System.Collections.Generic;
using UnityEngine;

namespace ZozoEngine
{
    public static class Geometry
    {
        public static Line GetLine(Vector2Int start, Vector2Int end)
        {
            return new Line(start, end);
        }

        public static IEnumerable<Vector2Int> GetRectangle(Vector2Int minimum, Vector2Int maximum)
        {
            for (var y = minimum.y; y < maximum.y; y++)
            {
                for (var x = minimum.x; x < maximum.x; x++)
                {
                    yield return new Vector2Int(x, y);
                }
            }
        }

        public static IEnumerable<Vector2Int> GetSquare(Vector2Int center, int distance)
        {
            var distance2 = new Vector2Int(distance, distance);

            var minimum = center - distance2;
            var maximum = center + distance2;

            return GetRectangle(minimum, maximum);
        }
    }
}