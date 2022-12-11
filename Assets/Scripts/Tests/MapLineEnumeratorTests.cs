using System.Linq;
using NUnit.Framework;
using UnityEngine;

namespace ZozoEngine.Tests.Tests
{
    public sealed class MapLineEnumeratorTests
    {
        [Test]
        public void Gets_cells_along_line()
        {
            var size = new Vector2Int(10, 10);
            var map = new Map(size);
            var start = new Vector2Int(0, 1);
            var end = new Vector2Int(6, 4);

            var mapLineEnumerator = new MapLineEnumerator(map, start, end);

            mapLineEnumerator.MoveNext();
            Assert.That(mapLineEnumerator.Current.Position, Is.EqualTo(new Vector2Int(0, 1)));

            mapLineEnumerator.MoveNext();
            Assert.That(mapLineEnumerator.Current.Position, Is.EqualTo(new Vector2Int(1, 1)));

            mapLineEnumerator.MoveNext();
            Assert.That(mapLineEnumerator.Current.Position, Is.EqualTo(new Vector2Int(2, 2)));

            mapLineEnumerator.MoveNext();
            Assert.That(mapLineEnumerator.Current.Position, Is.EqualTo(new Vector2Int(3, 2)));

            mapLineEnumerator.MoveNext();
            Assert.That(mapLineEnumerator.Current.Position, Is.EqualTo(new Vector2Int(4, 3)));

            mapLineEnumerator.MoveNext();
            Assert.That(mapLineEnumerator.Current.Position, Is.EqualTo(new Vector2Int(5, 3)));

            mapLineEnumerator.MoveNext();
            Assert.That(mapLineEnumerator.Current.Position, Is.EqualTo(new Vector2Int(6, 4)));
        }

        [Test]
        public void Gets_cells_along_line_clamped_to_map()
        {
            var size = new Vector2Int(5, 5);
            var map = new Map(size);

            var start = new Vector2Int(-1, -1);
            var end = new Vector2Int(5, 5);
            var line = map.GetLine(start, end).ToList();

            Assert.That(line[0].Position, Is.EqualTo(new Vector2Int(0, 0)));
            Assert.That(line[1].Position, Is.EqualTo(new Vector2Int(1, 1)));
            Assert.That(line[2].Position, Is.EqualTo(new Vector2Int(2, 2)));
            Assert.That(line[3].Position, Is.EqualTo(new Vector2Int(3, 3)));
            Assert.That(line[4].Position, Is.EqualTo(new Vector2Int(4, 4)));
        }
    }
}