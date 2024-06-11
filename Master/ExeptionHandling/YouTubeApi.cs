using System;
using System.Collections.Generic;

namespace ExceptionHandling
{
    public class YouTubeApi
    {
        public List<Video> GetVideos(string user)
        {
            try
            {
                throw new Exception("Oops some low level YouTube error.");
            }
            catch (Exception ex)
            {
                throw new YouTubeException("Could not fetch the videos from YouTube.", ex);
            }

            return new List<Video>();
        }
    }
}