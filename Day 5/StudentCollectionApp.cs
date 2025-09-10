using System;
using System.Collections.Generic;

namespace StudentCollectionApp
{
    class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public Dictionary<string, int> SubjectMarks { get; set; }

        public Student(int id, string name)
        {
            StudentId = id;
            StudentName = name;
            SubjectMarks = new Dictionary<string, int>();
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"\nID: {StudentId}, Name: {StudentName}");
            Console.WriteLine("Subject Marks:");
            int total = 0;
            foreach (var subject in SubjectMarks)
            {
                Console.WriteLine($"  {subject.Key}: {subject.Value}");
                total += subject.Value;
            }
            double avg = SubjectMarks.Count > 0 ? (double)total / SubjectMarks.Count : 0;
            Console.WriteLine($"Average Marks: {avg:F2}");
        }
    }

    class Program
    {
        static void Main()
        {
            List<Student> students = new List<Student>();
            Console.Write("Enter number of students: ");
            int numberOfStudents = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfStudents; i++)
            {
                Console.WriteLine($"\nEnter details for student #{i + 1}:");
                Console.Write("Student ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Student Name: ");
                string name = Console.ReadLine();

                Student student = new Student(id, name);

                Console.Write("Enter number of subjects: ");
                int numberOfSubjects = int.Parse(Console.ReadLine());

                for (int j = 0; j < numberOfSubjects; j++)
                {
                    Console.Write($"Enter name of subject #{j + 1}: ");
                    string subject = Console.ReadLine();
                    Console.Write($"Enter marks for {subject}: ");
                    int marks = int.Parse(Console.ReadLine());
                    student.SubjectMarks.Add(subject, marks);
                }
                students.Add(student);
            }

            // Display all student info
            Console.WriteLine("\n--- Student Details ---");
            foreach (var student in students)
            {
                student.DisplayInfo();
            }
        }
    }
}
