Imports ceTe.DynamicPDF.HtmlConverter
Friend Class WithConversionOptions
    Friend Shared Sub Run()
        Dim taleOfTwoCities As String = "https://www.gutenberg.org/files/98/98-h/98-h.htm"
        Dim resolvePath As Uri = New Uri(taleOfTwoCities)
        Dim leftRightMarginsPts As Double = 36
        Dim topBottomMarginsPts As Double = 144

        Dim conversionOptions As ConversionOptions = New ConversionOptions(PageSize.Letter,
  PageOrientation.Portrait, leftRightMarginsPts, topBottomMarginsPts)
        conversionOptions.Author = "Charles Dickens"
        conversionOptions.Creator = "James B"
        conversionOptions.Title = "A Tale of Two Cities"
        conversionOptions.Subject = "Guttenberg press version of Charles Dickens\'s" &
  "A Tale of Two Cities."
        conversionOptions.Header = "<div style = 'text-align:center;width:100%" &
  ";font-size:15em;'>A Tale of Two Cities</div>"
        Converter.Convert(resolvePath, Util.GetPath("Output/WithConversionOptions-out.pdf"), conversionOptions)
    End Sub
End Class
