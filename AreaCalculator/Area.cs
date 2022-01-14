using System;
using System.Linq;
using AreaCalculator.Figures;

namespace AreaCalculator
{
    public static class Area
    {
        /// <summary>
        /// Пытается вычислить площадь неизвестной фигуры по переданным аргументам 
        /// </summary>
        /// <param name="result">Переменная в которую записывается результат</param>
        /// <param name="args">Массив аргументов</param>
        /// <returns>true если удалось найти фигуру, которая может вычислить площадь по переданным аргументам, 
        /// иначе false</returns>
        public static bool TryCalculateAreaOfFigure(out double result, params double[] args)
        {
            result = default;
            var figures = typeof(Area).Assembly.ExportedTypes
                .Where(x => typeof(IFigure).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IFigure>()
                .ToList();

            foreach (var figure in figures)
            {
                if(figure.TryCalculateArea(out result, args))
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}
