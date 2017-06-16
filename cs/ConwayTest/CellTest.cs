using Conway;
using NUnit.Framework;

namespace ConwayTest
{
    [TestFixture]
    public class CellTest
    {
        [Test]
        public void Test_GivenLivingCell_AliveReturnsTrue()
        {
            var cell = new Cell(CellStatus.Living);

            Assert.IsTrue(cell.IsAlive());
        }

        [Test]
        public void Test_GivenDeadCell_AliveReturnsFalse()
        {
            var cell = new Cell(CellStatus.Dead);

            Assert.IsFalse(cell.IsAlive());
        }

        [Test]
        public void Test_CountLivingNeighbors_ReturnsZero()
        {
            var cell = new Cell();

            Assert.AreEqual(0, cell.CountLivingNeighbors());
        }
    }
}
