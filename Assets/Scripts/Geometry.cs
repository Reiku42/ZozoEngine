using UnityEngine;

namespace ZozoEngine
{
    public static class Geometry
    {
        public static Line GetLine(Vector2Int start, Vector2Int end)
        {
            return new Line(start, end);
        }

        public static Rectangle GetRectangle(Vector2Int minimum, Vector2Int maximum)
        {
            return new Rectangle(minimum, maximum);
        }

        public static Rectangle GetSquare(Vector2Int center, int distance)
        {
            var distance2 = new Vector2Int(distance, distance);

            var minimum = center - distance2;
            var maximum = center + distance2;

            return new Rectangle(minimum, maximum);
        }
    }
}