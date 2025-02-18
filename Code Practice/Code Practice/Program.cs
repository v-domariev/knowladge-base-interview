using Code_Practice.Delegate;

namespace Code_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            DelegateMain delegateMain =new DelegateMain();
            delegateMain.Execute();
        }
    }
}
