﻿using NUnit.Framework;
using UnityEngine;

namespace ZozoEngine.Tests
{
    public sealed class MapEnumeratorTests
    {
        [Test]
        public void Enumerates_all_cells()
        {
            var size = new Vector2Int(3, 3);
            var map = new Map(size);

            using var mapEnumerator = map.GetEnumerator();

            for (var y = 0; y < size.y; y++)
            {
                for (var x = 0; x < size.x; x++)
                {
                    var position = new Vector2Int(x, y);
                    
                    var result = mapEnumerator.MoveNext();
                    Assert.That(result, Is.True);

                    var current = mapEnumerator.Current;
                    Assert.That(current.Position, Is.EqualTo(position));
                }
            }

            var finalResult = mapEnumerator.MoveNext();
            Assert.That(finalResult, Is.False);
        }
    }
}