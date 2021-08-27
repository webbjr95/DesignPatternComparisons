using DesignPatternComparisons.Models;
using DesignPatternComparisons.Patterns.FluentBuilder;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatternsTests
{
    public class FluentBuilderTests
    {
        private ExcelReportBuilder _excelBuilder = new ExcelReportBuilder();
        private PdfReportBuilder _pdfBuilder = new PdfReportBuilder();

        public FluentBuilderTests()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        [Fact]
        public void SetDataPasses()
        {
            // Arrange
            var data = new List<Person>()
            {
                new Person{ FirstName = "James", LastName = "Webb", Email = "jwebb@email.com", Phone = "123-456-7890"},
                new Person{ FirstName = "John", LastName = "Smith", Email = "jsmith@email.com", Phone = "456-789-1234"},
                new Person{ FirstName = "Shawn", LastName = "Doe", Email = "sdoe@email.com", Phone = "111-111-1111"},
                new Person{ FirstName = "Bill", LastName = "Hader", Email = "bhader@email.com", Phone = "999-999-9999"}
            };

            // Act
            var excelReport = _excelBuilder.SetData(data);
            var pdfReport = _pdfBuilder.SetData(data);

            var excelData = excelReport.GetData();
            var pdfData = pdfReport.GetData();

            // Assert
            Assert.True(excelData == pdfData);
        }
    }
}
