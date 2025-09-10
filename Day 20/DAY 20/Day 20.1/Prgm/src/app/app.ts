import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  template:
  `
     <h2 style="color: green; font-size: 18px;">Welcome to the Dashboard</h2>
     <h3 style="color: purple; font-size: 18px;">Welcome to the Dashboard</h3>
  
  
  `,
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('stylesdemo');
}