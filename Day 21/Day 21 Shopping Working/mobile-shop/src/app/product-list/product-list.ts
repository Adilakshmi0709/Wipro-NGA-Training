import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [CommonModule],
  template: `
    <h1 style="text-align:center; color:#2c3e50; font-family:Arial;">📱 Mobile Phones</h1>

    <div *ngFor="let mobile of mobiles" 
         style="border:1px solid #ccc; padding:15px; margin:10px; border-radius:8px; box-shadow:0 2px 5px rgba(0,0,0,0.1); transition:transform 0.2s; cursor:pointer;"
         onmouseover="this.style.transform='scale(1.03)'; this.style.backgroundColor='#f9f9f9';" 
         onmouseout="this.style.transform='scale(1)'; this.style.backgroundColor='white';">
      
      <h3 style="color:#34495e; margin-bottom:5px;">{{mobile.name}}</h3>
      <p style="color:#7f8c8d;">{{mobile.details}}</p>
      <p style="font-weight:bold; color:#27ae60;">Price: ₹{{mobile.price}}</p>
      
      <button (click)="addToCart(mobile)" 
              style="padding:8px 15px; background-color:#3498db; color:white; border:none; border-radius:4px; cursor:pointer; transition:background 0.3s;"
              onmouseover="this.style.backgroundColor='#2980b9';"
              onmouseout="this.style.backgroundColor='#3498db';">
        ➕ Add to Cart
      </button>
    </div>

    <div style="text-align:center; margin-top:20px;">
      <button (click)="goToBilling()" 
              [disabled]="cart.length === 0" 
              style="padding:10px 20px; background-color:#e67e22; color:white; border:none; border-radius:5px; cursor:pointer; font-size:16px; transition:background 0.3s;"
              onmouseover="if(!this.disabled){this.style.backgroundColor='#d35400';}"
              onmouseout="if(!this.disabled){this.style.backgroundColor='#e67e22';}">
        ✅ Submit
      </button>
      <p *ngIf="cart.length > 0" style="color:#16a085; margin-top:10px;">🛒 {{cart.length}} item(s) in cart</p>
    </div>
  `

})
export class ProductListComponent {
  mobiles = [
    { name: 'Samsung Galaxy S23', details: '8GB RAM, 128GB Storage', price: 80000 },
    { name: 'iPhone 14', details: '6GB RAM, 128GB Storage', price: 75000 },
    { name: 'OnePlus 11', details: '12GB RAM, 256GB Storage', price: 60000 },
    { name: 'Xiaomi 13 Pro', details: '12GB RAM, 256GB Storage', price: 55000 },
    { name: 'Google Pixel 7', details: '8GB RAM, 128GB Storage', price: 65000 }
  ];

  cart: any[] = [];

  constructor(private router: Router) {}

  addToCart(mobile: any) {
    this.cart.push({ ...mobile, quantity: 1 });
  }

  goToBilling() {
    localStorage.setItem('cart', JSON.stringify(this.cart));
    this.router.navigate(['/billing']);
  }
}