using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
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
            //Example2ParametersListWithoutType();
            //Example3ReturningValue();
            Example5LambdaAsReturningParameter();
        }
        private void Example1()
        {
            var hello1 = () => Console.WriteLine("Hello"); // Due to "var" compiler is looking for delegate "Action".
            var hello2 = () =>
            {
                Console.WriteLine("Hello2");
            };
            hello1.Invoke();
            hello1.Invoke();
            hello1.Invoke();
            hello2.Invoke();

        }

        delegate void Operation(int x, int y);
        delegate int OperationReturningValue(int x, int y);
        delegate void MessageHandler(string message);
        delegate void MessageHandlerWithDefault(string message = "DEFAULT_IN_DELEGATE");
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
            messageHander.Invoke("Message параметр без типа данных");

            MessageHandlerWithDefault messageHandlerWithDefault = (string message) => Console.WriteLine(message);
            var lambdaWithDefault = (string message = "DEFAULT_MESSAGE_IN_LAMBDA") => Console.WriteLine(message);
            messageHandlerWithDefault.Invoke();
            lambdaWithDefault.Invoke();
        }

        // A lambda expression can return a result.
        private void Example3ReturningValue()
        {
            var sum = (int x, int y) => x + y;
            int sumResult = sum(4, 5);
            Console.WriteLine(sumResult);
            OperationReturningValue multiply = (x, y) => x * y;
            int multiplyResult = multiply(4, 5);
            Console.WriteLine(multiplyResult);

            var substract = (int x, int y) =>
            {
                if (x > y)
                {
                    return x - y;
                }
                else
                {
                    return y - x;
                }

            };
            int result1 = substract.Invoke(10, 6);
            int result2 = substract.Invoke(-10, 6);
            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }

        private void Example4AddingRemovingFromInvokeList()
        {
            var hello = () => Console.WriteLine("METANIT.COM");
            var message = () => Console.WriteLine("Hello ");
            message += () => Console.WriteLine("World");
            message += hello;
            message += Print;

            message?.Invoke();

            Console.WriteLine("-----------------------");

            message -= Print;
            message -= hello;

            message?.Invoke();

            void Print() => Console.WriteLine("Welcome to C#");
        }

        delegate bool IsEqual(int x);
        private void Example5LambdaAsMethodParameter()
        {
            int[] integers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int result1 = Sum(integers, x => x > 5);
            Console.WriteLine(result1);
            int result2 = Sum(integers, x => x % 2 == 0);
            Console.WriteLine(result2);


            int Sum(int[] numbers, IsEqual func)
            {
                int result = 0;
                foreach (int x in numbers)
                {
                    if (func(x))
                    {
                        result += x;
                    }
                }
                return result;
            }
        }


        enum EmpType
        {
            Admin,
            Operator,
            Cashier
        }

        delegate MessageHandlerWithDefault WhichEmpType(EmpType empType);

        private void Example5LambdaAsReturningParameter()
        {

            WhichEmpType whichEmpType = (EmpType empType) =>
            {
                MessageHandlerWithDefault messageHandlerWithDefault = (string msg) => Console.WriteLine($"SWITCH_HAVE_NO_MATCHES. {msg}");
                switch (empType)
                {
                    case EmpType.Admin:
                        messageHandlerWithDefault = (string msg) => Console.WriteLine($"I am an admin. {msg}");
                        break;
                    case EmpType.Operator:
                        messageHandlerWithDefault = (string msg) => Console.WriteLine($"I am an Operator. {msg}");
                        break;
                    case EmpType.Cashier:
                        messageHandlerWithDefault = (string msg) => Console.WriteLine($"I am an Cashier. {msg}");
                        break;
                }

                return messageHandlerWithDefault;
            };

            whichEmpType.Invoke(EmpType.Cashier)?.Invoke("Cashier type send");
            whichEmpType.Invoke(EmpType.Operator)?.Invoke("Operator type send");
            whichEmpType.Invoke(EmpType.Admin)?.Invoke("Admin type send");
        }

    }
}