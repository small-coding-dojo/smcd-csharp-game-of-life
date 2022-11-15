using System;
using Xunit;

namespace GameOfLife.Tests
{
    public class CellTest
    {
        [Fact]
        public void LoneCellIsDead()
        {
            Assert.True(Cell.At(0,0).IsDead());
        }

        /*[Fact]
         
        // Ideas: Split Cell into World and Cell 
        public void CellIsBorn()
        {
            Assert.True(Cell.At(1,1).IsDead());
            // Three outer cells are alive
            Cell.At(0, 0).Live();
            Cell.At(0, 1).Live();
            Cell.At(0, 2).Live();
            
            Cell.At(1, 0).Die();
            Cell.At(1, 2).Die();
            
            Cell.At(2, 0).Die();
            Cell.At(2, 1).Die();
            Cell.At(2, 2).Die();
            // middle cell should get alive now
            Cell.Generation();
            Assert.False(Cell.At(1,1).IsDead());
        }*/
        
        [Fact]
        public void CellHandlesBirthCorrectly()
        {
            Assert.True(Cell.At(0,0).IsDead());
            Cell.At(0,0).Live();
            Assert.False(Cell.At(0,0).IsDead());
        }
    }
}