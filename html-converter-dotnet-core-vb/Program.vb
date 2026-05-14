Imports System

Module Program
    Sub Main(args As String())
        Util.CreatePath("Output")

        SimpleConversion.Run()
        Console.WriteLine("SimpleConversion is completed...")

        SimpleConversion2.Run(Util.GetPath("./Resources/products.html"), Util.GetPath("Output"))
        Console.WriteLine("SimpleConversion2 is completed...")

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

        BasePathExample.Run()
        Console.WriteLine("BasePathExample is completed...")

        ConverterParallelExample.Run().GetAwaiter().GetResult()
        Console.WriteLine("ConverterParallelExample was completed...")

        EventHandlingExample.Run(Util.GetPath("Output/event_output.pdf"))
        Console.WriteLine("EventHandlingExample is completed...")

    End Sub
End Module
