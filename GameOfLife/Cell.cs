namespace GameOfLife
{
    public class Cell
    {
        private readonly bool _isAlive;

        public Cell(bool isAlive = true)
        {
            _isAlive = isAlive;
        }

        public bool IsAlive()
        {
            return _isAlive;
        }

    }
}
