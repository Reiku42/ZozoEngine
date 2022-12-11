using NUnit.Framework;

namespace ZozoEngine.Tests.Tests
{
    public class MapEnumeratorTests
    {
        [Test]
        public void Enumerates_all_cells()
        {
            const int width = 3;
            const int height = 3;
            var map = new Map(width, height);

            var mapEnumerator = map.GetAllCells();

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var result = mapEnumerator.MoveNext();
                    Assert.That(result, Is.True);

                    var current = mapEnumerator.Current;
                    Assert.That(current.X, Is.EqualTo(x));
                    Assert.That(current.Y, Is.EqualTo(y));
                }
            }

            var finalResult = mapEnumerator.MoveNext();
            Assert.That(finalResult, Is.False);
        }
    }
}