// 01 — JAVASCRIPT FUNDAMENTALS
// Run: node 01-fundamentals.js

// Types and equality
console.log(typeof null); // "object" (historical quirk)
console.log(Array.isArray([])); // true
console.log(5 === "5"); // false
console.log(5 == "5"); // true, coercion

// Scope and closure
function makeCounter() {
  let count = 0;
  return () => ++count;
}
const counter = makeCounter();
console.log(counter()); // 1
console.log(counter()); // 2

// Hoisting
console.log(declaration()); // works
function declaration() { return "function declaration"; }
// console.log(value); // ReferenceError (TDZ)
// let value = 1;

// `this`
const user = {
  name: "Pittu",
  regular:function() { return this.name; },
  arrow: () => this?.name
};
console.log(user.regular()); // "Pittu"
// Arrow `this` is lexical, not the `user` object.

// Call, apply, bind
function introduce(city) { return `${this.name} from ${city}`; }
const person = { name: "Pittu" };
console.log(introduce.call(person, "Hyderabad"));
console.log(introduce.apply(person, ["Hyderabad"]));
const bound = introduce.bind(person, "Hyderabad");
console.log(bound());

// Shallow vs deep copy
const original = { nested: { value: 1 } };
const shallow = { ...original };
shallow.nested.value = 2;
console.log(original.nested.value); // 2
const deep = structuredClone(original);
deep.nested.value = 3;
console.log(original.nested.value); // 2

// Prototype and class
class User {
  constructor(name) { this.name = name; }
  greet() { return `Hello ${this.name}`; }
}
class Admin extends User {
  greet() { return `${super.greet()}, admin`; }
}
console.log(new Admin("Pittu").greet());








// # 01 — JavaScript Fundamentals

// Run the file using:

// ```bash
// node 01-fundamentals.js
// ```

// ## 1. Types and Equality

// ```javascript
// // typeof tells us the type of a value.
// console.log(typeof null); // "object"

// // Explanation:
// // This is a historical bug in JavaScript.
// // null represents the intentional absence of a value,
// // but typeof null returns "object".

// // Array.isArray() checks whether a value is an array.
// console.log(Array.isArray([])); // true

// // Strict equality (===) checks value and type.
// console.log(5 === "5"); // false

// // Loose equality (==) performs type coercion when needed.
// console.log(5 == "5"); // true

// // Interview tip:
// // Prefer === because it avoids unexpected type conversions.
// ```

// **Remember:**
// - `typeof` checks the type of a value.
// - `Array.isArray()` identifies arrays reliably.
// - `===` compares without type coercion.
// - `==` may convert types before comparing.

// ## 2. Scope and Closures

// ```javascript
// function makeCounter() {
//   let count = 0;

//   // This function remembers the variable count,
//   // even after makeCounter() has finished executing.
//   return () => ++count;
// }

// const counter = makeCounter();

// console.log(counter()); // 1
// console.log(counter()); // 2
// console.log(counter()); // 3
// ```

// **Explanation:**

// 1. `makeCounter()` creates a local variable called `count`.
// 2. It returns an arrow function that uses `count`.
// 3. The outer function finishes, but the returned function still has access to `count`.
// 4. Every call increments the same variable.

// This behavior is called a **closure**.

// **Interview definition:** A closure is a function that retains access to variables from its lexical scope, even after the outer function has finished executing.

// **Common use cases:** Private state, callbacks, function factories, and memoization.

// ## 3. Hoisting and the Temporal Dead Zone (TDZ)

// ```javascript
// // Function declarations can be called before they appear.
// console.log(declaration()); // "function declaration"

// function declaration() {
//   return "function declaration";
// }

// // let and const cannot be accessed before initialization.

// // console.log(value); // ReferenceError
// let value = 10;

// console.log(value); // 10
// ```

// **Explanation:**

// JavaScript processes declarations before executing the code in their scope. This behavior is commonly called *hoisting*.

// - **Function declarations:** You can generally call them before their declaration.
// - **`var`:** The declaration is hoisted and initialized to `undefined`.
// - **`let` and `const`:** They are hoisted, but accessing them before initialization causes a `ReferenceError`.

// The period before a `let` or `const` declaration is initialized is called the **Temporal Dead Zone (TDZ)**.

// **Interview tip:** Hoisting does not mean every variable can safely be used before its declaration.

// ## 4. The `this` Keyword

// ```javascript
// const user = {
//   name: "Pittu",

//   regular: function () {
//     return this.name;
//   },

//   arrow: () => this?.name
// };

// console.log(user.regular()); // "Pittu"
// console.log(user.arrow());   // Usually undefined in a Node.js file
// ```

// **Explanation:**

// ### Regular function

// When you call `user.regular()`, the function is called as a method of `user`. Therefore, `this` refers to the `user` object.

// So `this.name` returns `"Pittu"`.

// ### Arrow function

// Arrow functions do not create their own `this`. They capture `this` from the surrounding lexical scope.

// Therefore, `user.arrow()` does not automatically use `user` as `this`.

// The exact result of the arrow function depends on the surrounding environment. In a typical Node.js CommonJS file, the top-level `this` is `module.exports`, which has no `name` property, so the result is `undefined`.

// **Interview definition:** In a regular function, `this` depends on how the function is called. In an arrow function, `this` is inherited from the surrounding scope.

// ## 5. `call()`, `apply()`, and `bind()`

// ```javascript
// function introduce(city) {
//   return `${this.name} from ${city}`;
// }

// const person = { name: "Pittu" };

// // call(): invoke immediately; pass arguments individually.
// console.log(introduce.call(person, "Hyderabad"));
// // "Pittu from Hyderabad"

// // apply(): invoke immediately; pass arguments as an array.
// console.log(introduce.apply(person, ["Hyderabad"]));
// // "Pittu from Hyderabad"

// // bind(): return a new function with a fixed this value.
// const bound = introduce.bind(person, "Hyderabad");

// console.log(bound());
// // "Pittu from Hyderabad"
// ```

// **Explanation:**

// All three methods let you specify the `this` value for a regular function.

// | Method | What it does | Arguments |
// |---|---|---|
// | `call()` | Calls the function immediately | Individual arguments |
// | `apply()` | Calls the function immediately | Arguments in an array |
// | `bind()` | Returns a new function | Can pre-fill arguments |

// **Memory trick:**
// - `call` = call now.
// - `apply` = call now with an array.
// - `bind` = create a function for later.

// **Common use case:** Reusing a function with a different object as its `this` value.

// ## 6. Shallow Copy vs Deep Copy

// ```javascript
// const original = {
//   nested: {
//     value: 1
//   }
// };

// // Spread syntax creates a shallow copy.
// const shallow = { ...original };

// shallow.nested.value = 2;

// console.log(original.nested.value); // 2

// // structuredClone() creates a deep copy
// // for supported structured-cloneable values.
// const deep = structuredClone(original);

// deep.nested.value = 3;

// console.log(deep.nested.value);    // 3
// console.log(original.nested.value); // 2
// ```

// **Explanation:**

// ### Shallow copy

// `{ ...original }` creates a new outer object, but nested objects are still shared references.

// When `shallow.nested.value` changes, `original.nested.value` also changes.

// ### Deep copy

// `structuredClone(original)` creates an independent copy of supported nested data.

// Changing the nested object in `deep` does not change the original.

// **Interview tip:** Spread syntax is shallow, not deep. `structuredClone()` supports many common data types but cannot clone everything, such as functions.

// ## 7. Prototypes, Classes, and Inheritance

// ```javascript
// class User {
//   constructor(name) {
//     this.name = name;
//   }

//   greet() {
//     return `Hello ${this.name}`;
//   }
// }

// class Admin extends User {
//   greet() {
//     return `${super.greet()}, admin`;
//   }
// }

// const admin = new Admin("Pittu");

// console.log(admin.greet()); // "Hello Pittu, admin"
// ```

// **Explanation:**

// ### `class User`

// Defines a class with a constructor and a `greet()` method.

// ### `constructor(name)`

// Runs when an object is created with `new`. It initializes the object's `name` property.

// ### `extends User`

// Makes `Admin` inherit from `User`.

// ### `super.greet()`

// Calls the inherited `greet()` method from `User`.

// ### Prototype system

// JavaScript uses prototypes for inheritance. Methods defined on a class are generally placed on its prototype, allowing instances to share those methods instead of each instance needing its own copy.

// **Interview definition:** Inheritance allows one class to reuse and extend the behavior of another class. JavaScript implements this through its prototype chain.

// ## Quick Interview Revision

// | Concept | One-line answer |
// |---|---|
// | Closure | A function retains access to its lexical scope. |
// | Hoisting | Declarations are processed before normal execution in their scope. |
// | TDZ | The period when `let` or `const` exists but cannot yet be accessed. |
// | `this` | Depends on the call site for regular functions; inherited lexically by arrow functions. |
// | `call()` | Invokes a function with a specified `this` and individual arguments. |
// | `apply()` | Invokes a function with a specified `this` and an argument array. |
// | `bind()` | Returns a function with a specified `this` value. |
// | Shallow copy | Copies the outer structure but shares nested object references. |
// | Deep copy | Independently copies supported nested data. |
// | Prototype | The object JavaScript uses for inherited properties and methods. |
// | `extends` | Establishes class inheritance. |
// | `super` | Accesses parent-class functionality. |

// **Practice rule:** For every concept, explain the definition, walk through the code, and describe one real-world use case without looking at the notes.