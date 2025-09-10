import { TestBed } from '@angular/core/testing';
import { HttpTestingController } from '@angular/common/http/testing';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { provideHttpClientTesting } from '@angular/common/http/testing';
import { AnswerService } from './answer.service';
import { environment } from '../../environments/environment';

describe('AnswerService', () => {
  let service: AnswerService;
  let httpMock: HttpTestingController;
  const base = `${environment.apiUrl}/answers`;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        provideHttpClient(withInterceptorsFromDi()),
        provideHttpClientTesting(),
        AnswerService
      ]
    });
    service = TestBed.inject(AnswerService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => httpMock.verify());

  it('should create an answer', () => {
    const formData = new FormData();
    formData.append('content', 'Test answer');

    service.createAnswer(formData).subscribe(res => {
      expect(res.id).toBe(1);
    });

    const req = httpMock.expectOne(base);
    expect(req.request.method).toBe('POST');
    req.flush({ id: 1, content: 'Test answer' });
  });

  it('should fetch my answers', () => {
    service.getMyAnswers().subscribe(res => {
      expect(res.length).toBe(1);
    });

    const req = httpMock.expectOne(`${base}/my-answers`);
    expect(req.request.method).toBe('GET');
    req.flush([{ id: 1, content: 'My answer' }]);
  });
});
