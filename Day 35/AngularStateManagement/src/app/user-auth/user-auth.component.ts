import { Component } from '@angular/core';
import { StateService } from '../services/state.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user-auth',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './user-auth.component.html',  // ← FIXED THIS LINE
  styleUrl: './user-auth.component.css'       // ← FIXED THIS LINE
})
export class UserAuthComponent {
  isAuthenticated = false;

  constructor(private stateService: StateService) {
    this.stateService.userAuth$.subscribe((auth: boolean) => {
      this.isAuthenticated = auth;
    });
  }

  login() {
    this.stateService.setUserAuth(true);
  }

  logout() {
    this.stateService.setUserAuth(false);
  }
}