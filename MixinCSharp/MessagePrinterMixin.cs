using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MixinCSharp
{
    static class MessagePrinterMixin
    {
        private static readonly Dictionary<Type, Func<IMessagePrinter>> Factories;

        static MessagePrinterMixin()
        {
            var pFacts = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Select(t => new { Type = t, Attribute = (MessagePrinterTypeAttribute)t.GetCustomAttributes(typeof(MessagePrinterTypeAttribute), false).SingleOrDefault() })
                .Where(obj => obj.Attribute != null).ToArray();

            Factories = pFacts.ToDictionary(obj => obj.Attribute.MessageClass, obj => new Func<IMessagePrinter>(() => (IMessagePrinter)Activator.CreateInstance(obj.Type)));
        }

        public static void Print(this Message doc)
        {
            GetPersistentItemFor(doc.GetType()).Print(doc);
        }

        private static IMessagePrinter GetPersistentItemFor(Type docType)
        {
            return Factories[docType]();
        }
    }
}
