using System.Collections.Generic;
using System.Linq;

namespace Conway
{
    public enum CellStatus
    {
        Living,
        Dead,
    }

    public enum Direction
    {
        North,
        East,
        South,
        West,
    }

    public class Cell
    {
        private CellStatus _status;
        private Dictionary<Direction, Cell> _neighbors = new Dictionary<Direction, Cell>();
        
        public Cell()
        {
            _status = CellStatus.Living;
        }

        public Cell(CellStatus initialStatus)
        {
            _status = initialStatus;
        }

        public bool IsAlive()
        {
            return _status == CellStatus.Living;
        }

        public int CountLivingNeighbors()
        {
            return _neighbors.Count(x => x.Value.IsAlive()) + CountNeighborsNeighbors();
        }

        private int CountNeighborsNeighbors()
        {
            return
                _neighbors.Where(n => n.Key == Direction.West || n.Key == Direction.East)
                    .Sum(x => x.Value.CountLivingNorthSouthNeighbors());
        }

        public void AddNeighbor(Cell neighbor, Direction direction)
        {
            _neighbors.Add(direction, neighbor);
        }

        public int CountLivingNorthSouthNeighbors()
        {
            return _neighbors.Count(n => n.Value.IsAlive() && n.Key == Direction.North || n.Key == Direction.South);
        }
    }
}
