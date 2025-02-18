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
        public void Execute()
        {
            Example1();
            Example2();
            Example3Calculate();
            Example4Similarity();
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
            //operation = (int x, int y) => {
            Int64 customDelegateDivision(int x, int y)
            {
                if (x == 0)
                {
                    throw new InvalidOperationException("Can't devide by zero");
                }
                var res = x/y;
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
    }
}
