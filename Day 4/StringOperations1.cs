using System;

class StringPrograms
{
    static void Main()
    {
        string text = "CSharp$Language@invented_in_2002!";

        int length = text.Length; // Get string length
        Console.WriteLine("The Length of a string : " + length);

        string subString = text.Substring(7, 8); // Get substring
        Console.WriteLine("The text from a string : " + subString);

        Console.WriteLine("Index of 'harp': " + text.IndexOf("harp")); // Find index

        Console.WriteLine("Uppercase version: " + text.ToUpper()); // Convert to uppercase

        string newString = text.Replace("CSharp", "Java"); // Replace word
        Console.WriteLine("After replace: " + newString);

        string replaced = text.Replace(" ", ""); // Remove spaces
        Console.WriteLine("Without space : " + replaced.Length);

        int pos = text.IndexOf("Language"); // Get position of "Language"
        string newText = text.Substring(pos, 8);
        Console.WriteLine("New Text Value: " + newText.ToUpper());

        // Splitting a comma-separated string
        string data = "CSharp,Language";
        string[] lang = data.Split(',');
        foreach (string value in lang)
        {
            Console.WriteLine("Split value: " + value);
        }

        // Count blank spaces in a sentence
        string data1 = "This is the day four training class";
        string[] lang1 = data1.Split(' ');
        Console.WriteLine("The blank spaces in the above statement: " + ((lang1.Length) - 1));

        // Count commas (as special characters)
        string data2 = "apple,orange,grapes,banana";
        string[] lang2 = data2.Split(',');
        Console.WriteLine("The Special characters in the above statement: " + ((lang2.Length) - 1));

        // Count number of words
        string data3 = "This is the day four training class";
        string[] lang3 = data3.Split(' ');
        Console.WriteLine("The Number of Words in the above statement: " + (lang3.Length));

        // Count special characters in original text
        int specialCharCount = 0;
        foreach (char c in text)
        {
            if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
                specialCharCount++;
        }
        Console.WriteLine("Total number of special characters: " + specialCharCount);

        // Count vowels in user input
        Console.Write("Enter a string to count vowels: ");
        string s = Console.ReadLine();
        int vowel = 0;
        foreach (char ch in s)
        {
            if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u' ||
                ch == 'A' || ch == 'E' || ch == 'I' || ch == 'O' || ch == 'U')
            {
                vowel++;
            }
        }
        Console.WriteLine("Total vowel count: " + vowel);
    }
}
