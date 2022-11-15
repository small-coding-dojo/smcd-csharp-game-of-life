namespace GameOfLife
{
    public class Cell
    {
        private bool _cellLiveness;
        private static Cell _ourCell = new Cell();

        public Cell()
        {
            _cellLiveness = false;
        }

        public static Cell At(int i, int i1)
        {
            return _ourCell;
        }

        public bool IsDead()
        {
            return !_cellLiveness;
        }

        public void Live()
        {
            _cellLiveness = true;
        }
    }
}