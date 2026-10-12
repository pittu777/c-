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












// # Day 4 — Topic 2: Nullable Types and Null Handling

// Let's continue with JavaScript → TypeScript → C#.

// This topic is important because real-world APIs and databases often contain missing values. For example, a user might not have a phone number, or a product might not have a discount.

// ## 1. What is `null`?

// `null` means a value is intentionally absent.

// JavaScript:

// ```
// let username = null;

// console.log(username); // null
// ```

// TypeScript:

// ```
// let username: string | null = null;

// username = "Prasanth"; // Allowed
// ```

// C#:

// ```
// string? username = null;

// username = "Prasanth"; // Allowed
// ```

// In C#, `string?` indicates that the string may be `null` when nullable reference types are enabled.

// ## 2. Nullable value types: `int?` and `double?`

// In C#, ordinary value types such as `int` and `double` cannot hold `null`.

// ```
// int age = null; // Compile-time error
// ```

// Use `int?` instead:

// ```
// int? age = null;

// Console.WriteLine(age); // Prints nothing

// age = 25;

// Console.WriteLine(age); // 25
// ```

// The `?` makes a value type nullable.

// | Type      | Can hold `null`? |
// | --------- | ---------------- |
// | `int`     | No               |
// | `int?`    | Yes              |
// | `double`  | No               |
// | `double?` | Yes              |
// | `bool`    | No               |
// | `bool?`   | Yes              |

// TypeScript equivalent:

// ```
// let age: number | null = null;
// ```

// JavaScript doesn't enforce these types.

// ## 3. Null-coalescing operator: `??`

// Use `??` to provide a fallback value when the left side is `null`.

// C#:

// ```
// string? username = null;

// string displayName = username ?? "Guest";

// Console.WriteLine(displayName); // Guest
// ```

// TypeScript:

// ```
// const username: string | null = null;

// const displayName = username ?? "Guest";

// console.log(displayName); // Guest
// ```

// JavaScript uses the same operator.

// Important: `??` only uses the fallback for `null` or `undefined` in JavaScript/TypeScript. In C#, it uses the fallback when the left operand is `null`.

// For example:

// ```
// int? age = null;

// int actualAge = age ?? 18;

// Console.WriteLine(actualAge); // 18
// ```

// ## 4. Null-conditional operator: `?.`

// Use `?.` to access a member only when the object isn't `null`.

// C#:

// ```
// string? username = null;

// int? length = username?.Length;

// Console.WriteLine(length); // Nothing
// ```

// If `username` is `null`, `username?.Length` evaluates to `null` instead of throwing a `NullReferenceException`.

// TypeScript:

// ```
// const username: string | null = null;

// const length = username?.length;

// console.log(length); // undefined
// ```

// Notice the difference: C# produces a nullable result (`null`), while TypeScript produces `undefined` for this example.

// ## 5. Null checks with `if`

// Sometimes you need to perform an operation only if a value exists.

// C#:

// ```
// string? email = null;

// if (email != null)
// {
//     Console.WriteLine(email.ToUpper());
// }
// else
// {
//     Console.WriteLine("Email is missing");
// }
// ```

// Output:

// ```
// Email is missing
// ```

// TypeScript:

// ```
// const email: string | null = null;

// if (email !== null) {
//   console.log(email.toUpperCase());
// } else {
//   console.log("Email is missing");
// }
// ```

// Both languages can narrow the type after a suitable null check.

// ## 6. Real-world example: user profile

// ```
// using System;

// class User
// {
//     public string Name { get; set; } = "";
//     public string? PhoneNumber { get; set; }
// }

// class Program
// {
//     static void Main()
//     {
//         User user = new User();

//         user.Name = "Prasanth";
//         user.PhoneNumber = null;

//         string phone = user.PhoneNumber ?? "No phone number";

//         Console.WriteLine($"Name: {user.Name}");
//         Console.WriteLine($"Phone: {phone}");
//     }
// }
// ```

// Output:

// ```
// Name: Prasanth
// Phone: No phone number
// ```

// This is useful when working with optional fields in database records or API responses.

// ## 7. Your practice task

// Create a C# product class with these requirements:

// 1. `Name` is a non-nullable string.
// 2. `Discount` is a nullable `double?`.
// 3. If the discount is `null`, use `0` as the default with `??`.
// 4. Print the product name and final discount.
// 5. Use `?.` to safely access a nullable string and print its length.

// Starter code:

// ```
// using System;

// class Program
// {
//     static void Main()
//     {
//         // Create a product name
//         // Create a nullable discount
//         // Use ?? to provide a default discount
//         // Print the values
//         // Use ?. to safely access a nullable string
//     }
// }
// ```

// Try writing the code yourself and send it here. I'll review it and score it out of 10.




// lambda

// Func<int, int, int> add = (a,b) => a+b;

// Console.WriteLine(add(10,20));

// Action<string> greet = name =>
// {
//     Console.WriteLine($"Hello, {name}");
// };

// greet("pittu");


// static int Add(int a, int b)
// {
//     return a+b;
// }

// Func<int,int,int> op = Add;

// Console.WriteLine(op(22,1));






// # Day 4 — Topic 3: Lambda Expressions and Delegates

// Today we'll learn how C# represents functions as values and passes behavior between methods. This is especially useful in LINQ, ASP.NET Core, and event handling.

// We'll compare JavaScript → TypeScript → C#.

// ## 1. Lambda expressions

// A lambda is a short way to write a function.

// ### JavaScript

// ```
// const square = n => n * n;

// console.log(square(5)); // 25
// ```

// ### TypeScript

// ```
// const square = (n: number): number => n * n;

// console.log(square(5)); // 25
// ```

// ### C\#

// ```
// Func<int, int> square = n => n * n;

// Console.WriteLine(square(5)); // 25
// ```

// Understand this C# declaration:

// ```
// Func<int, int> square = n => n * n;
// ```

// - `Func<int, int>` represents a function that accepts an `int` and returns an `int`.
// - The first `int` is the input type.
// - The second `int` is the return type.
// - `n => n * n` is the lambda expression.

// Think of `Func<int, int>` as similar to a typed JavaScript or TypeScript function reference.

// ## 2. `Func` — A function that returns a value

// Use `Func` when you want to store or pass a function that returns a result.

// ```
// Func<int, int, int> add = (a, b) => a + b;

// Console.WriteLine(add(10, 20)); // 30
// ```

// Here, `Func<int, int, int>` means:

// - Input 1: `int`
// - Input 2: `int`
// - Return: `int`

// TypeScript equivalent:

// ```
// const add = (a: number, b: number): number => a + b;

// console.log(add(10, 20)); // 30
// ```

// ## 3. `Action` — A function that returns nothing

// Use `Action` when the function performs an operation but doesn't return a value.

// ### C\#

// ```
// Action<string> greet = name =>
// {
//     Console.WriteLine($"Hello, {name}!");
// };

// greet("Prasanth");
// ```

// Output:

// ```
// Hello, Prasanth!
// ```

// TypeScript equivalent:

// ```
// const greet = (name: string): void => {
//   console.log(`Hello, ${name}!`);
// };

// greet("Prasanth");
// ```

// The difference:

// | C# type            | Purpose                            | Example                            |
// | ------------------ | ---------------------------------- | ---------------------------------- |
// | `Func<T, TResult>` | Accepts input and returns a value  | Calculate a total                  |
// | `Action<T>`        | Accepts input and returns nothing  | Print a message                    |
// | `Predicate<T>`     | Accepts a value and returns `bool` | Check whether a number is positive |

// ## 4. Delegates — Store and pass methods

// A delegate is a type-safe reference to a method. It defines the method signature that can be assigned to it.

// ```
// using System;

// class Program
// {
//     static int Add(int a, int b)
//     {
//         return a + b;
//     }

//     static void Main()
//     {
//         Func<int, int, int> operation = Add;

//         int result = operation(10, 20);

//         Console.WriteLine(result); // 30
//     }
// }
// ```

// Here, `operation` references the `Add` method. Calling `operation(10, 20)` invokes that method.

// In modern C#, `Func` and `Action` are commonly used delegate types, so you often don't need to declare a custom delegate.

// ## 5. Use lambdas with LINQ

// This connects today's topic to the LINQ lesson.

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

// In `n => n > 20`, the lambda supplies the condition that `Where()` uses to decide which values to keep.

// JavaScript equivalent:

// ```
// const numbers = [10, 15, 20, 25, 30];

// const result = numbers.filter(n => n > 20);

// console.log(result); // [25, 30]
// ```

// ## 6. Your practice task

// Create a C# program with these requirements:

// 1. Use `Func<int, int, int>` to add two numbers.
// 2. Use `Func<int, int, int>` to multiply two numbers.
// 3. Use `Action<string>` to print a message.
// 4. Use a lambda with `Where()` to filter numbers greater than 50 from a list.

// Expected output:

// ```
// Addition: 30
// Multiplication: 200
// Hello from C#
// 60
// 80
// 100
// ```

// Try writing the code yourself. Send it here, and I'll review it and score it out of 10.





// // async and wait 

// class Program
// {
//     static async Task<string> GetDataAsync()
//     {
//         await Task.Delay(2000);
//         return "Data received";
//     }
//     static async Task<string> GetMessageAsync()
//     {
//         await Task.Delay(2000);
//         return "Data";
//     }

//     static async Task Main()
//     {
//         Console.WriteLine("async started");
//         string res = await GetMessageAsync();
//         Console.WriteLine(res);
//     }
// }




// # Day 4 — Topic 4: `async` / `await` in C\#

// This is one of the most important topics for your goal of becoming a React + ASP.NET Core full-stack developer. You'll use asynchronous programming when calling APIs, querying databases, and reading files.

// We'll compare JavaScript → TypeScript → C#.

// ## 1. What is asynchronous programming?

// Imagine your application requests data from a server. The response takes two seconds.

// You don't want your application to block a thread unnecessarily while waiting for that response. Asynchronous programming lets the application wait for the operation to complete while allowing other work to proceed.

// In JavaScript, you already know `async` and `await`.

// ### JavaScript

// ```
// async function getData() {
//   console.log("Started");

//   await new Promise(resolve => setTimeout(resolve, 2000));

//   console.log("Data received");
// }

// getData();
// console.log("Other work");
// ```

// Output:

// ```
// Started
// Other work
// Data received
// ```

// The code after `getData()` continues while the asynchronous function is waiting.

// ## 2. TypeScript equivalent

// TypeScript adds types to the same model.

// ```
// async function getData(): Promise<string> {
//   await new Promise(resolve => setTimeout(resolve, 2000));

//   return "Data received";
// }

// async function main(): Promise<void> {
//   const result = await getData();
//   console.log(result);
// }

// main();
// ```

// Remember:

// - JavaScript async functions return promises.
// - TypeScript expresses the return type using `Promise<T>`.
// - `await` waits for the promise to settle and gives you its result.

// ## 3. C# equivalent

// C# uses `Task` and `Task<T>` for asynchronous operations.

// ```
// using System;
// using System.Threading.Tasks;

// class Program
// {
//     static async Task<string> GetDataAsync()
//     {
//         await Task.Delay(2000);

//         return "Data received";
//     }

//     static async Task Main()
//     {
//         Console.WriteLine("Started");

//         string result = await GetDataAsync();

//         Console.WriteLine(result);
//     }
// }
// ```

// Output after approximately two seconds:

// ```
// Started
// Data received
// ```

// `Task.Delay(2000)` asynchronously waits for approximately two seconds without blocking the current thread for the duration.

// ## 4. Understand `Task` vs. `Task<T>`

// | C#             | Similar TypeScript concept | Meaning                                          |
// | -------------- | -------------------------- | ------------------------------------------------ |
// | `Task`         | `Promise<void>`            | Async operation with no returned value           |
// | `Task<string>` | `Promise<string>`          | Async operation returning a string               |
// | `Task<int>`    | `Promise<number>`          | Async operation returning an integer             |
// | `await`        | `await`                    | Wait for the result of an asynchronous operation |

// Example:

// ```
// static async Task SaveDataAsync()
// {
//     await Task.Delay(1000);
//     Console.WriteLine("Data saved");
// }
// ```

// This returns a `Task`, not a string or integer.

// ```
// static async Task<int> GetNumberAsync()
// {
//     await Task.Delay(1000);
//     return 100;
// }
// ```

// This returns a `Task<int>`. When awaited, the result is `100`.

// ## 5. A real-world ASP.NET Core example

// Suppose your API needs to retrieve a user from a database.

// ```
// public async Task<string> GetUserNameAsync()
// {
//     string userName = await _dbContext.Users
//         .Select(user => user.Name)
//         .FirstAsync();

//     return userName;
// }
// ```

// This is an illustrative Entity Framework Core query; `_dbContext` must be configured and the database operation can fail. In a real application, you'd typically handle the case where no user exists, for example with `FirstOrDefaultAsync()`.

// The key benefit is that asynchronous database I/O doesn't need to tie up an ASP.NET Core request thread while waiting for the database response.

// Important: `async` alone does not make CPU-heavy code run faster. `await` is most useful for operations that spend time waiting, such as network, database, and file I/O.

// ## 6. Your practice task

// Create a console application with these requirements:

// 1. Create `GetMessageAsync()` that returns `Task<string>`.
// 2. Use `await Task.Delay(2000)` inside it.
// 3. Return `"Hello from async C#"`.
// 4. In `Main()`, await the method and print the returned message.
// 5. Print `"Program started"` before awaiting and `"Program completed"` after awaiting.

// Expected output:

// ```
// Program started
// Hello from async C#
// Program completed
// ```



// 
// Try the code yourself first. Send it here, and I'll review it and score it out of 10.






// file read and writing 

// using System;
// using System.IO;

// class Program
// {
//     static void Main()
//     {
//         File.WriteAllText("notes.txt", "learn c#");
//         string c = File.ReadAllText("notes.txt");
//         Console.WriteLine(c);
//     }
// }




// # Day 4 — Topic 5: File Handling and JSON in C\#

// You've covered LINQ, nullable types, lambda expressions, delegates, and `async`/`await`. Next, let's learn how to read files, write files, and work with JSON.

// These skills are useful when building .NET applications that save settings, import data, generate reports, or exchange data with APIs.

// We'll compare JavaScript, TypeScript, and C#.

// ## 1. Reading and writing text files

// Imagine your application needs to save a user's notes in a file.

// ### JavaScript (Node.js)

// ```
// const fs = require("fs");

// fs.writeFileSync("notes.txt", "Learning C# and .NET");

// const content = fs.readFileSync("notes.txt", "utf8");

// console.log(content);
// ```

// ### TypeScript (Node.js)

// ```
// import { writeFileSync, readFileSync } from "node:fs";

// writeFileSync("notes.txt", "Learning C# and .NET");

// const content: string = readFileSync("notes.txt", "utf8");

// console.log(content);
// ```

// ### C\#

// ```
// using System;
// using System.IO;

// class Program
// {
//     static void Main()
//     {
//         File.WriteAllText("notes.txt", "Learning C# and .NET");

//         string content = File.ReadAllText("notes.txt");

//         Console.WriteLine(content);
//     }
// }
// ```

// Output:

// ```
// Learning C# and .NET
// ```

// - `File.WriteAllText()` creates or overwrites a file.
// - `File.ReadAllText()` reads the entire file as a string.
// - `System.IO` provides file and directory operations.

// Be careful: `WriteAllText()` overwrites existing file contents. Use `File.AppendAllText()` when you want to add text to the end.

// ## 2. Asynchronous file handling

// For larger files or server applications, asynchronous file operations can be useful.

// ```
// using System;
// using System.IO;
// using System.Threading.Tasks;

// class Program
// {
//     static async Task Main()
//     {
//         await File.WriteAllTextAsync(
//             "notes.txt",
//             "Learning ASP.NET Core"
//         );

//         string content = await File.ReadAllTextAsync("notes.txt");

//         Console.WriteLine(content);
//     }
// }
// ```

// Here, `WriteAllTextAsync()` and `ReadAllTextAsync()` return tasks that you can await.

// ## 3. What is JSON?

// JSON stands for JavaScript Object Notation. It's a common format for sending structured data between a frontend and backend.

// For example, your React frontend might send this data to an ASP.NET Core API:

// ```
// {
//   "name": "Prasanth",
//   "age": 22,
//   "isDeveloper": true
// }
// ```

// JavaScript and TypeScript can work with JSON using `JSON.stringify()` and `JSON.parse()`.

// C# commonly uses `System.Text.Json`.

// ## 4. Convert a C# object to JSON

// This is called serialization.

// ```
// using System;
// using System.Text.Json;

// class Student
// {
//     public string Name { get; set; } = "";
//     public int Age { get; set; }
// }

// class Program
// {
//     static void Main()
//     {
//         Student student = new Student
//         {
//             Name = "Prasanth",
//             Age = 22
//         };

//         string json = JsonSerializer.Serialize(student);

//         Console.WriteLine(json);
//     }
// }
// ```

// Output:

// ```
// {"Name":"Prasanth","Age":22}
// ```

// To make the JSON easier to read, you can use formatting options:

// ```
// string json = JsonSerializer.Serialize(
//     student,
//     new JsonSerializerOptions { WriteIndented = true }
// );
// ```

// ## 5. Convert JSON back into a C# object

// This is called deserialization.

// ```
// using System;
// using System.Text.Json;

// class Student
// {
//     public string Name { get; set; } = "";
//     public int Age { get; set; }
// }

// class Program
// {
//     static void Main()
//     {
//         string json = """
//         {
//             "Name": "Prasanth",
//             "Age": 22
//         }
//         """;

//         Student? student = JsonSerializer.Deserialize<Student>(json);

//         if (student != null)
//         {
//             Console.WriteLine(student.Name);
//             Console.WriteLine(student.Age);
//         }
//     }
// }
// ```

// Output:

// ```
// Prasanth
// 22
// ```

// The null check matters because deserialization can return `null`. Invalid JSON can also cause a `JsonException`, so production code should handle malformed input appropriately.

// ## 6. JavaScript / TypeScript vs. C\#

// | Operation        | JavaScript / TypeScript   | C#                                    |
// | ---------------- | ------------------------- | ------------------------------------- |
// | Serialize object | `JSON.stringify(obj)`     | `JsonSerializer.Serialize(obj)`       |
// | Deserialize JSON | `JSON.parse(json)`        | `JsonSerializer.Deserialize<T>(json)` |
// | Write text file  | Node.js `writeFileSync()` | `File.WriteAllText()`                 |
// | Read text file   | Node.js `readFileSync()`  | `File.ReadAllText()`                  |
// | Async file read  | Node.js `fs/promises`     | `File.ReadAllTextAsync()`             |

// One key difference: `JSON.parse()` produces a JavaScript value, while `JsonSerializer.Deserialize<T>()` attempts to produce an object of the specified C# type.

// ## 7. Your practice task

// Build a small Student Data Saver.

// Requirements:

// 1. Create a `Student` class with `Name`, `Age`, and `Course` properties.
// 2. Create a student object.
// 3. Serialize the object into JSON.
// 4. Save the JSON into `student.json`.
// 5. Read the JSON from the file.
// 6. Deserialize it back into a `Student` object.
// 7. Print the student's name, age, and course.

// Use `File.WriteAllText()`, `File.ReadAllText()`, and `JsonSerializer`.

// After this topic, your next major milestone is ASP.NET Core Web API — where you'll apply classes, interfaces, dependency injection, async programming, and JSON together to build real backend endpoints.




