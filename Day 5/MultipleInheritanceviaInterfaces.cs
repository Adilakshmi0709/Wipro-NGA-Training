using System;

namespace School
{
    public interface ICurricularActivities
    {
        void Stream();
    }

    public interface INonCurricularActivities
    {
        void Activities();
    }

    public class Person
    {
        protected string Name { get; set; }
        public virtual void Display()
        {
            Console.WriteLine("Displaying Name you entered : " + Name);
        }
    }

    public class Student : Person, ICurricularActivities, INonCurricularActivities
    {
        public int RollNumber { get; set; }

        public void Study()
        {
            Console.WriteLine(Name + " is studying.");
        }

        public void Stream()
        {
            Console.WriteLine("Taken Science Stream");
        }

        public void Activities()
        {
            Console.WriteLine("Sports - BasketBall");
        }

        public static void Main()
        {
            Student s = new Student();
            Console.Write("Enter the name of student: ");
            s.Name = Console.ReadLine();
            s.Study();
            s.Display();
            s.Stream();
            s.Activities();
        }
    }
}
