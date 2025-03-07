Imports ceTe.DynamicPDF.HtmlConverter

Class JavaScriptCssConversion

    Private Shared samplePageWithCss As String = "<!DOCTYPE html><html><head ><style>" _
            & "body {background-color: lightblue;}" _
            & "h1 {color: white; text-align: center;} p " _
            & "{font-family: verdana;font-size: 20px;}</style>" _
            & "</head><body><h1>My First CSS Example</h1>" _
            & "<p>This is a paragraph.</p></body></html>"

    Private Shared samplePageWithJavaScript As String = "<!DOCTYPE html><html><body>" _
            & "<h2>My First Web Page</h2>" _
            & "<p>My First Paragraph.</p><p id=""demo""></p>" _
            & "<script>document.getElementById(""demo"")" _
            & ".innerHTML = 5 + 6;</script></body></html>"

    Public Shared Sub Run()
        Converter.Convert(samplePageWithCss, Util.GetPath("Output/cssExample.pdf"))
        Converter.Convert(samplePageWithJavaScript, Util.GetPath("Output/jscriptExample.pdf"))
    End Sub

End Class

