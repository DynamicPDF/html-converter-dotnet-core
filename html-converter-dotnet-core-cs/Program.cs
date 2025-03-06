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

            /*
                        FileConversion.Run();
                        Console.WriteLine("Conversion with file content and anchor tag completed...");

                       


                        WithConversionOptions.Run();
                        Console.WriteLine("WithConversionOptions is completed...");

                        AsyncConversion.Run();
                        Console.WriteLine("AsyncConversion was started...");

                        Console.WriteLine("Completed...");
                        Console.ReadLine();
            */
        }
    }
}
