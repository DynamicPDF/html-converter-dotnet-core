using ceTe.DynamicPDF.HtmlConverter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace html_converter_dotnet_core_cs
{
    internal class ConverterParallelExample
    {
        public static async Task Run()
        {
            // Get the output folder and input HTML resource folder.
            string outputPath = Util.GetPath("Output");
            string inputFolder = Util.GetPath("Resources/html");

            // Get all files from the input folder.
            string[] files = Directory.GetFiles(inputFolder);

            // Create the list of documents to convert.
            List<string> testDocuments = new List<string>();

            // Add each file multiple times to simulate a larger workload.
            foreach (string file in files)
            {
                testDocuments.Add(file);
                testDocuments.Add(file);
                testDocuments.Add(file);
            }

            // Add one extra document to demonstrate remainder batching.
            testDocuments.Add(Util.GetPath("Resources/html/10.html"));

            Console.WriteLine("=======================================");
            Console.WriteLine("Total documents: " + testDocuments.Count);

            // Divide the workload into three full-sized batches.
            // Any remaining files are processed in a final smaller batch.
            int batchDivisions = 3;
            int batchSize = testDocuments.Count / batchDivisions;

            if (batchSize == 0)
                batchSize = 1;

            int batchNumber = 1;

            // Process each batch.
            for (int batchStart = 0; batchStart < testDocuments.Count; batchStart += batchSize)
            {
                int batchEnd = batchStart + batchSize;

                if (batchEnd > testDocuments.Count)
                    batchEnd = testDocuments.Count;

                int currentBatchCount = batchEnd - batchStart;

                Console.WriteLine();
                Console.WriteLine("=======================================");
                Console.WriteLine("Starting Batch " + batchNumber);
                Console.WriteLine("Documents In Batch: " + currentBatchCount);
                Console.WriteLine("=======================================");

                // Store the conversion tasks for the current batch.
                List<Task> tasks = new List<Task>();

                // Start one conversion task for each document in the batch.
                for (int i = batchStart; i < batchEnd; i++)
                {
                    // Capture local copies for use inside the task.
                    int documentNumber = i;
                    string documentPath = testDocuments[i];

                    tasks.Add(Task.Run(async () =>
                    {
                        try
                        {
                            // Create a URI from the document path.
                            Uri inputPath = new Uri(documentPath);

                            // Create a unique output file name.
                            string outputFile = Path.Combine(
                                outputPath,
                                "output-" + documentNumber + ".pdf");

                            Console.WriteLine("Converting " + documentNumber);

                            // Convert the HTML document to PDF.
                            await Converter.ConvertAsync(inputPath, outputFile);

                            Console.WriteLine("Finished " + documentNumber);
                        }
                        catch (Exception ex)
                        {
                            // Continue processing even if one document fails.
                            Console.WriteLine("Error converting document " + documentNumber);
                            Console.WriteLine(ex.Message);
                        }
                    }));
                }

                // Wait until all conversions in the current batch are complete.
                await Task.WhenAll(tasks);

                // Release converter resources only after the whole batch has finished.
                Converter.ReleaseResources();

                Console.WriteLine();
                Console.WriteLine("=======================================");
                Console.WriteLine("Completed Batch " + batchNumber);
                Console.WriteLine("=======================================");

                batchNumber++;
            }

            Console.WriteLine();
            Console.WriteLine("All batches completed.");
        }
    }
}