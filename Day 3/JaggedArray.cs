using System;

class JaggedArrayExample
{
    static void Main()
    {
        string[] studentNames = new string[5];
        string[][] studentSubjects = new string[5][];

        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Enter name of student {i + 1}: ");
            studentNames[i] = Console.ReadLine();

            Console.Write($"How many subjects has {studentNames[i]} taken? ");
            int subjectCount = int.Parse(Console.ReadLine());

            studentSubjects[i] = new string[subjectCount];

            for (int j = 0; j < subjectCount; j++)
            {
                Console.Write($"Enter subject {j + 1} for {studentNames[i]}: ");
                studentSubjects[i][j] = Console.ReadLine();
            }

            Console.WriteLine(); // For spacing
        }

        // Display all data
        Console.WriteLine("\n--- Student and Their Subjects ---");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"\nStudent: {studentNames[i]}");
            Console.WriteLine("Subjects:");
            foreach (var subject in studentSubjects[i])
            {
                Console.WriteLine($"- {subject}");
            }
        }
    }
}
