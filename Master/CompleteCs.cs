/*
Topics:
1. Overview of C#
2. Core C# Features
3. Generics
4. Delegates and Events
5. OOP Principles in C#
6. Collections and Data Structures
7. LINQ and Querying Data
8. Exception Handling
9. Memory Management and Garbage Collection
10. Threads and Asynchronous Programming
11. Design Patterns
12. Important Differences (e.g., class vs struct, throw vs throw ex)
13. Miscellaneous Concepts
14. Dependency Injection (DI)
15. C# 9+ Features
16. Code Examples and Practice Questions
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CompleteCs
{
    class Program
    {
        static async Task Main(string[] args)
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
            var data = await GetDataAsync();
            Console.WriteLine(data);

            // Example of Dependency Injection
            var logger = new ConsoleLogger();
            var app = new Application(logger);
            app.Run();

            // Example of OOP Principles
            var dog = new Dog();
            dog.Speak();

            // Example of Design Patterns
            var singleton = Singleton.Instance;
            Console.WriteLine("Singleton instance created.");
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

    // OOP Principles in C#
    public class Animal
    {
        public virtual void Speak() => Console.WriteLine("Animal speaks");
    }

    public class Dog : Animal
    {
        public override void Speak() => Console.WriteLine("Bark");
    }

    public abstract class Shape
    {
        public abstract double GetArea();
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override double GetArea() => Math.PI * Radius * Radius;
    }

    // Generics
    public class GenericList<T>
    {
        private readonly List<T> _list = new List<T>();

        public void Add(T value) => _list.Add(value);

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

    // Dependency Injection
    public interface ILogger
    {
        void Log(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message) => Console.WriteLine(message);
    }

    public class Application
    {
        private readonly ILogger _logger;

        public Application(ILogger logger)
        {
            _logger = logger;
        }

        public void Run()
        {
            _logger.Log("Application is running...");
        }
    }

    // LINQ and Querying Data
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

    // Design Patterns
    public class Singleton
    {
        private static Singleton _instance;
        private static readonly object Lock = new object();

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                lock (Lock)
                {
                    return _instance ??= new Singleton();
                }
            }
        }
    }
}
