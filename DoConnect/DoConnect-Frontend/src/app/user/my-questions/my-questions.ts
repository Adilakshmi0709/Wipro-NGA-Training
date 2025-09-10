import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-my-questions',
  templateUrl: './my-questions.html',
  styleUrls: ['./my-questions.css'],
  standalone: true,
  imports: [CommonModule]
})
export class MyQuestionsComponent implements OnInit {
  questions: any[] = [];
  loading = true;
  apiBaseUrl = environment.apiUrl.replace('/api', '');

  // 👇 add for preview
  previewImage: string | null = null;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get<any[]>(`${environment.apiUrl}/questions/my-questions`).subscribe({
      next: (res) => {
        this.questions = res;
        this.loading = false;
      },
      error: () => {
        this.loading = false;
      }
    });
  }

  // 👇 methods for image preview
  openPreview(img: string) {
    this.previewImage = img;
  }

  closePreview() {
    this.previewImage = null;
  }
}
