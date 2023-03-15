using System.Collections.Generic;

namespace GameOfLife;

public class Universe
{
    protected readonly Cell[,] Cells;
    protected List<(int, int)> coordinateOfNeighbor = new List<(int, int)>()
    {
        (0,0), (0,1), (0,2),
        (1,0),        (1,2),
        (2,0), (2,1), (2,2)
    }; 
    
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

    protected int CountLivingNeighbors(int row, int column)
    {
        if (row != 1 || column != 1)
        {
            return 1;
        }
        
        var counter = 0;

        foreach (var (rowNeighbor, columnNeighbor) in coordinateOfNeighbor)
        {
            counter += Cells[rowNeighbor, columnNeighbor].IsAlive() ? 1 : 0;
        }

        return counter;
    }

    protected void MakeAlive(int row, int column)
    {
        Cells[row, column] = new Cell(true);
    }
    

}