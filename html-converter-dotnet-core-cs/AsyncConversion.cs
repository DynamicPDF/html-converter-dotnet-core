﻿using System;
using System.Collections.Generic;
using System.Text;
using ceTe.DynamicPDF.HtmlConverter;

namespace html_converter_dotnet_core_cs
{
    public class AsyncConversion
    {
        public static void Run()
        {
            // Create a conversion options class
            ConversionOptions conversionOptions = new ConversionOptions(PageSize.A4, PageOrientation.Portrait, 54.0f);
            
            // Create a simple HTML string 
            string sampleHtml = "<html><body><p>This is a very simple HTML string including a Table below.</p>" +
                        "<h4>Two rows and three columns:</h4><table border=\"1\"><tr><td>100</td><td>200</td>" +
                        "<td>300</td></tr><tr><td>400</td><td>500</td><td>600</td></tr></table></body></html>";

            // Asynchronously Convert HTML to PDF with the conversion options specified
            Converter.ConvertAsync(sampleHtml, "AsyncConversion.pdf");
        }
    }
}