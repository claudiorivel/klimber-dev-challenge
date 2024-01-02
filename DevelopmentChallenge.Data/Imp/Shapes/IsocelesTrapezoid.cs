using DevelopmentChallenge.Data.Helpers;
using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Imp
{
    public class IsocelesTrapezoid : I2DShape
    {
        private decimal _base;
        private decimal _top;
        private readonly decimal _sides;

        public string Name => Shapes.Trapezoid;
        public decimal Perimeter => _base + _top + (_sides * 2);
        public decimal Area => GetHeight() * ((_top + _base) / 2);

        public IsocelesTrapezoid(decimal bottom, decimal top, decimal sides)
        {
            _sides = sides;
            _base = bottom;
            _top = top;
        }

        private decimal GetHeight()
        {
            if (_base < _top)
            {
                var aux = _top;
                _top = _base;
                _base = aux;
            }

            // Based on the base and the top of an isoceles trapezoid we can get a rectangle triangle and therefore get the height of the trapezoid.
            // First we need to find the base of the rectangle triangle, then we can use Pitagoras.
            var x = (_base - _top) / 2;
            var height = (decimal)Math.Sqrt(Math.Pow((double)_sides, 2) - Math.Pow((double)x, 2));

            return height;
        }
    }
}
