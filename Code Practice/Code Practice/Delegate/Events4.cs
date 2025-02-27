using Code_Practice.Delegate.MaterialsEvents;
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
    internal class Events4
    {
        // WebSiteLink: https://metanit.com/sharp/tutorial/3.14.php

        // Events/События сигнализируют системе о том, что произошло определенное действие. 

        public void Execute()
        {
            Example2();
            //Example2ParametersListWithoutType();
            //Example3ReturningValue();
            //Example5LambdaAsReturningParameter();
        }

        
        private void Example2()
        {
            Account account = new Account(100);
            //account.Notify += new Account.AccountHandler(DisplayMessage);
            account.Notify += DisplayMessage;
            account.Put(20);
            account.Take(70);

            account.Take(180);
            

            void DisplayMessage(Account sender, AccountEventArgs e)
            {
                /*
                DisplayMessage. Благодаря первому параметру в методе можно получить информацию об отправителе события - счете, с которым производится операция. 
                А через второй параметр можно получить инфомацию о состоянии операции.
                */

                Console.WriteLine($"Сумма транзакции: {e.Sum}");
                Console.WriteLine(e.Message);
                Console.WriteLine($"Текущая сумма на счете: {sender.Sum}");
            }            
        }
    
        //private void Example1()
        //{
        //    Account account = new Account(100);
        //    account.Notify += new Account.AccountHandler(DisplayMessage);
        //    account.Notify += DisplayMessage;
        //    account.Notify += DisplayRedMessage;
        //    account.Put(20);
        //    account.Notify -= DisplayRedMessage;
        //    account.ShowSumOnAccount();
        //    account.Take(70);
        //    account.ShowSumOnAccount();
        //    account.Take(180);
        //    account.ShowSumOnAccount();

        //    void DisplayMessage(string message) => Console.WriteLine(message);
        //    void DisplayRedMessage(string message)
        //    { 
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine(message);
        //        Console.ResetColor();
        //    }
        //}
    }
}