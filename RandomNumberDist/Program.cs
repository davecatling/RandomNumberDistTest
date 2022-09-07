using System.Text;

namespace RandomNumberDistCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var exit = false;
            while (!exit)
            {
                var numberGenerator = new NumberGenerator();
                int? quantityToGenerate = null;
                while (quantityToGenerate == null)
                    quantityToGenerate = UserProvidedInt("Enter the quantity of numbers to generate:");
                int? numberLength = null;
                while (numberLength == null)
                    numberLength = UserProvidedInt("Enter the length of each number (2 to 19):");
                var randomNumbers = numberGenerator.RandomValues((int)quantityToGenerate, (byte)numberLength);
                for (int i = 0; i < 10; i++)
                    Console.WriteLine(ReportNumber(i, ref randomNumbers));
                Console.WriteLine("Press enter to restart, any other key to exit");
                var key = Console.ReadKey();
                if (key.Key != ConsoleKey.Enter) exit = true;
            }
        }

        private static string ReportNumber(int numberToReport, ref List<byte[]> randomNumbers)
        {
            var length = randomNumbers[0].Length;
            var sb = new StringBuilder();
            sb.AppendLine($"Distribution for number {numberToReport}:");
            for (int i = 0; i < length; i++)
            {
                var percentage = PercentageInPosition(numberToReport, i, ref randomNumbers);
                sb.Append($"{i + 1}: {percentage}% ");
            }
            return $"{sb}\r\n";
        }

        private static int? UserProvidedInt(string prompt)
        {
            Console.WriteLine(prompt);
            var strValue = Console.ReadLine();
            if (!int.TryParse(strValue, out int intValue))
            {
                Console.WriteLine($"[{strValue}] could not be interpreted as an integer");
                return null;
            }
            return intValue;
        }

        private static float PercentageInPosition(int number, int posn, ref List<byte[]> randomValues)
        {
            var count = (float)(randomValues.Count(rv => rv[posn] == number));
            float result = (count / randomValues.Count) * 100;
            return result;
        }
    }
}