using System.Diagnostics.Metrics;
using Xunit;

namespace GameOfLife.Tests;

public class UniverseTest
{
    private class UniverseAdapter : Universe
    {
        public UniverseAdapter(int rows, int columns, bool cellsAliveAtInitialization) : base(rows, columns,
            cellsAliveAtInitialization)
        {
        }

        public int CellsLength => Cells.Length;

        public Cell CellAt(int row, int column) => Cells[row, column];

        public int GetLivingNeighbors(int row, int column)
        {
            return CountLivingNeighbors(row, column);
        }

        public void MakeAlive(int row, int column) => base.MakeAlive(row,column);
    }

    [Fact]
    public void CreatesUniverseWithOneAliveCell()
    {
        var universe = new UniverseAdapter(1, 1, true);

        Assert.Equal(1, universe.CellsLength);
        Assert.NotNull(universe.CellAt(0, 0));
        Assert.True(universe.CellAt(0, 0).IsAlive());
    }

    [Fact]
    public void CreatesUniverseWithOneDeadCell()
    {
        var universe = new UniverseAdapter(1, 1, false);
        Assert.False(universe.CellAt(0, 0).IsAlive());
    }

    [Fact]
    public void OneIterationWithSingleAliveCell()
    {
        var universe = new UniverseAdapter(1, 1, true);
        universe.Iterate();
        Assert.False(universe.CellAt(0, 0).IsAlive());
    }

    [Fact]
    public void UniverseHas2AliveCells()
    {
        var universe = new UniverseAdapter(2, 1, true);
        Assert.Equal(2, universe.CellsLength);
        Assert.True(universe.CellAt(0, 0).IsAlive());
        Assert.True(universe.CellAt(1, 0).IsAlive());
    }
    
    [Fact]
    public void UniverseHas2AliveCellsVertical()
    {
        var universe = new UniverseAdapter(1, 2, true);
        Assert.Equal(2, universe.CellsLength);
        Assert.True(universe.CellAt(0, 0).IsAlive());
        Assert.True(universe.CellAt(0, 1).IsAlive());
    }

    [Theory]
    [InlineData(2, 1, 0, 0)]
    [InlineData(2, 1, 1, 0)]
    public void CountNeighborsForSingleCellIn2x1AliveCells(int rows, int columns, int rowOfTestedCell, int columnOfTestedCell)
    {
        var universe = new UniverseAdapter(rows, columns, true);
        var actual = universe.GetLivingNeighbors(rowOfTestedCell, columnOfTestedCell);
        Assert.Equal(1, actual);
    }

    [Fact]
    public void CountNeighborsForCenterCellIn3x3DeadCells()
    {
        var universe = new UniverseAdapter(3, 3, false);
        var actual = universe.GetLivingNeighbors(1, 1);
        Assert.Equal(0, actual);
    }   
    
    [Theory]
    [InlineData(0,0)]
    [InlineData(0,1)]
    [InlineData(0,2)]
    [InlineData(1,0)]
    [InlineData(1,2)]
    [InlineData(2,0)]
    [InlineData(2,1)]
    [InlineData(2,2)]
    public void CountNeighborsForCenterCellIn3x3WithOneAliveCell(int row, int column)
    {
        var universe = new UniverseAdapter(3, 3, false);
        universe.MakeAlive(row,column);
        var actual = universe.GetLivingNeighbors(1, 1);
        Assert.Equal(1, actual);
    }
    
    [Theory]
    [InlineData(0,1)]
    [InlineData(0,2)]
    [InlineData(1,0)]
    [InlineData(1,2)]
    [InlineData(2,0)]
    [InlineData(2,1)]
    [InlineData(2,2)]
    public void CountNeighborsForCenterCellIn3x3WithTwoAliveCells(int row, int column)
    {
        var universe = new UniverseAdapter(3, 3, false);
        universe.MakeAlive(row,column);
        universe.MakeAlive(0,0);
        var actual = universe.GetLivingNeighbors(1, 1);
        Assert.Equal(2, actual);
    }

    [Fact]
    public void CountNeighborsForCenterCellIn3x3WithAllAliveCells()
    {
        var universe = new UniverseAdapter(3, 3, true);
        var actual = universe.GetLivingNeighbors(1, 1);
        Assert.Equal(8,actual);
    }

    [Fact]
    public void CountNeighborsForCenterCellIn3x3WithOnlyCenterCellAlive()
    {
        var universe = new UniverseAdapter(3, 3, false);
        universe.MakeAlive(1,1);
        var actual = universe.GetLivingNeighbors(1, 1);
        Assert.Equal(0, actual);
    }


    [Fact]
    public void MakeCellAlive()
    {
        var universe = new UniverseAdapter(1, 1, false);
        universe.MakeAlive(0, 0);
        Assert.True(universe.CellAt(0, 0).IsAlive());
    }
}