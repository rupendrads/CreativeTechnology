namespace stringcalc
{
    public class Replacer : IReplacer
    {
        public void Replace(ref string target, string oldValue, string newValue)
        {
            if(target.Contains(oldValue))
            { 
               target = target.Replace(oldValue, newValue);
            }
        }
    }
}