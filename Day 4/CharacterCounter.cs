using System;
using System.Linq;

class CharacterCounter
{
    static void Main()
    {
        int vowelsCount = 0;
        int consonantsCount = 0;
        int specialCharCount = 0;

        Console.Write("Enter a string: ");
        string givenData = Console.ReadLine();

        char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

        foreach (char c in givenData)
        {
            if (vowels.Contains(c))
            {
                vowelsCount++;
            }
            else if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
            {
                specialCharCount++;
            }
            else if (char.IsLetter(c))
            {
                consonantsCount++;
            }
        }

        Console.WriteLine("Vowels: " + vowelsCount);
        Console.WriteLine("Consonants: " + consonantsCount);
        Console.WriteLine("Special Characters: " + specialCharCount);
    }
}
