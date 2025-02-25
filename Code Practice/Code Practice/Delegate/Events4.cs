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
            Example1();
            //Example2ParametersListWithoutType();
            //Example3ReturningValue();
            //Example5LambdaAsReturningParameter();
        }

        
        private void Example1()
        {
            Account account = new Account(100);
            account.Notify += new Account.AccountHandler(DisplayMessage);
            account.Notify += DisplayMessage;
            account.Notify += DisplayRedMessage;
            account.Put(20);
            account.Notify -= DisplayRedMessage;
            account.ShowSumOnAccount();
            account.Take(70);
            account.ShowSumOnAccount();
            account.Take(180);
            account.ShowSumOnAccount();

            void DisplayMessage(string message) => Console.WriteLine(message);
            void DisplayRedMessage(string message)
            { 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
    }
}