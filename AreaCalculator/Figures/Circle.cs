using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator.Figures
{
    /// <summary>
    /// Фигура - круг
    /// </summary>
    public class Circle : IFigure
    {
        /// <summary>
        /// Радиус круга. Должен быть больше нуля
        /// </summary>
        public readonly double Radius;

        /// <summary>
        /// Создаёт круг с радиусом 1
        /// </summary>
        public Circle()
        {
            Radius = 1;
        }

        /// <summary>
        /// Создаёт круг с заданным радиусом
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        /// <param name="radius">Радиус</param>
        public Circle(double radius)
        {
            if(radius <= 0)
            {
                throw new ArgumentException("Radius cannot be negative");
            }

            Radius = radius;
        }

        /// <summary>
        /// Вычисляет площадь круга
        /// </summary>
        /// <returns>Площадь круга</returns>
        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        /// <summary>
        /// Пытается вычислить площадь круга 
        /// </summary>
        /// <param name="result">Переменная в которую записывается результат</param>
        /// <param name="args">Массив аргументов</param>
        /// <returns>true если количество аргументов равно 1 и удалось вычислить площадь, иначе false</returns>
        public bool TryCalculateArea(out double result, params double[] args)
        {
            result = default;
            if (args.Length != 1)
                return false;

            try
            {
                var circle = new Circle(args[0]);
                result = circle.CalculateArea();
            }
            catch (ArgumentException)
            {
                return false;
            }
            

            return true;
        }
    }
}
