// Declare a tuple type for a user: [ID, name, isLoggedIn]
let user: [number, string, boolean];

// Assign values that match the type and order
user = [101, "Alice", true]; // This is correct

// Accessing elements is just like an array
console.log(user[0]); // Output: 101 (Type is number)
console.log(user[1]); // Output: "Alice" (Type is string)

// --- ERROR EXAMPLES ---

// Error: Wrong type at index 2. Expected boolean, got string.
// user = [102, "Bob", "false"];

// Error: Incorrect number of elements. Expected 3, got 2.
// user = [103, "Charlie"];