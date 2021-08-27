using DesignPatternComparisons.Models;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System.Collections.Generic;
using System.IO;

namespace DesignPatternComparisons.Patterns.FluentBuilder
{
    public class PdfReportBuilder : IReportBuilder<PdfReportBuilder>
    {
        private PdfDocument _report = new PdfDocument();
        private IEnumerable<Person> _data;

        public PdfReportBuilder Build()
        {
            PdfPage page = _report.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);
            XTextFormatter tf = new XTextFormatter(gfx);

            var rect = new XRect(0, 0, page.Width, page.Height);

            var dataString = "";
            foreach (var item in _data)
            {
                dataString += $"{item.FirstName} {item.LastName} {item.Email}\n";
            }

            gfx.DrawRectangle(XBrushes.SeaShell, rect);
            tf.Alignment = XParagraphAlignment.Center;
            tf.DrawString(dataString, font, XBrushes.Black, rect, XStringFormats.TopLeft);

            return this;
        }

        public PdfReportBuilder SetWorksheetName(string name)
        {
            _report.Info.Title = name;
            return this;
        }

        public IEnumerable<Person> GetData()
        {
            return _data;
        }

        public PdfReportBuilder SetData(IEnumerable<Person> data)
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
                    _report.Save(stream);

                    return stream;
                }
            }
        }
    }
}
