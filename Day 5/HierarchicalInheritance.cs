using System;

namespace School
{
    public class Person
    {
        protected string Name { get; set; }
        public virtual void Display()
        {
            Console.WriteLine("Displaying Name you entered : " + Name);
        }
    }

    public class Student : Person
    {
        public int RollNumber { get; set; }
        public void Study()
        {
            Console.WriteLine(Name + " is studying.");
        }
    }

    public class Teacher : Person
    {
        public string Subject { get; set; }
        public void Teaches()
        {
            Console.WriteLine(Name + " teaches Computer Science.");
        }

        public static void Main()
        {
            Teacher t = new Teacher();
            t.Name = "Niti";
            t.Teaches();      // From Teacher
            t.Display();      // From Person
        }
    }
}
