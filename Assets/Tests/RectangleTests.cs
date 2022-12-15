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

        [Test]
        public void Checks_if_position_is_in_bounds()
        {
            var start = new Vector2Int(0, 0);
            var end = new Vector2Int(9, 9);

            var rectangle = new Rectangle(start, end);

            var position = new Vector2Int(5, 5);
            Assert.That(rectangle.Contains(position), Is.True);
        }

        [Test]
        public void Checks_position_that_is_not_in_bounds_to_the_left()
        {
            var start = new Vector2Int(0, 0);
            var end = new Vector2Int(9, 9);

            var rectangle = new Rectangle(start, end);

            var left = new Vector2Int(-1, 0);
            Assert.That(rectangle.Contains(left), Is.False);
        }

        [Test]
        public void Checks_position_that_is_not_in_bounds_to_the_bottom()
        {
            var start = new Vector2Int(0, 0);
            var end = new Vector2Int(9, 9);

            var rectangle = new Rectangle(start, end);

            var bottom = new Vector2Int(0, -1);
            Assert.That(rectangle.Contains(bottom), Is.False);
        }

        [Test]
        public void Checks_position_that_is_not_in_bounds_to_the_right()
        {
            var start = new Vector2Int(0, 0);
            var end = new Vector2Int(9, 9);

            var rectangle = new Rectangle(start, end);

            var right = new Vector2Int(10, 9);
            Assert.That(rectangle.Contains(right), Is.False);
        }

        [Test]
        public void Checks_position_that_is_not_in_bounds_to_the_top()
        {
            var start = new Vector2Int(0, 0);
            var end = new Vector2Int(9, 9);

            var rectangle = new Rectangle(start, end);

            var top = new Vector2Int(9, 10);
            Assert.That(rectangle.Contains(top), Is.False);
        }

        [Test]
        public void Clamps_position_that_is_not_in_bounds_to_the_left()
        {
            var start = new Vector2Int(0, 0);
            var end = new Vector2Int(9, 9);

            var rectangle = new Rectangle(start, end);

            var left = new Vector2Int(-1, 0);
            var min = new Vector2Int(0, 0);
            Assert.That(rectangle.Clamp(left), Is.EqualTo(min));
        }

        [Test]
        public void Clamps_position_that_is_not_in_bounds_to_the_bottom()
        {
            var start = new Vector2Int(0, 0);
            var end = new Vector2Int(9, 9);

            var rectangle = new Rectangle(start, end);

            var bottom = new Vector2Int(0, -1);
            var min = new Vector2Int(0, 0);
            Assert.That(rectangle.Clamp(bottom), Is.EqualTo(min));
        }

        [Test]
        public void Clamps_position_that_is_not_in_bounds_to_the_right()
        {
            var start = new Vector2Int(0, 0);
            var end = new Vector2Int(9, 9);

            var rectangle = new Rectangle(start, end);

            var right = new Vector2Int(10, 9);
            var max = new Vector2Int(9, 9);
            Assert.That(rectangle.Clamp(right), Is.EqualTo(max));
        }

        [Test]
        public void Clamps_position_that_is_not_in_bounds_to_the_top()
        {
            var start = new Vector2Int(0, 0);
            var end = new Vector2Int(9, 9);

            var rectangle = new Rectangle(start, end);

            var top = new Vector2Int(9, 10);
            var max = new Vector2Int(9, 9);
            Assert.That(rectangle.Clamp(top), Is.EqualTo(max));
        }

        [Test]
        public void Does_not_clamp_position_that_is_already_in_bounds()
        {
            var start = new Vector2Int(0, 0);
            var end = new Vector2Int(9, 9);

            var rectangle = new Rectangle(start, end);

            var position = new Vector2Int(5, 5);
            Assert.That(rectangle.Clamp(position), Is.EqualTo(position));
        }

    }
}