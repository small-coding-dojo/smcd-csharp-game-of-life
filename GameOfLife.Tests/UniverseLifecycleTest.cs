using Xunit;

namespace GameOfLife.Tests;

public class UniverseLifecycleTest
{
    [Fact(DisplayName = "Rule 1 - 1x1 Universe - cell dies")]
    public void Rule1_1x1_CellAlwaysDies()
    {
        var universe = new Universe(1, 1, true);
        universe.Iterate();
        Assert.False(universe.CellAt(0, 0).IsAlive());
    }

    [Fact(
        DisplayName = "Rule 1 - 3x3 Universe - The centered cell will die with 0 living neighbors"
    )]
    public void Rule1_3x3_CenterCellWith_0_LivingNeighborsDies()
    {
        var universe = new Universe(3, 3, false);
        universe.MakeAlive(1, 1);
        universe.Iterate();
        Assert.False(universe.CellAt(1, 1).IsAlive());
    }

    [Fact(
        DisplayName = "Rule 1 - 3x3 Universe - The centered cell will die with 1 living neighbor"
    )]
    public void Rule1_3x3_CenterCellWith_1_LivingNeighborDies()
    {
        var universe = new Universe(3, 3, false);
        universe.MakeAlive(1, 1);
        universe.MakeAlive(0, 0);
        universe.Iterate();
        Assert.False(universe.CellAt(1, 1).IsAlive());
    }

    [Fact(
        DisplayName = "Rule 1 - 3x3 Universe - A cell at the edge will die with 0 living neighbors"
    )]
    public void Rule1_3x3_CellAtEdgeWith_0_LivingNeighborsDies()
    {
        var universe = new Universe(3, 3, false);
        universe.MakeAlive(2, 0);
        universe.Iterate();
        Assert.False(universe.CellAt(2, 0).IsAlive());
    }
}
