namespace Conway
{
    public class Rules
    {
        public static CellStatus NextStatus(Cell cell)
        {
            return LiveCellShouldStayAlive(cell) ? CellStatus.Living : CellStatus.Dead;
        }

        private static bool LiveCellShouldStayAlive(Cell cell)
        {
            var livingNeighbors = cell.CountLivingNeighbors();

            return livingNeighbors == 2 || livingNeighbors == 3;
        }
    }
}
