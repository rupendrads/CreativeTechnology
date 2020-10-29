namespace stringcalc
{
    public class NumbersExtractor : INumbersExtractor
    {
        public string ExtractNumbers(string str, char delimiter, ref char[] delimiterArray)
        {
            if(str.StartsWith("//") && str.Contains("\\n"))
            {
                // get all lines
                string[] numbersArray = str.Split("\\n");
                
                // get delimiter array from the first line
                string firstLine = numbersArray[0];
                string delims = firstLine.Substring(2);
                delimiterArray = delims.ToCharArray();

                // get only numbers input
                str = string.Join("",numbersArray, 1, numbersArray.Length - 1);                           
            }
            else
            {
                // add default delimiter
                delimiterArray = new char[] { delimiter };
            }

            return str;
        }
    }
}