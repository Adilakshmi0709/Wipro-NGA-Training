import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Answer } from '../models/answer.model';

@Injectable({ providedIn: 'root' })
export class AnswerService {
  private base = `${environment.apiUrl}/answers`;

  constructor(private http: HttpClient) {}

  createAnswer(data: FormData): Observable<any> {
    return this.http.post(this.base, data);
  }

  getMyAnswers(): Observable<Answer[]> {
    return this.http.get<Answer[]>(`${this.base}/my-answers`);
  }
}
