using ceTe.DynamicPDF.HtmlConverter;
using System;

namespace html_converter_dotnet_core_cs
{
    class SimpleConversion2
    {

        public static void Run(string inputPath, string outputPath)
        {
            RunLocalFile(inputPath, outputPath);
            RunString(outputPath);
            RunConversionOptions(inputPath, outputPath);
        }
       
        public static void RunLocalFile(string inputPath, string outputPath)
        {
            Uri uri = new Uri(new Uri("file://"), inputPath);
            Converter.Convert(uri, outputPath + "/simple_one.pdf");
        }

        public static void RunString(string outputPath)
        {
            string html = "<html><body><h2>Hello DynamicPDF HTML Converter</h2></body></html>";
            Converter.Convert(html, outputPath + "/simple_two.pdf");
        }

        public static void RunConversionOptions(string inputPath, string outputPath)
        {
            Uri uri = new Uri(new Uri("file://"), inputPath);
            ConversionOptions options = new ConversionOptions();
            options.Author = "ceTe Software";
            options.Title = "Simple Conversion with Conversion Options";
            options.TopMargin = 50;
            options.BottomMargin = 50;
            Converter.Convert(uri, outputPath + "/simple_three.pdf", options);
        }
    }
}
