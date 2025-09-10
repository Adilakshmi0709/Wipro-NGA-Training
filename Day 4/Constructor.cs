using System;

namespace StructExample
{
    public struct Book
    {
        public string Title;
        public string Author;
        public decimal Price;
        public short Year;

        // Constructor
        public Book(string title, string author, decimal price, short year)
        {
            Title = title;
            Author = author;
            Price = price;
            Year = year;
        }

        public void Display()
        {
            Console.WriteLine($"Title: {Title}, Author: {Author}, Price: {Price}, Year: {Year}");
        }
    }

    // Enum for days
    enum DaysOfWeek
    {
        Monday, Tuesday, Wednesday
    }

    // Enum for status
    enum Status
    {
        Pending,
        Approved,
        Rejected
    }

    class BookStructure
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Book Struct with Constructor and Enums ===");

            // Using constructor to initialize
            Book myBook = new Book("CSharp", "ABC", 4545.00M, 2017);
            myBook.Display();

            // Working with enum
            DaysOfWeek today = DaysOfWeek.Tuesday;

            if (today == DaysOfWeek.Monday || today == DaysOfWeek.Tuesday)
            {
                Console.WriteLine("Today is either Monday or Tuesday");
            }

            switch (today)
            {
                case DaysOfWeek.Monday:
                    Console.WriteLine("It's Monday");
                    break;
                case DaysOfWeek.Tuesday:
                    Console.WriteLine("It's Tuesday");
                    break;
                case DaysOfWeek.Wednesday:
                    Console.WriteLine("It's Wednesday");
                    break;
                default:
                    Console.WriteLine("Weekend");
                    break;
            }

            Console.WriteLine("\nAvailable Statuses:");
            foreach (Status st in Enum.GetValues(typeof(Status)))
            {
                Console.WriteLine(st);
            }
        }
    }
}
