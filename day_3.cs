
// using System;

// class Product
// {
//     // Properties: data belonging to each product
//     public string Name { get; set; }
//     public double Price { get; set; }

//     // Instance method: works with this product's data
//     public void DisplayDetails()
//     {
//         Console.WriteLine($"Product: {Name}");
//         Console.WriteLine($"Price: ₹{Price}");
//     }

//     // Static method: can be called without creating a Product
//     public static double CalculateDiscount(double price)
//     {
//         return price * 0.10;
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         // Create two separate objects
//         Product laptop = new Product();
//         laptop.Name = "Laptop";
//         laptop.Price = 50000;

//         Product phone = new Product();
//         phone.Name = "Phone";
//         phone.Price = 20000;

//         // Call instance methods
//         laptop.DisplayDetails();
//         Console.WriteLine();

//         phone.DisplayDetails();
//         Console.WriteLine();

//         // Call a static method using the class name
//         double discount = Product.CalculateDiscount(laptop.Price);

//         Console.WriteLine($"Laptop discount: ₹{discount}");
//         Console.WriteLine($"Price after discount: ₹{laptop.Price - discount}");
//     }
// }


// class Product
// {
//     public string Name {get; set;} = "";
//     public int Price {get; set;} = 0;
//     public int Quantity {get; set;} = 0;
// }

// class Program
// {
//     static void Main()
//     {
//         Product p1 = new Product();
//         p1.Name = "p1";
//         p1.Price = 100;
//         p1.Quantity = 22;
//         Console.WriteLine(p1.Name);
//     }

// }





// Lesson 2: Constructors in C#
// using System;

// class Product
// {
//     public string Name { get; set; }
//     public double Price { get; set; }
//     public int Quantity { get; set; }

//     // Constructor
//     public Product(string name, double price, int quantity)
//     {
//         Name = name;
//         Price = price;
//         Quantity = quantity;
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Product p1 = new Product("Dell", 50000, 22);

//         Console.WriteLine(p1.Name);
//         Console.WriteLine(p1.Price);
//         Console.WriteLine(p1.Quantity);
//     }
// }





// using System;

// class Student
// {
//     public string Name { get; set; }
//     public int Age { get; set; }
//     public string Course { get; set; }

//     public Student(string name, int age, string course)
//     {
//         Name = name;
//         Age = age;
//         Course = course;
//     }
// }

// class Program
// {
//     static void Main()
//     {
//        Student s1 = new Student("pittu", 23, "c1");
//        Student s2 = new Student("pittu2", 24, "c2");

//        Console.WriteLine(s1.Name);
//        Console.WriteLine(s2.Name);
//     }
// }



// using System.Security.Cryptography;

// class Student
// {
//     public string Name {get; set;} = "";
//     public int Age {get; set;} = 1;
//     public double Marks {get; set;} = 0.0;

//     public Student(string name, int age, double marks)
//     {
//         Name = name;
//         Age = age;
//         Marks = marks;
//     }
//     public Student(string name, int age)
//     {
//         Name = name;
//         Age = age;
//         Marks = 0;
//     }

//     public void DisplayDetails()
// {
//     Console.WriteLine($"Name: {Name}");
//     Console.WriteLine($"Age: {Age}");
//     Console.WriteLine($"Marks: {Marks}");

//     if (Marks >= 35)
//     {
//         Console.WriteLine("Result: Pass");
//     }
//     else
//     {
//         Console.WriteLine("Result: Fail");
//     }

//     Console.WriteLine();
// }
// }

// class Program
// {
//     public static void Main()
//     {
//         Student s1 = new Student("s1", 23, 37.8);
//         Student s2 = new Student("s2", 24);

//         s1.DisplayDetails();
//         s2.DisplayDetails();
//     }
// }



// // inheritence

// class Product
// {
//     public string Name { get; set; } = "";
//     public double Price { get; set; }

//     public void DisplayDetails()
//     {
//         Console.WriteLine($"Name: {Name}");
//         Console.WriteLine($"Price: ₹{Price}");
//     }
// }

// class Laptop : Product
// {
//     public string Brand { get; set; } = "";
// }



// class Employee
// {
//     public string Name {get; set;} = "";
//     public double Salary {get; set;} = 0.0;

//     public virtual void DisplayEmployee()
//     {
//         Console.WriteLine($"Name: {Name}");
// Console.WriteLine($"Salary: {Salary}");
//     }
// }

// class Developer: Employee
// {
//     public string ProgrammingLanguage {get; set;} = "";

//     public override void DisplayEmployee()
//     {
//         Console.WriteLine("overrided");
//     }

// }



// class Program
// {
//     public static void Main()
//     {
//         Developer s1 = new Developer();
//         s1.ProgrammingLanguage = "c#";
//         s1.Name = "pittu";
//         s1.Salary = 222.44;



       
//         s1.DisplayEmployee();
//     }
// }




