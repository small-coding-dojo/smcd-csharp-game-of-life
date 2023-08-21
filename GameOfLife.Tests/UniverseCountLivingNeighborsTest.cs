using Xunit;

namespace GameOfLife.Tests;

public class UniverseCountLivingNeighborsTest
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0)]
    public void CountNeighborsForSingleCellIn2x1AliveCells(
        int rowOfTestedCell,
        int columnOfTestedCell
    )
    {
        var universe = new Universe(2, 1, true);
        var actual = universe.GetLivingNeighbors(rowOfTestedCell, columnOfTestedCell);
        Assert.Equal(1, actual);
    }

    [Fact]
    public void CountLivingNeighborsForCenterCellIn3x3DeadCells()
    {
        var universe = new Universe(3, 3, false);
        var actual = universe.GetLivingNeighbors(1, 1);
        Assert.Equal(0, actual);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(0, 1)]
    [InlineData(0, 2)]
    [InlineData(1, 0)]
    [InlineData(1, 2)]
    [InlineData(2, 0)]
    [InlineData(2, 1)]
    [InlineData(2, 2)]
    public void CountLivingNeighborsForCenterCellIn3x3WithOneAliveCell(
        int rowOfAliveCell,
        int columnOfAliveCell
    )
    {
        var universe = new Universe(3, 3, false);
        universe.MakeAlive(rowOfAliveCell, columnOfAliveCell);
        var actual = universe.GetLivingNeighbors(1, 1);
        Assert.Equal(1, actual);
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(0, 2)]
    [InlineData(1, 0)]
    [InlineData(1, 2)]
    [InlineData(2, 0)]
    [InlineData(2, 1)]
    [InlineData(2, 2)]
    public void CountLivingNeighborsForCenterCellIn3x3WithTwoAliveCells(
        int rowOfAliveCell,
        int columnOfAliveCell
    )
    {
        var universe = new Universe(3, 3, false);
        universe.MakeAlive(rowOfAliveCell, columnOfAliveCell);
        universe.MakeAlive(0, 0);
        var actual = universe.GetLivingNeighbors(1, 1);
        Assert.Equal(2, actual);
    }

    [Fact]
    public void CountLivingNeighborsForCenterCellIn3x3WithAllAliveCells()
    {
        var universe = new Universe(3, 3, true);
        var actual = universe.GetLivingNeighbors(1, 1);
        Assert.Equal(8, actual);
    }

    [Fact]
    public void CountLivingNeighborsForCenterCellIn3x3WithOnlyCenterCellAlive()
    {
        var universe = new Universe(3, 3, false);
        universe.MakeAlive(1, 1);
        var actual = universe.GetLivingNeighbors(1, 1);
        Assert.Equal(0, actual);
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 0, 0)]
    [InlineData(2, 0, 0)]
    [InlineData(2, 2, 1)]
    public void CountLivingNeighborsForRightCenterCellIn3x4WithNoAliveCells(
        int rowOfAliveCell,
        int columnOfAliveCell,
        int expected
    )
    {
        var universe = new Universe(3, 4, false);
        universe.MakeAlive(rowOfAliveCell, columnOfAliveCell);
        var actual = universe.GetLivingNeighbors(1, 2);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(0, 1)]
    [InlineData(1, 0)]
    [InlineData(1, 1)]
    public void CountLivingNeighborsOfCornerCellWith3AliveCells(
        int rowOfInterest,
        int columnOfInterest
    )
    {
        var universe = new Universe(2, 2, true);
        var actual = universe.GetLivingNeighbors(rowOfInterest, columnOfInterest);
        Assert.Equal(3, actual);
    }
}
