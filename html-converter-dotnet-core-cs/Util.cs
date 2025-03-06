using System.IO;
using System.Text.RegularExpressions;

namespace html_converter_dotnet_core_cs
{
    public class Util
    {
        public static string GetPath(string filePath)
        {
            var exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return System.IO.Path.Combine(appRoot, filePath);
        }

        public static void CreatePath(string filePath)
        {
            var exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            DirectoryInfo dirInfo = new DirectoryInfo(exePath + filePath);

            if (!dirInfo.Exists)
            {
                Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
                var appRoot = appPathMatcher.Match(exePath).Value;

                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(appRoot, filePath));
            }
        }

    }
}



