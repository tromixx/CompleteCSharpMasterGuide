using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CompleteCs
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example of Delegates
            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();
            Action<Photo> filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += RemoveRedEyeFilter;
            processor.Process("photo.jpg", filterHandler);

            // Example of Nullable Types
            DateTime? nullableDate = null;
            DateTime date = nullableDate ?? DateTime.Today;
            Console.WriteLine($"The date is: {date}");

            // Example of Lambda Expressions
            var books = new BookRepository().GetBooks();
            var cheapBooks = books.FindAll(b => b.Price < 10);
            foreach (var book in cheapBooks)
                Console.WriteLine(book.Title);

            // Example of LINQ
            var expensiveBooks = books.Where(b => b.Price > 10).OrderBy(b => b.Title);
            foreach (var book in expensiveBooks)
                Console.WriteLine($"{book.Title} - ${book.Price}");

            // Example of Threads
            var thread = new Thread(() => Console.WriteLine("Thread running"));
            thread.Start();

            // Example of Asynchronous Programming
            var data = GetDataAsync().Result;
            Console.WriteLine(data);
        }

        static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("Applying Remove Red Eye filter...");
        }

        static async Task<string> GetDataAsync()
        {
            await Task.Delay(1000);
            return "Async data loaded!";
        }
    }

    // Delegates and Events
    public class PhotoProcessor
    {
        public void Process(string path, Action<Photo> filterHandler)
        {
            var photo = Photo.Load(path);
            filterHandler(photo);
        }
    }

    public class Photo
    {
        public static Photo Load(string path)
        {
            Console.WriteLine($"Loading photo from {path}...");
            return new Photo();
        }
    }

    public class PhotoFilters
    {
        public void ApplyBrightness(Photo photo)
        {
            Console.WriteLine("Applying Brightness...");
        }

        public void ApplyContrast(Photo photo)
        {
            Console.WriteLine("Applying Contrast...");
        }
    }

    // Dynamic Binding
    public class DynamicBinding
    {
        public void Example()
        {
            int i = 5;
            dynamic d = i;
            long l = d;
            Console.WriteLine($"Dynamic value: {l}");
        }
    }

    // Exception Handling
    public class ExceptionHandlingExample
    {
        public void HandleException()
        {
            try
            {
                var api = new YouTubeApi();
                var videos = api.GetVideos("Tom");
            }
            catch (YouTubeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    public class YouTubeApi
    {
        public List<Video> GetVideos(string user)
        {
            try
            {
                throw new Exception("Low-level YouTube error.");
            }
            catch (Exception ex)
            {
                throw new YouTubeException("Could not fetch videos from YouTube.", ex);
            }
        }
    }

    public class YouTubeException : Exception
    {
        public YouTubeException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    public class Video { }

    // Generics
    public class GenericList<T>
    {
        private List<T> _list = new List<T>();

        public void Add(T value)
        {
            _list.Add(value);
        }

        public T this[int index] => _list[index];
    }

    public class GenericsExample
    {
        public void Demo()
        {
            var numbers = new GenericList<int>();
            numbers.Add(10);

            var books = new GenericList<Book>();
            books.Add(new Book { Title = "C# Advanced Topics" });
        }
    }

    // LINQ
    public class LINQExample
    {
        public void QueryBooks()
        {
            var books = new BookRepository().GetBooks();

            var expensiveBooks = books.Where(b => b.Price > 10).OrderBy(b => b.Title);
            foreach (var book in expensiveBooks)
                Console.WriteLine($"{book.Title} - ${book.Price}");
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public float Price { get; set; }
    }

    public class BookRepository
    {
        public List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book { Title = "C# Basics", Price = 5 },
                new Book { Title = "Advanced C#", Price = 12 },
                new Book { Title = "LINQ in Action", Price = 9.99f }
            };
        }
    }

    // Miscellaneous: HashSet Example
    public class HashSetExample
    {
        public int FindSmallestPositiveMissingNumber(int[] numbers)
        {
            var existingNumbers = new HashSet<int>(numbers.Where(n => n > 0));
            int minResult = 1;
            while (existingNumbers.Contains(minResult))
                minResult++;
            return minResult;
        }
    }
}
