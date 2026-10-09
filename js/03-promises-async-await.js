// 03 — PROMISES AND ASYNC/AWAIT
// Run: node 03-promises-async-await.js

const delay = ms => new Promise(resolve => setTimeout(resolve, ms));

async function getUser(id) {
  await delay(100);
  if (id < 1) throw new Error("Invalid user ID");
  return { id, name: "Pittu" };
}

// async function always returns a Promise.
getUser(1)
  .then(user => console.log(user))
  .catch(error => console.error(error.message));

// async/await and try/catch
async function main() {
  try {
    const user = await getUser(1);
    console.log("User:", user.name);
  } catch (error) {
    console.error("Could not load user:", error.message);
  }
}

// Run tasks concurrently when independent.
async function loadTwoUsers() {
  const [first, second] = await Promise.all([getUser(1), getUser(2)]);
  return [first, second];
}

// allSettled: inspect every outcome, even if some fail.
async function inspectAll() {
  return Promise.allSettled([getUser(1), getUser(0)]);
}

// Sequential vs concurrent:
// await taskA(); await taskB(); // sequential
// await Promise.all([taskA(), taskB()]); // concurrent

// Promise combinators:
// all       -> all fulfill, or reject at first rejection
// allSettled-> wait for all outcomes
// race      -> first settled outcome wins
// any       -> first fulfillment wins

// Uncomment to run:
// main();
// loadTwoUsers().then(console.log);
// inspectAll().then(console.log);











// # 03 — JavaScript Promises and Async/Await

// ## 1. What is a Promise?

// A **Promise** represents the eventual result of an asynchronous operation, such as an API request, a timer, or reading data.

// A Promise has three states:

// 1. **Pending** — the operation is still in progress.
// 2. **Fulfilled** — the operation completed successfully.
// 3. **Rejected** — the operation failed.

// Example:

// ```js
// const promise = new Promise((resolve, reject) => {
//   resolve("Success!");
// });

// promise.then(result => console.log(result));
// // Output: Success!
// ```

// - `resolve(value)` fulfills the Promise with a value.
// - `reject(error)` rejects the Promise with a reason.
// - `.then()` handles successful fulfillment.
// - `.catch()` handles rejection.

// ## 2. Create a Delay Using a Promise

// ```js
// const delay = ms =>
//   new Promise(resolve => setTimeout(resolve, ms));
// ```

// This function creates a Promise that fulfills after the specified number of milliseconds.

// For example:

// ```js
// await delay(1000);
// ```

// This waits approximately one second before continuing inside the async function.

// How it works:

// - `ms` is the delay duration in milliseconds.
// - `setTimeout()` schedules a callback to run after the delay.
// - `resolve` is passed directly as that callback.
// - When the timer fires, the Promise is fulfilled.

// **Important:** This does not block the JavaScript thread. Other JavaScript work can continue while the timer is waiting.

// ## 3. An Async Function That Returns Data

// ```js
// async function getUser(id) {
//   await delay(100);

//   if (id < 1) {
//     throw new Error("Invalid user ID");
//   }

//   return { id, name: "Pittu" };
// }
// ```

// Explanation:

// - `async` makes the function return a Promise.
// - `await delay(100)` pauses this function until the delay Promise fulfills.
// - If `id` is less than `1`, `throw` creates an error and causes the returned Promise to reject.
// - Otherwise, the function returns a user object.

// Example:

// ```js
// getUser(1).then(console.log);
// ```

// Output:

// ```js
// { id: 1, name: "Pittu" }
// ```

// Even though the function returns an ordinary object, an async function wraps that value in a fulfilled Promise.

// Conceptually:

// ```js
// async function example() {
//   return 10;
// }

// // Similar result:
// function example() {
//   return Promise.resolve(10);
// }
// ```

// ## 4. Handle a Promise Using `.then()` and `.catch()`

// ```js
// getUser(1)
//   .then(user => console.log(user))
//   .catch(error => console.error(error.message));
// ```

// - `.then()` runs when the Promise fulfills.
// - `user` receives the returned user object.
// - `.catch()` handles a rejection from `getUser()` or an error thrown in the preceding `.then()` callback.

// If you call `getUser(0)`, the output from the catch handler is:

// ```text
// Invalid user ID
// ```

// **Interview point:** `.then()` and `.catch()` are Promise-handling methods. They do not make a function synchronous.

// ## 5. Use `async/await` with `try/catch`

// ```js
// async function main() {
//   try {
//     const user = await getUser(1);
//     console.log("User:", user.name);
//   } catch (error) {
//     console.error("Could not load user:", error.message);
//   }
// }
// ```

// Here, `await` lets you write asynchronous code in a style that looks sequential.

// Execution:

// 1. `main()` starts.
// 2. `getUser(1)` begins.
// 3. `await` waits for its Promise to settle.
// 4. On fulfillment, the user object is assigned to `user`.
// 5. The user's name is printed.
// 6. If the awaited Promise rejects, execution jumps to `catch`.

// Output:

// ```text
// User: Pittu
// ```

// If the code called `getUser(0)` instead, the error would be handled by `catch`.

// **Remember:** Use `try/catch` around awaited operations when you need to handle errors locally.

// ## 6. Run Independent Tasks Concurrently with `Promise.all()`

// ```js
// async function loadTwoUsers() {
//   const [first, second] = await Promise.all([
//     getUser(1),
//     getUser(2)
//   ]);

//   return [first, second];
// }
// ```

// `Promise.all()` waits for every supplied Promise to fulfill.

// - Both `getUser()` calls are started when the array is evaluated.
// - They can run concurrently because neither needs the result of the other.
// - Once both fulfill, their results are assigned to `first` and `second`.
// - The result order matches the input order, not necessarily the completion order.

// Output from:

// ```js
// loadTwoUsers().then(console.log);
// ```

// ```js
// [
//   { id: 1, name: "Pittu" },
//   { id: 2, name: "Pittu" }
// ]
// ```

// If any Promise rejects, `Promise.all()` rejects with that reason. It does not automatically cancel the other operations.

// **Interview use:** Loading a user profile and notifications at the same time when they are independent.

// ## 7. Inspect All Results with `Promise.allSettled()`

// ```js
// async function inspectAll() {
//   return Promise.allSettled([
//     getUser(1),
//     getUser(0)
//   ]);
// }
// ```

// Unlike `Promise.all()`, `Promise.allSettled()` waits for every supplied Promise to settle, whether fulfilled or rejected.

// The result has this general structure:

// ```js
// [
//   {
//     status: "fulfilled",
//     value: { id: 1, name: "Pittu" }
//   },
//   {
//     status: "rejected",
//     reason: Error("Invalid user ID")
//   }
// ]
// ```

// The exact error object is displayed differently depending on the environment.

// **Interview use:** Processing multiple independent operations when you need to know which succeeded and which failed.

// ## 8. Sequential vs. Concurrent Execution

// ### Sequential execution

// ```js
// await taskA();
// await taskB();
// ```

// - `taskB()` starts only after `taskA()` fulfills.
// - Useful when task B depends on task A's result.

// ### Concurrent execution

// ```js
// await Promise.all([
//   taskA(),
//   taskB()
// ]);
// ```

// - Both tasks are started without waiting for the other to finish.
// - Useful when tasks are independent.
// - The total waiting time is often close to the duration of the slower task, rather than the sum of both durations.

// **Important:** `Promise.all()` does not make CPU-heavy synchronous JavaScript execute in parallel. It coordinates asynchronous operations.

// ## 9. Promise Combinators

// | Method | Behavior | Typical use |
// |---|---|---|
// | `Promise.all()` | Fulfills when all fulfill; rejects if any rejects | All results are required |
// | `Promise.allSettled()` | Waits for every outcome | Need success and failure details |
// | `Promise.race()` | Settles with the first Promise to settle | First result or error wins |
// | `Promise.any()` | Fulfills with the first fulfillment; rejects if all reject | Accept the first successful result |

// ### Example: `Promise.race()`

// ```js
// Promise.race([
//   delay(100),
//   delay(200)
// ]).then(() => console.log("First settled"));
// ```

// The first timer fulfills the race, so `"First settled"` is printed after approximately 100 milliseconds.

// ### Example: `Promise.any()`

// ```js
// Promise.any([
//   Promise.reject("Failed A"),
//   Promise.resolve("Success B")
// ]).then(console.log);
// ```

// Output:

// ```text
// Success B
// ```

// `Promise.any()` ignores earlier rejections if another Promise fulfills. If all reject, it rejects with an `AggregateError`.

// ## 10. Common Interview Mistakes

// - Thinking an async function returns a plain value instead of a Promise.
// - Forgetting that `await` is used inside an async function in ordinary JavaScript scripts and modules.
// - Using sequential `await` for independent tasks when concurrency is appropriate.
// - Assuming `Promise.all()` waits for all failures to be reported individually; use `Promise.allSettled()` for that.
// - Assuming `Promise.race()` always succeeds; the first settled Promise can reject.
// - Forgetting error handling for rejected Promises.

// ## Quick Revision

// - **Promise:** Represents the eventual outcome of an asynchronous operation.
// - **`async`:** Makes a function return a Promise.
// - **`await`:** Waits for a Promise's outcome inside an async function.
// - **`try/catch`:** Handles errors from awaited operations.
// - **`Promise.all()`:** Wait for all successes; reject if one rejects.
// - **`Promise.allSettled()`:** Collect every outcome.
// - **`Promise.race()`:** First settled outcome wins.
// - **`Promise.any()`:** First successful outcome wins.

// ### Practice rule

// For every Promise question, explain three things: **when the operation starts, when execution continues, and how errors are handled.**