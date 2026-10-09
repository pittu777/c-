/*
JAVASCRIPT INTERVIEW CHEAT SHEET
Run: node javascript-cheat-sheet.js
Examples are grouped for fast revision. Uncomment any section you want to execute.
*/

// ============================================================
// 1. VARIABLES, TYPES, EQUALITY, COERCION
// ============================================================
const name = "Pittu";       // cannot reassign binding
let count = 0;              // can reassign
// var oldStyle = true;     // function-scoped; generally avoid in modern code

typeof "hello";             // "string"
typeof 42;                  // "number"
typeof true;                // "boolean"
typeof undefined;           // "undefined"
typeof null;                // "object" (historical JavaScript quirk)
typeof 10n;                 // "bigint"
typeof Symbol("id");        // "symbol"
Array.isArray([]);          // true

// Primitive values: string, number, bigint, boolean, undefined, symbol, null
// Objects (including arrays and functions) are reference values.

5 === "5";                  // false: no coercion
5 == "5";                   // true: coercion; usually prefer ===
Boolean("");                // false
Boolean(0);                 // false
Boolean(null);              // false
Boolean("0");               // true
Boolean([]);                // true
Boolean({});                // true
0 || 10;                    // 10: returns first truthy value
0 ?? 10;                    // 0: only null/undefined trigger fallback
"" ?? "fallback";           // ""

// Optional chaining and nullish coalescing
const user = { profile: { city: "Hyderabad" } };
user.profile?.city;         // "Hyderabad"
user.settings?.theme;       // undefined
const pageSize = undefined ?? 20; // 20

// ============================================================
// 2. SCOPE, HOISTING, TDZ
// ============================================================
function scopeExample() {
  var functionScoped = "visible in function";
  let blockScoped = "visible in this block";
  if (true) {
    var stillVisible = true;
    let onlyHere = true;
  }
  // stillVisible is accessible here; onlyHere is not.
}

// `var` declarations are hoisted and initialized to undefined.
// `let`/`const` are hoisted but inaccessible in the temporal dead zone
// until their declaration is evaluated.
// Function declarations can generally be called before their declaration.
sayHello();
function sayHello() { return "hello"; }

// const prevents rebinding, not object mutation:
const settings = { dark: false };
settings.dark = true;       // allowed
// settings = {};           // TypeError

// ============================================================
// 3. FUNCTIONS, PARAMETERS, REST, SPREAD
// ============================================================
function add(a, b = 0) { return a + b; }
const multiply = (a, b) => a * b;
const square = n => n * n;
add(2, 3);                  // 5
add(2);                     // 2

function total(...numbers) {
  return numbers.reduce((sum, n) => sum + n, 0);
}
total(1, 2, 3);             // 6
const original = [1, 2];
const copied = [...original]; // shallow copy
const merged = { ...{ a: 1 }, b: 2 };

// Function declaration: hoisted.
// Function expression / arrow: follows its variable declaration rules.
// Arrow functions do not have their own `this` or `arguments`.

// ============================================================
// 4. CLOSURES
// ============================================================
// A closure is a function plus access to variables from its outer scope,
// even after that outer function has finished.
function createCounter(initial = 0) {
  let value = initial;
  return {
    increment() { value += 1; return value; },
    decrement() { value -= 1; return value; },
    get() { return value; },
    reset() { value = initial; }
  };
}
const counter = createCounter(5);
counter.increment();        // 6
counter.get();              // 6
// Use cases: private state, callbacks, function factories, memoization.

function makeMultiplier(factor) {
  return number => number * factor;
}
const double = makeMultiplier(2);
double(7);                  // 14

// Classic loop trap: `var` shares one function-scoped binding.
// for (var i = 0; i < 3; i++) setTimeout(() => console.log(i), 0); // 3,3,3
// for (let i = 0; i < 3; i++) setTimeout(() => console.log(i), 0); // 0,1,2

// ============================================================
// 5. `this`, CALL/APPLY/BIND
// ============================================================
const person = {
  name: "Pittu",
  greet() { return `Hi, ${this.name}`; }
};
person.greet();             // "Hi, Pittu"
const other = { name: "Sam" };
person.greet.call(other);   // "Hi, Sam"
person.greet.apply(other);  // same; arguments are passed as an array
const greetSam = person.greet.bind(other);
greetSam();                 // "Hi, Sam"

// `this` depends on how a regular function is called.
// Arrow functions capture `this` lexically from the surrounding scope.
// Avoid relying on `this` in callbacks unless the binding is clear.

// ============================================================
// 6. OBJECTS, REFERENCES, SHALLOW COPY
// ============================================================
const a = { nested: { score: 1 } };
const b = { ...a };         // shallow copy
b.nested.score = 9;
a.nested.score;             // 9: nested object is shared
const separateNested = structuredClone(a); // deep clone supported data
// JSON.parse(JSON.stringify(value)) loses/changes values such as undefined,
// functions, BigInt, Date, Map, Set, and circular references.

// ============================================================
// 7. PROTOTYPES AND CLASSES
// ============================================================
class Animal {
  constructor(name) { this.name = name; }
  speak() { return `${this.name} makes a sound`; }
}
class Dog extends Animal {
  speak() { return `${this.name} barks`; }
}
new Dog("Rex").speak();     // "Rex barks"
// JavaScript class syntax uses the prototype system under the hood.
// `extends` establishes inheritance; `super()` calls the parent constructor.

// ============================================================
// 8. ARRAY METHODS — MUST KNOW
// ============================================================
const nums = [1, 2, 3, 4, 5];

nums.map(n => n * 2);               // [2,4,6,8,10] transform each item
nums.filter(n => n % 2 === 0);      // [2,4] keep matching items
nums.reduce((sum, n) => sum + n, 0);// 15 combine into one value
nums.find(n => n > 3);              // 4 first matching item or undefined
nums.findIndex(n => n > 3);         // 3 index or -1
nums.some(n => n > 4);              // true: at least one
nums.every(n => n > 0);             // true: all
nums.includes(3);                   // true
nums.slice(1, 3);                   // [2,3], does not mutate
nums.splice(1, 2);                  // removes 2 items; MUTATES array
[1, [2, 3]].flat();                 // [1,2,3]
["hello world", "hello JS"].flatMap(s => s.split(" "));
// ["hello","world","hello","JS"]

// sort mutates the array; numeric sort needs a comparator.
[10, 2, 30].sort();                 // [10, 2, 30] lexicographic order
[10, 2, 30].sort((a, b) => a - b); // [2, 10, 30] ascending
[10, 2, 30].sort((a, b) => b - a); // [30, 10, 2] descending

// Quick decisions:
// map = transform; filter = select; reduce = accumulate;
// find = first match; some/every = boolean checks;
// slice = non-mutating copy/portion; splice = mutating edit.

// ============================================================
// 9. PROMISES
// ============================================================
const resolvedPromise = Promise.resolve("done");
const rejectedPromise = Promise.reject(new Error("failed"));
// Attach a rejection handler if running rejectedPromise to avoid an
// unhandled rejection warning.

function fakeRequest(shouldFail = false) {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      if (shouldFail) reject(new Error("Request failed"));
      else resolve({ id: 1, title: "Example" });
    }, 100);
  });
}

fakeRequest()
  .then(data => data.title)
  .then(title => console.log("Title:", title))
  .catch(error => console.error(error.message))
  .finally(() => console.log("Request finished"));

// Promise states: pending -> fulfilled OR rejected (settled states are final).
// .then handles fulfillment; .catch handles rejection; .finally runs either way.
// Returning a value from .then passes it to the next .then.
// Throwing inside .then turns the chain into a rejection.

// ============================================================
// 10. ASYNC / AWAIT
// ============================================================
async function loadTitle() {
  try {
    const data = await fakeRequest();
    return data.title;             // async function returns a Promise
  } catch (error) {
    console.error(error.message);
    throw error;                   // rethrow if caller must know it failed
  }
}
// loadTitle().then(console.log).catch(() => {});

// `await` pauses this async function, not the entire JavaScript thread.
// Always handle errors when a failure matters.

// Sequential: second waits for first.
async function sequential() {
  const first = await fakeRequest();
  const second = await fakeRequest();
  return [first, second];
}

// Concurrent: start both, then wait for both.
async function concurrent() {
  const results = await Promise.all([fakeRequest(), fakeRequest()]);
  return results;
}
// Promise.all rejects if any input rejects.
// Promise.allSettled waits for every input and reports each outcome.
// Promise.race settles with the first settled input.
// Promise.any fulfills with the first fulfilled input (rejects if all reject).

// ============================================================
// 11. EVENT LOOP: OUTPUT ORDER
// ============================================================
// Example output order:
// console.log("A");
// setTimeout(() => console.log("B"), 0);
// Promise.resolve().then(() => console.log("C"));
// console.log("D");
// Output: A, D, C, B
// Why: synchronous code first, then promise microtasks, then timer tasks.

// ============================================================
// 12. DOM / BROWSER BASICS
// ============================================================
// Browser-only examples (not executable in Node.js):
// document.querySelector(".button");
// element.addEventListener("click", handler);
// event.preventDefault(); // stop default browser behavior
// event.stopPropagation(); // stop bubbling
// localStorage.setItem("theme", "dark"); // strings only
// JSON.parse(localStorage.getItem("user") ?? "null");

// Cookies, localStorage, and sessionStorage have different lifetimes and
// security properties. Do not store sensitive secrets in localStorage.

// ============================================================
// 13. COMMON INTERVIEW TRAPS
// ============================================================
[] + [];                    // ""
[] + {};                    // commonly "[object Object]"
"5" - 2;                    // 3 (numeric coercion)
"5" + 2;                    // "52" (string concatenation)
NaN === NaN;                // false
Number.isNaN(NaN);          // true
Object.is(NaN, NaN);        // true
Object.is(-0, 0);           // false
// Avoid memorizing weird coercion puzzles without understanding the rules.

// ============================================================
// 14. BIG-O QUICK LOOK
// ============================================================
// Array index read: O(1)
// Linear search / find: O(n)
// map/filter/reduce: typically O(n)
// Sorting: typically O(n log n)
// Set/Map lookup: average O(1)
// Nested loops over n items: often O(n^2), depending on loop bounds.

// End: explain each concept aloud, then write a tiny example from memory.
