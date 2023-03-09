namespace GameOfLife;

public class Universe
{
    protected readonly Cell[,] Cells;
    
    public Universe(int rows, int columns, bool cellsAliveAtInitialization)
    {
        Cells = new Cell[rows, columns];
        for (var row = 0; row < rows; row++)
        {
            for (var column=0; column < columns; column++)
            {
                Cells[row, column] = new Cell(cellsAliveAtInitialization);
            }
        }
    }

    public void Iterate()
    {
        bool nextState = Cells[0, 0].WillBeAliveInNextIncarnation(CountLivingNeighbors(0,0));
        Cells[0,0] = new Cell(nextState);
    }

    private int CountLivingNeighbors(int row, int column)
    {
        return 0;
    }
}