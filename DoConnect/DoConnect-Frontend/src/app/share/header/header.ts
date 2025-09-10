import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.html',
  styleUrls: ['./header.css'],
  standalone: true,
  imports: [CommonModule, RouterModule]
})
export class HeaderComponent {
  navbarCollapsed = true;

  constructor(private auth: AuthService, private router: Router) {}

  isLoggedIn(): boolean {
    return this.auth.isLoggedIn();
  }

  getRole(): string | null {
    return this.auth.getRole();
  }

  getUsername(): string | null {
    return `${localStorage.getItem('firstName')} ${localStorage.getItem('lastName')}` || localStorage.getItem('username');
  }

  logout() {
    this.auth.logout();
  }
  closeNavbar() {
    this.navbarCollapsed = true;
  }

  // ✅ toggle navbar (hamburger)
  toggleNavbar() {
    this.navbarCollapsed = !this.navbarCollapsed;
  }
}
