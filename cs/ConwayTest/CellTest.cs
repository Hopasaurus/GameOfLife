using Conway;
using NUnit.Framework;

namespace ConwayTest
{
    [TestFixture]
    public class CellTest
    {
        [Test]
        public void SanityTest()
        {
            var cell = new Cell();

            Assert.AreEqual(1, cell.foo(1));
        }
    }
}
