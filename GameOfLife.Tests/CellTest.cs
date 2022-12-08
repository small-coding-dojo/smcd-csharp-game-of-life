using System;
using Xunit;

namespace GameOfLife.Tests
{
    public class CellTest
    {
  
        [Fact]
        public void TestThereIsACell()
        {
            // Given
            // nothing

            // When
            Cell cell = new Cell();

            // Then
            Assert.NotNull(cell);
        }

        [Fact]
        public void TestTheCellIsAlive()
        {
            // Given
            Cell cell = new Cell(true);

            // When
            // always
        
            // Then
            Assert.True(cell.IsAlive());
        }
        
        [Fact]
        public void TestTheCellIsDead()
        {
            // Given
            Cell deadCell = new Cell(false);

            // When
            // always
        
            // Then
            Assert.False(deadCell.IsAlive());
        }
        
        [Fact]
        public void TestTheCellIsAliveByDefault()
        {
            // Given
            Cell cell = new Cell();

            // When
            // always
        
            // Then
            Assert.True(cell.IsAlive());
        }

        [Fact]
        public void TestFirstRuleForNoLivingNeighbors()
        {
            // Given
            Cell cell = new Cell(true);

            // When
            Cell actual = Universe.GetNextIncarnation(cell, 0);
        
            // Then
            Assert.False(actual.IsAlive());
        }

        [Fact]
        public void TestFirstRuleForOneLivingNeighbor()
        {
            // Given
            Cell cell = new Cell(true);

            // When
            Cell actual = Universe.GetNextIncarnation(cell, 1);
        
            // Then
            Assert.False(actual.IsAlive());
        }
    }
}