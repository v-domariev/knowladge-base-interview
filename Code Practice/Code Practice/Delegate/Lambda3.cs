using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Code_Practice.Delegate
{
    internal class Lambda3
    {
        // WebSiteLink: https://metanit.com/sharp/tutorial/3.16.php

        // Lambda: (parameters_list) => exporession/body-logic/{}
        // DataType of Lambda it is Delegate.



        /*
         Выше мы определили переменную hello, которая представляет делегат Message. 
        Но начиная с версии C# 10 мы можем применять неявную типизацию (определение переменной с помощью оператора var) при 
        определении лямбда-выражения. 
         */
        public void Execute()
        {
            //Example1();
            Example2ParametersListWithoutType();

        }
        private void Example1()
        {
            var hello1 = () => Console.WriteLine("Hello"); // Due to "var" compiler is looking for delegate "Action".
            var hello2 = () => { 
                Console.WriteLine("Hello2");
            };
            hello1.Invoke();
            hello1.Invoke();
            hello1.Invoke();
            hello2.Invoke();

        }

        delegate void Operation(int x, int y);
        delegate void MessageHandler(string message);
        private void Example2ParametersListWithoutType()
        {
            Operation sum = (x, y) =>
            {
                Console.WriteLine($"{x} + {y} = {x + y}");
            };
            /* // Doesnt work
            var sum = (x, y) =>
            {
                Console.WriteLine($"{x} + {y} = {x + y}");
            };

            */
            // But, it works:
            var sum1 = (int x, int y) =>
            {
                Console.WriteLine($"anon/var handler: {x} + {y} = {x + y}");
            };

            sum.Invoke(1, 2);
            sum.Invoke(22, 14);
            sum1.Invoke(1, 2);
            sum1.Invoke(22, 14);


            MessageHandler messageHander = message => Console.WriteLine(message);
            messageHander

        }
    }
}