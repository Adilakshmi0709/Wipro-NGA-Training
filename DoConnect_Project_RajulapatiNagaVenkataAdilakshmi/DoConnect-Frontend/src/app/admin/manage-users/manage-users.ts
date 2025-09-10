import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminService } from '../../services/admin.service';
import { AdminSidebarComponent } from '../../share/admin-sidebar/admin-sidebar';

@Component({
  selector: 'app-manage-users',
  standalone: true,
  imports: [CommonModule, AdminSidebarComponent],
  templateUrl: './manage-users.html',
  styleUrls: ['./manage-users.css']
})
export class ManageUsersComponent implements OnInit {
  users: any[] = [];
  selectedUser: any = null;
  sidebarOpen = false;

  constructor(private admin: AdminService) {}

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers() {
    this.admin.getUsers().subscribe({
      next: (res) => this.users = res,
      error: (err) => console.error('Failed to load users', err)
    });
  }

  // Show user details in modal
  showDetails(user: any) {
    this.selectedUser = user;
  }

  // Change role
  changeRole(id: number, role: string) {
    this.admin.updateUserRole(id, role).subscribe(() => this.loadUsers());
  }

  // Delete user
  delete(id: number) {
    if (confirm('Are you sure you want to delete this user?')) {
      this.admin.deleteUser(id).subscribe(() => this.loadUsers());
    }
  }

  // Close details modal
  closeModal() {
    this.selectedUser = null;
  }
  toggleSidebar() {
  this.sidebarOpen = !this.sidebarOpen;
}
}
