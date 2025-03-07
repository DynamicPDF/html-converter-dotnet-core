Imports ceTe.DynamicPDF.HtmlConverter
Imports System

Namespace html_converter_dotnet_core_vb
    Class CssFileConversion

        Public Shared Sub Run()
            FromFile()
            FromHtml()
        End Sub

        Public Shared Sub FromFile()
            Dim uri As New Uri(New Uri("file://"), Util.GetPath("./Resources/example.html").ToString())
            Converter.Convert(uri, Util.GetPath("Output/CssFileConversion-file-out.pdf"))
        End Sub

        Public Shared Sub FromHtml()
            Dim uri As New Uri(New Uri("file://"), Util.GetPath("./Resources/").ToString())
            Dim html As String = "<html><head><link rel = 'stylesheet' type = 'text/css' href = './example.css' />" &
                "</head><body><h1>Welcome to DynamicPDF Html Converter.</h1>" &
                "<p>An example of embedded CSS stylesheet.</p>" &
                "</body></html>"
            Console.WriteLine(html)
            Converter.Convert(html, Util.GetPath("Output/CssFileConversion-raw-out.pdf"), uri)
        End Sub

    End Class
End Namespace
