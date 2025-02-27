using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Practice.Delegate.MaterialsCovarianceAndContravariance
{
    public class SmsMessage : Message
    {
        public SmsMessage(string text) : base(text) { }
        public override void Print()
        {
            Console.WriteLine($"Sms: {this.Text}");
        }
    }
}
