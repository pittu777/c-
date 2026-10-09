// 06 — OUTPUT PREDICTION
// Try to predict each output before reading the answer comment.

// Q1
console.log(typeof null); // "object"

// Q2
console.log(1 + "2" + 3); // "123"
console.log(1+3);

// Q3
console.log("6" - 2); // 4

// Q4
console.log(Boolean([]), Boolean("")); // true false

// Q5
const numbers = [1, 2, 3];
console.log(numbers.map(n => n * 2)); // [2, 4, 6]
console.log(numbers.filter(n => n > 1)); // [2, 3]

// Q6
console.log([10, 2, 1].sort()); // [1, 10, 2] (string-based default sort)

// Q7
console.log([10, 2, 1].sort((a, b) => a - b)); // [1, 2, 10]

// Q8
console.log("A");
Promise.resolve().then(() => console.log("B"));
setTimeout(() => console.log("C"), 0);
console.log("D");
// A, D, B, C

// Q9
function outer() {
  let value = 10;
  return () => ++value;
}
const next = outer();
console.log(next(), next()); // 11 12

// Q10
async function example() { return 42; }
example().then(console.log); // 42 (Promise fulfillment)

// Q11
const original = { nested: { x: 1 } };
const copy = { ...original };
copy.nested.x = 7;
console.log(original.nested.x); // 7: shallow copy

// Q12
console.log(NaN === NaN, Number.isNaN(NaN)); // false true
