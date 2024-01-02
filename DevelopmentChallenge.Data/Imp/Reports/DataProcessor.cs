using DevelopmentChallenge.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DevelopmentChallenge.Data.Imp
{
    public class DataProcessor
    {
        private readonly List<I2DShape> _shapes;
        public DataProcessor(IEnumerable<I2DShape> shapes) 
        {
            _shapes = shapes.ToList();
        }

        public ReportData ProcessData()
        {
            var shapesTypes = _shapes.GroupBy(x => x.Name)
                .Select(y => new { Name = y.Key, Shapes = y.ToList() })
                .ToList();

            var reportData = new ReportData();

            foreach (var shapeType in shapesTypes)
            {
                var shape = new ShapeData
                {
                    ShapeName = shapeType.Name,
                    Quantity = shapeType.Shapes.Count(),
                    TotalArea = shapeType.Shapes.Sum(x => x.Area),
                    TotalPerimeter = shapeType.Shapes.Sum(x => x.Perimeter)
                };

                reportData.ShapesData.Add(shape);
            }

            reportData.TotalCountOfShapes = _shapes.Count;
            reportData.TotalSumOfArea = reportData.ShapesData.Sum(x => x.TotalArea);
            reportData.TotalSumOfPerimeter = reportData.ShapesData.Sum(x => x.TotalPerimeter);

            return reportData;
        }
    }

    public class ReportData
    {
        public ReportData()
        {
            ShapesData = new List<ShapeData>();
        }

        public List<ShapeData> ShapesData { get; set; }
        public int TotalCountOfShapes { get; set; }
        public decimal TotalSumOfArea { get; set; }
        public decimal TotalSumOfPerimeter { get; set; }
    }

    public class ShapeData
    {
        public string ShapeName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalArea { get; set; }
        public decimal TotalPerimeter { get; set; }
    }
}
