using Code_Practice.Delegate;

namespace Code_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //DelegateMain1 delegateMain =new DelegateMain1();
            //delegateMain.Execute();
            //AnonymousMethod2 anonymousMethod2 = new AnonymousMethod2();
            //anonymousMethod2.Execute();

            //Lambda3 lambda3 = new Lambda3();
            //lambda3.Execute();
            
            //Events4 events4 = new Events4();
            //events4.Execute();
            
            //CovarianceAndContravariance5 covarianceAndContravariance5 = new CovarianceAndContravariance5();
            //covarianceAndContravariance5.Execute();
            
            ActionPredicateFunc6 actionPredicateFunc6 = new ActionPredicateFunc6();
            actionPredicateFunc6.Execute();


        }
    }
}
