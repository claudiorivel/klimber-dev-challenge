using DevelopmentChallenge.Data.Helpers;
using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Imp
{
    public class EquilateralTriangle : I2DShape
    {
        private readonly decimal _side;

        public string Name => Shapes.Triangle;
        public decimal Perimeter => _side * 3;
        public decimal Area => (decimal)(Math.Sqrt(3) / 4) * (decimal)Math.Pow((double)_side, 2);

        public EquilateralTriangle(decimal _base)
        {
            _side = _base;
        }
    }
}
