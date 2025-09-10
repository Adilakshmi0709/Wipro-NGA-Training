using System;

class Program
{
    static void Main()
    {
        int noOfStudents = 5;
        string[,] sName = new string[noOfStudents, 2];

        Console.WriteLine("Enter the name and age of 5 students:");

        for (int i = 0; i < noOfStudents; i++)
        {
            Console.Write($"Enter name of student {i + 1}: ");
            sName[i, 0] = Console.ReadLine();

            Console.Write($"Enter age of student {i + 1}: ");
            sName[i, 1] = Console.ReadLine();
        }

        Console.WriteLine("\nStudent Data:");
        for (int i = 0; i < noOfStudents; i++)
        {
            Console.WriteLine($"The {i + 1} student name is: {sName[i, 0]} and age is: {sName[i, 1]}");
        }
    }
}
