using System;

class Program2
{
    static void Main()
    {
        // Shared one (interned)
        string a = "Niti"; // stored in string pool
        string e = "Niti";
        Console.WriteLine(object.ReferenceEquals(a, e)); // True

        // Not shared (different objects)
        string b = new string("Niti");
        string d = new string("Niti");
        Console.WriteLine(object.ReferenceEquals(b, d)); // False

        Console.WriteLine("The value of B is: " + b);
        Console.WriteLine(a == b); // True (value equality)
        Console.WriteLine(a.GetHashCode());
        Console.WriteLine(b.GetHashCode());
        Console.WriteLine(object.ReferenceEquals(a, b)); // False

        // Intern the string
        string c = string.Intern(b);
        Console.WriteLine(c.GetHashCode());
        Console.WriteLine(object.ReferenceEquals(a, c)); // True

        // Ordinal hash codes
        Console.WriteLine(StringComparer.Ordinal.GetHashCode(a));
        Console.WriteLine(StringComparer.Ordinal.GetHashCode(c));
    }
}
