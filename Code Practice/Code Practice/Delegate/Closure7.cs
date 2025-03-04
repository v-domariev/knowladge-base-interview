using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Practice.Delegate
{
    public class Closure7
    {
        // WebSiteLink: https://metanit.com/sharp/tutorial/3.54.php
        // замыкание(closure) - объект функции.

        public void Execute()
        {
            //this.Example1ClosureByLocalMethod();
            //this.Example2ClousureByLambda();
            this.Example3UsingParameters();
        }
        private void Example1ClosureByLocalMethod()
        {
            //var fn = Outer();
            Action fn = Outer();

            fn();
            fn();
            fn();
            // функцию "Innner()" используем во внешней среде. С сохранением информации о внутренем состоянии переменных в функции Outer;
            Action Outer()
            {
                int x = 5;
                void Inner()
                {
                    x++;
                    int y = 100;
                    y++;
                    Console.WriteLine($"x: {x}; y: {y}");
                }
                return Inner;
            }
        }

        private void Example2ClousureByLambda()
        {
            var outherFn = () =>
            {
                int x = 10;
                var innerFn = () => Console.WriteLine(++x);
                return innerFn;
            };

            var fn = outherFn();
            fn();
            fn();
            fn();
        }
        
        private void Example3UsingParameters() 
        {
            var fn = Multiply(5);

            Console.WriteLine(fn.Invoke(5));
            Console.WriteLine(fn.Invoke(6));
            Console.WriteLine(fn.Invoke(7));

            Func<int, int> Multiply(int n) // n = 5
            {
                int Inner(int m) // m = {5, 6, 7}.
                {
                    return n * m;
                }
                return Inner;
            }
            
        }
    }
}
