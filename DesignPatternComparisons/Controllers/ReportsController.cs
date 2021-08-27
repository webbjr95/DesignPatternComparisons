using DesignPatternComparisons.Models;
using DesignPatternComparisons.Models.Constants;
using DesignPatternComparisons.Patterns.FluentBuilder;
using DesignPatternComparisons.Patterns.Strategy;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DesignPatternComparisons.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly List<Person> _data;

        public ReportsController()
        {
            _data = new List<Person>{
                new Person { FirstName = "James", LastName = "Webb", Email = "jwebb@email.com", Phone = "123-456-7890" },
                new Person { FirstName = "John", LastName = "Smith", Email = "jsmith@email.com", Phone = "456-789-1234" },
                new Person { FirstName = "Shawn", LastName = "Doe", Email = "sdoe@email.com", Phone = "111-111-1111" },
                new Person { FirstName = "Bill", LastName = "Hader", Email = "bhader@email.com", Phone = "999-999-9999" }
            };
        }

        [HttpGet]
        [Route("ExcelFluentBuilder")]
        public FileContentResult FluentBuilderIndex()
        {
            var stream  = new ExcelReportBuilder()
                .SetWorksheetName("Too many cooks")
                .SetData(_data)
                .Build()
                .CreateStream();

            return File(stream.ToArray(), Constants.MimeTypes.XLSX);
        }

        [HttpGet]
        [Route("PdfFluentBuilder")]
        public FileContentResult PdfFluentBuilderIndex()
        {
            var stream = new PdfReportBuilder()
                .SetWorksheetName("PDFs are hard")
                .SetData(_data)
                .Build()
                .CreateStream();

            return File(stream.ToArray(), Constants.MimeTypes.PDF);
        }

        [HttpGet]
        [Route("ExcelStrategy")]
        public FileContentResult ExcelStrategyIndex()
        {
            var context = new ReportContext(new ExcelReportStrategy());
            var stream = context.ExecuteStrategy();

            return File(stream.ToArray(), Constants.MimeTypes.XLSX);
        }

        [HttpGet]
        [Route("PdfStrategy")]
        public FileContentResult PdfStrategyIndex()
        {
            var context = new ReportContext(new PdfReportStrategy());
            var stream = context.ExecuteStrategy();

            return File(stream.ToArray(), Constants.MimeTypes.PDF);
        }
    }
}
