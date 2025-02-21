using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Practice.Delegate
{
    internal class AnonymousMethod2
    {
        // website: https://metanit.com/sharp/tutorial/3.15.php
        // core: В каких ситуациях используются анонимные методы?
        // Когда нам надо определить однократное действие, которое не имеет много инструкций и нигде больше не используется.
        // В частности, их можно использовать для обработки событий, которые будут рассмотрены далее.
        public void Execute() 
        {
            //Example1();
            //Example2();
            Example3();
        }

        private delegate void MessageHandler(string messsage);
        public void Example1() 
        {
            MessageHandler handler = delegate (string mes)
            {
                Console.WriteLine(mes);
            };
            handler.Invoke("Anon method");

        }

        public void Example2() 
        {
            this.ShowMessage("Hello, setting anon method as parameter", delegate (string mes) 
            {
                Console.WriteLine($"{mes} <=at Anon method");
            });
        }
        private void ShowMessage(string messsage, MessageHandler handler) 
        {
            handler.Invoke(messsage);
        }

        delegate int Operation(int x, int y);
        delegate void NoParamsMessageHandler();
        public void Example3() 
        {
            int z = 8;
            Operation operation = delegate (int x, int y)
            {
                return x + y + z;
            };
            NoParamsMessageHandler handler = delegate
            {
                Console.WriteLine("No params - no \"()\".");
            };

            int result = operation.Invoke(4,5);
            MessageHandler messageHandler = delegate (string message)
            {
                Console.WriteLine(message);
            };
            messageHandler.Invoke($"Result: {result}");
            handler.Invoke();
        }

    }
}
