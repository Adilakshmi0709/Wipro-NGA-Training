// 1. Traverse an Array using for...of
const fruits: string[] = ['apple', 'banana', 'cherry'];
for (const fruit of fruits) {
  console.log('Fruit:', fruit);
}
// traverse a Map using for...of loop
const scores1 = new Map([
    ['Raj', 95],
    ['Nikhil', 87],
    ['Tejas', 78],
  ]);
  
  for (const [name, scores] of scores1) {
    console.log(`${name}: ${scores1}`);
  }
  
  // traverse a Set using for...of loop
  const uniqueNumbers = new Set([1, 2, 3, 4, 5]);
  for (const number of uniqueNumbers) {
    console.log(number);
  }
  