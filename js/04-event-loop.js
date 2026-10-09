// 04 — EVENT LOOP
// Run: node 04-event-loop.js

console.log("1: synchronous start");

setTimeout(() => console.log("4: timer callback"), 0);

Promise.resolve().then(() => console.log("3: promise microtask"));

console.log("2: synchronous end");

// Expected order:
// 1: synchronous start
// 2: synchronous end
// 3: promise microtask
// 4: timer callback

// Rule of thumb:
// 1. Run current synchronous JavaScript.
// 2. Drain queued microtasks (Promise callbacks, queueMicrotask).
// 3. Run a timer/task when its turn comes.
// A 0ms timer means "not before this delay"; it is not immediate.





// # 04 — JavaScript Event Loop

// ## 1. What is the Event Loop?

// JavaScript executes synchronous code on the call stack. The event loop coordinates when queued asynchronous callbacks can run after the current synchronous work finishes.

// In JavaScript interviews, understand these three concepts:

// - **Call stack:** Executes the currently running JavaScript functions.
// - **Microtask queue:** Holds callbacks such as Promise `.then()`, `.catch()`, `.finally()`, and `queueMicrotask()`.
// - **Task queue:** Holds tasks such as timer callbacks from `setTimeout()`.

// ## 2. Understand the Example

// ```js
// console.log("1: synchronous start");

// setTimeout(() => console.log("4: timer callback"), 0);

// Promise.resolve().then(() => console.log("3: promise microtask"));

// console.log("2: synchronous end");
// ```

// ### Step-by-step execution

// **Step 1 — Synchronous start**

// ```js
// console.log("1: synchronous start");
// ```

// Prints immediately:

// ```text
// 1: synchronous start
// ```

// **Step 2 — Schedule a timer**

// ```js
// setTimeout(() => console.log("4: timer callback"), 0);
// ```

// The timer callback is scheduled to run later. It does not execute immediately, even with a delay of `0`.

// **Step 3 — Schedule a microtask**

// ```js
// Promise.resolve().then(() => console.log("3: promise microtask"));
// ```

// The Promise is already fulfilled, but its `.then()` callback is scheduled as a microtask.

// **Step 4 — Continue synchronous execution**

// ```js
// console.log("2: synchronous end");
// ```

// Prints:

// ```text
// 2: synchronous end
// ```

// **Step 5 — Process microtasks**

// After the current synchronous JavaScript finishes, the Promise callback runs:

// ```text
// 3: promise microtask
// ```

// **Step 6 — Run the timer callback**

// When the timer task gets its turn, the callback runs:

// ```text
// 4: timer callback
// ```

// ### Final output

// ```text
// 1: synchronous start
// 2: synchronous end
// 3: promise microtask
// 4: timer callback
// ```

// ## 3. The Interview Rule

// For this kind of example, remember:

// 1. Run the current synchronous JavaScript to completion.
// 2. Process queued microtasks, including newly queued microtasks, before moving to the next task.
// 3. Process the next eligible task, such as a timer callback, according to the runtime's scheduling rules.

// A zero-millisecond timer means the callback is eligible after the delay threshold; it does not guarantee immediate execution.

// ## 4. A Common Interview Trick

// ```js
// console.log("A");

// setTimeout(() => console.log("B"), 0);

// Promise.resolve().then(() => {
//   console.log("C");
//   Promise.resolve().then(() => console.log("D"));
// });

// console.log("E");
// ```

// Output:

// ```text
// A
// E
// C
// D
// B
// ```

// Why?

// - `A` and `E` run synchronously.
// - The first Promise callback prints `C`.
// - That callback schedules another Promise microtask, which prints `D`.
// - The timer callback prints `B` afterward.

// Microtasks queued by a running microtask are processed before the runtime moves on to the next task.

// ## 5. Another Trick — `async/await`

// ```js
// async function example() {
//   console.log("A");
//   await Promise.resolve();
//   console.log("B");
// }

// console.log("C");
// example();
// console.log("D");
// ```

// Output:

// ```text
// C
// A
// D
// B
// ```

// Why?

// - `C` runs first.
// - Calling `example()` runs its synchronous part, printing `A`.
// - `await` suspends the async function until its continuation can resume.
// - `D` runs synchronously.
// - Finally, the async function resumes and prints `B`.

// ## Quick Revision

// - Synchronous code runs before queued callbacks.
// - Promise `.then()` callbacks are microtasks.
// - `queueMicrotask()` schedules a microtask.
// - `setTimeout()` schedules a timer callback.
// - `await` suspends the current async function, not the entire JavaScript thread.
// - A `0ms` timer is not immediate.
// - Microtasks are drained before the next task in the usual browser and Node.js execution scenarios shown here.

// **Interview tip:** Never guess the output. Label every statement as *synchronous*, *microtask*, or *task*, then trace the execution order.
