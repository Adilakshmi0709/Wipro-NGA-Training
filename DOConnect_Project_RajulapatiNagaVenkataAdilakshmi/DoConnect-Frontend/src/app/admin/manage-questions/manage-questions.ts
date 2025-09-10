import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminService } from '../../services/admin.service';
import { AdminSidebarComponent } from '../../share/admin-sidebar/admin-sidebar';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-manage-questions',
  standalone: true,
  imports: [CommonModule, AdminSidebarComponent],
  templateUrl: './manage-questions.html',
  styleUrls: ['./manage-questions.css']
})
export class ManageQuestionsComponent implements OnInit {
  questions: any[] = [];
  sidebarOpen = false;
  apiBaseUrl = environment.apiUrl.replace('/api', '');
  previewImage: string | null = null;

  constructor(private admin: AdminService) {}

  ngOnInit(): void {
    this.loadQuestions();
  }

  loadQuestions() {
    this.admin.getAllQuestions().subscribe({
      next: (res) => this.questions = res,
      error: (err) => console.error('Failed to load questions', err)
    });
  }

  approve(id: number) {
    this.admin.updateQuestionStatus(id, 'Approved').subscribe(() => this.loadQuestions());
  }

  reject(id: number) {
    this.admin.updateQuestionStatus(id, 'Rejected').subscribe(() => this.loadQuestions());
  }

  delete(id: number) {
    this.admin.deleteQuestion(id).subscribe(() => this.loadQuestions());
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
