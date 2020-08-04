using System.Text;

namespace BankOCR
{
    public static class ScannedDocProcessor
    {
        public static string Process(this string scannedDoc)
        {
            var resultBuilder = new StringBuilder();

            for (var i = 0; i < 9; i++)
            {
                var test = i * 3;
                resultBuilder.Append(
                    ScanNumber(scannedDoc.Substring(0 + test, 3),
                        scannedDoc.Substring(28 + test, 3),
                        scannedDoc.Substring(52 + test, 3),
                        scannedDoc.Substring(79 + test, 3)));
            }

            return resultBuilder.ToString();
        }

        public static int ScanNumber(string firstLine, string secondLine, string thirdLine, string fourthLine)
        {
            if (thirdLine == "|_|")
            {
                return 4;
            }
            if (thirdLine == " _|")
            {
                return 3;
            }
            if (secondLine == " _|")
            {
                return 2;
            }
            if (string.IsNullOrWhiteSpace(firstLine))
            {
                return 1;
            }
            
            return 0;
        }
    }
}