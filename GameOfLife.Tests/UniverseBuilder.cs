namespace GameOfLife.Tests;

public static class UniverseBuilder
{
    /// <summary>
    /// Build a universe from a string representation.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Purpose:
    /// <list type="">
    ///   <item>- The UniverseBuilder creates a new Universe every time the Build method is called.</item>
    ///   <item>- This is intended to be used as an initial state for test cases.</item>
    ///   <item>- The <c>Build</c> method should be called to setup the initial state for every test case.</item>
    /// </list>
    /// </para>
    /// <para>
    /// Info: <br/>
    /// - Don't have any validity checks
    /// </para>
    /// <para>
    ///     Example: <br/>
    ///         ..O. <br/>
    ///         O..O <br/>
    /// -> means 2 by 4 universe with living cell on the 3rd position in the 1st row and living cells in 1st and 4th position in the 2nd row
    /// </para>
    /// </remarks>
    ///
    /// <param name="stringRepresentation">Use "." for dead and "O" for alive cells, e.g. "...O." means "dead dead dead alive dead"</param>
    /// <returns>A universe as described by the parameter stringRepresentation</returns>
    public static Universe Build(string stringRepresentation)
    {
        // rule disabled to prevent ternary operator (?:)
        // ReSharper disable once ConvertIfStatementToReturnStatement
        if (stringRepresentation == "O")
        {
            return new Universe(1, 1, desiredCellState(stringRepresentation[0]));
        }
        else if (stringRepresentation == ".")
        {
            return new Universe(1, 1, desiredCellState(stringRepresentation[0]));
        }
        else if (stringRepresentation == "..")
        {
            return new Universe(1, 2, false);
        }
        return new Universe(0, 0, false);
    }

    public static bool desiredCellState(char input)
    {
        return input == 'O' ? true : false;
    }
}
