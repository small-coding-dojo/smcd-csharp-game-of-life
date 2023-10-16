using Xunit;
using System;

namespace GameOfLife.Tests;

public class UniverseBuilderTest
{
    [Fact]
    public void BuildEmptyUniverse()
    {
        var universe = UniverseBuilder.Build("");
        Assert.Equal(0, universe.CellsLength);
        Assert.Throws<IndexOutOfRangeException>(() => (universe.CellAt(0, 0)));
    }

    [Fact]
    public void Build1X1UniverseWithAnAliveCell()
    {
        var universe = UniverseBuilder.Build("O");
        Assert.Equal(1, universe.CellsLength);
        Assert.True(universe.CellAt(0, 0).IsAlive());
        Assert.Throws<IndexOutOfRangeException>(() => (universe.CellAt(-1, 0)));
        Assert.Throws<IndexOutOfRangeException>(() => (universe.CellAt(1, 0)));
        Assert.Throws<IndexOutOfRangeException>(() => (universe.CellAt(0, -1)));
        Assert.Throws<IndexOutOfRangeException>(() => (universe.CellAt(0, 1)));
    }

    [Fact]
    public void Build1X1UniverseWithADeadCell()
    {
        var universe = UniverseBuilder.Build(".");
        Assert.Equal(1, universe.CellsLength);
        Assert.False(universe.CellAt(0, 0).IsAlive());
        Assert.Throws<IndexOutOfRangeException>(() => (universe.CellAt(-1, 0)));
        Assert.Throws<IndexOutOfRangeException>(() => (universe.CellAt(1, 0)));
        Assert.Throws<IndexOutOfRangeException>(() => (universe.CellAt(0, -1)));
        Assert.Throws<IndexOutOfRangeException>(() => (universe.CellAt(0, 1)));
    }
}
