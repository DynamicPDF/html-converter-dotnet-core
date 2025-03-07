using ceTe.DynamicPDF.HtmlConverter;
using System;
using System.IO;

namespace html_converter_dotnet_core_cs
{
    class ImageLocalExample
    {
        public static void Run()
        {
            FromFile();
            FromHtml();
        }

        public static void FromFile()
        {
            Uri uri = new Uri(new Uri("file://"), Util.GetPath("./Resources/products.html"));
            Converter.Convert(uri, Util.GetPath("Output/ImageLocalExample-file-out.pdf"));
        }

        public static void FromHtml()
        {
            Uri uri = new Uri(new Uri("file://"), Util.GetPath("./Resources/"));
            string html = File.ReadAllText(Util.GetPath("./Resources/products.html"));
            Converter.Convert(html, Util.GetPath("Output/ImageLocalExample-raw-out.pdf"), uri);
        }

    }
}
