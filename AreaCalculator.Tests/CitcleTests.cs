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
    class CitcleTests
    {
        [Test]
        public void Constructor_ShouldThrowsArgumentException_WhenRadiusIsNegative()
        {
            // Arrange
            var radius = -1;

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => new Circle(radius));
        }

        [Test]
        public void Constructor_ShouldSetCorrectRadius()
        {
            // Arrange
            var radius = 2;

            // Act
            var circle = new Circle(radius);

            // Assert
            Assert.AreEqual(radius, circle.Radius);
        }

        [Test]
        public void CalculateArea_ShouldReturnCorrectValue()
        {
            // Arrange
            var radius = 2;
            var circle = new Circle(radius);

            // Act
            var actualAreaValue = circle.CalculateArea();

            // Assert
            Assert.AreEqual(Math.PI * radius * radius, actualAreaValue);
        }

        [Test]
        public void TryCalculateArea_ShouldReturnTrue_WhenArgsCountIsOne()
        {
            // Arrange
            var args = new double[] { 54 };
            double actualArea;
            var circle = new Circle();

            // Act
            var actualResult = circle.TryCalculateArea(out actualArea, args);

            // Assert
            Assert.IsTrue(actualResult);
            Assert.AreEqual(Math.PI * args[0] * args[0], actualArea);
        }

        [Test]
        public void TryCalculateArea_ShouldReturnTrue_WhenArgsCountIsMoreThenOne()
        {
            // Arrange
            var args = new double[] { 54,2,3 };
            double actualArea;
            var circle = new Circle();

            // Act
            var actualResult = circle.TryCalculateArea(out actualArea, args);

            // Assert
            Assert.IsFalse(actualResult);
            Assert.AreEqual(default(double), actualArea);
        }
    }
}
