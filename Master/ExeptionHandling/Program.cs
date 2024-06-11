
using System;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var api = new YoutubeApi();
                var videos = api.GetVideos("Tom");

            }
            catch(Exeption ex)
            {}
        }
    }
}