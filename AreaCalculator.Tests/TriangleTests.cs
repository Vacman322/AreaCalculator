using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AreaCalculator.Figures;
using NUnit.Framework;

namespace AreaCalculator.Tests
{
    [TestFixture]
    class TriangleTests
    {
        [Test]
        public void Constructor_ShouldThrowsArgumentException_WhenOneOrMoreSidesAreNegative()
        {
            // Arrange
            var sideA = -1;
            var sideB = 1;
            var sideC = 1;

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => new Triangle(sideA,sideB,sideC));
        }

        [Test]
        public void Constructor_ShouldThrowsArgumentException_WhenTriangleIsImpossible()
        {
            // Arrange
            var sideA = 10;
            var sideB = 5;
            var sideC = 1;

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
        }

        [Test]
        public void Constructor_ShouldSetCorrectSides()
        {
            // Arrange
            var sideA = 3;
            var sideB = 4;
            var sideC = 5;

            // Act
            var triangle = new Triangle(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual(sideA, triangle.SideA);
            Assert.AreEqual(sideB, triangle.SideB);
            Assert.AreEqual(sideC, triangle.SideC);
        }

        [Test]
        public void CalculateArea_ShouldReturnCorrectValue()
        {
            // Arrange
            var sideA = 3;
            var sideB = 4;
            var sideC = 5;
            var p = (sideA + sideB + sideC) / 2;
            var expected = Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));

            // Act
            var triangle = new Triangle(sideA, sideB, sideC);
            var actualArea = triangle.CalculateArea();

            // Assert
            Assert.AreEqual(expected, actualArea);
        }

        [Test]
        public void IsRightTriangle_ShouldReturnTrue_WhenTriangelIsRight()
        {
            // Arrange
            var sideA = 3;
            var sideB = 4;
            var sideC = 5;

            // Act
            var triangle = new Triangle(sideA, sideB, sideC);
            var result = triangle.IsRightTriangle;

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsRightTriangle_ShouldReturnFalse_WhenTriangelIsNotRight()
        {
            // Arrange
            var sideA = 3;
            var sideB = 2;
            var sideC = 5;

            // Act
            var triangle = new Triangle(sideA, sideB, sideC);
            var result = triangle.IsRightTriangle;

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TryCalculateArea_ShouldReturnTrue_WhenArgsCountIsThree()
        {
            // Arrange
            var args = new double[] { 3,4,5 };
            double actualArea;
            var triangle = new Triangle();
            var p = (args[0] + args[1] + args[2]) / 2;
            var expected = Math.Sqrt(p * (p - args[0]) * (p - args[1]) * (p - args[2]));


            // Act
            var actualResult = triangle.TryCalculateArea(out actualArea, args);

            // Assert
            Assert.IsTrue(actualResult);
            Assert.AreEqual(expected, actualArea);
        }

        [Test]
        public void TryCalculateArea_ShouldReturnFalse_WhenArgsCountNotEqualsThree()
        {
            // Arrange
            var args = new double[] { 3};
            double actualArea;
            var triangle = new Triangle();


            // Act
            var actualResult = triangle.TryCalculateArea(out actualArea, args);

            // Assert
            Assert.IsFalse(actualResult);
            Assert.AreEqual(default(double), actualArea);
        }
    }
}
