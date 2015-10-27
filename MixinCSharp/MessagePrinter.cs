using System;

namespace MixinCSharp
{
    [MessagePrinterType(typeof(Message))]
    class MessagePrinter : IMessagePrinter
    {
        public void Print(Message message)
        {
            Console.WriteLine(message.Type);
        }
    }
}
