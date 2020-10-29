using Ninject.Modules;

namespace stringcalc
{
    public class DIRegistration: NinjectModule
    {
        public override void Load()
        {
            Bind<IReplacer>().To<Replacer>();
            Bind<ISumCalculator>().To<SumCalculator>();
            Bind<ICalculator>().To<Calculator>();
            Bind<IValidator>().To<Validator>();
            Bind<INumbersExtractor>().To<NumbersExtractor>();
        }
    }
}