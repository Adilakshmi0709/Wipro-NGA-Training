import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-admin-sidebar',
  templateUrl: './admin-sidebar.html',
  styleUrls: ['./admin-sidebar.css'],
  standalone: true,
  imports: [CommonModule, RouterModule]
})
export class AdminSidebarComponent {}
