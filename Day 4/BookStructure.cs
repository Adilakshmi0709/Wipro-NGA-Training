using System;

public struct Book
{
    public string Title;
    public string Author;
    public decimal Price;
    public short Year;
}

enum DaysOfWeek
{
    Monday, Tuesday, Wednesday
}

enum Status
{
    Pending,
    Approved,
    Rejected
}

class BookStructure
{
    static void Main()
    {
        DaysOfWeek t1 = DaysOfWeek.Tuesday;
        Console.WriteLine("Structure Example");

        Book myBook = new Book();
        myBook.Title = "CSharp";
        myBook.Author = "ABC";
        myBook.Price = 4545.00M;
        myBook.Year = 2017;

        Console.WriteLine("Book Details:");
        Console.WriteLine($"Title: {myBook.Title}");
        Console.WriteLine($"Author: {myBook.Author}");
        Console.WriteLine($"Price: {myBook.Price}");
        Console.WriteLine($"Year: {myBook.Year}");

        if (t1 == DaysOfWeek.Monday || t1 == DaysOfWeek.Tuesday)
        {
            Console.WriteLine("Either it is Monday or Tuesday");
        }
        else
        {
            Console.WriteLine("It's not Monday or Tuesday");
        }

        switch (t1)
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
                Console.WriteLine("It's Weekend");
                break;
        }

        Console.WriteLine("Status enum values:");
        foreach (Status st in Enum.GetValues(typeof(Status)))
        {
            Console.WriteLine(st);
        }
    }
}
