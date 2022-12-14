using NUnit.Framework;
using UnityEngine;

namespace ZozoEngine.Tests
{
    public sealed class CellTests
    {
        [Test]
        public void Initializes_position()
        {
            var position = new Vector2Int(20, 30);

            var cell = new Cell(position);

            Assert.That(cell.Position, Is.EqualTo(position));
        }
    }
}