using ceTe.DynamicPDF.HtmlConverter;
using System;

namespace html_converter_dotnet_core_cs
{
    class Program
    {
        static void Main(string[] args)
         {
            Util.CreatePath("Output");


            SimpleConversion.Run();
            Console.WriteLine("SimpleConversion is completed...");


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
            Console.WriteLine("AsyncConversionis completed...");

            /*
                        FileConversion.Run();
                        Console.WriteLine("Conversion with file content and anchor tag completed...");

                       


                        WithConversionOptions.Run();
                        Console.WriteLine("WithConversionOptions is completed...");

                        Console.WriteLine("Completed...");
                        Console.ReadLine();
            */
        }
    }
}
