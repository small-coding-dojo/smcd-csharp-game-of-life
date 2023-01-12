using System;
using Xunit;

namespace GameOfLife.Tests
{
    public class CellTest
    {
        private readonly Cell _aliveCell;
        private readonly Cell _deadCell;

        public CellTest () 
        {
            _aliveCell = new Cell(true);
            _deadCell = new Cell(false);

        }

        [Fact]
        public void Invariant_FreshlyCreatedAliveCellIsReallyAlive()
        {
            Assert.True(_aliveCell.IsAlive());
        }
        
        [Fact]
        public void Invariant_FreshlyCreatedDeadCellIsReallyDead()
        {
            Assert.False(_deadCell.IsAlive());
        }

        [Theory(DisplayName = "Any live cell with fewer than two live neighbours dies, as if by underpopulation.")]
        [InlineData(0)]
        [InlineData(1)]
        public void Rule1_DiesWithFewerThanTwoAliveNeighbors(int numberOfAliveNeighbors)
        {
            Assert.False(_aliveCell.WillBeAliveInNextIncarnation(numberOfAliveNeighbors));
        }
        
        [Theory(DisplayName = "Any live cell with more than three live neighbours dies, as if by overpopulation.")]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void Rule3_DiesWithMoreThanThreeNeighbors(int numberOfAliveNeighbors)
        {
            Assert.False(_aliveCell.WillBeAliveInNextIncarnation(numberOfAliveNeighbors));
        }

        [Theory(DisplayName = "Any live cell with two or three live neighbours lives on to the next generation.")]
        [InlineData(2)]
        [InlineData(3)]
        public void Rule2_AliveCellWillStillLiveWithTwoOrThreeNeighbors(int numberOfAliveNeighbors)
        {
            Assert.True(_aliveCell.WillBeAliveInNextIncarnation(numberOfAliveNeighbors));
        }

        [Fact]
        public void Rule5_DeadCellWillStayDeadWithTwoNeighbors()
        {
            Assert.False(_deadCell.WillBeAliveInNextIncarnation(2));
        }
        
    }
}