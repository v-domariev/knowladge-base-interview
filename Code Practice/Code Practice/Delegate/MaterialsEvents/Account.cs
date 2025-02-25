using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Practice.Delegate.MaterialsEvents
{
    public class Account
    {
        public delegate void AccountHandler(string message);
        private event AccountHandler? notify;
        
        public event AccountHandler Notify 
        {
            add 
            {
                notify += value;
                Console.WriteLine($"{value.Method.Name} добавлен");
            }
            remove
            {
                notify -= value;
                Console.WriteLine($"{value.Method.Name} удален");
            }

        }


        public int Sum { get; private set; }
        public Account(int sum) => Sum = sum;
        //public Account(int sum)
        // {
        // Sum = sum;
        // }

        //public void Put(int sum) => Sum += sum;
        public void Put(int sum) {
            Sum += sum;
            notify?.Invoke($"На счет поступило: {sum}");
        }

        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                notify?.Invoke($"Со счета снято: {sum}");
            }
            else 
            {
                notify?.Invoke($"Недостаточно денег на счете. Текущий баланс: {Sum}");
            }
        }


        
        public void ShowSumOnAccount()
        {
            Console.WriteLine($"Сумма на счете: {this.Sum}");
        }

    }
}
