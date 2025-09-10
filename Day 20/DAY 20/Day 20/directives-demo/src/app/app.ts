
// import { Component, signal } from '@angular/core';
// import { CommonModule } from '@angular/common'; // Needed for @if, @for, and @switch

// @Component({
//   selector: 'app-root',
//   standalone: true,
//   imports: [CommonModule],
//   template: `
//     <h1>{{ title() }}</h1>
//     Hello {{ name }}

//     <!-- ngIf -->
//     @if (showmessage) {
//       <p>Welcome!</p>
//     }

//     <!-- ngFor -->
//     <table border="1" cellpadding="5" style="margin-top: 20px;">
//       @for (f of data; track f.id) {
//         <tr>
//           <td>{{ f.name }}</td>
//         </tr>
//       }
//       @empty {
//         <tr>
//           <td>No data available</td>
//         </tr>
//       }
//     </table>

//     <!-- ngSwitch -->
//     <div class="status-wrapper" style="margin-top: 20px;">
//       @switch (status) {
//         @case ('pending') {
//           <p>Status: Pending Approval</p>
//         }
//         @case ('approved') {
//           <p>Status: Approved</p>
//         }
//         @case ('rejected') {
//           <p>Status: Rejected</p>
//         }
//         @default {
//           <p>Status: Unknown</p>
//         }
//       }
//     </div>
//   `,
//   styles: [`
//     h1 { color: #2c3e50; }
//     table { border-collapse: collapse; }
//     .status-wrapper { padding: 10px; border: 1px solid #ccc; }
//   `]
// })
// export class App {
//   protected readonly title = signal('directives_demo');

//   name: string = 'directives demo';
//   showmessage = true;

//   data = [
//     { id: 1, name: 'Apple' },
//     { id: 2, name: 'Banana' },
//     { id: 3, name: 'Mango' }
//   ];

//   // for ngSwitch
//   status: string = 'pending'; // Try 'approved', 'rejected', or something else
// }


import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common'; // Needed for @if, @for, @switch, and pipes

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  template: `
    <h1>{{ title() }}</h1>
    Hello {{ name }}

    <!-- ngIf -->
    @if (showmessage) {
      <p>Welcome!</p>
    }

    <!-- ngFor -->
    <table border="1" cellpadding="5" style="margin-top: 20px;">
      @for (f of data; track f.id) {
        <tr>
          <td>{{ f.name }}</td>
        </tr>
      }
      @empty {
        <tr>
          <td>No data available</td>
        </tr>
      }
    </table>

    <!-- ngSwitch -->
    <div class="status-wrapper" style="margin-top: 20px;">
      @switch (status) {
        @case ('pending') {
          <p>Status: Pending Approval</p>
        }
        @case ('approved') {
          <p>Status: Approved</p>
        }
        @case ('rejected') {
          <p>Status: Rejected</p>
        }
        @default {
          <p>Status: Unknown</p>
        }
      }
    </div>

    <!-- Pipes Example -->
    <div style="margin-top: 20px; border: 1px solid #ccc; padding: 10px;">
      <h3>Pipes Demo</h3>
      <p>Company Name: {{ companyName | uppercase }}</p>
      <p>Purchase Date: {{ purchaseDate | date:'fullDate' }}</p>
      <p>Total Amount: {{ totalAmount | currency:'USD':'symbol':'1.2-2' }}</p>
      <p>Discount Rate: {{ discountRate | percent:'1.2-2' }}</p>
      <p>Note: {{ note | slice:0:30 }}...</p>
      <p>Product ID: {{ productDetails.id }}</p>
      <p>Product Name: {{ productDetails.name }}</p>
      <p>Product Specs: {{ productDetails.specs | json }}</p>
    </div>
  `,
  styles: [`
    h1 { color: #2c3e50; }
    table { border-collapse: collapse; }
    .status-wrapper { padding: 10px; border: 1px solid #ccc; }
  `]
})
export class App {
  protected readonly title = signal('directives_and_pipes_demo');

  name: string = 'directives demo';
  showmessage = true;

  // ngFor data
  data = [
    { id: 1, name: 'Apple' },
    { id: 2, name: 'Banana' },
    { id: 3, name: 'Mango' }
  ];

  // ngSwitch
  status: string = 'pending'; // Try changing to 'approved' or 'rejected'

  // Pipes data
  companyName = 'acme technologies';
  purchaseDate = new Date(2025, 7, 9); // month is zero-based
  totalAmount = 12345.678;
  discountRate = 0.15;
  note = 'This is a limited-time offer for premium customers only.';
  productDetails = { id: 101, name: 'Laptop', specs: { ram: '16GB', cpu: 'i7' } };
}
