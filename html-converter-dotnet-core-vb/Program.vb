Imports System

Module Program
    Sub Main(args As String())
        Util.CreatePath("Output")

        SimpleConversion.Run()
        Console.WriteLine("SimpleConversion is completed...")

        ConvertToByteArray.Run()
        Console.WriteLine("ConvertToByteArray is completed...")

        HtmlConversionUsingString.Run()
        Console.WriteLine("HtmlConversionUsingString is completed...")

        WithConversionOptions.Run()
        Console.WriteLine("WithConversionOptions is completed...")

        AsyncConversion.Run()
        Console.WriteLine("AsyncConversion was started...")

        CssFileConversion.Run()
        Console.WriteLine("CssFileConversion is completed...")

        ImageLocalExample.Run()
        Console.WriteLine("ImageLocalExample is completed...")

        JavaScriptCssConversion.Run()
        Console.WriteLine("JavaScriptCssConversion is completed...")

    End Sub
End Module
