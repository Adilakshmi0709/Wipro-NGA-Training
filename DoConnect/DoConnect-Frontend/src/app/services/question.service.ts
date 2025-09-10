import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Question } from '../models/question.model';

@Injectable({ providedIn: 'root' })
export class QuestionService {
  private base = `${environment.apiUrl}/questions`;

  constructor(private http: HttpClient) {}

  createQuestion(data: FormData): Observable<any> {
    return this.http.post(this.base, data);
  }

  getQuestions(): Observable<Question[]> {
    return this.http.get<Question[]>(this.base);
  }

  getMyQuestions(): Observable<Question[]> {
    return this.http.get<Question[]>(`${this.base}/my-questions`);
  }

  getById(id: number): Observable<Question> {
    return this.http.get<Question>(`${this.base}/${id}`);
  }

  // ✅ new search method
  searchQuestions(query: string): Observable<Question[]> {
    return this.http.get<Question[]>(`${this.base}?query=${encodeURIComponent(query)}`);
  }
}
