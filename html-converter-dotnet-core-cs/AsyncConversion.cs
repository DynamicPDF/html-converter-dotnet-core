
using ceTe.DynamicPDF.HtmlConverter;
using System;
using System.IO;
using System.Threading.Tasks;

namespace html_converter_dotnet_core_cs
{
    public class AsyncConversion
    {
        public static void Run()
        {
            RunFile();
            RunHtml();
            RunHtmlReturnByte();
          
        }

        public static void RunFile()
        {
            Uri uri = new Uri(new Uri("file://"), Util.GetPath("./Resources/products.html"));
            Task<bool> task = Converter.ConvertAsync(uri, Util.GetPath("Output/AsyncConversion-file-out.pdf"));
            Console.WriteLine("The result of task from file: " + task.Result);
        }

        public static void RunHtml()
        {
            // Create a simple HTML string 
            string sampleHtml = "<html><body><p>This is a very simple HTML string including a Table below.</p>" +
                        "<h4>Two rows and three columns:</h4><table border=\"1\"><tr><td>100</td><td>200</td>" +
                        "<td>300</td></tr><tr><td>400</td><td>500</td><td>600</td></tr></table></body></html>";

            // Asynchronously Convert HTML to PDF with the conversion options specified
            Task<bool> task = Converter.ConvertAsync(sampleHtml, Util.GetPath("Output/AsyncConversion.pdf"));
            Console.WriteLine("The result of task from html: " + task.Result);
        }

        public static void RunHtmlReturnByte()
        {
            // Create a simple HTML string 
            string sampleHtml = "<html><body><p>This is a very simple HTML string including a Table below.</p>" +
                        "<h4>Two rows and three columns:</h4><table border=\"1\"><tr><td>100</td><td>200</td>" +
                        "<td>300</td></tr><tr><td>400</td><td>500</td><td>600</td></tr></table></body></html>";

            Task<Byte[]> task = Converter.ConvertAsync(sampleHtml);
            File.WriteAllBytes(Util.GetPath("Output/AsyncConversion-byte-out.pdf"), task.Result);
        }

    }
}