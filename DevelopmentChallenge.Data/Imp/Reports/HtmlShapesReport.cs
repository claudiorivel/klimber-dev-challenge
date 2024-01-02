using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Imp
{
    public class HtmlShapesReport : ShapesReportBase
    {
        private readonly StringBuilder _sb = new StringBuilder();

        public HtmlShapesReport(ReportData data, string language) : base(data, language) 
        {
        }

        private void SetHeader()
        {
            var str = $"<h1>{Text.Header}</h1>";
            _sb.Append(str);
        }

        private void SetFooter()
        {
            _sb.Append($"{Text.Total.ToUpper()}:<br/>");
            _sb.Append($"{ReportData.TotalCountOfShapes} {Text.Shapes} ");
            _sb.Append($"{Text.Perimeter} {ReportData.TotalSumOfPerimeter:#.##} ");
            _sb.Append($"{Text.Area} {ReportData.TotalSumOfArea:#.##}");
        }

        private void SetBody()
        {
            foreach (var item in ReportData.ShapesData)
            {
                var shapeDisplayName = ResourceManager.GetString(item.ShapeName);
                var str = $"{item.Quantity} {shapeDisplayName}(s) | {Text.Area} {item.TotalArea:#.##} | {Text.Perimeter} {item.TotalPerimeter:#.##} <br/>";
                _sb.Append(str);
            }
        }

        private string EmptyList()
        {
            var str = $"<h1>{Text.EmptyList}</h1>";
            _sb.Append(str);

            return _sb.ToString();
        }

        public override string Print()
        {
            if (!ReportData.ShapesData.Any())
            {
                return EmptyList();
            }

            SetHeader();
            SetBody();
            SetFooter();

            return _sb.ToString();
        }
    }
}
