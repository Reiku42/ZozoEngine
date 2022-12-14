using System.Linq;
using NUnit.Framework;
using UnityEngine;

namespace ZozoEngine.Tests
{
    public sealed class LineEnumeratorTests
    {
        [Test]
        public void Enumerates_points_on_a_line()
        {
            var start = new Vector2Int(0, 1);
            var end = new Vector2Int(6, 4);

            using var lineEnumerator = Geometry.GetLine(start, end).GetEnumerator();

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

            var initialPosition = lineEnumerator.Current;
            Assert.That(initialPosition, Is.EqualTo(default(Vector2Int)));

            foreach (var expectedPosition in expectedPositions)
            {
                var result = lineEnumerator.MoveNext();
                Assert.That(result, Is.True);

                var position = lineEnumerator.Current;
                Assert.That(position, Is.EqualTo(expectedPosition));
            }

            var finalResult = lineEnumerator.MoveNext();
            Assert.That(finalResult, Is.False);

            var finalPosition = lineEnumerator.Current;
            Assert.That(finalPosition, Is.EqualTo(expectedPositions.Last()));
        }

        [Test]
        public void Enumerates_points_on_a_horizontal_line()
        {
            var start = new Vector2Int(1, 0);
            var end = new Vector2Int(5, 0);

            using var lineEnumerator = Geometry.GetLine(start, end).GetEnumerator();

            var expectedPositions = new Vector2Int[]
            {
                new(1, 0),
                new(2, 0),
                new(3, 0),
                new(4, 0),
                new(5, 0),
            };

            var initialPosition = lineEnumerator.Current;
            Assert.That(initialPosition, Is.EqualTo(default(Vector2Int)));

            foreach (var expectedPosition in expectedPositions)
            {
                var result = lineEnumerator.MoveNext();
                Assert.That(result, Is.True);

                var position = lineEnumerator.Current;
                Assert.That(position, Is.EqualTo(expectedPosition));
            }

            var finalResult = lineEnumerator.MoveNext();
            Assert.That(finalResult, Is.False);

            var finalPosition = lineEnumerator.Current;
            Assert.That(finalPosition, Is.EqualTo(expectedPositions.Last()));
        }

        [Test]
        public void Enumerates_points_on_a_vertical_line()
        {
            var start = new Vector2Int(0, 1);
            var end = new Vector2Int(0, 5);

            using var lineEnumerator = Geometry.GetLine(start, end).GetEnumerator();

            var expectedPositions = new Vector2Int[]
            {
                new(0, 1),
                new(0, 2),
                new(0, 3),
                new(0, 4),
                new(0, 5),
            };

            var initialPosition = lineEnumerator.Current;
            Assert.That(initialPosition, Is.EqualTo(default(Vector2Int)));

            foreach (var expectedPosition in expectedPositions)
            {
                var result = lineEnumerator.MoveNext();
                Assert.That(result, Is.True);

                var position = lineEnumerator.Current;
                Assert.That(position, Is.EqualTo(expectedPosition));
            }

            var finalResult = lineEnumerator.MoveNext();
            Assert.That(finalResult, Is.False);

            var finalPosition = lineEnumerator.Current;
            Assert.That(finalPosition, Is.EqualTo(expectedPositions.Last()));
        }

        [Test]
        public void Enumerates_points_on_a_diagonal_line()
        {
            var start = new Vector2Int(1, 1);
            var end = new Vector2Int(5, 5);

            using var lineEnumerator = Geometry.GetLine(start, end).GetEnumerator();

            var expectedPositions = new Vector2Int[]
            {
                new(1, 1),
                new(2, 2),
                new(3, 3),
                new(4, 4),
                new(5, 5),
            };

            var initialPosition = lineEnumerator.Current;
            Assert.That(initialPosition, Is.EqualTo(default(Vector2Int)));

            foreach (var expectedPosition in expectedPositions)
            {
                var result = lineEnumerator.MoveNext();
                Assert.That(result, Is.True);

                var position = lineEnumerator.Current;
                Assert.That(position, Is.EqualTo(expectedPosition));
            }

            var finalResult = lineEnumerator.MoveNext();
            Assert.That(finalResult, Is.False);

            var finalPosition = lineEnumerator.Current;
            Assert.That(finalPosition, Is.EqualTo(expectedPositions.Last()));
        }

        [Test]
        public void Enumerates_points_on_a_line_with_slope_of_zero()
        {
            var start = new Vector2Int(5, 5);
            var end = new Vector2Int(10, 5);

            using var lineEnumerator = Geometry.GetLine(start, end).GetEnumerator();

            var expectedPositions = new Vector2Int[]
            {
                new(5, 5),
                new(6, 5),
                new(7, 5),
                new(8, 5),
                new(9, 5),
                new(10, 5),
            };

            var initialPosition = lineEnumerator.Current;
            Assert.That(initialPosition, Is.EqualTo(default(Vector2Int)));

            foreach (var expectedPosition in expectedPositions)
            {
                var result = lineEnumerator.MoveNext();
                Assert.That(result, Is.True);

                var position = lineEnumerator.Current;
                Assert.That(position, Is.EqualTo(expectedPosition));
            }

            var finalResult = lineEnumerator.MoveNext();
            Assert.That(finalResult, Is.False);

            var finalPosition = lineEnumerator.Current;
            Assert.That(finalPosition, Is.EqualTo(expectedPositions.Last()));
        }

        [Test]
        public void Enumerates_points_on_a_line_with_infinite_slope()
        {
            var start = new Vector2Int(5, 5);
            var end = new Vector2Int(5, 10);

            using var lineEnumerator = Geometry.GetLine(start, end).GetEnumerator();

            var expectedPositions = new Vector2Int[]
            {
                new(5, 5),
                new(5, 6),
                new(5, 7),
                new(5, 8),
                new(5, 9),
                new(5, 10),
            };

            var initialPosition = lineEnumerator.Current;
            Assert.That(initialPosition, Is.EqualTo(default(Vector2Int)));

            foreach (var expectedPosition in expectedPositions)
            {
                var result = lineEnumerator.MoveNext();
                Assert.That(result, Is.True);

                var position = lineEnumerator.Current;
                Assert.That(position, Is.EqualTo(expectedPosition));
            }

            var finalResult = lineEnumerator.MoveNext();
            Assert.That(finalResult, Is.False);

            var finalPosition = lineEnumerator.Current;
            Assert.That(finalPosition, Is.EqualTo(expectedPositions.Last()));
        }

        [Test]
        public void Enumerates_points_on_a_line_with_slope_of_one()
        {
            var start = new Vector2Int(5, 5);
            var end = new Vector2Int(10, 10);

            using var lineEnumerator = Geometry.GetLine(start, end).GetEnumerator();

            var expectedPositions = new Vector2Int[]
            {
                new(5, 5),
                new(6, 6),
                new(7, 7),
                new(8, 8),
                new(9, 9),
                new(10, 10),
            };

            var initialPosition = lineEnumerator.Current;
            Assert.That(initialPosition, Is.EqualTo(default(Vector2Int)));

            foreach (var expectedPosition in expectedPositions)
            {
                var result = lineEnumerator.MoveNext();
                Assert.That(result, Is.True);

                var position = lineEnumerator.Current;
                Assert.That(position, Is.EqualTo(expectedPosition));
            }

            var finalResult = lineEnumerator.MoveNext();
            Assert.That(finalResult, Is.False);

            var finalPosition = lineEnumerator.Current;
            Assert.That(finalPosition, Is.EqualTo(expectedPositions.Last()));
        }

        [Test]
        public void Enumerates_points_on_a_line_with_slope_of_negative_one()
        {
            var start = new Vector2Int(5, 5);
            var end = new Vector2Int(0, 10);
            var line = new Line(start, end);
            var slope = line.CalculateSlope();
            Assert.That(slope, Is.EqualTo(-1.0f));

            using var lineEnumerator = Geometry.GetLine(start, end).GetEnumerator();

            var expectedPositions = new Vector2Int[]
            {
                new(5, 5),
                new(4, 6),
                new(3, 7),
                new(2, 8),
                new(1, 9),
                new(0, 10),
            };

            var initialPosition = lineEnumerator.Current;
            Assert.That(initialPosition, Is.EqualTo(default(Vector2Int)));

            foreach (var expectedPosition in expectedPositions)
            {
                var result = lineEnumerator.MoveNext();
                Assert.That(result, Is.True);

                var position = lineEnumerator.Current;
                Assert.That(position, Is.EqualTo(expectedPosition));
            }

            var finalResult = lineEnumerator.MoveNext();
            Assert.That(finalResult, Is.False);

            var finalPosition = lineEnumerator.Current;
            Assert.That(finalPosition, Is.EqualTo(expectedPositions.Last()));
        }

        [Test]
        public void Enumerates_points_on_a_line_with_slope_of_zero_point_five()
        {
            var start = new Vector2Int(5, 5);
            var end = new Vector2Int(10, 7);

            using var lineEnumerator = Geometry.GetLine(start, end).GetEnumerator();

            var expectedPositions = new Vector2Int[]
            {
                new(5, 5),
                new(6, 5),
                new(7, 6),
                new(8, 6),
                new(9, 7),
                new(10, 7),
            };

            var initialPosition = lineEnumerator.Current;
            Assert.That(initialPosition, Is.EqualTo(default(Vector2Int)));

            foreach (var expectedPosition in expectedPositions)
            {
                var result = lineEnumerator.MoveNext();
                Assert.That(result, Is.True);

                var position = lineEnumerator.Current;
                Assert.That(position, Is.EqualTo(expectedPosition));
            }

            var finalResult = lineEnumerator.MoveNext();
            Assert.That(finalResult, Is.False);

            var finalPosition = lineEnumerator.Current;
            Assert.That(finalPosition, Is.EqualTo(expectedPositions.Last()));
        }

        [Test]
        public void Enumerates_points_on_a_line_with_slope_of_negative_zero_point_five()
        {
            var start = new Vector2Int(5, 5);
            var end = new Vector2Int(0, 7);

            using var lineEnumerator = Geometry.GetLine(start, end).GetEnumerator();

            var expectedPositions = new Vector2Int[]
            {
                new(5, 5),
                new(4, 5),
                new(3, 6),
                new(2, 6),
                new(1, 7),
                new(0, 7),
            };

            var initialPosition = lineEnumerator.Current;
            Assert.That(initialPosition, Is.EqualTo(default(Vector2Int)));

            foreach (var expectedPosition in expectedPositions)
            {
                var result = lineEnumerator.MoveNext();
                Assert.That(result, Is.True);

                var position = lineEnumerator.Current;
                Assert.That(position, Is.EqualTo(expectedPosition));
            }

            var finalResult = lineEnumerator.MoveNext();
            Assert.That(finalResult, Is.False);
            
            var finalPosition = lineEnumerator.Current;
            Assert.That(finalPosition, Is.EqualTo(expectedPositions.Last()));
        }
    }
}