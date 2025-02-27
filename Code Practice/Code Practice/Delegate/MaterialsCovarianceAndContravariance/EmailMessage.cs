using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Practice.Delegate.MaterialsCovarianceAndContravariance
{
    public class EmailMessage : Message
    {
        public EmailMessage(string text): base(text) { }
        public override void Print()
        {
            Console.WriteLine($"Email: {this.Text}");
        }
    }
}
