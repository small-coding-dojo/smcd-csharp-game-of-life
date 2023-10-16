namespace GameOfLife.Tests;

public static class UniverseBuilder
{
    /// <summary>
    /// Build a universe from a string representation.
    /// </summary>
    /// <param name="stringRepresentation">use . for dead and 0 for alive cells, e.g. "...O." means dead dead dead alive dead</param>
    /// <returns>A universe as described by the parameter stringRepresentation</returns>
    public static Universe Build(string stringRepresentation)
    {
        // rule disabled to prevent ternary operator (?:)
        // ReSharper disable once ConvertIfStatementToReturnStatement
        if (stringRepresentation == "O")
        {
            return new Universe(1, 1, true);
        }
        else if (stringRepresentation == ".")
        {
            return new Universe(1, 1, false);
        }
        else if (stringRepresentation == "..")
        {
            return new Universe(1, 2, false);
        }
        return new Universe(0, 0, false);
    }
}
