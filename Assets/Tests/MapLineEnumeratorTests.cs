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

            var cellPositions = new Vector2Int[]
            {
                new(0, 1),
                new(1, 1),
                new(2, 2),
                new(3, 2),
                new(4, 3),
                new(5, 3),
                new(6, 4),
            };

            foreach (var cellPosition in cellPositions)
            {
                var result = mapLineEnumerator.MoveNext();
                Assert.That(result, Is.True);

                var cell = mapLineEnumerator.Current;
                Assert.That(cell.Position, Is.EqualTo(cellPosition));
            }

            var finalResult = mapLineEnumerator.MoveNext();
            Assert.That(finalResult, Is.False);
        }

        [Test]
        public void Gets_cells_along_horizontal_line()
        {
            var size = new Vector2Int(7, 7);
            var map = new Map(size);
            var start = new Vector2Int(1, 0);
            var end = new Vector2Int(5, 0);

            var mapLineEnumerator = new MapLineEnumerator(map, start, end);

            var cellPositions = new Vector2Int[]
            {
                new(0, 0),
                new(1, 0),
                new(2, 0),
                new(3, 0),
                new(4, 0),
                new(5, 0),
            };

            var initialCell = mapLineEnumerator.Current;
            Assert.That(initialCell.Position, Is.EqualTo(cellPositions.First()));

            foreach (var cellPosition in cellPositions.Skip(1))
            {
                var result = mapLineEnumerator.MoveNext();
                Assert.That(result, Is.True);

                var cell = mapLineEnumerator.Current;
                Assert.That(cell.Position, Is.EqualTo(cellPosition));
            }

            var finalResult = mapLineEnumerator.MoveNext();
            Assert.That(finalResult, Is.False);
        }

        [Test]
        public void Gets_cells_along_vertical_line()
        {
            var size = new Vector2Int(7, 7);
            var map = new Map(size);
            var start = new Vector2Int(0, 1);
            var end = new Vector2Int(0, 5);

            var mapLineEnumerator = new MapLineEnumerator(map, start, end);

            var cellPositions = new Vector2Int[]
            {
                new(0, 0),
                new(0, 1),
                new(0, 2),
                new(0, 3),
                new(0, 4),
                new(0, 5),
            };

            var initialCell = mapLineEnumerator.Current;
            Assert.That(initialCell.Position, Is.EqualTo(cellPositions.First()));

            foreach (var cellPosition in cellPositions.Skip(1))
            {
                var result = mapLineEnumerator.MoveNext();
                Assert.That(result, Is.True);

                var cell = mapLineEnumerator.Current;
                Assert.That(cell.Position, Is.EqualTo(cellPosition));
            }

            var finalResult = mapLineEnumerator.MoveNext();
            Assert.That(finalResult, Is.False);
        }

        [Test]
        public void Gets_cells_along_diagonal_line()
        {
            var size = new Vector2Int(7, 7);
            var map = new Map(size);
            var start = new Vector2Int(1, 1);
            var end = new Vector2Int(5, 5);

            var mapLineEnumerator = new MapLineEnumerator(map, start, end);

            var cellPositions = new Vector2Int[]
            {
                new(0, 0),
                new(1, 1),
                new(2, 2),
                new(3, 3),
                new(4, 4),
                new(5, 5),
            };

            var initialCell = mapLineEnumerator.Current;
            Assert.That(initialCell.Position, Is.EqualTo(cellPositions.First()));

            foreach (var cellPosition in cellPositions.Skip(1))
            {
                var result = mapLineEnumerator.MoveNext();
                Assert.That(result, Is.True);

                var cell = mapLineEnumerator.Current;
                Assert.That(cell.Position, Is.EqualTo(cellPosition));
            }

            var finalResult = mapLineEnumerator.MoveNext();
            Assert.That(finalResult, Is.False);
        }
    }
}