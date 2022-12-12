using System.Linq;
using NUnit.Framework;
using UnityEngine;

namespace ZozoEngine.Tests.Tests
{
    public sealed class LineEnumeratorTests
    {
        [Test]
        public void Enumerates_points_on_line()
        {
            var start = new Vector2Int(0, 1);
            var end = new Vector2Int(6, 4);
            var line = new Line(start, end);

            var lineEnumerator = new LineEnumerator(line);

            var expectedPositions = new Vector2Int[]
            {
                new(0, 1),
                new(1, 1),
                new(2, 2),
                new(3, 2),
                new(4, 3),
                new(5, 3),
                new(6, 4),
            };

            foreach (var expectedPosition in expectedPositions)
            {
                var result = lineEnumerator.MoveNext();
                Assert.That(result, Is.True);

                var position = lineEnumerator.Current;
                Assert.That(position, Is.EqualTo(expectedPosition));
            }

            var finalResult = lineEnumerator.MoveNext();
            Assert.That(finalResult, Is.False);
        }

        [Test]
        public void Enumerates_points_on_horizontal_line()
        {
            var start = new Vector2Int(1, 0);
            var end = new Vector2Int(5, 0);
            var line = new Line(start, end);

            var lineEnumerator = new LineEnumerator(line);

            var expectedPositions = new Vector2Int[]
            {
                new(0, 0),
                new(1, 0),
                new(2, 0),
                new(3, 0),
                new(4, 0),
                new(5, 0),
            };

            var initialPosition = lineEnumerator.Current;
            Assert.That(initialPosition, Is.EqualTo(expectedPositions.First()));

            foreach (var expectedPosition in expectedPositions.Skip(1))
            {
                var result = lineEnumerator.MoveNext();
                Assert.That(result, Is.True);

                var position = lineEnumerator.Current;
                Assert.That(position, Is.EqualTo(expectedPosition));
            }

            var finalResult = lineEnumerator.MoveNext();
            Assert.That(finalResult, Is.False);
        }

        [Test]
        public void Enumerates_points_on_vertical_line()
        {
            var start = new Vector2Int(0, 1);
            var end = new Vector2Int(0, 5);
            var line = new Line(start, end);

            var lineEnumerator = new LineEnumerator(line);

            var cellPositions = new Vector2Int[]
            {
                new(0, 0),
                new(0, 1),
                new(0, 2),
                new(0, 3),
                new(0, 4),
                new(0, 5),
            };

            var initialPosition = lineEnumerator.Current;
            Assert.That(initialPosition, Is.EqualTo(cellPositions.First()));

            foreach (var cellPosition in cellPositions.Skip(1))
            {
                var result = lineEnumerator.MoveNext();
                Assert.That(result, Is.True);

                var position = lineEnumerator.Current;
                Assert.That(position, Is.EqualTo(cellPosition));
            }

            var finalResult = lineEnumerator.MoveNext();
            Assert.That(finalResult, Is.False);
        }

        [Test]
        public void Enumerates_points_on_diagonal_line()
        {
            var size = new Vector2Int(7, 7);
            var map = new Map(size);
            var start = new Vector2Int(1, 1);
            var end = new Vector2Int(5, 5);
            var line = new Line(start, end);

            var lineEnumerator = new LineEnumerator(line);

            var cellPositions = new Vector2Int[]
            {
                new(0, 0),
                new(1, 1),
                new(2, 2),
                new(3, 3),
                new(4, 4),
                new(5, 5),
            };

            var initialPosition = lineEnumerator.Current;
            Assert.That(initialPosition, Is.EqualTo(cellPositions.First()));

            foreach (var cellPosition in cellPositions.Skip(1))
            {
                var result = lineEnumerator.MoveNext();
                Assert.That(result, Is.True);

                var position = lineEnumerator.Current;
                Assert.That(position, Is.EqualTo(cellPosition));
            }

            var finalResult = lineEnumerator.MoveNext();
            Assert.That(finalResult, Is.False);
        }
    }
}