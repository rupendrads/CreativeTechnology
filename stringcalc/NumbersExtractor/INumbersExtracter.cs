namespace stringcalc
{
    public interface INumbersExtractor
    {
        public string ExtractNumbers(string str, char delimiter, ref char[] delimiterArray);
    }
}