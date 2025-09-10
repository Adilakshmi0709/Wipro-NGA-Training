import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-give-answer',
  templateUrl: './give-answer.html',
  styleUrls: ['./give-answer.css'],
  standalone: true,
  imports: [CommonModule, FormsModule]
})
export class GiveAnswerComponent implements OnInit {
  questions: any[] = [];
  selectedQuestion: any = null;
  loading = false;
  apiBaseUrl = environment.apiUrl.replace('/api', '');

  answerText: string = '';
  selectedImage: File | null = null;
  previewImage: string | null = null;
  imageError: string | null = null;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.loadQuestions();
  }

  loadQuestions() {
    this.loading = true;
    this.http.get<any[]>(`${environment.apiUrl}/questions`).subscribe({
      next: (res) => {
        this.questions = res;
        this.loading = false;
      },
      error: () => {
        this.loading = false;
      }
    });
  }

  viewQuestion(id: number) {
    this.loading = true;
    this.http.get(`${environment.apiUrl}/questions/${id}`).subscribe({
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
    this.answerText = '';
    this.selectedImage = null;
  }

  onFileChange(event: any) {
  if (event.target.files.length > 0) {
    const file: File = event.target.files[0];
    const allowedExtensions = ['jpg', 'jpeg', 'png', 'gif', 'webp'];
    const fileExtension = file.name.split('.').pop()?.toLowerCase();

    if (!fileExtension || !allowedExtensions.includes(fileExtension)) {
      this.imageError = 'Only image files (jpg, jpeg, png, gif, webp) are allowed.';
      event.target.value = ''; // reset the input
      this.selectedImage = null;
      return;
    }
    this.imageError = null;
    this.selectedImage = file;
    }
  }

  submitAnswer() {
    if (!this.answerText.trim()) {
      alert('Please enter your answer');
      return;
    }

    const formData = new FormData();
    formData.append('questionId', this.selectedQuestion.questionId.toString());
    formData.append('answerText', this.answerText);
    if (this.selectedImage) {
      formData.append('image', this.selectedImage);
    }

    this.http.post(`${environment.apiUrl}/answers`, formData).subscribe({
      next: () => {
        alert('Answer submitted successfully!');
        this.backToList();
      },
      error: () => {
        alert('Failed to submit answer');
      }
    });
  }
  openPreview(img: string) {
    this.previewImage = img;
  }

  closePreview() {
    this.previewImage = null;
  }
}
