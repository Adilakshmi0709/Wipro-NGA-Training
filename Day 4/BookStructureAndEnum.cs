using System;

namespace StructExample
{
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
        static void Main(string[] args)
        {
            DaysOfWeek t1 = DaysOfWeek.Tuesday;
            Console.WriteLine("Structure Example");

            Book myBook = new Book
            {
                Title = "CSharp",
                Author = "ABC",
                Price = 4545.00M,
                Year = 2017
            };

            Console.WriteLine($"{myBook.Title}, {myBook.Author}, ₹{myBook.Price}, {myBook.Year}");

            if (t1 == DaysOfWeek.Monday || t1 == DaysOfWeek.Tuesday)
            {
                Console.WriteLine("Either it is Monday or Tuesday");
            }
            else
            {
                Console.WriteLine("It is another day");
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

            Status s = Status.Pending;
            string statusstring = s.ToString();
            Console.WriteLine("Order status is: " + statusstring);
        }
    }
}
