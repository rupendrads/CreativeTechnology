using System;
using System.Collections.Generic;

namespace stringcalc
{
    public class SumCalculator : ISumCalculator
    {
        public int CalculateSum(string numbers, char[] delimiterArray)
        {
            int sum = 0;

            string[] nums = new string[]{};
            
            // get numbers to string array
            nums = numbers.Split(delimiterArray, StringSplitOptions.RemoveEmptyEntries); 

            int number = 0;
            List<string> negativeNumbers = new List<string>();  // negative number list

            foreach(var num in nums)
            {
                // converting string number to int number
                number = Convert.ToInt32(num);

                // check for negative number
                if(number < 0)
                {   
                    // add negative number to list
                    negativeNumbers.Add(number.ToString());
                }

                // calculate sum by ignoring number greater than 1000
                if(number <= 1000)
                {
                    sum += number;
                }                 
            }

            // if negative numbers present throw error
            if(negativeNumbers.Count > 0)
            {                    
                string msg = string.Join(',', negativeNumbers.ToArray());
                throw new Exception($"Negatives not allowed : { msg }");
            }

            return sum;
        }
    }
}