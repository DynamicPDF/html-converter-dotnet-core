Imports ceTe.DynamicPDF.HtmlConverter
Imports System
Imports System.Threading
Imports System.Threading.Tasks


Friend Class CancelationTokenExample

    Public Shared Async Function RunAsync() As Task

        Dim conversionOptions As New ConversionOptions()
        Dim tokenSource As New CancellationTokenSource()

        conversionOptions.CancelToken = tokenSource.Token

        Dim cancelTask As Task = Task.Run(
                Sub()
                    Thread.Sleep(1000)
                    tokenSource.Cancel()
                End Sub)

        Try

            Dim pdf As Byte() = Await Converter.ConvertAsync(
                    New Uri("https://www.dynamicpdf.com"),
                    conversionOptions)

            Console.WriteLine("Conversion completed.")

        Catch

            If tokenSource.IsCancellationRequested Then
                Console.WriteLine("Conversion canceled.")
            Else
                Throw
            End If

        End Try

    End Function

End Class
