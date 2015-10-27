using System;

namespace MixinCSharp
{
    [MessagePrinterType(typeof(ErrorMessage))]
    class ErrorMessagePrinter : IMessagePrinter
    {
        public void Print(Message message)
        {
            Console.WriteLine(message.Type);
        }
    }
}
