import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms'; 

@Component({
  selector: 'app-billing',
  standalone: true,
  imports: [CommonModule, FormsModule], 
  template: `
    <h1 style="text-align:center; color:#2c3e50; font-family:Arial;">🧾 Billing Details</h1>

    <table border="1" cellpadding="5" 
           style="border-collapse:collapse; width:100%; margin-top:20px; font-family:Arial; box-shadow:0 2px 6px rgba(0,0,0,0.1);">
      <tr style="background-color:#3498db; color:white;">
        <th>Product</th>
        <th>Price</th>
        <th>Quantity</th>
        <th>Total</th>
      </tr>
      <tr *ngFor="let item of cart" 
          style="transition:background 0.3s;" 
          onmouseover="this.style.backgroundColor='#f9f9f9';" 
          onmouseout="this.style.backgroundColor='white';">
        <td>{{item.name}}</td>
        <td style="color:#27ae60; font-weight:bold;">₹{{item.price}}</td>
        <td>
          <input type="number" [(ngModel)]="item.quantity" min="1" (input)="calculateTotal()" 
                 style="width:60px; padding:5px; text-align:center; border-radius:4px; border:1px solid #ccc; outline:none; transition:border 0.3s;"
                 onfocus="this.style.border='1px solid #3498db';" 
                 onblur="this.style.border='1px solid #ccc';">
        </td>
        <td style="color:#8e44ad; font-weight:bold;">₹{{item.price * item.quantity}}</td>
      </tr>
    </table>

    <h3 style="margin-top:20px; color:#e67e22; text-align:right;">💰 Grand Total: ₹{{grandTotal}}</h3>

    <div style="text-align:center; margin-top:20px;">
      <button (click)="submitOrder()" 
              style="padding:10px 20px; background-color:#2ecc71; color:white; border:none; border-radius:5px; cursor:pointer; font-size:16px; transition:background 0.3s;"
              onmouseover="this.style.backgroundColor='#27ae60';"
              onmouseout="this.style.backgroundColor='#2ecc71';">
        ✅ Submit Order
      </button>
    </div>
  `

})
export class BillingComponent {
  cart: any[] = [];
  grandTotal = 0;

  constructor(private router: Router) {
    const savedCart = localStorage.getItem('cart');
    this.cart = savedCart ? JSON.parse(savedCart) : [];
    this.calculateTotal();
  }

  calculateTotal() {
    this.grandTotal = this.cart.reduce((sum, item) => sum + (item.price * item.quantity), 0);
  }

  submitOrder() {
    localStorage.removeItem('cart');
    this.router.navigate(['/thank-you']);
  }
}