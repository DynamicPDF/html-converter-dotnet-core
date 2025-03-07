using ceTe.DynamicPDF.HtmlConverter;

namespace html_converter_dotnet_core_cs
{
    class JavaScriptCssConversion
    {

        static string samplePageWithCss = "<!DOCTYPE html><html><head ><style>" 
            + "body {background-color: lightblue;}"
            + "h1 {color: white; text-align: center;} p "
            + "{font-family: verdana;font - size: 20px;}</style>"
            + "</head><body><h1>My First CSS Example</h1>"
            + "<p>This is a paragraph.</p></body></html>";

        static string samplePageWithJavaScript = "<!DOCTYPE html><html><body>"
            + "<h2>My First Web Page</h2>"
            + "<p>My First Paragraph.</p><p id=\"demo\"></p>"
            + "<script>document.getElementById(\"demo\")"
            + ".innerHTML = 5 + 6;</script></body></html>";

        public static void Run()
        {
            Converter.Convert(samplePageWithCss, Util.GetPath("Output/cssExample.pdf"));
            Converter.Convert(samplePageWithJavaScript, Util.GetPath("Output/jscriptExample.pdf"));
        }
    }
}
