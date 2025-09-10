using System;

class StringPrograms
{
    static void Main()
    {
        string text = "CSharp Language invented in 2002";

        // 1. Get the length of the string
        int length = text.Length;
        Console.WriteLine("The Length of the string: " + length);

        // 2. Extract substring starting at index 7 with 8 characters
        string subString = text.Substring(7, 8);
        Console.WriteLine("Substring from the string: " + subString);

        // 3. Find the position of the word "harp"
        Console.WriteLine("Index of 'harp': " + text.IndexOf("harp"));

        // 4. Convert entire string to uppercase
        Console.WriteLine("Uppercase text: " + text.ToUpper());

        // 5. Replace "CSharp" with "Java"
        string newString = text.Replace("CSharp", "Java");
        Console.WriteLine("After replacing 'CSharp' with 'Java': " + newString);

        // 6. Remove spaces and display the length of the resulting string
        string noSpaces = text.Replace(" ", "");
        Console.WriteLine("Length without spaces: " + noSpaces.Length);

        // 7. Extract and convert "Language" to uppercase
        int pos = text.IndexOf("Language");
        string extracted = text.Substring(pos, 8); // "Language"
        Console.WriteLine("Extracted and Uppercased Text: " + extracted.ToUpper());

        // 8. Count and print the number of blank spaces
        int spaceCount = 0;
        foreach (char c in text)
        {
            if (c == ' ')
                spaceCount++;
        }
        Console.WriteLine("Number of blank spaces: " + spaceCount);

        // 9. Split a string using comma as separator
        string data = "CSharp,Language";
        string[] lang = data.Split(',');
        foreach (string value in lang)
        {
            Console.WriteLine("Split value: " + value);
        }
    }
}
