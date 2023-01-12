namespace GameOfLife
{
    public class Cell
    {
        private readonly bool _isAlive;

        public Cell(bool isAlive)
        {
            _isAlive = isAlive;
        }

        public bool IsAlive()
        {
            return _isAlive;
        }

        public Cell GetNextIncarnation(int numberOfAliveNeighbors)
        {
            if ( numberOfAliveNeighbors == 2 || numberOfAliveNeighbors == 3) 
                return new Cell(true);
            return new Cell(false);
        }

    }
}
