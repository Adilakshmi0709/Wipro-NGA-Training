import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StateService {
  private userAuthSubject = new BehaviorSubject<boolean>(false);
  private cartItemsSubject = new BehaviorSubject<string[]>([]);

  userAuth$: Observable<boolean> = this.userAuthSubject.asObservable();
  cartItems$: Observable<string[]> = this.cartItemsSubject.asObservable();

  setUserAuth(isAuthenticated: boolean) {
    this.userAuthSubject.next(isAuthenticated);
  }

  addToCart(item: string) {
    const currentItems = this.cartItemsSubject.value;
    this.cartItemsSubject.next([...currentItems, item]);
  }

  removeFromCart(item: string) {
    const currentItems = this.cartItemsSubject.value;
    this.cartItemsSubject.next(currentItems.filter(i => i !== item));
  }
}