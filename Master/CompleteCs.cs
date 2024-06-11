/*
Delegates
Dynamic Binding
Events&Delegates
ExeptionHandling
ExtensionMethods
Generics
Lambda
LinQ
Nullable

*/

using System;

namespace CompleteCs
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();
            Action<Photo> filterHandler = filters.ApplyBrightness;
            filterHandlerHandler += filterHandler.ApplyContrast;
            filterHandler += RemoveRedEyeFilter;
        }

        static void RemoveRedEyeFilter(Photo photo)
        {
            System.Console.WriteLine("Apply Remove Red Eye");
        }
    }
    public class Delegates
    {
        public void ApplyBrightness(Photo photo)
        {
            System.Console.WriteLine("wenoweno");
        }

        public void ApplyContrast(Photo photo)
        {
            System.Console.WriteLine("mema");
        }
    }

    public class Photo
    {
        public static void Photo(string path)
        {
            return new Photo();
        }
    }
}