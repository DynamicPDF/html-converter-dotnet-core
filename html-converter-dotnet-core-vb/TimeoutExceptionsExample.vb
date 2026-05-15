Imports ceTe.DynamicPDF.HtmlConverter
Imports System


Friend Class TimeoutExceptionsExample

    Public Shared Sub Run()

        Dim defaultPageLoad As Integer = ConversionOptions.DefaultPageLoadTimeout
        Dim defaultConversionTimeout As Integer = ConversionOptions.DefaultConversionTimeout

        Console.WriteLine("defaultPageLoadTimeout: " & defaultPageLoad)
        Console.WriteLine("defaultConversionTimeout: " & defaultConversionTimeout)
        Console.WriteLine("defaultCommandTimeout: " & ConversionOptions.DefaultCommandTimeout)

        RunPageLoad()
        Console.WriteLine("----------------------------------------")
        RunConversionTimeout(defaultPageLoad)

    End Sub

    Public Shared Sub RunPageLoad()

        Try
            ConversionOptions.DefaultPageLoadTimeout = 10

            Converter.Convert(
                    New Uri("https://www.gutenberg.org/cache/epub/815/pg815-images.html"),
                    Util.GetPath("Output/TimeoutExampleConversion.pdf"))

            Console.WriteLine("Conversion completed successfully.")

        Catch ex As Exception

            Dim errorText As String = ex.ToString()

            If errorText.Contains(
                    "Navigation response not received",
                    StringComparison.OrdinalIgnoreCase) Then

                Console.WriteLine("The page load operation timed out.")
                Console.WriteLine($"Class: {ex}")
                Return

            End If

            If errorText.Contains(
                    "Conversion timeout",
                    StringComparison.OrdinalIgnoreCase) Then

                Console.WriteLine("The conversion operation timed out.")
                Console.WriteLine($"Details: {ex.Message}")
                Console.WriteLine($"Class: {ex}")
                Return

            End If

            Console.WriteLine("An unexpected error occurred during conversion.")
            Console.WriteLine($"Details: {ex.Message}")

        End Try

    End Sub

    Public Shared Sub RunConversionTimeout(defaultPageLoad As Integer)

        Try
            ConversionOptions.DefaultPageLoadTimeout = defaultPageLoad
            ConversionOptions.DefaultConversionTimeout = 120

            Converter.Convert(
                    New Uri("https://www.gutenberg.org/cache/epub/815/pg815-images.html"),
                    Util.GetPath("Output/TimeoutExampleConversion.pdf"))

            Console.WriteLine("Conversion completed successfully.")

        Catch ex As Exception

            Dim errorText As String = ex.ToString()

            If errorText.Contains(
                    "Conversion timeout",
                    StringComparison.OrdinalIgnoreCase) Then

                Console.WriteLine("The conversion operation timed out.")
                Console.WriteLine($"Details: {ex.Message}")
                Console.WriteLine($"Exception: {ex}")
                Return

            End If

            Console.WriteLine("An unexpected error occurred during conversion.")
            Console.WriteLine($"Details: {ex.Message}")

        End Try

    End Sub

End Class
