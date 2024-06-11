using System;
using System.Collections.Generic;

namespace Indexers
{
    class Program
    {
        static void Main(string[] args)
        {
            var cookie = new HttpCookie();
            cookie["name"] = "Tom";
            System.Console.WriteLine(cookie["Tom"]);
        }

    }
}