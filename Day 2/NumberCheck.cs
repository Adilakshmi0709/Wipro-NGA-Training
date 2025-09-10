using System;

class NumberCheck
{
    static void Main()
    {
        Console.WriteLine("\n--- Number Check Menu ---");
        Console.WriteLine("1. Check Prime Number");
        Console.WriteLine("2. Check Odd Number");
        Console.WriteLine("3. Check Even Number");
        Console.Write("Enter your choice (1/2/3): ");
        int choice = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                CheckPrime(number);
                break;
            case 2:
                CheckOdd(number);
                break;
            case 3:
                CheckEven(number);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static void CheckPrime(int num)
    {
        bool isPrime = true;

        if (num <= 1)
        {
            isPrime = false;
        }
        else
        {
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
        }

        Console.WriteLine(isPrime ? "It is a Prime Number." : "It is NOT a Prime Number.");
    }

    static void CheckOdd(int num)
    {
        Console.WriteLine(num % 2 != 0 ? "It is an Odd Number." : "It is NOT an Odd Number.");
    }

    static void CheckEven(int num)
    {
        Console.WriteLine(num % 2 == 0 ? "It is an Even Number." : "It is NOT an Even Number.");
    }
}
