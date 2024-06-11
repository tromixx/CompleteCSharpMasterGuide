using System:

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var point = new Point(10, 20);
                point.Move(new Point(40, 60));
                System.Console.WriteLine("Point is at ({0})", point.X);

                point.Move(100, 200);
                System.Console.WriteLine("Point is at {0}", point.X);

                var calculator = new Calculator();
                System.Console.WriteLine(calculator.Add(1,2));

                int num;
                int.TryParse("abc", number);
                
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("An error occured");;
            }
            
        }
    }
    
}