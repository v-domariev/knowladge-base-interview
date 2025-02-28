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
            this.Example1Action();
            this.Example2Predicate();
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

    }
}
