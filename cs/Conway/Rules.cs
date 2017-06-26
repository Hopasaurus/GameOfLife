using System;

namespace Conway
{
    public class Rules
    {
        public static void Foo()
        {
        }

        public static CellStatus NextStatus(Cell cell)
        {
            var livingNeighbors = cell.CountLivingNeighbors();

            return livingNeighbors == 2 || livingNeighbors == 3 ? CellStatus.Living : CellStatus.Dead;
        }
    }
}
