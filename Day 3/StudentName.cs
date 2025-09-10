using System;

class Program
{
    static void Main()
    {
        int noOfStudents = 5;
        string[] sName = new string[noOfStudents];

        Console.WriteLine("Enter the names of 5 students:");

        for (int i = 0; i < noOfStudents; i++)
        {
            Console.Write($"Enter name of student {i + 1}: ");
            sName[i] = Console.ReadLine();
        }

        Console.WriteLine("\nStudent Data:");
        for (int i = 0; i < noOfStudents; i++)
        {
            Console.WriteLine($"The {i + 1} student name is: {sName[i]}");
        }
    }
}
