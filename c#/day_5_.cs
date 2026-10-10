// # Day 4 — Topic 1: LINQ in C\#

// Let's learn LINQ step by step using JavaScript → TypeScript → C#, with practical examples and one coding task at the end.

// ## 1. What is LINQ?

// LINQ (Language Integrated Query) is a C# feature that helps you query collections of data.

// Imagine you have 100 students and need to:

// - Find students who scored more than 80.
// - Sort students by marks.
// - Find the first student who passed.
// - Calculate the average marks.
// - Check whether any student failed.

// Without LINQ, you might write several loops. LINQ lets you express these operations concisely.

// ## 2. `Where()` — Filter elements

// JavaScript / TypeScript: `.filter()` · C#: `.Where()`

// JavaScript:

// ```
// const numbers = [10, 15, 20, 25, 30];

// const result = numbers.filter(n => n > 20);

// console.log(result); // [25, 30]
// ```

// TypeScript:

// ```
// const numbers: number[] = [10, 15, 20, 25, 30];

// const result = numbers.filter((n: number) => n > 20);

// console.log(result); // [25, 30]
// ```

// C#:

// ```
// using System;
// using System.Linq;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         List<int> numbers = new List<int> { 10, 15, 20, 25, 30 };

//         var result = numbers.Where(n => n > 20);

//         foreach (int number in result)
//         {
//             Console.WriteLine(number);
//         }
//     }
// }
// ```

// Output:

// ```
// 25
// 30
// ```

// ### Understand `n => n > 20`

// This is a lambda expression.

// - `n` represents each number.
// - `=>` separates the input from the expression.
// - `n > 20` is the condition.

// The condition returns `true` for 25 and 30, so those numbers are included.

// ## 3. `Select()` — Transform elements

// JavaScript / TypeScript: `.map()` · C#: `.Select()`

// Suppose you want to multiply every number by two.

// JavaScript:

// ```
// const numbers = [1, 2, 3, 4];

// const result = numbers.map(n => n * 2);

// console.log(result); // [2, 4, 6, 8]
// ```

// C#:

// ```
// List<int> numbers = new List<int> { 1, 2, 3, 4 };

// var result = numbers.Select(n => n * 2);

// foreach (int number in result)
// {
//     Console.WriteLine(number);
// }
// ```

// Output:

// ```
// 2
// 4
// 6
// 8
// ```

// Difference: `Where()` decides which elements to keep. `Select()` decides what each element becomes.

// ## 4. `OrderBy()` and `OrderByDescending()` — Sort elements

// JavaScript:

// ```
// const numbers = [40, 10, 30, 20];

// console.log([...numbers].sort((a, b) => a - b));
// // [10, 20, 30, 40]
// ```

// C#:

// ```
// List<int> numbers = new List<int> { 40, 10, 30, 20 };

// var ascending = numbers.OrderBy(n => n);
// var descending = numbers.OrderByDescending(n => n);

// Console.WriteLine(string.Join(", ", ascending));
// Console.WriteLine(string.Join(", ", descending));
// ```

// Output:

// ```
// 10, 20, 30, 40
// 40, 30, 20, 10
// ```

// - `OrderBy()` sorts ascending.
// - `OrderByDescending()` sorts descending.

// ## 5. `FirstOrDefault()` — Find the first matching element

// Suppose you need the first number greater than 20.

// ```
// List<int> numbers = new List<int> { 10, 15, 25, 30 };

// int result = numbers.FirstOrDefault(n => n > 20);

// Console.WriteLine(result); // 25
// ```

// If there is no match, `FirstOrDefault()` returns the type's default value. For `int`, that is `0`; for a reference type, it is typically `null`.

// JavaScript equivalent:

// ```
// const numbers = [10, 15, 25, 30];

// const result = numbers.find(n => n > 20);

// console.log(result); // 25
// ```

// Note that JavaScript `.find()` returns `undefined` when there is no match, unlike C#'s default value behavior.

// ## 6. `Any()` — Check whether at least one element matches

// ```
// List<int> numbers = new List<int> { 10, 15, 25, 30 };

// bool hasLargeNumber = numbers.Any(n => n > 20);

// Console.WriteLine(hasLargeNumber); // True
// ```

// JavaScript equivalent:

// ```
// const numbers = [10, 15, 25, 30];

// const hasLargeNumber = numbers.some(n => n > 20);

// console.log(hasLargeNumber); // true
// ```

// Use `Any()` when you only need a yes/no answer rather than the matching items.

// ## 7. `Count()`, `Sum()`, and `Average()`

// These methods calculate useful values from a collection.

// ```
// List<int> marks = new List<int> { 60, 75, 80, 95 };

// Console.WriteLine(marks.Count());   // 4
// Console.WriteLine(marks.Sum());     // 310
// Console.WriteLine(marks.Average()); // 77.5
// ```

// You can also count only matching elements:

// ```
// int passed = marks.Count(mark => mark >= 70);

// Console.WriteLine(passed); // 3
// ```

// JavaScript equivalents include `.length`, `.reduce()`, and `.filter().length`.

// Remember: `Count` is a property on a `List<T>` (`marks.Count`), but `Count()` is a LINQ method (`marks.Count()`). Both can give the total number of items, though the property is preferable for a list.

// ## 8. Combine LINQ methods

// Now let's apply multiple operations to a student collection.

// ```
// using System;
// using System.Linq;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         List<int> marks = new List<int> { 45, 90, 65, 85, 30, 95 };

//         var result = marks
//             .Where(mark => mark >= 60)
//             .OrderByDescending(mark => mark)
//             .Select(mark => $"Marks: {mark}");

//         foreach (string item in result)
//         {
//             Console.WriteLine(item);
//         }
//     }
// }
// ```

// Output:

// ```
// Marks: 95
// Marks: 90
// Marks: 85
// Marks: 65
// ```

// The operations run conceptually in this order:

// 1. `Where()` keeps marks greater than or equal to 60.
// 2. `OrderByDescending()` sorts the matching marks from highest to lowest.
// 3. `Select()` converts each mark into a formatted string.
// 4. `foreach` iterates through the results.

// One useful detail: LINQ methods such as `Where()` and `Select()` commonly use deferred execution, meaning the query is evaluated when you enumerate the results, rather than necessarily when you first declare the query.

// ## 9. Your practice task

// Build a Student Marks Analyzer in C#.

// Use this collection:

// ```
// List<int> marks = new List<int> { 45, 90, 65, 85, 30, 95, 70 };
// ```

// Your requirements:

// ### Task checklist

// 0 of 5

// Filter marks greater than or equal to 70 using Where().

// Sort those marks from highest to lowest using OrderByDescending().

// Find the first mark greater than 80 using FirstOrDefault().

// Check whether any mark is below 35 using Any().

// Calculate the average of all marks using Average().

// Try writing the complete program yourself. You can refer to the examples above, but try to write each LINQ expression from memory.

// Send me your code, and I'll review it, explain any errors, and score it out of 10.

