using System;

class CampusCanteenCouponTracker
{
    static void Main()
    {
        Console.Write("Enter number of coupons: ");
        int n = int.Parse(Console.ReadLine());

        // Validate n
        if (n < 1 || n > 100)
        {
            Console.WriteLine("Invalid number of coupons. It should be between 1 and 100.");
            return;
        }

        int[] coupons = new int[n];

        Console.WriteLine("Enter coupon values, separated by spaces:");
        string[] input = Console.ReadLine().Split(' ');

        if (input.Length != n)
        {
            Console.WriteLine("Number of coupon values entered does not match the count.");
            return;
        }

        // Reading values into array
        for (int i = 0; i < n; i++)
        {
            coupons[i] = int.Parse(input[i]);
        }

        // Initialize statistics
        int totalValue = 0;
        int highestValue = int.MinValue;
        int highestPosition = -1;

        int smallCount = 0;
        int mediumCount = 0;
        int largeCount = 0;

        // Processing
        for (int i = 0; i < n; i++)
        {
            int value = coupons[i];
            totalValue += value;

            // Track highest value and its first position
            if (value > highestValue)
            {
                highestValue = value;
                highestPosition = i + 1; // 1-based index
            }

            // Classify into categories
            if (value <= 50)
            {
                smallCount++;
            }
            else if (value <= 100)
            {
                mediumCount++;
            }
            else
            {
                largeCount++;
            }
        }

        // Output
        Console.WriteLine("\n----- Daily Coupon Summary -----");
        Console.WriteLine("Total coupons redeemed  : " + n);
        Console.WriteLine("Total value collected   : " + totalValue);
        Console.WriteLine("Highest coupon redeemed : " + highestValue + " (coupon #" + highestPosition + ")");

        Console.WriteLine("\nCategory breakdown");
        Console.WriteLine("Small  (≤50)   : " + smallCount);
        Console.WriteLine("Medium (51–100): " + mediumCount);
        Console.WriteLine("Large  (>100)  : " + largeCount);
    }
}
