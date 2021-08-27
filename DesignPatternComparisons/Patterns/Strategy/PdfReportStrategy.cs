using DesignPatternComparisons.Models;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System.Collections.Generic;
using System.IO;

namespace DesignPatternComparisons.Patterns.Strategy
{
    public class PdfReportStrategy : IReportStrategy
    {
        private PdfDocument _report = new PdfDocument();

        MemoryStream IReportStrategy.GetReport()
        {
            var data = new List<Person>()
            {
                new Person{ FirstName = "James", LastName = "Webb", Email = "jwebb@email.com", Phone = "123-456-7890"},
                new Person{ FirstName = "John", LastName = "Smith", Email = "jsmith@email.com", Phone = "456-789-1234"},
                new Person{ FirstName = "Shawn", LastName = "Doe", Email = "sdoe@email.com", Phone = "111-111-1111"},
                new Person{ FirstName = "Bill", LastName = "Hader", Email = "bhader@email.com", Phone = "999-999-9999"}
            };

            PdfPage page = _report.AddPage();
            _report.Info.Title = "Strat Your PDF";
            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);
            XTextFormatter tf = new XTextFormatter(gfx);

            var rect = new XRect(0, 0, page.Width, page.Height);

            var dataString = "";
            foreach (var item in data)
            {
                dataString += $"{item.FirstName} {item.LastName} {item.Email}\n";
            }

            gfx.DrawRectangle(XBrushes.SeaShell, rect);
            tf.Alignment = XParagraphAlignment.Center;
            tf.DrawString(dataString, font, XBrushes.Black, rect, XStringFormats.TopLeft);

            using (_report)
            {
                using (var stream = new MemoryStream())
                {
                    _report.Save(stream);

                    return stream;
                }
            }
        }
    }
}
