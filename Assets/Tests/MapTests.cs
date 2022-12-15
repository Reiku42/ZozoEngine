using NUnit.Framework;
using UnityEngine;

namespace ZozoEngine.Tests
{
    public sealed class MapTests
    {
        [Test]
        public void Initializes_bounds()
        {
            var size = new Vector2Int(5, 5);

            var map = new Map(size);

            Assert.That(map.Bounds.Minimum, Is.EqualTo(new Vector2Int(0, 0)));
            Assert.That(map.Bounds.Maximum, Is.EqualTo(new Vector2Int(4, 4)));
        }

        [Test]
        public void Initializes_all_cell_positions()
        {
            var size = new Vector2Int(5, 5);
            var map = new Map(size);

            for (var y = 0; y < size.y; y++)
            {
                for (var x = 0; x < size.x; x++)
                {
                    var position = new Vector2Int(x, y);
                    var cell = map[position];
                    Assert.That(cell.Position, Is.EqualTo(position));
                }
            }
        }

        [Test]
        public void Gets_center_cell()
        {
            var size = new Vector2Int(10, 10);
            var map = new Map(size);

            var position = new Vector2Int(5, 5);
            var origin = map[position];

            Assert.That(origin.Position, Is.EqualTo(position));
        }

        [Test]
        public void Checks_if_cell_is_walkable()
        {
            var size = new Vector2Int(20, 30);
            var map = new Map(size);

            var position = new Vector2Int(10, 15);
            ref var cell = ref map[position];
            cell.IsWalkable = true;

            Assert.That(map.IsWalkable(position), Is.True);
        }

        [Test]
        public void Checks_if_cell_is_transparent()
        {
            var size = new Vector2Int(20, 30);
            var map = new Map(size);

            var position = new Vector2Int(10, 15);
            ref var cell = ref map[position];
            cell.IsTransparent = true;

            Assert.That(map.IsTransparent(position), Is.True);
        }
    }
}