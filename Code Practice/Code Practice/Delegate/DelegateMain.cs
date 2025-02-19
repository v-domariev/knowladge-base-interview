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
    internal class DelegateMain
    {
        // WebSiteLink: https://metanit.com/sharp/tutorial/3.13.php
        // Stopped at topic: "Добавление методов в делегат"

        // Суть: Однако наиболее сильная сторона делегатов состоит в том, что они позволяют делегировать выполнение некоторому коду извне.
        public void Execute()
        {
            //Example1();
            //Example2();
            //Example3Calculate();
            //Example4Similarity();
            //Example5AddDelegate();
            //Example6CallDelegateByInvoke();
            MyExample1RefOperation();
        }

        delegate void Message();
        delegate void MessagePar(string fname);

        private void Example1()
        {
            Message mes;
            mes = Hello;
            mes();

            void Hello() => Console.WriteLine("Hello METANIT.COM"); // А вот это дилигат(тип).
            // void Hello2() => { Console.WriteLine("Hello METANIT.COM"); }; // <- Не правильно, так как это лямбда-выражение или анонимный метод. 


        }

        private void Example2()
        {
            string fname = "Ivan";
            MessagePar mes;
            mes = HelloPar;
            mes(fname);

            void HelloPar(string name) => Console.WriteLine($"Hello {name}");
            string fname2 = string.Concat(fname, " Dolski"); // #string_concat
            mes(fname2);

        }

        delegate int Operation(int x, int y);
        private void Example3Calculate()
        {
            Operation operation = Add;
            int result = operation(4, 5);
            Console.WriteLine(result);

            operation = Multiply;
            result = operation(4, 5);
            Console.WriteLine(result);

            operation = Module;
            result = operation(result, 5);
            Console.WriteLine(result);


            //operation = (int x, int y) => {
            var customDelegateDivision = (int x, int y) =>
            {
                if (x == 0)
                {
                    throw new InvalidOperationException("Can't devide by zero");
                }
                return Convert.ToInt64(x / y);
            };

            // operation = customDelegateDivision; // Not working, cause "customDelegateDivision" it is lambda. But not the delegate.
            result = operation(10023, 5);
            Console.WriteLine($"Devide by zero: {result}");

            try
            {
                result = operation(0, 5);
                Console.WriteLine($"Devide by zero: {result}");

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Devide by zero");
                throw ex; // At interview asked: throw ex; VS throw new Exception();
                // In my opinion: throw new Exception(ex.StactTrace, COPY_SOME_ATTRIBUTES);
            }

            int Add(int x, int y) => x + y;
            int Multiply(int x, int y) => x * y;
            int Module(int x, int y) => x % y;

        }

        delegate void SomeDel(int a, double b);
        delegate Int64 Operation2(int x, int y);
        delegate T Operation3Generic<T, K, V>(K x, V y);

        private T DoOperation<T, K, V>(K a, V b, Operation3Generic<T, K, V> op)
        {
            Console.WriteLine($"You in DoOperation; That is your parameters: a={a}, b={b}");
            return op.Invoke(a, b);
        }
        public void Example4Similarity()
        {
            SomeDel someDel = SomeMethod1;
            someDel(3, 5);

            void SomeMethod1(int d, double n)
            {
                Console.WriteLine($"Parameter d: {d}");
                Console.WriteLine($"Parameter n: {n}");
                var res = d * -n;
                Console.WriteLine($"res: {res}");
            }



            Operation2 operation = customDelegateDivision;


            //Operation3Generic<Double, Int64, Int64> operation3Generic = customDelegateDivision;
            //Operation3Generic<long, int, int> operation3Generic = customDelegateDivision;
            Operation3Generic<Int64, int, int> operation3Generic = customDelegateDivision;
            //Console.WriteLine($"operation3Generic: {operation3Generic.Invoke(1200, 4)}");
            Console.WriteLine($"operation3Generic: {DoOperation(1200, 4, operation3Generic)}");
            //devideGeneric<Tag()

            //operation = (int x, int y) => {
            Int64 customDelegateDivision(int x, int y)
            {
                if (x == 0)
                {
                    throw new InvalidOperationException("Can't devide by zero");
                }
                var res = x / y;
                return Convert.ToInt64(x / y);
            };

            // operation = customDelegateDivision; // Not working, cause "customDelegateDivision" it is lambda. But not the delegate.
            var result = operation(10023, 5);
            Console.WriteLine($"Devide by zero: {result}");

            try
            {
                result = operation(0, 5);
                Console.WriteLine($"Devide by zero: {result}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new InvalidCastException("dev by Z", e); // Set InnerException. So that will be info about REAL StackTrace in Exception. 
            }
            /*
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Devide by zero");

                throw ex; // At interview asked: throw ex; VS throw new Exception();
                // In my opinion: throw new Exception(ex.StactTrace, COPY_SOME_ATTRIBUTES);
                // UPD: Some bulshit, because "ex.StackTrace" showing source path of exception this line, during the runtime.
                // But not the real place of exception, where was diveded by zero.
            }
            */


        }


        delegate void TelegramMessage();
        private void Example5AddDelegate()
        {
            TelegramMessage? telegramMessage = Hello;
            telegramMessage += Hello;
            telegramMessage += HowAreYou;
            telegramMessage += Fine;
            telegramMessage += Bye;
            telegramMessage += Bye;

            if (telegramMessage != null)
            {
                telegramMessage();
            }
            Console.WriteLine("telegramMessage();");

            telegramMessage = null;

            telegramMessage += Hello;
            telegramMessage += Why;
            telegramMessage += Fine;
            telegramMessage += Hello;
            telegramMessage += Why;
            telegramMessage += Fine;
            telegramMessage -= Why; // <- removing from end of array.
            if (telegramMessage != null)
            {
                telegramMessage();
            }

            void Hello() => Console.WriteLine("Hello!");
            void HowAreYou() => Console.WriteLine("How are you?");
            void Fine() => Console.WriteLine("Fine");
            void Bye() => Console.WriteLine("Bye");
            void Why() => Console.WriteLine("Why");

            Console.WriteLine("join delegates -> call only mes3  ");
            Message mes1 = Hello;
            Message mes2 = HowAreYou;
            Message mes3 = mes1 + mes2; // объединяем делегаты
            mes3(); // вызываются все методы из mes1 и mes2

        }

        public void Example6CallDelegateByInvoke()
        {

            Message mes = Hello;
            mes.Invoke(); // Hello
            Operation op = Add;
            int n = op.Invoke(3, 4);
            Console.WriteLine(n);   // 7

            void Hello() => Console.WriteLine("Hello");
            int Add(int x, int y) => x + y;

        }

        public void Example7CallDelegateByInvoke()
        {

            Message? mes = null;
            mes?.Invoke();        // ошибки нет, делегат просто не вызывается

            Operation? op = Add;
            op -= Add;          // делегат op пуст
            int? n = op?.Invoke(3, 4);   // ошибки нет, делегат просто не вызывается, а n = null}
            void Hello() => Console.WriteLine("Hello");
            int Add(int x, int y) => x + y;
        }


        delegate ref int RefOperation(ref int x, ref int y);

        public void MyExample1RefOperation() // Consiquence operation execution on the one final result.
        {
            RefOperation del = Add;
            del += Multiply;
            int x = 6;
            int y = 5;
            //int result = del(6, 5);
            int result = del(ref x, ref y);
            Console.WriteLine(result);
            Console.Read();
        }
        private ref int Add(ref int x, ref int y)
        {
            x = x + y;
            return ref x;
        }
        private ref int Multiply(ref int x, ref int y) {
            x = x* y;
            return ref x;
        }
    }


    /*

    // Устанавливаем красный цвет символов
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    // Сбрасываем настройки цвета
    Console.ResetColor();
        */
}
