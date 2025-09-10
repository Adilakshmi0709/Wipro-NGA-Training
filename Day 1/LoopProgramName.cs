using System;

class LoopProgram
{
    static void Main()
    {
        // For loop
        Console.WriteLine("For Loop:");
        for (int i = 0; i <= 5; i++)
        {
            Console.WriteLine("The value of i is: " + i);
        }

        // While loop
        Console.WriteLine("\nWhile Loop:");
        int x = 0;
        while (x < 5)
        {
            Console.WriteLine("The value of x is: " + x);
            x++;
        }

        // Do-while loop
        Console.WriteLine("\nDo-While Loop:");
        int y = 5;
        do
        {
            Console.WriteLine("Even if condition is false, this block executes once.");
            y++;
        }
        while (y < 1);

        // Foreach loop
        Console.WriteLine("\nForeach Loop:");
        string[] names = { "Niti", "Jatin", "Preeti" };
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
    }
}
