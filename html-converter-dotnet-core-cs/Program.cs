using ceTe.DynamicPDF.HtmlConverter;
using System;

namespace html_converter_dotnet_core_cs
{
    class Program
    {
        static void Main(string[] args)
         {
            Util.CreatePath("Output");

            //   SimpleConversion.Run(Util.GetPath("Output/SimpleConversion.pdf"));
            //   Console.WriteLine("SimpleConversion is completed...");

            //    string inputPath = Util.GetPath("../html-converter-dotnet-core-cs/Resources/products.html");
            //    SimpleConversion2.Run(inputPath, Util.GetPath("Output/"));
            //    Console.WriteLine("SimpleConversion2 is completed...");

            //      EventHandlingExample.Run(Util.GetPath("Output/EventHandling.pdf"));
            //     Console.WriteLine("EventHandlingExample is completed...");

            CancelationTokenExample.RunAsync().GetAwaiter().GetResult();
            Console.WriteLine("CancelationTokenExample is completed...");

            /*
                        HtmlConversionUsingString.Run();
                        Console.WriteLine("HtmlConversionUsingString is completed...");

                        ConvertToByteArray.Run();
                        Console.WriteLine("ConvertToByteArray is completed...");

                        JavaScriptCssConversion.Run();
                        Console.WriteLine("JavaScriptConversion is completed...");

                        CssFileConversion.Run();
                        Console.WriteLine("CssFileConversion is completed...");

                        ImageLocalExample.Run();
                        Console.WriteLine("ImageLocalExample is completed...");

                        AsyncConversion.Run();
                        Console.WriteLine("AsyncConversion is completed...");

                        BasePathExample.Run();
                        Console.WriteLine("BasePathExample conversion is completed...");

                        FileConversion.Run();
                        Console.WriteLine("Conversion with file content and anchor tag completed...");


                        WithConversionOptions.Run();
                        Console.WriteLine("WithConversionOptions is completed...");
                        */

            // TimeoutExceptionsExample.Run();
            //    Console.WriteLine("TimeoutExampleConversion is completed...");

            // ConverterParallelExample.Run().Wait();
            //  Console.WriteLine("ConverterParallelExample is completed...");

            Console.WriteLine("Completed...");

        }
    }
}
