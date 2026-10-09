// 02 — ARRAY METHODS
// Run: node 02-array-methods.js

const products = [
  { name: "Keyboard", price: 1200, inStock: true },
  { name: "Mouse", price: 500, inStock: false },
  { name: "Monitor", price: 9000, inStock: true }
];

console.log(products.map(p => p.name)); // transform
console.log(products.filter(p => p.inStock)); // select
console.log(products.find(p => p.price > 1000)); // first match
console.log(products.some(p => !p.inStock)); // any?
console.log(products.every(p => p.price > 0)); // all?
console.log(products.reduce((sum, p) => sum + p.price, 0)); // total
console.log("slice",products.slice(-1,-1)); // non-mutating
console.log([3, 1, 20].sort((a, b) => a - b)); // numeric ascending

// Count occurrences
function frequency(items) {
  return items.reduce((counts, item) => {
    counts[item] = (counts[item] ?? 0) + 1;
    return counts;
  }, {});
}
console.log(frequency(["a", "b", "a"])); // { a: 2, b: 1 }

// Remove duplicates
const values = [1, 2, 2, 3, 1];
console.log([...new Set(values)]); // [1, 2, 3]

// Group by property
function groupBy(items, key) {
  return items.reduce((groups, item) => {
    const group = item[key];
    (groups[group] ??= []).push(item);
    return groups;
  }, {});
}
console.log(groupBy(products, "inStock"));

// Mutation reminder:
// push/pop/shift/unshift/splice/sort/reverse mutate the array.
// map/filter/slice/concat/flat return new arrays.

















// # 02 — JavaScript Array Methods

// ## 1. `map()` — Transform Each Element

// ```js
// console.log(products.map(p => p.name));
// ```

// **Output:**
// ```js
// ["Keyboard", "Mouse", "Monitor"]
// ```

// - `map()` loops through every element and returns a **new array**.
// - Here, `p` represents each product object.
// - `p.name` extracts the name from each object.
// - The original `products` array is unchanged.

// **Interview use:** Extracting names, converting values, formatting API data.

// **Remember:** `map()` transforms elements.

// ---

// ## 2. `filter()` — Select Matching Elements

// ```js
// console.log(products.filter(p => p.inStock));
// ```

// **Output:**
// ```js
// [
//   { name: "Keyboard", price: 1200, inStock: true },
//   { name: "Monitor", price: 9000, inStock: true }
// ]
// ```

// - `filter()` checks every element against a condition.
// - If the condition is `true`, that element is included in the new array.
// - `p.inStock` is shorthand for `p.inStock === true`.

// **Interview use:** Filtering available products, active users, or expensive items.

// **Remember:** `filter()` selects elements.

// ---

// ## 3. `find()` — Get the First Matching Element

// ```js
// console.log(products.find(p => p.price > 1000));
// ```

// **Output:**
// ```js
// { name: "Keyboard", price: 1200, inStock: true }
// ```

// - `find()` returns the **first element** that satisfies the condition.
// - It stops searching after finding a match.
// - If nothing matches, it returns `undefined`.

// **Remember:** `find()` returns one element, not an array.

// ---

// ## 4. `some()` — Does Any Element Match?

// ```js
// console.log(products.some(p => !p.inStock));
// ```

// **Output:**
// ```js
// true
// ```

// - `some()` returns `true` if at least one element satisfies the condition.
// - `!p.inStock` means the product is not in stock.
// - The Mouse is out of stock, so the result is `true`.

// **Remember:** `some()` means **at least one**.

// ---

// ## 5. `every()` — Do All Elements Match?

// ```js
// console.log(products.every(p => p.price > 0));
// ```

// **Output:**
// ```js
// true
// ```

// - `every()` returns `true` only if all elements satisfy the condition.
// - Every product has a price greater than zero.

// **Remember:** `every()` means **all elements**.

// ---

// ## 6. `reduce()` — Combine Elements Into One Result

// ```js
// console.log(products.reduce((sum, p) => sum + p.price, 0));
// ```

// **Output:**
// ```js
// 10700
// ```

// How it works:

// 1. `sum` is the accumulator that stores the running total.
// 2. `p` is the current product.
// 3. `sum + p.price` adds the current product's price.
// 4. `0` is the initial value of `sum`.

// | Product | Running total |
// |---|---:|
// | Start | 0 |
// | Keyboard | 1200 |
// | Mouse | 1700 |
// | Monitor | 10700 |

// **Interview use:** Calculating totals, counting items, building objects, and grouping data.

// **Remember:** `reduce()` combines elements into a single result, which can be a number, array, object, or another value.

// ---

// ## 7. `slice()` — Copy a Portion of an Array

// ```js
// console.log([3, 1, 20].slice(0, 2));
// ```

// **Output:**
// ```js
// [3, 1]
// ```

// - The first argument is the starting index.
// - The second argument is the ending index, **excluded**.
// - `slice()` does not mutate the original array.

// For `slice(0, 2)`, indexes `0` and `1` are included, but index `2` is excluded.

// **Remember:** `slice()` copies a portion without changing the original array.

// ---

// ## 8. `sort()` — Sort Array Elements

// ```js
// console.log([3, 1, 20].sort((a, b) => a - b));
// ```

// **Output:**
// ```js
// [1, 3, 20]
// ```

// - `sort()` changes the original array.
// - `(a, b) => a - b` sorts numbers in ascending order.
// - Use `(a, b) => b - a` for descending order.

// ```js
// const numbers = [3, 1, 20];

// numbers.sort((a, b) => a - b); // Ascending
// numbers.sort((a, b) => b - a); // Descending
// ```

// **Important:** Without a comparator, `sort()` sorts elements as strings. For example, `[3, 20, 100].sort()` produces `[100, 20, 3]`.

// ---

// ## 9. Count Occurrences Using `reduce()`

// ```js
// function frequency(items) {
//   return items.reduce((counts, item) => {
//     counts[item] = (counts[item] ?? 0) + 1;
//     return counts;
//   }, {});
// }

// console.log(frequency(["a", "b", "a"]));
// ```

// **Output:**
// ```js
// { a: 2, b: 1 }
// ```

// How it works:

// - `counts` is an object that stores each item's frequency.
// - `item` is the current array element.
// - `counts[item] ?? 0` uses the existing count, or `0` if the value is `null` or `undefined`.
// - `+ 1` increments the count.
// - `{}` initializes the accumulator as an empty object.
// - `return counts` passes the updated object to the next iteration.

// **Interview use:** Counting character frequencies, duplicate detection, and counting votes.

// ---

// ## 10. Remove Duplicates Using `Set`

// ```js
// const values = [1, 2, 2, 3, 1];

// console.log([...new Set(values)]);
// ```

// **Output:**
// ```js
// [1, 2, 3]
// ```

// - A `Set` stores unique values.
// - `new Set(values)` removes duplicate values.
// - The spread operator `...` converts the Set back into an array.
// - The original order of first occurrences is preserved.

// **Interview use:** Removing duplicate numbers or strings from an array.

// ---

// ## 11. Group Elements by a Property

// ```js
// function groupBy(items, key) {
//   return items.reduce((groups, item) => {
//     const group = item[key];
//     (groups[group] ??= []).push(item);
//     return groups;
//   }, {});
// }

// console.log(groupBy(products, "inStock"));
// ```

// The result is an object with two groups: `true` and `false`. Products with `inStock: true` go into one array, while products with `inStock: false` go into another.

// Key expressions:

// - `item[key]` accesses a property dynamically. If `key` is `"inStock"`, it reads `item.inStock`.
// - `groups[group] ??= []` creates an empty array if that group does not exist yet.
// - `.push(item)` adds the current product to the appropriate group.
// - `{}` is the initial accumulator.

// **Remember:** `groupBy()` is a custom helper built using `reduce()`.

// ---

// ## 12. Mutating vs. Non-Mutating Methods

// **Methods that mutate the original array:**

// - `push()` — add to the end.
// - `pop()` — remove from the end.
// - `shift()` — remove from the beginning.
// - `unshift()` — add to the beginning.
// - `splice()` — add, remove, or replace elements.
// - `sort()` — sort the array in place.
// - `reverse()` — reverse the array in place.

// **Methods that return a new array without mutating the original array:**

// - `map()`
// - `filter()`
// - `slice()`
// - `concat()`
// - `flat()`

// Note: `find()`, `some()`, and `every()` return a value rather than a new array. `reduce()` returns whatever value your reducer builds.

// ---

// ## Quick Interview Revision

// | Method | Main purpose | Return value |
// |---|---|---|
// | `map()` | Transform elements | New array |
// | `filter()` | Select matching elements | New array |
// | `find()` | First matching element | Element or `undefined` |
// | `some()` | At least one matches | Boolean |
// | `every()` | All elements match | Boolean |
// | `reduce()` | Accumulate a result | Accumulated value |
// | `slice()` | Copy a portion | New array |
// | `sort()` | Sort elements | Same array, mutated |
// | `Set` | Keep unique values | Set; spread to get an array |

// ### Practice rule

// Before an interview, practise explaining **what the method returns, whether it mutates the original array, and when you would use it**. These three points help you answer most array-method questions clearly.



const pets = [
  { name: 'Fluffy', type: 'dog' },
  { name: 'Whiskers', type: 'cat' },
  { name: 'Spot', type: 'dog' }
];

const groupedByTarget = pets.reduce((grouped, pet) => {
  console.log("grouped", grouped);
  if (!grouped[pet.type]) {
    grouped[pet.type] = [];
  }
  grouped[pet.type].push(pet.name);
  return grouped;
}, {}); // Initial value is an empty object

console.log(groupedByTarget);
// Output: { dog: ['Fluffy', 'Spot'], cat: ['Whiskers'] }
