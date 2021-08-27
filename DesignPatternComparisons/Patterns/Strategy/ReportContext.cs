using System.IO;

namespace DesignPatternComparisons.Patterns.Strategy
{
    public class ReportContext
    {
        private IReportStrategy _strategy;

        public ReportContext(IReportStrategy strategy)
        {
            _strategy = strategy;
        }

        public MemoryStream ExecuteStrategy()
        {
            return _strategy.GetReport();
        }
    }
}
