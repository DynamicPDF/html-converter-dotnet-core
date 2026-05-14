
using ceTe.DynamicPDF.HtmlConverter;
using System;

namespace html_converter_dotnet_core_cs
{
    internal class EventHandlingExample
    {
        public static void Run(string outputPath)
        {
            Converter.Loaded += OnPageLoaded;
            Converter.Convert(new Uri("https://www.google.com"), outputPath);
        }
        private static void OnPageLoaded(LoadedEventAgrs args)
        {
            Console.WriteLine("Page loaded.");
        }
    }
}
