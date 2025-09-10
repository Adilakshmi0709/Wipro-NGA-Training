using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number (1-3): ");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("You selected One.");
                break;

            case 2:
                Console.WriteLine("You selected Two.");
                break;

            case 3:
                Console.WriteLine("You selected Three.");
                break;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
