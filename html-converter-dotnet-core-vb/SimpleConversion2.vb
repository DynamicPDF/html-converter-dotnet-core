Imports ceTe.DynamicPDF.HtmlConverter
Imports System

Public Class SimpleConversion2

    Public Shared Sub Run(
            inputPath As String,
            outputPath As String)

        RunLocalFile(inputPath, outputPath)
        RunString(outputPath)
        RunConversionOptions(inputPath, outputPath)

    End Sub

    Public Shared Sub RunLocalFile(
            inputPath As String,
            outputPath As String)

        Dim uri As New Uri(
                New Uri("file://"),
                inputPath)

        Converter.Convert(
                uri,
                outputPath & "/simple_one.pdf")

    End Sub

    Public Shared Sub RunString(
            outputPath As String)

        Dim html As String =
                "<html><body><h2>Hello DynamicPDF HTML Converter</h2></body></html>"

        Converter.Convert(
                html,
                outputPath & "/simple_two.pdf")

    End Sub

    Public Shared Sub RunConversionOptions(
            inputPath As String,
            outputPath As String)

        Dim uri As New Uri(
                New Uri("file://"),
                inputPath)

        Dim options As New ConversionOptions()

        options.Author = "ceTe Software"
        options.Title =
                "Simple Conversion with Conversion Options"

        options.TopMargin = 50
        options.BottomMargin = 50

        Converter.Convert(
                uri,
                outputPath & "/simple_three.pdf",
                options)

    End Sub

End Class
