//The dynamic variable changes depending the sistuation
namespace DynamicBinding
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 5;
            dynamic d = i;
            long l = d;
        }
    }
}
