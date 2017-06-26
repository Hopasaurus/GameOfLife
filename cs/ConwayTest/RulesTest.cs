using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            var cell = new Cell();
            Rules.Foo();
        }
    }
}
