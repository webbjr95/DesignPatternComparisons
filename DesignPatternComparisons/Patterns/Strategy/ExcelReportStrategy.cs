using ClosedXML.Excel;
using DesignPatternComparisons.Models;
using DesignPatternComparisons.Models.Enum;
using System;
using System.Collections.Generic;
using System.IO;

namespace DesignPatternComparisons.Patterns.Strategy
{
    public class ExcelReportStrategy : IReportStrategy
    {

        MemoryStream IReportStrategy.GetReport()
        {
            var data = new List<Person>()
            {
                new Person{ FirstName = "James", LastName = "Webb", Email = "jwebb@email.com", Phone = "123-456-7890"},
                new Person{ FirstName = "John", LastName = "Smith", Email = "jsmith@email.com", Phone = "456-789-1234"},
                new Person{ FirstName = "Shawn", LastName = "Doe", Email = "sdoe@email.com", Phone = "111-111-1111"},
                new Person{ FirstName = "Bill", LastName = "Hader", Email = "bhader@email.com", Phone = "999-999-9999"}
            };

            var workbook = BuildWorkbook(data);

            return workbook;
        }

        private MemoryStream BuildWorkbook(IEnumerable<Person> data)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("People");
                var currentRow = 1;
                var columnDictionary = BuildReportColumnHeaderDictionary();

                foreach (var item in columnDictionary)
                {
                    worksheet.Cell(currentRow, item.Key).Value = item.Value;
                }

                AddDataRowsToReportWorksheet(worksheet, currentRow, data);

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);

                    return stream;
                }
            }
        }

        private void AddDataRowsToReportWorksheet(IXLWorksheet worksheet, int currentRow, IEnumerable<Person> data)
        {
            foreach (var row in data)
            {
                currentRow++;

                worksheet.Cell(currentRow, (int)ReportColumnHeader.FirstName).Value = row.FirstName;
                worksheet.Cell(currentRow, (int)ReportColumnHeader.LastName).Value = row.LastName;
                worksheet.Cell(currentRow, (int)ReportColumnHeader.Email).Value = row.Email;
                worksheet.Cell(currentRow, (int)ReportColumnHeader.Phone).Value = row.Phone;
            }
        }

        private Dictionary<int, string> BuildReportColumnHeaderDictionary()
        {
            var commonProperties = Enum.GetValues(typeof(ReportColumnHeader));
            var columnDictionary = new Dictionary<int, string>();

            foreach (var prop in commonProperties)
            {
                columnDictionary.Add((int)prop, prop.ToString());
            }

            return columnDictionary;
        }
    }
}
