using Conway;
using NUnit.Framework;

namespace ConwayTest
{
    [TestFixture]
    public class RulesTest
    {
        [TestCase(2)]
        [TestCase(3)]
        public void Test_LiveCellWithTwoOrThreeNeighbors_Lives(int neighbors)
        {
            var cell = SetupCell(CellStatus.Living, neighbors);

            var result = Rules.NextStatus(cell);

            Assert.AreEqual(CellStatus.Living, result);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        public void Test_LiveCellWithLessThanTwoOrMoreThanThreeNeighbors_Dies(int neighbors)
        {
            var cell = SetupCell(CellStatus.Living, neighbors);

            var result = Rules.NextStatus(cell);

            Assert.AreEqual(CellStatus.Dead, result);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        public void Test_DeadCellWithOtherThanThreeNeighbors_StaysDead(int neighbors)
        {
            var cell = SetupCell(CellStatus.Dead, neighbors);

            var result = Rules.NextStatus(cell);

            Assert.AreEqual(CellStatus.Dead, result);
        }

        [TestCase(3)]
        public void Test_DeadCellWithThreeNeighbors_BecomesAlive(int neighbors)
        {
            var cell = SetupCell(CellStatus.Dead, neighbors);

            var result = Rules.NextStatus(cell);

            Assert.AreEqual(CellStatus.Living, result);
        }

        private static Cell SetupCell(CellStatus status, int livingNeighbors)
        {
            var cell = new Cell(status);

            var cellStatuses = new CellStatus[8];

            for (var i = 0; i < 8; ++i)
            {
                cellStatuses[i] = i < livingNeighbors ? CellStatus.Living : CellStatus.Dead;
            }
            
            var west = new Cell(cellStatuses[0]);
            cell.AddNeighbor(west, Direction.West);

            var east = new Cell(cellStatuses[1]);
            cell.AddNeighbor(east, Direction.East);
            
            cell.AddNeighbor(new Cell(cellStatuses[2]), Direction.North);
            cell.AddNeighbor(new Cell(cellStatuses[3]), Direction.South);

            west.AddNeighbor(new Cell(cellStatuses[4]), Direction.North);
            west.AddNeighbor(new Cell(cellStatuses[5]), Direction.South);

            east.AddNeighbor(new Cell(cellStatuses[6]), Direction.North);
            east.AddNeighbor(new Cell(cellStatuses[7]), Direction.South);

            return cell;
        }

    }
}
