using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Queue<string> tickets = new Queue<string>();
        tickets.Enqueue("Learn C#");
        tickets.Enqueue("Revise the concepts");
        tickets.Enqueue("Clear your exam");

        foreach (string task in tickets)
        {
            Console.WriteLine(task);
        }
    }
}
