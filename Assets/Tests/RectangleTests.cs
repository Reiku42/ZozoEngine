using NUnit.Framework;
using UnityEngine;

namespace ZozoEngine.Tests
{
    public sealed class RectangleTests
    {
        [Test]
        public void Initializes_minimum_and_maximum()
        {
            var position = new Vector2Int(5, 5);
            var size = new Vector2Int(10, 10);

            var rectangle = new Rectangle(position, size);
            
            Assert.That(rectangle.Minimum, Is.EqualTo(position));
            Assert.That(rectangle.Maximum, Is.EqualTo(position + size));
        }

        [Test]
        public void Initializes_minimum_and_maximum_from_negative_size()
        {
            var position = new Vector2Int(5, 5);
            var size = new Vector2Int(-10, -10);

            var rectangle = new Rectangle(position, size);
            
            Assert.That(rectangle.Minimum, Is.EqualTo(new Vector2Int(-5, -5)));
            Assert.That(rectangle.Maximum, Is.EqualTo(new Vector2Int(5, 5)));
        }
    }
}