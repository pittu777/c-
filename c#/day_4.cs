// polymorphism

// class Employee {
//   work() {
//     console.log("Employee is doing general work");
//   }
// }

// class Developer extends Employee {
//   work() {
//     console.log("Developer is writing code");
//   }
// }

// class Designer extends Employee {
//   work() {
//     console.log("Designer is designing UI");
//   }
// }

// const employees = [
//   new Employee(),
//   new Developer(),
//   new Designer()
// ];

// for (const employee of employees) {
//   employee.work();
// } in js

// in c#


// class Employee {
//   work() {
//     console.log("Employee is doing general work");
//   }
// }

// class Developer extends Employee {
//   work() {
//     console.log("Developer is writing code");
//   }
// }

// class Designer extends Employee {
//   work() {
//     console.log("Designer is designing UI");
//   }
// }

// const employees = [
//   new Employee(),
//   new Developer(),
//   new Designer()
// ];

// for (const employee of employees) {
//   employee.work();
// }

// class Employee
// {
//     public virtual void Work()
//     {
//         Console.WriteLine("Employee is doing general work");
//     }
// }

// class Dev: Employee
// {
//     public override void Work()
//     {
//         Console.WriteLine("dev");
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Employee [] employees =
//         {
//             new Employee(),
//             new Dev(),
//         };
//         foreach(Employee employee in employees)
//         {
//             employee.Work();
//         }
//     }
// }

// polymorphism in c# writinng same method with different behaviour 


// class Payment {
//   constructor() {
//     if (new.target === Payment) {
//       throw new Error("Cannot instantiate Payment directly");
//     }
//   }

//   processPayment() {
//     throw new Error("Subclass must implement processPayment()");
//   }
// }

// class UpiPayment extends Payment {
//   processPayment() {
//     console.log("Processing UPI payment");
//   }
// }

// class CardPayment extends Payment {
//   processPayment() {
//     console.log("Processing card payment");
//   }
// }

// const p1 = new UpiPayment();
// const p2 = new CardPayment();

// p1.processPayment();
// p2.processPayment();



// abstract class means every concrete shape must implement 
// this method 

// abstract class Shape
// {
//     public abstract double CalcArea();
// }

// class Rect : Shape
// {
//     public int w {get;set;}
//     public int h {get;set;}
//     public override double CalcArea()
//     {
//         return w*h;
//     }
// }


// interface 

// in ts 

// interface INotification {
//   send(message: string): void;
// }

// class EmailNotification implements INotification {
//   send(message: string): void {
//     console.log(`Email sent: ${message}`);
//   }
// }


// interface INotification
// {
//     void Send(string message);
// }

// class EmailNotification : INotification
// {
//     public void Send(string message)
//     {
//         Console.WriteLine($"{message}");
//     }
// }
// class SmsNotification : INotification
// {
//     public void Send(string message)
//     {
//         Console.WriteLine($"SMS sent: {message}");
//     }
// }

// class Program
// {
//     static void NotifyUser(INotification notification)
//     {
//         notification.Send("sending..");
//     }
//     static void Main()
//     {
//         EmailNotification e = new EmailNotification();
//         SmsNotification s = new SmsNotification();
//         NotifyUser(e);
//         NotifyUser(s);

//     }
// }


// using System;

// class Program
// {
//     static void Withdraw(double balance, double amount)
//     {
//         try
//         {
//             if (amount <= 0)
//             {
//                 throw new Exception("Amount must be greater than zero");
//             }

//             if (amount > balance)
//             {
//                 throw new Exception("Insufficient balance");
//             }

//             double remainingBalance = balance - amount;

//             Console.WriteLine($"Withdrawal successful!");
//             Console.WriteLine($"Remaining balance: {remainingBalance}");
//         }
//         catch (Exception error)
//         {
//             Console.WriteLine($"Withdrawal failed: {error.Message}");
//         }
//         finally
//         {
//             Console.WriteLine("Withdrawal process completed.");
//         }
//     }

//     static void Main()
//     {
//         Withdraw(1000, 200);

//         Console.WriteLine();

//         Withdraw(1000, 1500);

//         Console.WriteLine();

//         Withdraw(1000, -50);
//     }
// } try,catch,finally


// # Day 3 — C# Collections: List, Dictionary, and HashSet

// Let's learn the next topic using JavaScript → TypeScript → C#, with examples and then one practice task.

// Collections let you store and manage multiple values. You'll use them constantly when building ASP.NET Core APIs and working with databases.

// ## 1. `List<T>` — Like a JavaScript array

// A `List<T>` stores multiple items of the same type and can grow or shrink dynamically.

// JavaScript

// `const nums = [10, 20, 30]`

// TypeScript

// `const nums: number[] = [10, 20, 30]`

// C#

// ```
// List<int> nums = new List<int> { 10, 20, 30 };
// ```

// C# needs this namespace:

// ```
// using System.Collections.Generic;
// ```

// ### Common operations

// ```
// List<int> numbers = new List<int> { 10, 20, 30 };

// // Add an item
// numbers.Add(40);

// // Remove an item
// numbers.Remove(20);

// // Access by index
// Console.WriteLine(numbers[0]); // 10

// // Loop through items
// foreach (int number in numbers)
// {
//     Console.WriteLine(number);
// }

// // Number of items
// Console.WriteLine(numbers.Count);
// ```

// Remember: JavaScript arrays use `.length`, whereas C# lists use `.Count`.

// ## 2. `Dictionary<TKey, TValue>` — Like a JavaScript object or Map

// A dictionary stores key-value pairs. It is useful when you need to look up a value by a key.

// Example: storing student marks by student name.

// Conceptual example

// "Ravi"

// 85

// "Priya"

// 92

// ### JavaScript

// ```
// const marks = {
//   Ravi: 85,
//   Priya: 92
// };

// console.log(marks["Ravi"]); // 85
// ```

// ### TypeScript

// ```
// const marks: Record<string, number> = {
//   Ravi: 85,
//   Priya: 92
// };

// console.log(marks["Ravi"]); // 85
// ```

// ### C\#

// ```
// Dictionary<string, int> marks = new Dictionary<string, int>
// {
//     { "Ravi", 85 },
//     { "Priya", 92 }
// };

// Console.WriteLine(marks["Ravi"]); // 85

// marks["Ravi"] = 90; // Update a value

// marks.Add("Arun", 78); // Add a new key-value pair

// if (marks.ContainsKey("Priya"))
// {
//     Console.WriteLine(marks["Priya"]);
// }
// ```

// Important: Dictionary keys must be unique. Accessing a missing key with `marks["Unknown"]` throws an exception. Use `TryGetValue()` when the key might not exist.

// ```
// if (marks.TryGetValue("Ravi", out int score))
// {
//     Console.WriteLine(score);
// }
// ```

// ## 3. `HashSet<T>` — Like a JavaScript `Set`

// A `HashSet<T>` stores unique values. Duplicate values are not added.

// ### JavaScript

// ```
// const numbers = new Set([10, 20, 20, 30]);

// console.log(numbers); // Set(3) { 10, 20, 30 }

// numbers.add(40);
// numbers.has(20); // true
// numbers.delete(10);
// ```

// ### TypeScript

// ```
// const numbers = new Set<number>([10, 20, 20, 30]);

// numbers.add(40);
// console.log(numbers.has(20)); // true
// ```

// ### C\#

// ```
// HashSet<int> numbers = new HashSet<int> { 10, 20, 20, 30 };

// numbers.Add(40);

// Console.WriteLine(numbers.Contains(20)); // True

// numbers.Remove(10);

// Console.WriteLine(numbers.Count); // 3
// ```

// A `HashSet<T>` is useful when removing duplicates or checking whether an item exists. It does not guarantee a particular iteration order.

// ## 4. Quick comparison

// | Purpose                     | JavaScript               | TypeScript                 | C#                       |
// | --------------------------- | ------------------------ | -------------------------- | ------------------------ |
// | Ordered collection of items | `Array`                  | `number[]`                 | `List<int>`              |
// | Key-value lookup            | `Object` / `Map`         | `Record<K,V>` / `Map<K,V>` | `Dictionary<K,V>`        |
// | Unique values               | `Set`                    | `Set<T>`                   | `HashSet<T>`             |
// | Number of items             | `.length`                | `.length` for arrays       | `.Count` for collections |
// | Check whether item exists   | `.includes()` / `.has()` | `.includes()` / `.has()`   | `.Contains()`            |

// C# collections are generic: `List<int>` stores integers, `List<string>` stores strings, and `Dictionary<string, int>` maps strings to integers. This provides compile-time type checking.

// ## 5. Practice task — Student Marks Manager

// Now try using all three concepts.

// Requirements:

// 1. Create a `List<string>` containing three student names.
// 2. Create a `Dictionary<string, int>` that stores each student's marks.
// 3. Create a `HashSet<string>` containing student names, including one duplicate.
// 4. Add a fourth student to the list.
// 5. Update one student's marks.
// 6. Print every student's name and marks using `foreach`.
// 7. Print the total number of students and the number of unique names.

// Starter code:

// ```
// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         // 1. Create a List<string>

//         // 2. Create a Dictionary<string, int>

//         // 3. Create a HashSet<string>

//         // 4. Add a student

//         // 5. Update marks

//         // 6. Print names and marks

//         // 7. Print counts
//     }
// }
// ```

// Try it yourself first. Send your code here, and I'll review it, explain any mistakes, and score it out of 10.