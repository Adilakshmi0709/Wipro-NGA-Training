"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class Trainer {
    name;
    experience;
    constructor(name, experience) {
        this.name = name;
        this.experience = experience;
    }
    introduce() {
        console.log(Hi, I, 'm ${this.name} with ${this.experience} years of experience.););
    }
    calculateSessions() {
        return this.experience * 75;
    }
}
const sushma = new Trainer("Jyoti", 16);
sushma.introduce(); // Output: Hi, I'm Jyoti with 16 years of experience.
console.log(sushma.calculateSessions()); // Output: 1200
//# sourceMappingURL=typescript.js.map