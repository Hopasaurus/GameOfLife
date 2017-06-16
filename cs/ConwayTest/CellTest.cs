using System.ComponentModel;
using Conway;
using NUnit.Framework;

namespace ConwayTest
{
    [TestFixture]
    public class CellTest
    {
        // TODO: what to do when adding a neighbor where there is one already?
        //  - I suspect that it in current state it will replace the neighbor
        //  - will need to think about this and decide what SHOULD happen. (later)

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

        [Test]
        public void Test_AddingLiveNeighborOnSouthSide_IncreasesLivingNeighborCount()
        {
            var cell = new Cell();
            var livingSouthernNeighbor = new Cell();

            cell.AddNeighbor(livingSouthernNeighbor, Direction.South);

            Assert.AreEqual(1, cell.CountLivingNeighbors());
        }

        [Test]
        public void Test_AddingDeadNeighborOnSouthSide_DoesNotIncreaseLivingNeighborCount()
        {
            var cell = new Cell();
            var livingSouthernNeighbor = new Cell(CellStatus.Dead);

            cell.AddNeighbor(livingSouthernNeighbor, Direction.South);

            Assert.AreEqual(0, cell.CountLivingNeighbors());
        }

        [Test]
        public void Test_AddingLiveNeighborOnNorthSide_IncreasesLivingNeighborCount()
        {
            var cell = new Cell();
            var livingNorthernNeighbor = new Cell();

            cell.AddNeighbor(livingNorthernNeighbor, Direction.North);

            Assert.AreEqual(1, cell.CountLivingNeighbors());
        }

        [Test]
        public void Test_AddingLiveNeighborOnNorthAndSouthSide_IncreasesLivingNeighborCount()
        {
            var cell = new Cell();
            var livingSouthernNeighbor = new Cell();
            var livingNorthernNeighbor = new Cell();

            cell.AddNeighbor(livingSouthernNeighbor, Direction.South);
            cell.AddNeighbor(livingNorthernNeighbor, Direction.North);

            Assert.AreEqual(2, cell.CountLivingNeighbors());
        }

        [Test]
        public void Test_NorthSouthCount_OnlyCountsLivingNeighborsToNorthAndSouth()
        {
            var cell = new Cell();
            var livingNeighbor = new Cell();

            cell.AddNeighbor(livingNeighbor, Direction.North);
            cell.AddNeighbor(livingNeighbor, Direction.South);
            cell.AddNeighbor(livingNeighbor, Direction.East);
            cell.AddNeighbor(livingNeighbor, Direction.West);

            Assert.AreEqual(2, cell.CountLivingNorthSouthNeighbors());
        }

        [Test, Ignore("Need to be able to request north/south count first")]
        public void Test_AddingLiveNeighborToNorthWest_IncreasesLivingNeighborCount()
        {
            var cell = new Cell();
            var livingNorthernNeighbor = new Cell();
            var livingNorthWesternNeighbor = new Cell();

            cell.AddNeighbor(livingNorthernNeighbor, Direction.North);
            livingNorthWesternNeighbor.AddNeighbor(livingNorthWesternNeighbor, Direction.West);

            Assert.AreEqual(2, cell.CountLivingNeighbors());
        }
    }
}
