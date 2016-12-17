using System;
using System.IO;
using System.Web.Mvc;

namespace Covalition.Igorary.Mvc.Extensions
{
    public class MvcPanel : IDisposable
    {
        private readonly TextWriter _writer;
        private readonly string _footer;

        public MvcPanel(ViewContext viewContext, string footer) {
            _writer = viewContext.Writer;
            _footer = footer;
        }

        public void Dispose() {
            string footerHtml = _footer != null ? string.Format("<div class=\"panel-footer\">{0}</div>", _footer) : string.Empty;
            _writer.Write(string.Format("</div>{0}</div>", footerHtml));
        }
    }
}