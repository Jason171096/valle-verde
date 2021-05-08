using Microsoft.Office.Interop.Word;

namespace ValleVerde
{
    internal class HTMLWorker
    {
        private Document pdfDoc;

        public HTMLWorker(Document pdfDoc)
        {
            this.pdfDoc = pdfDoc;
        }
    }
}