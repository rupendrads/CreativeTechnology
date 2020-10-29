namespace stringcalc
{
    public interface IReplacer
    {
        public void Replace(ref string target, string oldValue, string newValue);
    }
}