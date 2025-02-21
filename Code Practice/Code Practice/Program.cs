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
            AnonymousMethod2 anonymousMethod2 = new AnonymousMethod2();
            anonymousMethod2.Execute();




        }
    }
}
