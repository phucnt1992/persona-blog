using Persona.SharedKernel;
using System.Collections.Generic;

namespace Persona.SharedKernel.Tests
{
    using System;
    using Xunit;

    internal class Point : ValueObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return this.X;
            yield return this.Y;
        }

    }

    public class ValueObjectTests
    {
        [Fact]
        public void Equals_GivenDifferenceValues_ShouldReturnFalse()
        {
            var point1 = new Point(1, 2);
            var point2 = new Point(2, 3);

            Assert.False(point1.Equals(point2));
        }

        [Fact]
        public void Equals_GivenSameValues_ShouldReturnTrue()
        {
            var point1 = new Point(1, 1);
            var point2 = new Point(1, 1);

            Assert.True(point1.Equals(point2));
        }
    }
}
