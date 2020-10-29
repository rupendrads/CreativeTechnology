namespace stringcalc
{
    public class Validator : IValidator
    {
        public bool IsValid(string str)
        {
            bool isValid = true;

            // invalid characters at start and end
            if(str.StartsWith("\\n") || str.EndsWith("\\n"))
            {
                isValid = false;
            }

            return isValid;
        }
    }
}