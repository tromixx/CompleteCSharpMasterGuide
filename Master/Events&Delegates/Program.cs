using System;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = new Nullable<int>();
            System.Console.WriteLine("has Value?" + number.HasValue);
            System.Console.WriteLine("Value?" + number.GetValueOrDefault());
        }
    }
}
