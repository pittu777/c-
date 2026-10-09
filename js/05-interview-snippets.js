// 05 — COMMON INTERVIEW SNIPPETS
// Run: node 05-interview-snippets.js

// Debounce: run after calls stop for `wait` milliseconds.
function debounce(fn, wait = 300) {
  let timer;
  return function (...args) {
    clearTimeout(timer);
    timer = setTimeout(() => fn.apply(this, args), wait);
  };
}

// Throttle: at most once per interval (simple leading-edge version).
function throttle(fn, wait = 300) {
  let lastRun = 0;
  return function (...args) {
    const now = Date.now();
    if (now - lastRun >= wait) {
      lastRun = now;
      return fn.apply(this, args);
    }
  };
}

// Frequency counter
function countChars(text) {
  const result = {};
  for (const char of text.toLowerCase()) {
    result[char] = (result[char] ?? 0) + 1;
  }
  return result;
}

// Palindrome after normalizing letters/numbers
function isPalindrome(text) {
  const normalized = text.toLowerCase().replace(/[^a-z0-9]/g, "");
  return normalized === [...normalized].reverse().join("");
}

// Find largest number
function maxNumber(numbers) {
  if (numbers.length === 0) return undefined;
  return numbers.reduce((max, n) => n > max ? n : max);
}

// Flatten nested arrays (one level or arbitrary depth)
// [1, [2, [3]]].flat(Infinity) => [1, 2, 3]

// `Map` for key-value data; `Set` for unique values.
const ids = new Set([1, 1, 2]);
const cache = new Map([["user:1", { name: "Pittu" }]]);
console.log([...ids], cache.get("user:1"));
