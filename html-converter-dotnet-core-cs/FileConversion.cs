using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ceTe.DynamicPDF.HtmlConverter;

namespace html_converter_dotnet_core_cs
{
    class FileConversion
    {
        public static void Run()
        {
            string contents = File.ReadAllText(FileUtility.GetPath("../html-converter-dotnet-core-cs/Resources/html-with-anchor.html"));

            Converter.Convert(contents, "FileConversion.pdf");
        }
    }
}