import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-my-answers',
  templateUrl: './my-answers.html',
  styleUrls: ['./my-answers.css'],
  standalone: true,
  imports: [CommonModule]
})
export class MyAnswersComponent implements OnInit {
  answers: any[] = [];
  loading = true;
  apiBaseUrl = environment.apiUrl.replace('/api', ''); // removes /api part

  // 👇 new field for preview
  previewImage: string | null = null;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get<any[]>(`${environment.apiUrl}/answers/my-answers`).subscribe({
      next: (res) => {
        this.answers = res;
        this.loading = false;
      },
      error: () => {
        this.loading = false;
      }
    });
  }

  // 👇 preview handlers
  openPreview(img: string) {
    this.previewImage = img;
  }

  closePreview() {
    this.previewImage = null;
  }
}
