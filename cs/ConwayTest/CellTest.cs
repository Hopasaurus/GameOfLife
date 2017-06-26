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

        [Test]
        public void Test_AddingLiveNeighborToNorthWest_IncreasesLivingNeighborCount()
        {
            var cell = new Cell();
            var livingWesternNeighbor = new Cell();
            var livingNorthWesternNeighbor = new Cell();

            cell.AddNeighbor(livingWesternNeighbor, Direction.West);
            livingWesternNeighbor.AddNeighbor(livingNorthWesternNeighbor, Direction.North);

            Assert.AreEqual(2, cell.CountLivingNeighbors());
        }

        [Test]
        public void Test_AddingDeadNeighborToSouthWest_DoesNotIncreaseLivingNeighborCount()
        {
            var cell = new Cell();
            var livingWesternNeighbor = new Cell();
            var deadSouthWesternNeighbor = new Cell(CellStatus.Dead);

            cell.AddNeighbor(livingWesternNeighbor, Direction.West);
            livingWesternNeighbor.AddNeighbor(deadSouthWesternNeighbor, Direction.South);

            Assert.AreEqual(1, cell.CountLivingNeighbors());
        }

        [Test]
        public void Test_AddingFullComplimentOfLivingNeigbors_YieldsEight()
        {
            var cell = new Cell();
            var livingWesternNeighbor = new Cell();
            var livingEasternNeighbor = new Cell();
            var livingNeighbor = new Cell();

            cell.AddNeighbor(livingWesternNeighbor, Direction.West);
            cell.AddNeighbor(livingEasternNeighbor, Direction.East);
            cell.AddNeighbor(livingNeighbor, Direction.North);
            cell.AddNeighbor(livingNeighbor, Direction.South);
            livingWesternNeighbor.AddNeighbor(livingNeighbor, Direction.North);
            livingWesternNeighbor.AddNeighbor(livingNeighbor, Direction.South);
            livingEasternNeighbor.AddNeighbor(livingNeighbor, Direction.North);
            livingEasternNeighbor.AddNeighbor(livingNeighbor, Direction.South);

            Assert.AreEqual(8, cell.CountLivingNeighbors());
        }
    }
}
