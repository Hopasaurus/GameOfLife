namespace Conway
{
    public class Rules
    {
        public static CellStatus NextStatus(Cell cell)
        {
            return CellShouldBeAlive(cell) ? CellStatus.Living : CellStatus.Dead;
        }

        private static bool CellShouldBeAlive(Cell cell)
        {
            var livingNeighbors = cell.CountLivingNeighbors();

            return (livingNeighbors == 2 && cell.IsAlive()) || livingNeighbors == 3;
        }
    }
}
