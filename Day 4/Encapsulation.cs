using System;

class Voter
{
    private int age = 0;

    public void SetAge(int age)
    {
        this.age = age;
        if (this.age < 18)
        {
            Console.WriteLine("Age should be greater than 18");
        }
    }

    public int GetAge() // changed to public
    {
        return age;
    }
}

class MainProgram
{
    static void Main()
    {
        Voter v = new Voter();

        v.SetAge(12);
        Console.WriteLine(v.GetAge());
    }
}
