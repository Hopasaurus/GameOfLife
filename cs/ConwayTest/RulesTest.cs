using Conway;
using NUnit.Framework;

namespace ConwayTest
{
    [TestFixture]
    public class RulesTest
    {
        // Rules are:
        // Live cell with less than two neighbors dies
        // Live cell with two or three neighbors lives
        // Live cell with more than three neighbors dies
        // Dead cell with three neighbors comes to life

        [Test]
        public void Test_LiveCell_ZeroNeighbors_Dies()
        {
            // pausing to think here....
            // should we use mocking to answer the neighbor count?
            // that seems heavy handed. I think for this case
            // make a setup method that we can give a neighbor count to
            // and have it set the cell up with the correct number of living neighbors.
            // If counting neighbors on the cell were to cause disk/network access or
            // were computationally intense the mocks would be more likely to be used.

            var cell = SetupCell(CellStatus.Living, 0);

            Assert.AreEqual(0, cell.CountLivingNeighbors());

            // quick check to make sure the setup function is sane.
            for (var i = 0; i <= 8; ++i)
            {
                Assert.AreEqual(i, SetupCell(CellStatus.Living, i).CountLivingNeighbors());
            }
            
            //Rules.Foo();
        }

        private static Cell SetupCell(CellStatus status, int livingNeighbors)
        {

            var cell = new Cell(status);

            var cellStatuses = new CellStatus[8];

            // Will think about making this prettier later. Would normally pretty it up before committing
            // it is interesting to capture this in this case.
            // A little hackish, but should work fine.  (Again, starting to look like an argument towards mocking.)
            for (var i = 0; i < 8; ++i)
            {
                cellStatuses[i] = i < livingNeighbors ? CellStatus.Living : CellStatus.Dead;
            }
            
            // Add cardinal neighbors
            var west = new Cell(cellStatuses[0]);
            cell.AddNeighbor(west, Direction.West);

            var east = new Cell(cellStatuses[1]);
            cell.AddNeighbor(east, Direction.East);
            
            cell.AddNeighbor(new Cell(cellStatuses[2]), Direction.North);
            cell.AddNeighbor(new Cell(cellStatuses[3]), Direction.South);

            // Add inter-cardinal neighbors - note we are 'cheating' a little by knowing the cell implementation
            // does not need full linkage. This could come back to haunt us if cell counting changes.
            // That is not good as this is a test for the rules and not the cell.
            //   - this seems to be arguing that we should do better setup or use mocking to isolate this test
            //      from changes to the cell class.
            // Leaving the 'cheat' in place as it was my first inclination and it might be interesting to 
            //  see if it leads to any issues.  I suspect it will not as I suspect that the cell class will not
            //  change but still it is interesting to become more aware of an think about.  How often does something
            //  like this happen in production code?
            
            west.AddNeighbor(new Cell(cellStatuses[4]), Direction.North);
            west.AddNeighbor(new Cell(cellStatuses[5]), Direction.South);

            east.AddNeighbor(new Cell(cellStatuses[6]), Direction.North);
            east.AddNeighbor(new Cell(cellStatuses[7]), Direction.South);

            return cell;
        }

    }
}
