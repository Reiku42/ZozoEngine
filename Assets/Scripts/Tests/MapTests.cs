using System.Linq;
using NUnit.Framework;
using UnityEngine;

namespace ZozoEngine.Tests.Tests
{
    public sealed class MapTests
    {
        [Test]
        public void Initializes_size()
        {
            var size = new Vector2Int(5, 5);

            var map = new Map(size);

            Assert.That(map.Size, Is.EqualTo(size));
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
        public void Checks_if_position_is_in_bounds()
        {
            var size = new Vector2Int(10, 10);
            var map = new Map(size);

            var position = new Vector2Int(5, 5);

            Assert.That(map.IsInBounds(position), Is.True);
        }

        [Test]
        public void Checks_position_that_is_not_in_bounds()
        {
            var size = new Vector2Int(10, 10);
            var map = new Map(size);

            Assert.That(map.IsInBounds(new Vector2Int(-1, 0)), Is.False);
            Assert.That(map.IsInBounds(new Vector2Int(0, -1)), Is.False);
            Assert.That(map.IsInBounds(new Vector2Int(size.x, 0)), Is.False);
            Assert.That(map.IsInBounds(new Vector2Int(0, size.y)), Is.False);
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

        [Test]
        public void Gets_cells_along_line()
        {
            var size = new Vector2Int(10, 10);
            var map = new Map(size);

            var start = new Vector2Int(0, 1);
            var end = new Vector2Int(6, 4);
            var line = map.GetLine(start, end).ToList();

            Assert.That(line[0].Position, Is.EqualTo(new Vector2Int(0, 1)));
            Assert.That(line[1].Position, Is.EqualTo(new Vector2Int(1, 1)));
            Assert.That(line[2].Position, Is.EqualTo(new Vector2Int(2, 2)));
            Assert.That(line[3].Position, Is.EqualTo(new Vector2Int(3, 2)));
            Assert.That(line[4].Position, Is.EqualTo(new Vector2Int(4, 3)));
            Assert.That(line[5].Position, Is.EqualTo(new Vector2Int(5, 3)));
            Assert.That(line[6].Position, Is.EqualTo(new Vector2Int(6, 4)));
        }
    }
}