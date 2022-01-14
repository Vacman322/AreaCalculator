using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator.Figures
{
    public interface IFigure
    {
        double CalculateArea();

        bool TryCalculateArea(out double result, params double[] args);
    }
}
