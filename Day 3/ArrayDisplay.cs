using System;

class Program
{
    static void Main()
    {
        int[] numbers = new int[5];
        numbers[0] = 34;
        numbers[1] = 45;
        numbers[2] = 67;

        Console.WriteLine("Single element output: " + numbers[2]);

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("The array elements are: " + numbers[i]);
        }
    }
}
