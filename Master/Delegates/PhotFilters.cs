using System;

namespace Delegates
{
    public class PhotoFilters
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
}