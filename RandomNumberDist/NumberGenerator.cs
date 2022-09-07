namespace BenfordLawChecker
{
    internal class NumberGenerator
    {
        private Random generator = new Random();

        public  List<byte[]> RandomValues(int quantity, byte length)
        {
            if (length < 2 || length > 19) throw new ArgumentException("Minumum length is 2, maximum is 19");
            var min = (long)Math.Pow(10, length - 1);
            var max = (long)Math.Pow(10, length) - 1;
            var randomNumbers = new List<ulong>();
            for (var numbersMade = 0; numbersMade < quantity; numbersMade++)
                randomNumbers.Add((ulong)generator.NextInt64(min, max));
            var result = new List<byte[]>();
            randomNumbers.ForEach(rn => result.Add(UlongToByteArray(rn)));
            return result;
        }

        private static byte[] UlongToByteArray(ulong value)
        {
            var strVal = value.ToString();
            var result = new byte[strVal.Length];
            for (var i = 0; i < strVal.Length; i++)
                result[i] = byte.Parse(strVal.Substring(i, 1));
            return result;
        }
    }
}
