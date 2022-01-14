using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator.Figures
{
    /// <summary>
    /// Фигура - треугольник
    /// </summary>
    public class Triangle : IFigure
    {
        /// <summary>
        /// Сторона А
        /// </summary>
        public readonly double SideA;

        /// <summary>
        /// Сторона B
        /// </summary>
        public readonly double SideB;

        /// <summary>
        /// Сторона C
        /// </summary>
        public readonly double SideC;

        /// <summary>
        /// Создаёт треугольник со сторонами 1, 1, 1 
        /// </summary>
        public Triangle() : this(1,1,1)
        {
        }

        /// <summary>
        /// Создаёт треугольник с заданными сторонами 
        /// </summary>
        /// <param name="sideA">Сторона А</param>
        /// <param name="sideB">Сторона B</param>
        /// <param name="sideC">Сторона C</param>
        /// <exception cref="ArgumentException"></exception>
        public Triangle(double sideA, double sideB, double sideC)
        {
            if(sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("Sides cannot be negative");
            }

            if (sideA + sideB < sideC || sideA + sideC < sideB || sideB + sideC < sideA)
            {
                throw new ArgumentException("Impossible triangle");
            }

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        /// <summary>
        /// Вычисляет площадь треугольника
        /// </summary>
        /// <returns>Площадь треугольника</returns>
        public double CalculateArea()
        {
            var p = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }

        /// <summary>
        /// Является ли данный треугольник прямоугольным
        /// </summary>
        public bool IsRightTriangle
            => (SideA * SideA + SideB * SideB - SideC * SideC) == 0 ||
               (SideA * SideA + SideC * SideC - SideB * SideB) == 0 ||
               (SideC * SideC + SideB * SideB - SideA * SideA) == 0;

        /// <summary>
        /// Пытается вычислить площадь треугольника 
        /// </summary>
        /// <param name="result">Переменная в которую записывается результат</param>
        /// <param name="args">Массив аргументов</param>
        /// <returns>true если количество аргументов равно 3 и удалось вычислить площадь, иначе false</returns>
        public bool TryCalculateArea(out double result, params double[] args)
        {
            result = default;
            if (args.Length != 3)
                return false;
            try
            {
                var triangle = new Triangle(args[0], args[1], args[2]);
                result = triangle.CalculateArea();
            }
            catch (ArgumentException)
            {
                return false;
            }
            

            return true;
        }
    }
}
