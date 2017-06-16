namespace Conway
{
    public enum CellStatus
    {
        Living,
        Dead,
    }

    public class Cell
    {
        private CellStatus _status;
        // TODO:  (things I currenlty think this class needs)
        // - Count living neighbors
        // - Construct
        // - Add neighbor

        // Things we might need later
        // - grid manager (build and maintain the grid)
        // - rules
        // - presentation - draw something to look at.

        public Cell(CellStatus initialStatus)
        {
            _status = initialStatus;
        }

        public bool IsAlive()
        {
            return _status == CellStatus.Living;
        }

//        public int CountLivingNeighbors()
//        {
//            return 0;
//        }
    }
}
