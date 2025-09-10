using System;

class Program
{
    static void Main(string[] args)
    {
        // Data type declaration with initialization
        int a = 456;
        int b; // Added declaration for b
        string s = "Hello";
        char ch = 'b';
        short num1 = 234; // Int16
        long num = 5767; // Int64
        double price = 45.00;
        decimal marks = 45.7m;

        Console.WriteLine($"Value : {a} second number : {num1}");
        Console.WriteLine($"char : " + ch);
        Console.WriteLine($"Equivalent Number : " + (byte)ch); // char to byte (ASCII)
        Console.WriteLine($"The minimum and maximum value : " + char.MinValue + " " + char.MaxValue);
        Console.WriteLine($"the char size : " + sizeof(char));

        Console.WriteLine("Enter first number:");
        a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter second number:");
        b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Sum of 2 numbers : " + (a + b));

        Console.ReadKey(); // wait for key press
    }
}