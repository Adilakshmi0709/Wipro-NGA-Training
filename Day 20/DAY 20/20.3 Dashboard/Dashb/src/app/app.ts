
// import { Component } from '@angular/core';
// import { CommonModule } from '@angular/common';

// @Component({
//   selector: 'app-root',
//   standalone: true,
//   imports: [CommonModule],
//   template: `
//     <div class="dashboard-container">
//       <h1>{{ title }}</h1>

//       <button class="toggle-btn" (click)="toggleFees()">
//         {{ showFees ? 'Hide Fees' : 'Show Fees' }}
//       </button>

//       <div class="student-list">
//         @for (student of students; track student.name) {
//           <div class="student-card">
//             <div class="card-header">
//               <div class="avatar">{{ student.name.charAt(0) }}</div>
//               <div>
//                 <h2>{{ student.name }}</h2>
//                 <span class="gender">({{ student.gender }})</span>
//               </div>
//             </div>

//             <div class="student-info">
//               <p><strong>DOB:</strong> {{ student.dob | date: 'longDate' }}</p>

//               @if (showFees) {
//                 <p class="fee" [ngClass]="student.fee > 7000 ? 'high-fee' : 'low-fee'">
//                   <strong>Fee:</strong> {{ student.fee | currency:'INR':'symbol':'1.2-2' }}
//                 </p>
//               }
//             </div>
//           </div>
//         }
//       </div>
//     </div>
//   `,
//   styles: [`
//     /* Container */
//     .dashboard-container {
//       max-width: 800px;
//       margin: 40px auto;
//       padding: 20px;
//       font-family: 'Poppins', sans-serif;
//     }

//     /* Title */
//     h1 {
//       text-align: center;
//       font-size: 28px;
//       font-weight: 600;
//       background: linear-gradient(to right, #007bff, #00c6ff);
//       -webkit-background-clip: text;
//       -webkit-text-fill-color: transparent;
//       margin-bottom: 25px;
//     }

//     /* Button */
//     .toggle-btn {
//       display: block;
//       margin: 0 auto 25px;
//       background: linear-gradient(45deg, #007bff, #00c6ff);
//       color: white;
//       padding: 10px 20px;
//       border: none;
//       border-radius: 30px;
//       font-size: 14px;
//       cursor: pointer;
//       transition: 0.3s ease;
//     }
//     .toggle-btn:hover {
//       background: linear-gradient(45deg, #0056b3, #0094cc);
//       transform: scale(1.05);
//     }

//     /* Student list */
//     .student-list {
//       display: grid;
//       grid-template-columns: repeat(auto-fill, minmax(250px, 1fr));
//       gap: 20px;
//     }

//     /* Card */
//     .student-card {
//       background: white;
//       border-radius: 12px;
//       overflow: hidden;
//       box-shadow: 0 4px 10px rgba(0,0,0,0.1);
//       transition: transform 0.2s ease, box-shadow 0.2s ease;
//     }
//     .student-card:hover {
//       transform: translateY(-5px);
//       box-shadow: 0 6px 15px rgba(0,0,0,0.15);
//     }

//     /* Card header */
//     .card-header {
//       display: flex;
//       align-items: center;
//       gap: 15px;
//       background: linear-gradient(45deg, #007bff, #00c6ff);
//       color: white;
//       padding: 15px;
//     }
//     .card-header h2 {
//       font-size: 18px;
//       margin: 0;
//     }
//     .gender {
//       font-size: 13px;
//       opacity: 0.85;
//     }

//     /* Avatar */
//     .avatar {
//       background: rgba(255,255,255,0.3);
//       width: 40px;
//       height: 40px;
//       border-radius: 50%;
//       display: flex;
//       align-items: center;
//       justify-content: center;
//       font-size: 18px;
//       font-weight: bold;
//     }

//     /* Info */
//     .student-info {
//       padding: 15px;
//       font-size: 14px;
//       color: #555;
//     }

//     /* Fee colors */
//     .fee {
//       font-weight: bold;
//       margin-top: 8px;
//     }
//     .high-fee {
//       color: green;
//     }
//     .low-fee {
//       color: red;
//     }
//   `]
// })
// export class App {
//   title = 'Wipro Student Dashboard';
//   showFees = false;

//   students = [
//     { name: 'Rakesh', gender: 'male', dob: new Date(1988, 11, 8), fee: 1234.56 },
//     { name: 'Anurag', gender: 'male', dob: new Date(1989, 9, 14), fee: 6666.00 },
//     { name: 'Priyanka', gender: 'female', dob: new Date(1992, 6, 24), fee: 6543.15 },
//     { name: 'Akash', gender: 'female', dob: new Date(1990, 7, 19), fee: 9000.50 },
//     { name: 'Gopi', gender: 'female', dob: new Date(1990, 7, 19), fee: 6000.50 },
//     { name: 'Rushi', gender: 'female', dob: new Date(1990, 7, 19), fee: 9000.50 }

//   ];

//   toggleFees() {
//     this.showFees = !this.showFees;
//   }
// }

import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="dashboard-container">
      <h1>{{ title }}</h1>

      <button class="toggle-btn" (click)="toggleFees()">
        {{ showFees ? 'Hide Fees' : 'Show Fees' }}
      </button>

      <div class="student-list">
        @for (student of students; track student.name) {
          <div class="student-card">
            <div class="card-header">
              <div class="avatar">{{ student.name.charAt(0) }}</div>
              <div>
                <h2>{{ student.name }}</h2>
                <span class="gender">({{ student.gender }})</span>
              </div>
            </div>

            <div class="student-info">
              <p><strong>DOB:</strong> {{ student.dob | date: 'longDate' }}</p>

              @if (showFees) {
                <p class="fee" [ngClass]="student.fee > 7000 ? 'high-fee' : 'low-fee'">
                  <strong>Fee:</strong> {{ student.fee | currency:'INR':'symbol':'1.2-2' }}
                </p>
              }
            </div>
          </div>
        }
      </div>
    </div>
  `,
  styles: [`
    /* Container */
    .dashboard-container {
      max-width: 900px;
      margin: 40px auto;
      padding: 20px;
      font-family: 'Segoe UI', sans-serif;
      background: linear-gradient(135deg, #f4f9ff, #e6f2ff);
      border-radius: 16px;
      box-shadow: 0 8px 20px rgba(0,0,0,0.08);
    }

    /* Title */
    h1 {
      text-align: center;
      font-size: 30px;
      font-weight: bold;
      background: linear-gradient(to right, #ff7e5f, #feb47b);
      -webkit-background-clip: text;
      -webkit-text-fill-color: transparent;
      margin-bottom: 25px;
    }

    /* Button */
    .toggle-btn {
      display: block;
      margin: 0 auto 25px;
      background: linear-gradient(90deg, #00c6ff, #0072ff);
      color: white;
      padding: 12px 25px;
      border: none;
      border-radius: 50px;
      font-size: 15px;
      font-weight: 500;
      cursor: pointer;
      transition: all 0.3s ease;
      box-shadow: 0 4px 8px rgba(0,114,255,0.3);
    }
    .toggle-btn:hover {
      background: linear-gradient(90deg, #0072ff, #00c6ff);
      transform: scale(1.05);
      box-shadow: 0 6px 14px rgba(0,114,255,0.4);
    }

    /* Student list */
    .student-list {
      display: grid;
      grid-template-columns: repeat(auto-fill, minmax(260px, 1fr));
      gap: 20px;
    }

    /* Card */
    .student-card {
      background: white;
      border-radius: 16px;
      overflow: hidden;
      box-shadow: 0 4px 15px rgba(0,0,0,0.08);
      transition: all 0.3s ease;
    }
    .student-card:hover {
      transform: translateY(-6px);
      box-shadow: 0 8px 20px rgba(0,0,0,0.15);
    }

    /* Card header */
    .card-header {
      display: flex;
      align-items: center;
      gap: 15px;
      background: linear-gradient(135deg, #6a11cb, #2575fc);
      color: white;
      padding: 15px;
    }
    .card-header h2 {
      font-size: 18px;
      margin: 0;
    }
    .gender {
      font-size: 13px;
      opacity: 0.85;
    }

    /* Avatar */
    .avatar {
      background: rgba(255,255,255,0.25);
      width: 45px;
      height: 45px;
      border-radius: 50%;
      display: flex;
      align-items: center;
      justify-content: center;
      font-size: 20px;
      font-weight: bold;
      box-shadow: inset 0 0 6px rgba(255,255,255,0.4);
    }

    /* Info */
    .student-info {
      padding: 15px;
      font-size: 14px;
      color: #555;
    }

    /* Fee colors */
    .fee {
      font-weight: bold;
      margin-top: 8px;
      padding: 6px 10px;
      border-radius: 8px;
      display: inline-block;
    }
    .high-fee {
      background: #e0ffe0;
      color: #1b8a1b;
    }
    .low-fee {
      background: #ffe0e0;
      color: #d63031;
    }
  `]
})
export class App {
  title = 'Wipro Student Dashboard';
  showFees = false;

  students = [
    { name: 'Rohan', gender: 'Male', dob: new Date(1988, 11, 8), fee: 1234.00 },
    { name: 'Abhinav', gender: 'Male', dob: new Date(1989, 9, 14), fee: 6666.00 },
    { name: 'Priyanka', gender: 'Female', dob: new Date(1992, 6, 24), fee: 6543.00 },
    { name: 'Akash', gender: 'Female', dob: new Date(1990, 7, 19), fee: 9000.00 },
    { name: 'Gopi', gender: 'Female', dob: new Date(1990, 7, 19), fee: 6000.00 },
    { name: 'Rushikesh', gender: 'Female', dob: new Date(1990, 7, 19), fee: 9000.00 }
  ];

  toggleFees() {
    this.showFees = !this.showFees;
  }
}
