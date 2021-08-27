using ClosedXML.Excel;
using DesignPatternComparisons.Models;
using DesignPatternComparisons.Models.Enum;
using System;
using System.Collections.Generic;
using System.IO;

namespace DesignPatternComparisons.Patterns.FluentBuilder
{
    public class ExcelReportBuilder : IReportBuilder<ExcelReportBuilder>
    {
        private XLWorkbook _report = new XLWorkbook();
        private string _worksheetName;
        private Enum _header;
        private IEnumerable<Person> _data;
        private int _currentRow = 1;

        public ExcelReportBuilder Build()
        {
            var worksheet = BuildWorksheet();
            BuildHeader(worksheet);
            BuildData(worksheet);

            return this;
        }

        public ExcelReportBuilder SetWorksheetName(string name)
        {
            _worksheetName = name;
            return this;
        }

        public ExcelReportBuilder SetHeader(Enum type)
        {
            _header = type;
            return this;
        }

        public IEnumerable<Person> GetData()
        {
            return _data;
        }

        public ExcelReportBuilder SetData(IEnumerable<Person> data)
        {
            _data = data;
            return this;
        }

        public MemoryStream CreateStream()
        {
            using (_report)
            {
                using (var stream = new MemoryStream())
                {
                    _report.SaveAs(stream);

                    return stream;
                }
            }
        }

        private IXLWorksheet BuildWorksheet()
        {
            return _report.Worksheets.Add(_worksheetName);
        }

        private void BuildHeader(IXLWorksheet worksheet)
        {
            var commonProperties = Enum.GetValues(typeof(ReportColumnHeader));

            foreach (var prop in commonProperties)
            {
                worksheet.Cell(_currentRow, (int)prop).Value = prop.ToString();
            }
        }

        private void BuildData(IXLWorksheet worksheet)
        {
            foreach (var row in _data)
            {
                _currentRow++;

                worksheet.Cell(_currentRow, (int)ReportColumnHeader.FirstName).Value = row.FirstName;
                worksheet.Cell(_currentRow, (int)ReportColumnHeader.LastName).Value = row.LastName;
                worksheet.Cell(_currentRow, (int)ReportColumnHeader.Email).Value = row.Email;
                worksheet.Cell(_currentRow, (int)ReportColumnHeader.Phone).Value = row.Phone;
            }
        }
    }
}

