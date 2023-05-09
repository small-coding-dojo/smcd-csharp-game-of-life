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

        public bool WillBeAliveInNextIncarnation(int numberOfAliveNeighbors)
        {
            if (numberOfAliveNeighbors == 3)
            {
                return true;
            }
            else
            {
                return _isAlive && (numberOfAliveNeighbors == 2 || numberOfAliveNeighbors == 3);
            }
        }
    }
}
