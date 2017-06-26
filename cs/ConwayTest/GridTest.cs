using Conway;
using NUnit.Framework;

namespace ConwayTest
{
    // Tests for the GRID
    // the grid is in charge of building and maintaining the world of cells
    // this grid will be a simple rectangular grid
    // future ideas include a 3d grid (think about rubiks cube) 


    // LOOK ... that is TWO responsibilities.... we can't do that!
    //  spawning a grid builder class, back here in a bit.

    // Building the grid means instantiating and linking the cells 
    //  that make up the grid
    
    // Maintaining the grid means causing the grid to progress from
    //  one generation to the next

    // Seems like we may also need to provide information on the status
    //  of the grid so that we can show it on the screen.
    //  worry about this later.  (don't entirely forget about it... just
    //  try not to let it distract us right now.)  This note helps to 
    //  keep the worry at bay, writing down the thought about something
    //  we are concerned about helps to put the mind at ease that we won't 
    //  forget and allows us to concentrate more fully on the immediate task
    //  at hand.

    [TestFixture]
    class GridTest
    {
        [Test]
        public void Test_Grid()
        {
            var grid = new Grid();
        }
    }
}
