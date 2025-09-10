import { Component, OnInit } from '@angular/core';
import { QuestionService } from '../../services/question.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-home',
  templateUrl: './home.html',
  styleUrls: ['./home.css'],
  standalone: true,
  imports: [CommonModule, FormsModule]
})
export class HomeComponent implements OnInit {
  questions: any[] = [];
  selectedQuestion: any = null;
  loading = false;
  apiBaseUrl = environment.apiUrl.replace('/api', '');
  noResults = false;   // ✅ flag for "not found"

  searchQuery: string = '';
  previewImage: string | null = null;

  constructor(private questionService: QuestionService) {}

  ngOnInit(): void {
    this.loadQuestions();
  }

  loadQuestions() {
    this.loading = true;
    this.noResults = false;  // ✅ reset
    this.questionService.getQuestions().subscribe({
      next: (res) => {
        this.questions = res;
        this.loading = false;
        this.noResults = res.length === 0;
      },
      error: () => {
        this.loading = false;
        this.questions = [];
        this.noResults = true;
      }
    });
  }

  searchQuestions() {
    if (!this.searchQuery.trim()) {
      this.loadQuestions();
      return;
    }

    this.loading = true;
    this.noResults = false;

    this.questionService.searchQuestions(this.searchQuery).subscribe({
      next: (res) => {
        this.questions = res;
        this.loading = false;
        this.selectedQuestion = null;

        // ✅ check if nothing found
        this.noResults = res.length === 0;
      },
      error: () => {
        this.loading = false;
        this.questions = [];
        this.noResults = true;
      }
    });
  }

  clearSearch() {
    this.searchQuery = '';
    this.noResults = false;
    this.loadQuestions();
  }

  viewQuestion(id: number) {
    this.loading = true;
    this.questionService.getById(id).subscribe({
      next: (res) => {
        this.selectedQuestion = res;
        this.loading = false;
      },
      error: () => {
        this.loading = false;
      }
    });
  }

  backToList() {
    this.selectedQuestion = null;
  }

  openPreview(img: string) {
    this.previewImage = img;
  }

  closePreview() {
    this.previewImage = null;
  }
}
