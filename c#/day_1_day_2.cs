
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("===== DAY 1: C# FUNDAMENTALS =====\n");

        Variables();
        Conditions();
        Loops();
        ArrayOperations();
        CountPositiveNegative();
        ReverseArray();

        Console.WriteLine("\n===== DAY 2: METHODS AND COLLECTIONS =====\n");

        ShowWelcome();
        Greet("Prasanth");
        DisplayDetails("Prasanth", 22, 1.5);

        Console.WriteLine($"Square of 5: {CalculateSquare(5)}");
        Console.WriteLine($"Is 8 even? {IsEven(8)}");
        Console.WriteLine($"Is 7 even? {IsEven(7)}");

        Console.WriteLine($"Total price: {CalculateTotal(99.50, 3)}");

        Console.WriteLine($"Square area: {CalculateArea(5)}");
        Console.WriteLine($"Rectangle area: {CalculateArea(5, 8)}");

        List<int> numbers = new() { -5, 2, 3, 4, 6, 9, 10 };

        Console.WriteLine("\nOriginal list:");
        PrintList(numbers);

        Console.WriteLine($"Sum of even numbers: {SumEvenNumbers(numbers)}");

        Console.WriteLine("\nPositive numbers:");
        PrintList(GetPositiveNumbers(numbers));

        string word = "Education";
        Console.WriteLine($"Vowel count in {word}: {VowelCount(word)}");

        Console.WriteLine($"Maximum number: {FindMax(numbers)}");

        string text = "  Hello CSharp  ";
        Console.WriteLine($"Trimmed: '{text.Trim()}'");
        Console.WriteLine($"Lowercase: {text.Trim().ToLower()}");
        Console.WriteLine($"Length: {text.Trim().Length}");
        Console.WriteLine($"Contains Hello: {text.Contains("Hello")}");

        Console.WriteLine("\n===== PRACTICE COMPLETED =====");
    }

    // DAY 1: VARIABLES AND DATA TYPES
    static void Variables()
    {
        string name = "Prasanth";
        int age = 22;
        double height = 5.8;
        bool isLearningCSharp = true;

        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Height: {height}");
        Console.WriteLine($"Learning C#: {isLearningCSharp}");
    }

    // DAY 1: CONDITIONS
    static void Conditions()
    {
        int number = -4;

        if (number > 0)
            Console.WriteLine($"{number} is positive");
        else if (number < 0)
            Console.WriteLine($"{number} is negative");
        else
            Console.WriteLine("Number is zero");

        Console.WriteLine(7 % 2 == 0 ? "Even" : "Odd");
    }

    // DAY 1: FOR LOOP
    static void Loops()
    {
        Console.WriteLine("\nNumbers from 1 to 5:");

        for (int i = 1; i <= 5; i++)
            Console.WriteLine(i);
    }

    // DAY 1: ARRAY SUM, MAX, MIN AND EVEN COUNT
    static void ArrayOperations()
    {
        int[] numbers = { 12, 5, 27, 9, 18 };

        int sum = 0;
        int max = numbers[0];
        int min = numbers[0];
        int evenCount = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];

            if (numbers[i] > max)
                max = numbers[i];

            if (numbers[i] < min)
                min = numbers[i];

            if (numbers[i] % 2 == 0)
                evenCount++;
        }

        Console.WriteLine($"\nArray sum: {sum}");
        Console.WriteLine($"Maximum: {max}");
        Console.WriteLine($"Minimum: {min}");
        Console.WriteLine($"Even count: {evenCount}");
    }

    // DAY 1: COUNT POSITIVE, NEGATIVE AND ZERO
    static void CountPositiveNegative()
    {
        int[] numbers = { -5, 0, 8, -2, 4, 0, 11 };

        int positive = 0;
        int negative = 0;
        int zero = 0;

        foreach (int number in numbers)
        {
            if (number > 0)
                positive++;
            else if (number < 0)
                negative++;
            else
                zero++;
        }

        Console.WriteLine($"Positive: {positive}");
        Console.WriteLine($"Negative: {negative}");
        Console.WriteLine($"Zero: {zero}");
    }

    // DAY 1: REVERSE ARRAY TRAVERSAL
    static void ReverseArray()
    {
        int[] numbers = { 10, 20, 30, 40, 50 };

        Console.WriteLine("\nArray in reverse:");

        for (int i = numbers.Length - 1; i >= 0; i--)
            Console.WriteLine(numbers[i]);
    }

    // DAY 2: VOID METHOD
    static void ShowWelcome()
    {
        Console.WriteLine("\nWelcome to C#!");
    }

    // DAY 2: PARAMETERS AND ARGUMENTS
    static void Greet(string name)
    {
        Console.WriteLine($"Hello, {name}!");
    }

    static void DisplayDetails(string name, int age, double experienceYears)
    {
        Console.WriteLine(
            $"Name: {name}, Age: {age}, Experience: {experienceYears} years"
        );
    }

    // DAY 2: RETURN VALUE
    static int CalculateSquare(int number)
    {
        return number * number;
    }

    // DAY 2: BOOLEAN METHOD
    static bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    // DAY 2: LOCAL VARIABLES AND SCOPE
    static double CalculateTotal(double price, int quantity)
    {
        double total = price * quantity;
        return total;
    }

    // DAY 2: METHOD OVERLOADING
    static int CalculateArea(int side)
    {
        return side * side;
    }

    static int CalculateArea(int length, int width)
    {
        return length * width;
    }

    // DAY 2: SUM EVEN NUMBERS IN A LIST
    static int SumEvenNumbers(List<int> numbers)
    {
        int sum = 0;

        foreach (int number in numbers)
        {
            if (number % 2 == 0)
                sum += number;
        }

        return sum;
    }

    // DAY 2: RETURN POSITIVE NUMBERS
    static List<int> GetPositiveNumbers(List<int> numbers)
    {
        List<int> positives = new();

        foreach (int number in numbers)
        {
            if (number > 0)
                positives.Add(number);
        }

        return positives;
    }

    // HELPER: PRINT LIST ITEMS
    static void PrintList(List<int> numbers)
    {
        foreach (int number in numbers)
            Console.WriteLine(number);
    }

    // DAY 2: COUNT VOWELS
    static int VowelCount(string word)
    {
        int count = 0;
        string vowels = "aeiou";

        foreach (char ch in word.ToLower())
        {
            if (vowels.Contains(ch))
                count++;
        }

        return count;
    }

    // DAY 2: FIND MAXIMUM IN A LIST
    static int FindMax(List<int> numbers)
    {
        if (numbers.Count == 0)
            throw new ArgumentException("List cannot be empty.");

        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
                max = number;
        }

        return max;
    }
}
