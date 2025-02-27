using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Practice.Delegate.MaterialsCovarianceAndContravariance
{
    public class Message
    {
        public string Text { get; set; }
        public Message(string text) => Text = text;
        public virtual void Print() => Console.WriteLine($"Message: {this.Text}");
    }
}
