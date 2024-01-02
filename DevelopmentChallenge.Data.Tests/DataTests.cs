using DevelopmentChallenge.Data.Helpers;
using DevelopmentChallenge.Data.Imp;
using DevelopmentChallenge.Data.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            var data = new DataProcessor(new List<I2DShape>()).ProcessData();
            var report = new HtmlShapesReport(data, Languages.Castellano);

            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                report.Print());
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            var data = new DataProcessor(new List<I2DShape>()).ProcessData();
            var report = new HtmlShapesReport(data, Languages.Ingles);

            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                report.Print());
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<I2DShape> { new Square(5) };
            var data = new DataProcessor(cuadrados).ProcessData();
            var resumen = new HtmlShapesReport(data, Languages.Castellano).Print();

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado(s) | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<I2DShape>
            {
                new Square(5),
                new Square(1),
                new Square(3),
            };

            var data = new DataProcessor(cuadrados).ProcessData();
            var resumen = new HtmlShapesReport(data, Languages.Ingles).Print();

            Assert.AreEqual("<h1>Shapes report</h1>3 Square(s) | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<I2DShape>
            {
                new Square(5),
                new Circle(3),
                new EquilateralTriangle(4),
                new Square(2),
                new EquilateralTriangle(9),
                new Circle(2.75M),
                new EquilateralTriangle(4.2M)
            };

            var data = new DataProcessor(formas).ProcessData();
            var resumen = new HtmlShapesReport(data, Languages.Ingles).Print();

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Square(s) | Area 29 | Perimeter 28 <br/>2 Circle(s) | Area 13,01 | Perimeter 18,06 <br/>3 Triangle(s) | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<I2DShape>
            {
                new Square(5),
                new Circle(3),
                new EquilateralTriangle(4),
                new Square(2),
                new EquilateralTriangle(9),
                new Circle(2.75M),
                new EquilateralTriangle(4.2M)
            };

            var data = new DataProcessor(formas).ProcessData();
            var resumen = new HtmlShapesReport(data, Languages.Castellano).Print();

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrado(s) | Area 29 | Perimetro 28 <br/>2 Círculo(s) | Area 13,01 | Perimetro 18,06 <br/>3 Triángulo(s) | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }


        // Some more tests


        [TestCase]
        public void TestResumenListaVaciaFormasEnItaliano()
        {
            var data = new DataProcessor(new List<I2DShape>()).ProcessData();
            var report = new HtmlShapesReport(data, Languages.Italiano);

            Assert.AreEqual("<h1>Lista vuota!</h1>",
                report.Print());
        }

        [TestCase]
        public void TestResumenListaConUnTrapecio()
        {
            var trapecios = new List<I2DShape> { new IsocelesTrapezoid(10, 4, 8) };
            var data = new DataProcessor(trapecios).ProcessData();
            var resumen = new HtmlShapesReport(data, Languages.Castellano).Print();

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Trapecio(s) | Area 51,91 | Perimetro 30 <br/>TOTAL:<br/>1 formas Perimetro 30 Area 51,91", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnRectangulo()
        {
            var rectangulos = new List<I2DShape> { new IsocelesTrapezoid(4, 4, 2) };      // Equivalente a un rectangulo de 4 x 2
            var data = new DataProcessor(rectangulos).ProcessData();
            var resumen = new HtmlShapesReport(data, Languages.Castellano).Print();

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Trapecio(s) | Area 8 | Perimetro 12 <br/>TOTAL:<br/>1 formas Perimetro 12 Area 8", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTrapeciosEnItaliano()
        {
            var trapecios = new List<I2DShape>
            {
                new IsocelesTrapezoid(10, 4, 8),
                new IsocelesTrapezoid(12, 6, 10),
                new IsocelesTrapezoid(14, 7, 10),
            };

            var data = new DataProcessor(trapecios).ProcessData();
            var resumen = new HtmlShapesReport(data, Languages.Italiano).Print();

            Assert.AreEqual("<h1>Rapporto sui moduli</h1>3 Trapezio(s) | Zona 236,13 | Perimetro 109 <br/>TOTALE:<br/>3 formes Perimetro 109 Zona 236,13", resumen);
        }
    }
}
