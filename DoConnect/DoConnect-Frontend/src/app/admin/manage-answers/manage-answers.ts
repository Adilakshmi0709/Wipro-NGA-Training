import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminService } from '../../services/admin.service';
import { AdminSidebarComponent } from '../../share/admin-sidebar/admin-sidebar';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-manage-answers',
  standalone: true,
  imports: [CommonModule, AdminSidebarComponent],
  templateUrl: './manage-answers.html',
  styleUrls: ['./manage-answers.css']
})
export class ManageAnswersComponent implements OnInit {
  answers: any[] = [];
  sidebarOpen = false; 
  apiBaseUrl = environment.apiUrl.replace('/api', '');
  previewImage: string | null = null;

  constructor(private admin: AdminService) {}

  ngOnInit(): void {
    this.loadAnswers();
  }

  loadAnswers() {
    this.admin.getAllAnswers().subscribe({
      next: (res) => this.answers = res,
      error: (err) => console.error('Failed to load answers', err)
    });
  }

  approve(id: number) {
    this.admin.updateAnswerStatus(id, 'Approved').subscribe(() => this.loadAnswers());
  }

  reject(id: number) {
    this.admin.updateAnswerStatus(id, 'Rejected').subscribe(() => this.loadAnswers());
  }

  delete(id: number) {
    this.admin.deleteAnswer(id).subscribe(() => this.loadAnswers());
  }
  toggleSidebar() {
    this.sidebarOpen = !this.sidebarOpen;
  }
  openPreview(img: string) {
    this.previewImage = img;
  }

  closePreview() {
    this.previewImage = null;
  }
}
