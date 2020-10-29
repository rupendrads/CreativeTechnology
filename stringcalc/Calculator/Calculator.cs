using System;
using System.Collections.Generic;

namespace stringcalc
{
    public class Calculator: ICalculator
    {
        private readonly ISumCalculator sumCalculator;
        private readonly IReplacer replacer;
        private readonly IValidator validator;
        private readonly INumbersExtractor numbersExtractor;

        public Calculator(ISumCalculator sumCalculator, 
            IReplacer replacer, 
            IValidator validator,
            INumbersExtractor numbersExtractor)
        {
            this.sumCalculator = sumCalculator;
            this.replacer = replacer;
            this.validator = validator;
            this.numbersExtractor = numbersExtractor;
        }

        public int Add(string numbers)
        {
            int sum = 0;

            // null, empty or whitespace input
            if(string.IsNullOrWhiteSpace(numbers))
                return sum;

            // validate input
            if(!validator.IsValid(numbers))
            {
                throw new Exception("Invalid Input");
            }

            // default delimiter
            char delimiter = ',';

            // delimiter array to hold multiple delimiter
            char[] delimiterArray = new char[]{};                    

            // get numbers input if multiple delimiters present
            // if single delimiter present then add it to delimiters array
            numbers = numbersExtractor.ExtractNumbers(numbers, delimiter, ref delimiterArray);

            // replace new line character with default or first delimiter
            replacer.Replace(ref numbers, "\\n", delimiterArray[0].ToString());

            //Console.WriteLine(numbers);
            
            // calculate sum
            if(delimiterArray.Length == 0)
            {
                // with no delimiter
                sum = Convert.ToInt32(numbers);
            }
            else
            {
                // with single or multiple delimeters
                sum = this.sumCalculator.CalculateSum(numbers, delimiterArray);
            }
            
            return sum;            
        }
    }
}