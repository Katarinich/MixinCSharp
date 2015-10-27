using System;

namespace MixinCSharp
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    class MessagePrinterTypeAttribute : Attribute
    {
        public Type MessageClass { get; }

        public MessagePrinterTypeAttribute(Type messageClass)
        {
            MessageClass = messageClass;
        }
    }
}
