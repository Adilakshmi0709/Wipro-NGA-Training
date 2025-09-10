import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AdminService {
  private base = `${environment.apiUrl}/Admin`;

  constructor(private http: HttpClient) {}

  // Questions
  getAllQuestions(): Observable<any> {
    return this.http.get<any[]>(`${this.base}/questions`);
  }

  updateQuestionStatus(id: number, status: string): Observable<any> {
  return this.http.patch(`${this.base}/questions/${id}/status`, { status });
}


  deleteQuestion(id: number): Observable<any> {
    return this.http.delete(`${this.base}/questions/${id}`);
  }

  // Answers
  getAllAnswers(): Observable<any> {
    return this.http.get<any[]>(`${this.base}/answers`);
  }

  updateAnswerStatus(id: number, status: string): Observable<any> {
    return this.http.patch(`${this.base}/answers/${id}/status`, { status: status });
  }

  deleteAnswer(id: number): Observable<any> {
    return this.http.delete(`${this.base}/answers/${id}`);
  }

  // Users
  getUsers(): Observable<any> {
    return this.http.get(`${this.base}/users`);
  }

  updateUserRole(id: number, role: string): Observable<any> {
    return this.http.patch(`${this.base}/users/${id}/role`, { role });
  }

  deleteUser(id: number): Observable<any> {
    return this.http.delete(`${this.base}/users/${id}`);
  }
}
