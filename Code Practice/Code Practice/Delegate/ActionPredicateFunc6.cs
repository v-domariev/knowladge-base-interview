using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Practice.Delegate
{
    public class ActionPredicateFunc6
    {
        // WebLinkSite: https://metanit.com/sharp/tutorial/3.33.php
        // Built-in delegates: Action, Predicate, Func, ...;
        public void Execute()
        {
            //this.Example1Action();
            //this.Example2Predicate();
            this.Example3Func();
        }
        // Action - do something. Return nothing.
        //public delegate void Action();
        //public delegate void Action<in T>(T obj);
        // Максимально можно передать до 16 параметров в метод( <in T1, in T2, ... in T16>);

        public void Example1Action()
        {
            DoOperation(10, 6, Add);
            DoOperation(10, 6, Multiply);

            void DoOperation(int a, int b, Action<int, int> op) => op(a, b);

            void Add(int x, int y) => Console.WriteLine($"{x} + {y} = {x + y}");
            void Multiply(int x, int y) => Console.WriteLine($"{x} * {y} = {x + y}");


            spellWords("a", "we", "s", "s", "sew", "sae", ShowAtConsole);

            void spellWords(string a1, string a2, string a3, string a4, string a5, string a6, Action<string, string, string, string, string, string> methodAction)
                => methodAction.Invoke(a1, a2, a3, a4, a5, a6);

            void ShowAtConsole(string a1, string a2, string a3, string a4, string a5, string a6) => Console.WriteLine($"  {a1},   {a2},   {a3},   {a4},   {a5},   {a6}");
        }

        //Predicate<T> - принимает один параметр, возвращает значение типа bool.
        //delegate bool Predicate<in T>(T obj);
        // Compare object "T" -> return bool result.
        public void Example2Predicate()
        {
            Console.Write("Example2Predicate");
            Predicate<int> isPositive = (int x) => x > 0;

            Console.WriteLine(isPositive(20));
            Console.WriteLine(isPositive(-20));

            Predicate<string> isStartingWithPlus = (string phoneNumber) =>
            {
                Console.WriteLine($"INput: {phoneNumber}");
                return phoneNumber.StartsWith("+");
            };

            Console.WriteLine(isStartingWithPlus("+2315415"));
            Console.WriteLine(isStartingWithPlus("2315415"));

        }

        // Func - принимает и возвращет результат.-
        //от Func<out T>(), где T - тип возвращаемого значения, до Func<in T1, in T2,...in T16, out TResult>(), то есть может принимать до 16 параметров.
        //Func<out T> параметр "out" всегда есть.
        public void Example3Func()
        {
            int result1 = DoOperation(6, DoubleNumber);
            Console.WriteLine(result1);

            int result2 = DoOperation(6, SquareNumber);
            Console.WriteLine(result2);

            int DoOperation(int n, Func<int, int> operation) => operation(n);
            int DoubleNumber(int n) => 2 * n;
            int SquareNumber(int n) => n * n;
            // EXample 2:
            Func<int, int, string> createString = (a, b) => $"{a}{b}";
            //Func<int, int, double> createString = (a, b) => ((double)b / (double)a);
            //Func<int, int, int> createString = (a, b) => ((double)b / (double)a); // not works, raise Exception. Because return value type requires "int", but not "double".
            Console.WriteLine(createString(1, 5));
            Console.WriteLine(createString(3, 5));
            // Разобраться с параметром "out TResult>".
        }

    }
}
