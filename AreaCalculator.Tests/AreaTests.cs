using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace AreaCalculator.Tests
{
    [TestFixture]
    public class AreaTests
    {
        [Test]
        public void TryCalculateAreaOfFigure_ShouldCalculateCircleAreaCorrectly_WhenArgsCountEqualsOne()
        {
            // Arrange
            var args = new double[] { 3 };
            double actualAreaValue;

            // Act
            var result = Area.TryCalculateAreaOfFigure(out actualAreaValue, args);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(Math.PI * args[0] * args[0],actualAreaValue);
        }

        [Test]
        public void TryCalculateAreaOfFigure_ShouldCalculateTriangleAreaCorrectly_WhenArgsCountEqualsThree()
        {
            // Arrange
            var args = new double[] { 3, 4, 5 };
            double actualAreaValue;
            var p = (args[0] + args[1] + args[2]) / 2;
            var expectedValue = Math.Sqrt(p * (p - args[0]) * (p - args[1]) * (p - args[2]));

            // Act
            var result = Area.TryCalculateAreaOfFigure(out actualAreaValue, args);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(expectedValue, actualAreaValue);
        }

        [Test]
        public void TryCalculateAreaOfFigure_ShouldReturnFalse_WhenArgsCountIsTooMany()
        {
            // Arrange
            var args = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            double actualAreaValue;

            // Act
            var result = Area.TryCalculateAreaOfFigure(out actualAreaValue, args);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(default(double),actualAreaValue);
        }

        [Test]
        public void TryCalculateAreaOfFigure_ShouldReturnFalse_WhenArgsCountEqualsZero()
        {
            // Arrange
            var args = new double[] { };
            double actualAreaValue;

            // Act
            var result = Area.TryCalculateAreaOfFigure(out actualAreaValue, args);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(default(double), actualAreaValue);
        }
    }
}