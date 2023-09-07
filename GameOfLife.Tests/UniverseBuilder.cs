namespace GameOfLife.Tests;

public static class UniverseBuilder
{
    public static Universe Build(string s)
    {
        // rule disabled to prevent ternary operator (?:)
        // ReSharper disable once ConvertIfStatementToReturnStatement
        if (s == "O")
        {
            return new Universe(1, 1, true);
        }
        return new Universe(0, 0, false);
    }
}
