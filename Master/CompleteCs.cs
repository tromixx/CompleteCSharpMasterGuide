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

// ================================
// C# Interview Practice Questions
// ================================

/* Question 1: Simple Class Definition
Create a class `Person` that contains properties `Name` and `Age` and a method `SayHello()` 
that prints a greeting message. Demonstrate how to instantiate and use this class. */
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public void SayHello()
    {
        Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
    }
}

public class SimpleClassExample
{
    public void Demo()
    {
        Person person = new Person { Name = "Alice", Age = 30 };
        person.SayHello();
    }
}

/* Question 2: Using Generics
Create a generic class `Stack<T>` that implements basic stack functionality with methods like `Push` and `Pop`.
Then, demonstrate using the `Stack<int>` to store integers. */
public class Stack<T>
{
    private List<T> _items = new List<T>();

    public void Push(T item)
    {
        _items.Add(item);
    }

    public T Pop()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("Stack is empty.");
        T item = _items[_items.Count - 1];
        _items.RemoveAt(_items.Count - 1);
        return item;
    }
}

public class StackExample
{
    public void Demo()
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        Console.WriteLine(stack.Pop()); // Output: 2
    }
}

/* Question 3: LINQ Query Example
Given a list of `Book` objects, write a LINQ query that retrieves books with a price greater than $10. 
Display their titles and prices. */
public class Book
{
    public string Title { get; set; }
    public double Price { get; set; }
}

public class LINQExample
{
    public void Demo()
    {
        List<Book> books = new List<Book>
        {
            new Book { Title = "C# Basics", Price = 5 },
            new Book { Title = "Advanced C#", Price = 15 },
            new Book { Title = "LINQ in Action", Price = 12 }
        };

        var expensiveBooks = books.Where(b => b.Price > 10).ToList();
        foreach (var book in expensiveBooks)
        {
            Console.WriteLine($"{book.Title} - ${book.Price}");
        }
    }
}

/* Question 4: Exception Handling
Write a method that attempts to divide two numbers. If division by zero occurs, catch the exception and 
return a custom error message. */
public class ExceptionHandlingExample
{
    public string Divide(int numerator, int denominator)
    {
        try
        {
            return (numerator / denominator).ToString();
        }
        catch (DivideByZeroException)
        {
            return "Error: Cannot divide by zero.";
        }
    }
}

public class ExceptionExample
{
    public void Demo()
    {
        ExceptionHandlingExample example = new ExceptionHandlingExample();
        Console.WriteLine(example.Divide(10, 0)); // Output: Error: Cannot divide by zero.
    }
}

/* Question 5: Asynchronous Programming
Write an asynchronous method that simulates downloading data and returns the result after a delay. 
In the `Main` method, await this task and display the result. */
public class AsynchronousExample
{
    public async Task<string> DownloadDataAsync()
    {
        await Task.Delay(2000); // Simulate delay
        return "Data downloaded successfully.";
    }
}

public class AsyncExample
{
    public async Task Demo()
    {
        AsynchronousExample example = new AsynchronousExample();
        string result = await example.DownloadDataAsync();
        Console.WriteLine(result); // Output: Data downloaded successfully.
    }
}

/* Question 6: Dependency Injection
Create a simple application that uses dependency injection. Define an `ILogger` interface, 
implement it in a `ConsoleLogger` class, and inject it into a `Service` class. */
public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

public class Service
{
    private readonly ILogger _logger;

    public Service(ILogger logger)
    {
        _logger = logger;
    }

    public void Run()
    {
        _logger.Log("Service is running.");
    }
}

public class DIExample
{
    public void Demo()
    {
        ILogger logger = new ConsoleLogger();
        Service service = new Service(logger);
        service.Run(); // Output: Service is running.
    }
}

/* Question 7: Inheritance and Polymorphism
Create a base class `Shape` with a method `Area()`. Derive `Circle` and `Rectangle` classes from it, 
implement the `Area` method for each, and display the area for both shapes. */
public abstract class Shape
{
    public abstract double Area();
}

public class Circle : Shape
{
    public double Radius { get; set; }

    public override double Area() => Math.PI * Radius * Radius;
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public override double Area() => Width * Height;
}

public class PolymorphismExample
{
    public void Demo()
    {
        Shape circle = new Circle { Radius = 5 };
        Shape rectangle = new Rectangle { Width = 10, Height = 5 };
        
        Console.WriteLine($"Circle Area: {circle.Area()}");
        Console.WriteLine($"Rectangle Area: {rectangle.Area()}");
    }
}

/* Question 8: Design Pattern - Singleton
Implement the Singleton pattern in C#. Ensure that only one instance of a `Logger` class exists 
and demonstrate its use. */
public class Logger
{
    private static Logger _instance;
    private static readonly object _lock = new object();

    private Logger() { }

    public static Logger Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }
        }
    }

    public void Log(string message)
    {
        Console.WriteLine($"Log: {message}");
    }
}

public class SingletonExample
{
    public void Demo()
    {
        Logger logger = Logger.Instance;
        logger.Log("Singleton pattern in action!");
    }
}
