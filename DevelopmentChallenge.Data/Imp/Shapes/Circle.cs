using DevelopmentChallenge.Data.Helpers;
using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Imp
{
    public class Circle : I2DShape
    {
        private readonly decimal _diameter;

        public string Name => Shapes.Circle;
        public decimal Perimeter => (decimal)Math.PI * _diameter;
        public decimal Area => (decimal)Math.PI * (_diameter / 2) * (_diameter / 2);

        public Circle(decimal diameter) 
        {
            _diameter = diameter;
        }
    }
}
