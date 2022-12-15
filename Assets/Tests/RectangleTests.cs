using NUnit.Framework;
using UnityEngine;

namespace ZozoEngine.Tests
{
    public sealed class RectangleTests
    {
        [Test]
        public void Initializes_start_and_end()
        {
            var start = new Vector2Int(5, 5);
            var end = new Vector2Int(10, 10);

            var rectangle = new Rectangle(start, end);
            
            Assert.That(rectangle.Minimum, Is.EqualTo(start));
            Assert.That(rectangle.Maximum, Is.EqualTo(end));
        }

        [Test]
        public void Initializes_minimum_and_maximum_from_negative_size()
        {
            var start = new Vector2Int(5, 5);
            var end = new Vector2Int(-10, -10);

            var rectangle = new Rectangle(start, end);
            
            Assert.That(rectangle.Minimum, Is.EqualTo(end));
            Assert.That(rectangle.Maximum, Is.EqualTo(start));
        }
    }
}