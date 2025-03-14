Imports ceTe.DynamicPDF.HtmlConverter
Imports System
Imports System.IO

Public Class BasePathExample
    Public Shared Sub Run()
        ImageRun()
        ImageFileRun()
        ImageFileHtmlRun()
    End Sub

    Public Shared Sub ImageRun()
        Dim baseUrl As New Uri("https://www.dynamicpdf.com/")
        Dim html As String = "<body><p>This is local HTML string.</p>" &
            "<img src=""./images/logo.png""></body>"

        Converter.Convert(html, Util.GetPath("Output/BasePathExample-out.pdf"), baseUrl)
    End Sub

    Public Shared Sub ImageFileHtmlRun()
        Dim baseUrl As New Uri("https://www.dynamicpdf.com/")
        Dim html As String = File.ReadAllText(Util.GetPath("./Resources/simple.html"))
        Converter.Convert(html, Util.GetPath("Output/BasePathExample-file-out.pdf"), baseUrl)
    End Sub

    Public Shared Sub ImageFileRun()
        Dim uri As New Uri(New Uri("file://"), Util.GetPath("./Resources/simple2.html"))

        Converter.Convert(uri, Util.GetPath("Output/BasePathExample-file-html-out.pdf"))
    End Sub

End Class

