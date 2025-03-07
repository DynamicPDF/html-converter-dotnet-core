Imports ceTe.DynamicPDF.HtmlConverter
Imports System.IO

Class ImageLocalExample
    Public Shared Sub Run()
        FromFile()
        FromHtml()
    End Sub

    Public Shared Sub FromFile()
        Dim uri As New Uri(New Uri("file://"), Util.GetPath("./Resources/products.html"))
        Converter.Convert(uri, Util.GetPath("Output/ImageLocalExample-file-out.pdf"))
    End Sub

    Public Shared Sub FromHtml()
        Dim uri As New Uri(New Uri("file://"), Util.GetPath("./Resources/"))
        Dim html As String = File.ReadAllText(Util.GetPath("./Resources/products.html"))
        Converter.Convert(html, Util.GetPath("Output/ImageLocalExample-raw-out.pdf"), uri)
    End Sub
End Class

