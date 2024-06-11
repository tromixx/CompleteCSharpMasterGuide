using System;

namespace Delegates
{
    public class PhotoProcessor
    {
        public void Process(Photo photo)
        {
            var photo = Photo.Load(path);

            filterHandler(photo);

            photo.Save();

        }

    }
}