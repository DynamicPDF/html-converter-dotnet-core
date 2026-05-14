Imports ceTe.DynamicPDF.HtmlConverter
Imports System.IO

Friend Class ConverterParallelExample
    Public Shared Async Function Run() As Task

        ' Get the output folder and input HTML resource folder.
        Dim outputPath As String = Util.GetPath("Output")
        Dim inputFolder As String = Util.GetPath("Resources/html")

        ' Get all files from the input folder.
        Dim files As String() = Directory.GetFiles(inputFolder)

        ' Create the list of documents to convert.
        Dim testDocuments As New List(Of String)()

        ' Add each file multiple times to simulate a larger workload.
        For Each file As String In files
            testDocuments.Add(file)
            testDocuments.Add(file)
            testDocuments.Add(file)
        Next

        ' Add one extra document to demonstrate remainder batching.
        testDocuments.Add(Util.GetPath("Resources/html/10.html"))

        Console.WriteLine("=======================================")
        Console.WriteLine("Total documents: " & testDocuments.Count)

        ' Divide the workload into three full-sized batches.
        ' Any remaining files are processed in a final smaller batch.
        Dim batchDivisions As Integer = 3
        Dim batchSize As Integer = testDocuments.Count \ batchDivisions

        If batchSize = 0 Then
            batchSize = 1
        End If

        Dim batchNumber As Integer = 1

        ' Process each batch.
        For batchStart As Integer = 0 To testDocuments.Count - 1 Step batchSize

            Dim batchEnd As Integer = batchStart + batchSize

            If batchEnd > testDocuments.Count Then
                batchEnd = testDocuments.Count
            End If

            Dim currentBatchCount As Integer = batchEnd - batchStart

            Console.WriteLine()
            Console.WriteLine("=======================================")
            Console.WriteLine("Starting Batch " & batchNumber)
            Console.WriteLine("Documents In Batch: " & currentBatchCount)
            Console.WriteLine("=======================================")

            ' Store the conversion tasks for the current batch.
            Dim tasks As New List(Of Task)()

            ' Start one conversion task for each document in the batch.
            For i As Integer = batchStart To batchEnd - 1

                ' Capture local copies for use inside the task.
                Dim documentNumber As Integer = i
                Dim documentPath As String = testDocuments(i)

                tasks.Add(Task.Run(
                        Async Function()
                            Try
                                ' Create a URI from the document path.
                                Dim inputPath As New Uri(documentPath)

                                ' Create a unique output file name.
                                Dim outputFile As String = Path.Combine(
                                    outputPath,
                                    "output-" & documentNumber & ".pdf")

                                Console.WriteLine("Converting " & documentNumber)

                                ' Convert the HTML document to PDF.
                                Await Converter.ConvertAsync(inputPath, outputFile)

                                Console.WriteLine("Finished " & documentNumber)

                            Catch ex As Exception
                                ' Continue processing even if one document fails.
                                Console.WriteLine("Error converting document " & documentNumber)
                                Console.WriteLine(ex.Message)
                            End Try
                        End Function))
            Next

            ' Wait until all conversions in the current batch are complete.
            Await Task.WhenAll(tasks)

            ' Release converter resources only after the whole batch has finished.
            Converter.ReleaseResources()

            Console.WriteLine()
            Console.WriteLine("=======================================")
            Console.WriteLine("Completed Batch " & batchNumber)
            Console.WriteLine("=======================================")

            batchNumber += 1
        Next

        Console.WriteLine()
        Console.WriteLine("All batches completed.")

    End Function
End Class
