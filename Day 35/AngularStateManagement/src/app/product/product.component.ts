import { Component } from '@angular/core';
import { StateService } from '../services/state.service';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent {
  constructor(private stateService: StateService) {}

  addToCart(product: string) {
    this.stateService.addToCart(product);
    alert(`Added ${product} to cart!`);
  }
}