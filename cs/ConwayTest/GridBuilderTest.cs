using Conway;
using NUnit.Framework;

namespace ConwayTest
{

    // Ripped from GridTest.cs:
    // Building the grid means instantiating and linking the cells 
    //  that make up the grid

    // GridBuilder will build a simple 2-d rectangular grid of cells.
    // More complex worlds are beyond the scope of this project so will
    // Wait until time permits (really excited about rubix cube world.)

    [TestFixture]
    class GridBuilderTest
    {

        [Test]
        public void Test_GridBuilder_SingleCellGrid_BuildsGrid()
        {
            var rootCell = GridBuilder.Build(1, 1);
        }
    }
}
