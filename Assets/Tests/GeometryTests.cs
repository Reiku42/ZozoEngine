using NUnit.Framework;
using UnityEngine;

namespace ZozoEngine.Tests
{
    public sealed class GeometryTests
    {
        [Test]
        public void Gets_rectangle()
        {
            var minimum = new Vector2Int(1, 1);
            var maximum = new Vector2Int(10, 10);

            using var rectangleEnumerator = Geometry.GetRectangle(minimum, maximum).GetEnumerator();

            var initialPosition = rectangleEnumerator.Current;
            Assert.That(initialPosition, Is.EqualTo(default(Vector2Int)));

            for (var y = minimum.y; y < maximum.y; y++)
            {
                for (var x = minimum.x; x < maximum.x; x++)
                {
                    var expectedPosition = new Vector2Int(x, y);

                    var result = rectangleEnumerator.MoveNext();
                    Assert.That(result, Is.True);

                    var position = rectangleEnumerator.Current;
                    Assert.That(position, Is.EqualTo(expectedPosition));
                }
            }

            var finalResult = rectangleEnumerator.MoveNext();
            Assert.That(finalResult, Is.False);

            var finalPosition = rectangleEnumerator.Current;
            Assert.That(finalPosition, Is.EqualTo(maximum - Vector2Int.one));
        }
    }
}