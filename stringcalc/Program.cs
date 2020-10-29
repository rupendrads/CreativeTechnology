using System;
using System.Reflection;
using Ninject;

namespace stringcalc
{
    class Program
    {
        internal static IKernel kernel = new StandardKernel();

        static void Main(string[] args)
        {                        
            if (args.Length > 0)
            {
                string input = args[0];
                
                kernel.Load(Assembly.GetExecutingAssembly());
                var calulator = kernel.Get<ICalculator>();

                try
                {
                    int sum = calulator.Add(input);
                    Console.WriteLine($"Sum: { sum }");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);                    
                }
            }
            else
            {
                Console.WriteLine("Please provide valid input");
            }
        }
    }
}
