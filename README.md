
# PhonePad

The `PhonePad` class simulates the behavior of an old phone keypad, where users input text by pressing numeric keys multiple times to cycle through letters associated with each key. This implementation processes a sequence of key presses (represented as a string) and converts it into the corresponding output text.

## Features

-   **Key Mapping** : Maps numeric keys (`2`-`9`) to their respective letters, similar to old mobile phones.
-   **Pause Handling** : Supports pauses (spaces) between key sequences to differentiate between consecutive presses of the same key.
-   **Send Button (`#`)** : Ends the input processing when the `#` character is encountered.
-   **Invalid Input Handling** : Ignores invalid characters and gracefully handles edge cases like null or empty input.
-   **Star Key (`*`)** : Ignores the `*` key, which can be used as a placeholder for special functions.

## Usage

### Input Format

The input string represents a sequence of key presses:

-   Numeric keys (`2`-`9`) correspond to letters.
-   Spaces () indicate pauses between key sequences.
-   The `#` character signifies the end of input.
-   The `*` character is ignored.

### Example Usage
-   Console.WriteLine(OldPhonePad("33#"));                // Output: E
-   Console.WriteLine(OldPhonePad("227*#"));              // Output: B
-   Console.WriteLine(OldPhonePad("4433555 555666#"));     // Output: HELLO
-   Console.WriteLine(OldPhonePad("8 88777444666*664#"));  // Output: TURING
-   Console.WriteLine(OldPhonePad("55 555*5#"));          // Output: KJ
-   Console.WriteLine(OldPhonePad("222 2 22#"));          // Output: CAB

### Edge Cases

-   **Null or Empty Input** : Returns an empty string.
-   **Invalid Characters** : Ignores characters not in the keypad mapping.
-   **Consecutive Same Keys** : Handles pauses () to differentiate between repeated presses of the same key.

## Implementation Details

### Key Mapping

The keypad mapping is defined as a dictionary:
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

### Processing Logic

1.  **Sequence Parsing** :
    
    -   Accumulates consecutive key presses into sequences.
    -   Uses spaces () to separate sequences for the same key.
    -   Processes sequences using the `ProcessSequence` method to determine the corresponding letter.
2.  **Character Selection** :
    
    -   For a given sequence of key presses, the `ProcessSequence` method calculates the index of the corresponding letter using modular arithmetic:
    - return letters[(count - 1) % letters.Length];
3.  **Edge Case Handling** :
    
    -   Null or empty input returns an empty string.
    -   Invalid characters are ignored.
    -   The `*` key is skipped without affecting the output.
### Main Method

The `Main` method demonstrates the functionality with various test cases.

## How to Run

1.  Copy the `PhonePad` class into a C# project.
2.  Compile and run the program.
3.  Use the `OldPhonePad` method to process input strings and observe the output.
