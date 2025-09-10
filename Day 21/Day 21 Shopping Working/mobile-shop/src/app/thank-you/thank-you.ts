import { Component } from '@angular/core';

@Component({
  selector: 'app-thank-you',
  standalone: true,
  template: `
    <h1 style="text-align:center; color:#27ae60; font-family:Arial; font-size:36px; animation:fadeIn 1s ease;">🎉 Thank You!</h1>
    <p style="text-align:center; color:#2c3e50; font-size:18px; font-family:Verdana; margin-top:10px; animation:fadeInUp 1.5s ease;">
      Your order has been placed successfully. ✅
    </p>

    <p style="text-align:center; color:#8e44ad; font-size:16px; margin-top:15px; font-style:italic; animation:fadeInUp 2.5s ease;">
      😊 Happy to serve you! Your products will be packed soon with love ❤️
    </p>

    <div style="text-align:center; margin-top:30px; animation:fadeIn 3s ease;">
      <span style="font-size:50px;">🛍️📦</span>
    </div>

    <style>
      @keyframes fadeIn {
        from {opacity:0;}
        to {opacity:1;}
      }
      @keyframes fadeInUp {
        from {opacity:0; transform:translateY(20px);}
        to {opacity:1; transform:translateY(0);}
      }
    </style>
  `


})
export class ThankYouComponent {}