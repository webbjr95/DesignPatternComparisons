using DesignPatternComparisons.Models;
using System.Collections.Generic;
using System.IO;

namespace DesignPatternComparisons.Patterns.FluentBuilder
{
    public interface IReportBuilder<T>
    {
        T Build();
        T SetWorksheetName(string name);
        IEnumerable<Person> GetData();
        T SetData(IEnumerable<Person> people);
        MemoryStream CreateStream();
    }
}
