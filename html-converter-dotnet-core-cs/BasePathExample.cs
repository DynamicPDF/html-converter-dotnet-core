using ceTe.DynamicPDF.HtmlConverter;
using System;
using System.IO;

namespace html_converter_dotnet_core_cs
{
    public class BasePathExample
    {
        public static void Run()
        {
            ImageRun();
            ImageFileRun();
            ImageFileHtmlRun();
        }

        public static void ImageRun()
        {
            Uri baseUrl = new Uri("https://www.dynamicpdf.com/");
            string html = "<body><p>This is local HTML string.</p>" +
                "<img src=\"./images/logo.png\"></body>";


            Converter.Convert(html, Util.GetPath("Output/BasePathExample-out.pdf"), baseUrl);
        }

        public static void ImageFileHtmlRun()
        {
            
            Uri baseUrl = new Uri("https://www.dynamicpdf.com/");
            string html = File.ReadAllText(Util.GetPath("./Resources/simple.html"));
            Converter.Convert(html, Util.GetPath("Output/BasePathExample-file-out.pdf"), baseUrl);
        }

        public static void ImageFileRun()
        {
            Uri uri = new Uri(new Uri("file://"), Util.GetPath("./Resources/simple2.html"));
           
            Converter.Convert(uri, Util.GetPath("Output/BasePathExample-file-html-out.pdf"));
        }

    }
}
