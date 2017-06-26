using System.Collections.Generic;
using System.Reflection;
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


//  potential test cases:
//	_ 1x1 grid - not super useful but should not crash
//	_ 10x1 grid (10 columns, 1 row)
//	_ 10x10 grid
//	_ 1x10 grid
//	_ 100x100 grid
//	_ 1mx1m grid ? (will it crash and blow up or die cleanly.)
//  _ 0x0 grid, what should happen.

    [TestFixture]
    class GridBuilderTest
    {

        [Test]
        public void Test_GridBuilder_SingleCellGrid_BuildsCellWithNoNeighbors()
        {
            var rootCell = GridBuilder.Build(1, 1);

            Assert.AreEqual(0, GetNeighbors(rootCell).Count);
        }

        private Dictionary<Direction, Cell> GetNeighbors(Cell cell)
        {
            // Not really sure I like breaking encapsulation here.
            // Will leave it for now, as I think it is sometimes ok
            // to use reflection to help test things.
            // It is better than exposing things that I really do not
            // want to be exposed.
            var cellType = cell.GetType();
            var fieldInfo = cellType.GetField("_neighbors", BindingFlags.NonPublic | BindingFlags.Instance);

            // I am ok with possible null ref here, it should not happen
            // and if it does I likely want it to blow up anyway, it
            // that means I need another test.
            // ReSharper disable once PossibleNullReferenceException
            return (Dictionary<Direction, Cell>) fieldInfo.GetValue(cell);
        }
    }
}
