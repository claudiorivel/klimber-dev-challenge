using DevelopmentChallenge.Data.Helpers;
using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Imp
{
    public class Square : I2DShape
    {
        private readonly decimal _side;

        public string Name => Shapes.Square;
        public decimal Perimeter => _side * 4;
        public decimal Area => _side * _side;

        public Square(decimal side)
        {
            _side = side;
        }
    }
}
