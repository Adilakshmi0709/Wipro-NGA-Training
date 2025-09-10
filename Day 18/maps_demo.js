"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
let scores = new Map();
scores.set("Alice", 95);
scores.set("Bob", 99);
scores.set("Raju", 55);
console.log(scores.get("Alice")); // 95
console.log(scores.get("Bob")); // 99
// Iterate over entries
for (let [name, score] of scores) {
    console.log(`${name} scored ${score}`);
}
// Remove an entry
scores.delete("Bob");
// Map size
console.log(scores.size); // Output: 2
// Clear all entries
scores.clear();
console.log(scores.size); // Output: 0
//# sourceMappingURL=maps_demo.js.map