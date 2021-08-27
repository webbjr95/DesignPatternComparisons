using System.IO;

namespace DesignPatternComparisons.Patterns.Strategy
{
    public interface IReportStrategy
    {
        MemoryStream GetReport();
    }
}
