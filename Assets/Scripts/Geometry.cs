using UnityEngine;

namespace ZozoEngine
{
    public static class Geometry
    {
        public static Line GetLine(Vector2Int start, Vector2Int end)
        {
            return new Line(start, end);
        }
    }
}