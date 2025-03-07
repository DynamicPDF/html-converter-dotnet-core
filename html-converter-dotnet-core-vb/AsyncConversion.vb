Imports ceTe.DynamicPDF.HtmlConverter
Imports System.IO

Public Class AsyncConversion
    Public Shared Sub Run()
        RunFile()
        RunHtml()
        RunHtmlReturnByte()
    End Sub

    Public Shared Sub RunFile()
        Dim uri As New Uri(New Uri("file://"), Util.GetPath("./Resources/products.html"))
        Dim task As Task(Of Boolean) = Converter.ConvertAsync(uri, Util.GetPath("Output/AsyncConversion-file-out.pdf"))
    End Sub

    Public Shared Sub RunHtml()
        ' Create a simple HTML string
        Dim sampleHtml As String = "<html><body><p>This is a very simple HTML string including a Table below.</p>" &
                        "<h4>Two rows and three columns:</h4><table border='1'><tr><td>100</td><td>200</td>" &
                        "<td>300</td></tr><tr><td>400</td><td>500</td><td>600</td></tr></table></body></html>"

        ' Asynchronously Convert HTML to PDF with the conversion options specified
        Dim task As Task(Of Boolean) = Converter.ConvertAsync(sampleHtml, Util.GetPath("Output/AsyncConversion.pdf"))
    End Sub

    Public Shared Sub RunHtmlReturnByte()
        ' Create a simple HTML string
        Dim sampleHtml As String = "<html><body><p>This is a very simple HTML string including a Table below.</p>" &
                        "<h4>Two rows and three columns:</h4><table border='1'><tr><td>100</td><td>200</td>" &
                        "<td>300</td></tr><tr><td>400</td><td>500</td><td>600</td></tr></table></body></html>"

        Dim task As Task(Of Byte()) = Converter.ConvertAsync(sampleHtml)
        File.WriteAllBytes(Util.GetPath("Output/AsyncConversion-byte-out.pdf"), task.Result)
    End Sub
End Class

