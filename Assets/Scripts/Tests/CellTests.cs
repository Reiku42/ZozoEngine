using NUnit.Framework;
using UnityEngine;

namespace ZozoEngine.Tests.Tests
{
    public sealed class CellTests
    {
        [Test]
        public void Initializes_position_using_x_and_y()
        {
            const int x = 20;
            const int y = 30;
            var position = new Vector2Int(x, y);
            
            var cell = new Cell(x, y);
            
            Assert.That(cell.X, Is.EqualTo(x));
            Assert.That(cell.Y, Is.EqualTo(y));
            Assert.That(cell.Position, Is.EqualTo(position));
        }
        
        [Test]
        public void Initializes_position()
        {
            const int x = 20;
            const int y = 30;
            var position = new Vector2Int(x, y);
            
            var cell = new Cell(position);
            
            Assert.That(cell.X, Is.EqualTo(x));
            Assert.That(cell.Y, Is.EqualTo(y));
            Assert.That(cell.Position, Is.EqualTo(position));
        }
    }
}