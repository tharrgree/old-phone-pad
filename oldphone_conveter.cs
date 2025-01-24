using System;
using System.Collections.Generic;
using System.Text;

public class PhonePad
{
    private static readonly Dictionary<char, string> keypad = new Dictionary<char, string>
    {
        { '2', "ABC" },
        { '3', "DEF" },
        { '4', "GHI" },
        { '5', "JKL" },
        { '6', "MNO" },
        { '7', "PQRS" },
        { '8', "TUV" },
        { '9', "WXYZ" },
        { '0', " " }
    };

    public static string OldPhonePad(string input)
    {
        // Handle null input
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }

        StringBuilder output = new StringBuilder();
        StringBuilder currentSequence = new StringBuilder();
        char previousKey = '\0';

        foreach (char ch in input)
        {
            // Handle end of input
            if (ch == '#')
            {
                // Process the last accumulated key presses
                if (currentSequence.Length > 0)
                {
                    output.Append(ProcessSequence(currentSequence.ToString()));
                }
                break; // End processing on send button
            }

            // Handle pauses (space)
            if (ch == ' ')
            {
                // Process the current sequence and reset it
                if (currentSequence.Length > 0)
                {
                    output.Append(ProcessSequence(currentSequence.ToString()));
                    currentSequence.Clear();
                }
                previousKey = '\0'; // Reset previous key
                continue;
            }

            // If ch is not a space or #
            if (keypad.ContainsKey(ch))
            {
                // check the current key is the same as the previous one
                if (previousKey == ch)
                {
                    currentSequence.Append(ch);
                }
                // check the current key is different with the previous one, will process
                else
                {
                    // Process the previous sequence if it exists
                    if (currentSequence.Length > 0)
                    {
                        output.Append(ProcessSequence(currentSequence.ToString()));
                        currentSequence.Clear();
                    }
                    // Start a new sequence with the current key
                    currentSequence.Append(ch);
                }
                previousKey = ch; // Update the previous key
            }
            // if current key is *, not process previous sequence
            else if (ch == '*')
            {
                
                continue;
            }
            // If there's invalid character, not process
            else
            {
                
                continue;
            }
        }

        return output.ToString();
    }

    private static char ProcessSequence(string sequence)
    { 
        char key = sequence[0];

        // Get the count of key presses
        int count = sequence.Length;

        // Check if the key is valid and map it to the corresponding letter
        if (keypad.ContainsKey(key))
        {
            string letters = keypad[key];
            // return character from keypad
            return letters[(count - 1) % letters.Length];
        }

        // If the key is not valid, return a space
        return ' ';
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(OldPhonePad(null));                // Output: 
        Console.WriteLine(OldPhonePad("33#"));                // Output: E
        Console.WriteLine(OldPhonePad("227*#"));              // Output: B
        Console.WriteLine(OldPhonePad("4433555 555666#"));     // Output: HELLO
        Console.WriteLine(OldPhonePad("8 88777444666*664#"));  // Output: TURING
        Console.WriteLine(OldPhonePad("55 555*5#"));          // Output: KJ
        Console.WriteLine(OldPhonePad("222 2 22#"));          // Output: CAB
    }
}