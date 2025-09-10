import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.html',
  styleUrls: ['./profile.css'],
  standalone: true,
  imports: [CommonModule]
})
export class ProfileComponent implements OnInit {
  user: any = null;
  loading = true;
  errorMessage: string | null = null;

  constructor(private auth: AuthService) {}

  ngOnInit(): void {
    if (this.auth.isLoggedIn()) {
      this.auth.getCurrentUser().subscribe({
        next: (res) => {
          this.user = res;
          this.loading = false;
        },
        error: () => {
          this.errorMessage = 'Failed to load profile details.';
          this.loading = false;
        }
      });
    } else {
      this.errorMessage = 'You must be logged in to view this page.';
      this.loading = false;
    }
  }
}
