/*
Delegates
Dynamic Binding
ExeptionHandling
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

    //Dynamic Binding
    public class DynamicBinding
    {
        int i = 5;
        dynamic d = i;
        long l = d;
    }

    //ExeptionHandling
    public class ExeptionHandling
    {
        try
        {
            var api = new YoutubeApi();
            var videos = api.GetVideos("Tom");

        }
        catch(Exeption ex)
        {}
    }

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

    public class Video
    {
    }
    
    public class YouTubeException : Exception
    {
        public YouTubeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }


    //Generics
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book{ Isbn = "1111", Title = "C# Advance"};

            var numbers = new GenericList<int>();
            numbers.Add(10);

            var books = new GenericList<Book>();
            books.Add(new Book());
        }
    }

    public class GenericList<T>
    {
        public void Add(T value)
        {

        }

        public T this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }


    //Lambda
    class Program
    {
        static void Main(string[] args)
        {
            var books = new BookRepository().GetBooks();

            var cheapBooks = books.FindAll(b => b.Price < 10);

            foreach (var book in cheapBooks)
            {
                Console.WriteLine(book.Title);
            }

        }
    }

    public class Book
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
    }

    public class BookRepository
    {
        public List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book() {Title = "Title 1", Price = 5},
                new Book() {Title = "Title 2", Price = 7},
                new Book() {Title = "Title 3", Price = 17}
            };
        }
    }


    //LinQ
    class Program
    {
        static void Main(string[] args)
        {
            
            Func<int, int, int> add = (a, b) => a + b;
            Console.WriteLine(add(2, 3));
        }

        private static float CalculateDiscount(float price)
        {
            return 0;
        }

    
    
    public class Book
    {
        public string Title { get; set; }
        public float Price { get; set; }
    }

    public class BookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book() {Title = "ADO.Net Step by Step", Price = 5 },
                new Book() {Title = "ASP.NET MVC", Price = 9.99f },
                new Book() {Title = "ASP.NET Web API", Price = 12 },
                new Book() {Title = "C# Advanced Topics", Price = 7 },
                new Book() {Title = "C# Advanced Topics", Price = 9 }
            };
        }
    }

    public class String
    {
        public void Shorten(int numberOfWords)
        {
        }

        public int Add(int a, int b)
        {
            return a + b;
        }
    }
    public class MessageArgs
    {
    }

    //Nullable

    class Program
    {
        static void Main(string[] args)
        {
            DateTime? date = null;
            DateTime date2 = date ?? DateTime.Today;

            DateTime date3 = (date != null) ? date.GetValueOrDefault() : DateTime.Today
        }
    }
}