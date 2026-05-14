

using ceTe.DynamicPDF.HtmlConverter;
using System;

namespace html_converter_dotnet_core_cs
{
    internal class TimeoutExceptionsExample
    {
        public static void Run()
        {
            int defaultPageLoad = ConversionOptions.DefaultPageLoadTimeout;
            int defaultConversionTimeout = ConversionOptions.DefaultConversionTimeout;

            Console.WriteLine("defaultPageLoadTimeout: " + defaultPageLoad);
            Console.WriteLine("defaultConversionTimeout: " + defaultConversionTimeout);
            Console.WriteLine("defaultCommandTimeout: " + ConversionOptions.DefaultCommandTimeout);

            RunPageLoad();
            Console.WriteLine("----------------------------------------");           
            RunConversionTimeout(defaultPageLoad);

        }
        public static void RunPageLoad()
        {
            try
            {

                ConversionOptions.DefaultPageLoadTimeout = 10;
                Converter.Convert(new Uri("https://www.gutenberg.org/cache/epub/815/pg815-images.html"), Util.GetPath("Output/TimeoutExampleConversion.pdf"));
                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                string errorText = ex.ToString();

                if (errorText.Contains("Navigation response not received",
                        StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("The page load operation timed out.");
                    Console.WriteLine($"Class: {ex}");
                    return;
                }
                if (errorText.Contains("Conversion timeout",
                        StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("The conversion operation timed out.");
                    Console.WriteLine($"Details: {ex.Message}");
                    Console.WriteLine($"Class: {ex}");
                    return;
                }

                Console.WriteLine("An unexpected error occurred during conversion.");
                Console.WriteLine($"Details: {ex.Message}");
            }

        }

        public static void RunConversionTimeout(int defaultPageLoad)
        {
            try
            {
                ConversionOptions.DefaultPageLoadTimeout = defaultPageLoad;
                ConversionOptions.DefaultConversionTimeout = 120;

                Converter.Convert(new Uri("https://www.gutenberg.org/cache/epub/815/pg815-images.html"), Util.GetPath("Output/TimeoutExampleConversion.pdf"));

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                string errorText = ex.ToString();
                if (errorText.Contains("Conversion timeout",
                        StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("The conversion operation timed out.");
                    Console.WriteLine($"Details: {ex.Message}");
                    Console.WriteLine($"Exception: {ex}");
                    return;
                }

                Console.WriteLine("An unexpected error occurred during conversion.");
                Console.WriteLine($"Details: {ex.Message}");
            }

        }
    }    
}
