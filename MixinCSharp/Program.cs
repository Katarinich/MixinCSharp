namespace MixinCSharp
{
    class Program
    {
        static void Main()
        {
            var mess = new Message();
            Message errMess = new ErrorMessage();
            mess.Print();
            errMess.Print();
        }
    }
}
