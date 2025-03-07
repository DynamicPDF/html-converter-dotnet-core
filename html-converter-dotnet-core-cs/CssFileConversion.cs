using ceTe.DynamicPDF.HtmlConverter;
using System;

namespace html_converter_dotnet_core_cs
{
    class CssFileConversion
    {

       public static void Run()
        {
            FromFile();
            FromHtml();
        }

        public static void FromFile()
        {
            Uri uri = new Uri(new Uri("file://"), Util.GetPath("./Resources/example.html").ToString());
            Converter.Convert(uri, Util.GetPath("Output/CssFileConversion-file-out.pdf"));
        }

        public static void FromHtml()
        {
            Uri uri = new Uri(new Uri("file://"), Util.GetPath("./Resources/").ToString());
            string html = "<html><head><link rel = \"stylesheet\" type = \"text/css\" href = \"./example.css\" />"
                + "</head><body><h1>Welcome to DynamicPDF Html Converter.</h1>"
                + "<p>An example of embedded CSS stylesheet.</p>"
                + "</body></html>";
            Console.WriteLine(html);
            Converter.Convert(html, Util.GetPath("Output/CssFileConversion-raw-out.pdf"), uri);
        }

    }
}
