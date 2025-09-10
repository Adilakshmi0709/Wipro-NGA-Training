import { Component, OnInit } from '@angular/core';
import { AdminSidebarComponent } from '../../share/admin-sidebar/admin-sidebar';
import { AuthService } from '../../services/auth.service';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-dashboard',
  imports: [AdminSidebarComponent, CommonModule],
  templateUrl: './dashboard.html',
  styleUrls: ['./dashboard.css'],
  standalone: true
})
export class DashboardComponent implements OnInit {
  username: string | null = '';
  role: string | null = '';
  sidebarOpen = false; 

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.username = this.authService.getUsername() || 'Admin';
    this.role = this.authService.getRole() || 'Admin';
  }
  toggleSidebar() {
    this.sidebarOpen = !this.sidebarOpen;
  }
}
