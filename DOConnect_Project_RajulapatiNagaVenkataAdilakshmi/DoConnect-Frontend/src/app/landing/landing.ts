import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.html',
  styleUrls: ['./landing.css'],
  standalone: true,
  imports: [CommonModule, RouterModule]
})
export class LandingComponent implements OnInit {
  isLoggedIn = false;
  username: string | null = null;
  role: string | null = null;

  constructor(private auth: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.isLoggedIn = this.auth.isLoggedIn();
    this.role = this.auth.getRole();

    if (this.isLoggedIn) {
      this.username = localStorage.getItem('firstName') || localStorage.getItem('username');
    }
  }

  goToApp() {
    if (this.role === 'Admin') {
      this.router.navigate(['/admin/dashboard']);
    } else {
      this.router.navigate(['/home']);
    }
  }
}
