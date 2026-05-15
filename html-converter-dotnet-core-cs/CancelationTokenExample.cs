using ceTe.DynamicPDF.HtmlConverter;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace html_converter_dotnet_core_cs
{
    internal class CancelationTokenExample
    {
        public static async Task RunAsync()
        {
            ConversionOptions conversionOptions = new ConversionOptions();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            conversionOptions.CancelToken = tokenSource.Token;

            Task cancelTask = Task.Run(() =>
            {
                Thread.Sleep(1000);
                tokenSource.Cancel();
            });

            try
            {
                byte[] pdf = await Converter.ConvertAsync(
                    new Uri("https://www.dynamicpdf.com"),
                    conversionOptions);

                Console.WriteLine("Conversion completed.");
            }
            catch
            {
                if (tokenSource.IsCancellationRequested)
                {
                    Console.WriteLine("Conversion canceled.");
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
