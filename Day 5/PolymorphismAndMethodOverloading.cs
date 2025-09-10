using System;

namespace Oops.Poly
{
    class InfoPrinter
    {
        public int Pages;

        // Default Constructor
        public InfoPrinter()
        {
            Console.WriteLine("Constructor Called");
        }

        // Parameterized Constructor
        public InfoPrinter(int pages)
        {
            this.Pages = pages + 1;
            Console.WriteLine("Total Pages Printed: " + this.Pages);
        }

        // Method Overloading: 1st version
        public void Print(string name, int empId)
        {
            Console.WriteLine("Name: " + name + ", EmpId: " + empId);
        }

        // Method Overloading: 2nd version (parameter order changed)
        public void Print(int empId, string name)
        {
            Console.WriteLine("Name: " + name + ", EmpId: " + empId);
        }

        // Main method
        static void Main()
        {
            InfoPrinter infPrinter = new InfoPrinter();               // Default
            infPrinter.Print("Niti", 1001);                           // 1st Print()
            infPrinter.Print(1002, "Sakshi");                         // 2nd Print()

            InfoPrinter infPrinter1 = new InfoPrinter(23);            // Param constructor
            InfoPrinter infPrinter2 = new InfoPrinter(12);            // Param constructor
        }
    }
}
