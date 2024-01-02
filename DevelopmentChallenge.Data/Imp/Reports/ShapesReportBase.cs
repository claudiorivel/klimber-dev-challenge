using System.Globalization;
using System.Resources;
using System.Threading;

namespace DevelopmentChallenge.Data.Imp
{
    public abstract class ShapesReportBase
    {
        protected readonly ResourceManager ResourceManager;
        protected ReportData ReportData = new ReportData();

        public ShapesReportBase(ReportData data, string language)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            ResourceManager = new ResourceManager("DevelopmentChallenge.Data.Text", typeof(HtmlShapesReport).Assembly);

            ReportData = data;
        }

        public abstract string Print();
    }
}