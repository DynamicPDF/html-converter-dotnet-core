Imports ceTe.DynamicPDF.HtmlConverter



Friend Class EventHandlingExample

    Public Shared Sub Run(outputPath As String)

        AddHandler Converter.Loaded, AddressOf OnPageLoaded

        Converter.Convert(
                New Uri("https://www.google.com"),
                outputPath)

    End Sub

    Private Shared Sub OnPageLoaded(
            args As LoadedEventAgrs)

        Console.WriteLine("Page loaded.")

    End Sub

End Class
