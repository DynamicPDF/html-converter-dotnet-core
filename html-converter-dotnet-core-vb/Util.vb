Imports System.IO
Imports System.Text.RegularExpressions

Namespace html_converter_dotnet_core_vb
    Public Class Util
        Public Shared Function GetPath(ByVal filePath As String) As String
            Dim exePath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
            Dim appPathMatcher As New Regex("(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)")
            Dim appRoot As String = appPathMatcher.Match(exePath).Value
            Return Path.Combine(appRoot, filePath)
        End Function

        Public Shared Sub CreatePath(ByVal filePath As String)
            Dim exePath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
            Dim dirInfo As New DirectoryInfo(Path.Combine(exePath, filePath))

            If Not dirInfo.Exists Then
                Dim appPathMatcher As New Regex("(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)")
                Dim appRoot As String = appPathMatcher.Match(exePath).Value
                Directory.CreateDirectory(Path.Combine(appRoot, filePath))
            End If
        End Sub
    End Class
End Namespace
