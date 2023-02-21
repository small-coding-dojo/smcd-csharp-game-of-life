namespace GameOfLife;

public class Universe
{
    protected readonly Cell[,] Cells = new Cell[1, 1];
    
    public Universe(int rows, int cols, bool cellsAliveAtInitialization)
    {
        Cells[0, 0] = new Cell(cellsAliveAtInitialization);
    }

    public void Iterate()
    {
        bool nextState = Cells[0, 0].WillBeAliveInNextIncarnation(CountLivingNeighbors(0,0));
        Cells[0,0] = new Cell(nextState);
    }

    private int CountLivingNeighbors(int row, int col)
    {
        return 0;
    }
}