using NUnit.Framework;
using UnityEngine;

namespace ZozoEngine.Tests.Tests
{
    public sealed class MapTests
    {
        [Test]
        public void Initializes_size()
        {
            const int width = 5;
            const int height = 5;
            var size = new Vector2Int(width, height);

            var map = new Map(size);

            Assert.That(map.Width, Is.EqualTo(width));
            Assert.That(map.Height, Is.EqualTo(height));
            Assert.That(map.Size, Is.EqualTo(size));
        }

        [Test]
        public void Initializes_all_cell_positions()
        {
            const int width = 5;
            const int height = 5;
            var size = new Vector2Int(width, height);

            var map = new Map(size);

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var position = new Vector2Int(x, y);
                    var cell = map[position];
                    Assert.That(cell.X, Is.EqualTo(x));
                    Assert.That(cell.Y, Is.EqualTo(y));
                    Assert.That(cell.Position, Is.EqualTo(position));
                }
            }
        }

        [Test]
        public void Indexes_into_center_cell()
        {
            var map = new Map(10, 10);

            const int x = 5;
            const int y = 5;
            var position = new Vector2Int(x, y);
            
            var origin = map[x, y];
            
            Assert.That(origin.X, Is.EqualTo(x));
            Assert.That(origin.Y, Is.EqualTo(y));
            Assert.That(origin.Position, Is.EqualTo(position));
        }

        [Test]
        public void Gets_center_cell()
        {
            var map = new Map(10, 10);

            const int x = 0;
            const int y = 0;
            var position = new Vector2Int(x, y);
            var origin = map.GetCell(position);

            Assert.That(origin.X, Is.EqualTo(x));
            Assert.That(origin.Y, Is.EqualTo(y));
            Assert.That(origin.Position, Is.EqualTo(position));
        }

        [Test]
        public void Checks_if_position_is_in_bounds()
        {
            var map = new Map(10, 10);

            var position = new Vector2Int(5, 5);
            
            Assert.That(map.IsInBounds(position), Is.True);
        }

        [Test]
        public void Checks_position_that_is_not_in_bounds()
        {
            const int width = 10;
            const int height = 10;
            
            var map = new Map(width, height);

            Assert.That(map.IsInBounds(-1, 0), Is.False);
            Assert.That(map.IsInBounds(0, -1), Is.False);
            Assert.That(map.IsInBounds(width, 0), Is.False);
            Assert.That(map.IsInBounds(0, height), Is.False);
        }

        [Test]
        public void Checks_if_cell_is_walkable()
        {
            var map = new Map(20, 30);

            const int x = 10;
            const int y = 15;
            var position = new Vector2Int(x, y);

            ref var cell = ref map[position];
            cell.IsWalkable = true;

            Assert.That(map.IsWalkable(position), Is.True);
        }

        [Test]
        public void Checks_if_cell_is_transparent()
        {
            var map = new Map(20, 30);

            const int x = 10;
            const int y = 15;
            var position = new Vector2Int(x, y);

            ref var cell = ref map[position];
            cell.IsTransparent = true;

            Assert.That(map.IsTransparent(position), Is.True);
        }
    }
}
