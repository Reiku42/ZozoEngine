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
        public void Checks_position_that_is_not_in_bounds_to_the_left()
        {
            var size = new Vector2Int(10, 10);
            var map = new Map(size);

            var left = new Vector2Int(-1, 0);
            Assert.That(map.IsInBounds(left), Is.False);
        }

        [Test]
        public void Checks_position_that_is_not_in_bounds_to_the_bottom()
        {
            var size = new Vector2Int(10, 10);
            var map = new Map(size);

            var bottom = new Vector2Int(0, -1);
            Assert.That(map.IsInBounds(bottom), Is.False);
        }

        [Test]
        public void Checks_position_that_is_not_in_bounds_to_the_right()
        {
            var size = new Vector2Int(10, 10);
            var map = new Map(size);

            var right = new Vector2Int(10, 9);
            Assert.That(map.IsInBounds(right), Is.False);
        }

        [Test]
        public void Checks_position_that_is_not_in_bounds_to_the_top()
        {
            var size = new Vector2Int(10, 10);
            var map = new Map(size);

            var top = new Vector2Int(9, 10);
            Assert.That(map.IsInBounds(top), Is.False);
        }

        [Test]
        public void Clamps_position_that_is_not_in_bounds_to_the_left()
        {
            var size = new Vector2Int(10, 10);
            var map = new Map(size);

            var left = new Vector2Int(-1, 0);
            var min = new Vector2Int(0, 0);
            Assert.That(map.ClampToBounds(left), Is.EqualTo(min));
        }

        [Test]
        public void Clamps_position_that_is_not_in_bounds_to_the_bottom()
        {
            var size = new Vector2Int(10, 10);
            var map = new Map(size);

            var bottom = new Vector2Int(0, -1);
            var min = new Vector2Int(0, 0);
            Assert.That(map.ClampToBounds(bottom), Is.EqualTo(min));
        }

        [Test]
        public void Clamps_position_that_is_not_in_bounds_to_the_right()
        {
            var size = new Vector2Int(10, 10);
            var map = new Map(size);

            var right = new Vector2Int(10, 9);
            var max = new Vector2Int(9, 9);
            Assert.That(map.ClampToBounds(right), Is.EqualTo(max));
        }

        [Test]
        public void Clamps_position_that_is_not_in_bounds_to_the_top()
        {
            var size = new Vector2Int(10, 10);
            var map = new Map(size);

            var top = new Vector2Int(9, 10);
            var max = new Vector2Int(9, 9);
            Assert.That(map.ClampToBounds(top), Is.EqualTo(max));
        }

        [Test]
        public void Does_not_clamp_position_that_is_already_in_bounds()
        {
            var size = new Vector2Int(10, 10);
            var map = new Map(size);

            var position = new Vector2Int(5, 5);
            Assert.That(map.ClampToBounds(position), Is.EqualTo(position));
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