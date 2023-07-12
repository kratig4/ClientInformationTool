using IronOcr;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ClientInformationServices.Services.Impl
{
    public class PdfToText 
    {
        public string call(string filePath)
        {
            var ocr = new IronTesseract();

            using (var ocrInput = new OcrInput())
            {
                ocrInput.AddPdf(filePath);

                var ocrResult = ocr.Read(ocrInput);
                return ocrResult.Text;
            }
        }
    }
}
