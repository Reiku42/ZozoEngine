using NUnit.Framework;
using UnityEngine;

namespace ZozoEngine.Tests
{
    public sealed class LineTests
    {
        [Test]
        public void Initializes_start_and_end()
        {
            var start = new Vector2Int(4, 7);
            var end = new Vector2Int(12, 32);

            var line = new Line(start, end);

            Assert.That(line.Start, Is.EqualTo(start));
            Assert.That(line.End, Is.EqualTo(end));
        }

        [Test]
        public void Calculates_slope()
        {
            var start = new Vector2Int(4, 7);
            var end = new Vector2Int(12, 32);
            var line = new Line(start, end);

            var slope = line.CalculateSlope();

            Assert.That(slope, Is.EqualTo(3.125f));
        }

        [Test]
        public void Calculates_zero_slope()
        {
            var start = new Vector2Int(0, 0);
            var end = new Vector2Int(10, 0);
            var line = new Line(start, end);

            var slope = line.CalculateSlope();

            Assert.That(slope, Is.EqualTo(0f));
        }

        [Test]
        public void Calculates_undefined_slope()
        {
            var start = new Vector2Int(0, 0);
            var end = new Vector2Int(0, 12);
            var line = new Line(start, end);

            var slope = line.CalculateSlope();

            Assert.That(float.IsInfinity(slope), Is.True);
        }

        [Test]
        public void Calculates_slope_of_one()
        {
            var start = new Vector2Int(0, 0);
            var end = new Vector2Int(10, 10);
            var line = new Line(start, end);

            var slope = line.CalculateSlope();

            Assert.That(slope, Is.EqualTo(1.0f));
        }

        [Test]
        public void Calculates_slope_of_zero_point_five()
        {
            var start = new Vector2Int(0, 0);
            var end = new Vector2Int(10, 5);
            var line = new Line(start, end);

            var slope = line.CalculateSlope();

            Assert.That(slope, Is.EqualTo(0.5f));
        }

        [Test]
        public void Calculates_slope_of_negative_one()
        {
            var start = new Vector2Int(0, 0);
            var end = new Vector2Int(-10, 10);
            var line = new Line(start, end);

            var slope = line.CalculateSlope();

            Assert.That(slope, Is.EqualTo(-1.0f));
        }

        [Test]
        public void Calculates_slope_of_negative_zero_point_five()
        {
            var start = new Vector2Int(0, 0);
            var end = new Vector2Int(-10, 5);
            var line = new Line(start, end);

            var slope = line.CalculateSlope();

            Assert.That(slope, Is.EqualTo(-0.5f));
        }
    }
}