using ceTe.DynamicPDF.HtmlConverter;
using System;

namespace html_converter_dotnet_core_cs
{
    class WithConversionOptions
    {
        public static void Run()
        {
            string taleOfTwoCities = "https://www.gutenberg.org/files/98/98-h/98-h.htm";
            Uri resolvePath = new Uri(taleOfTwoCities);
            double leftRightMarginsPts = 36;
            double topBottomMarginsPts = 144;

            ConversionOptions conversionOptions = new ConversionOptions(PageSize.Letter,
              PageOrientation.Portrait, leftRightMarginsPts, topBottomMarginsPts);
            conversionOptions.Author = "Charles Dickens";
            conversionOptions.Creator = "James B";
            conversionOptions.Title = "A Tale of Two Cities";
            conversionOptions.Subject = "Guttenberg press version of Charles Dickens\'s"
              + "A Tale of Two Cities.";
            conversionOptions.Header = "<div style = 'text-align:center;width:100%"
              + ";font-size:15em;'>A Tale of Two Cities</div>";
            Converter.Convert(resolvePath, Util.GetPath("Output/WithConversionOptions.pdf"), conversionOptions);
        }
    }
}
