using System;
using System.Collections.Generic;

class StudentManagement
{
    static Dictionary<int, string> students = new Dictionary<int, string>();

    static void Main()
    {
        int choice;

        do
        {
            Console.WriteLine("\n--- Student Management Menu ---");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Delete Student");
            Console.WriteLine("3. View All Students");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    DeleteStudent();
                    break;
                case 3:
                    ViewStudents();
                    break;
                case 4:
                    UpdateStudent();
                    break;
                case 5:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 5);
    }

    static void AddStudent()
    {
        Console.Write("Enter student ID: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();
        students[id] = name;
        Console.WriteLine("Student added successfully.");
    }

    static void DeleteStudent()
    {
        Console.Write("Enter student ID to delete: ");
        int id = Convert.ToInt32(Console.ReadLine());

        if (students.ContainsKey(id))
        {
            students.Remove(id);
            Console.WriteLine("Student deleted successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    static void ViewStudents()
    {
        Console.WriteLine("\n--- Student List ---");
        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.Key}, Name: {student.Value}");
        }
    }

    static void UpdateStudent()
    {
        Console.Write("Enter student ID to update: ");
        int id = Convert.ToInt32(Console.ReadLine());

        if (students.ContainsKey(id))
        {
            Console.Write("Enter new name: ");
            string name = Console.ReadLine();
            students[id] = name;
            Console.WriteLine("Student updated successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }
}
