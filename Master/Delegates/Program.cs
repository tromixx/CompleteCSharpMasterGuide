
using System;

namespace Delegates
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
}