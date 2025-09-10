import { TestBed } from '@angular/core/testing';
import { HttpTestingController } from '@angular/common/http/testing';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { provideHttpClientTesting } from '@angular/common/http/testing';
import { QuestionService } from './question.service';
import { environment } from '../../environments/environment';

describe('QuestionService', () => {
  let service: QuestionService;
  let httpMock: HttpTestingController;
  const base = `${environment.apiUrl}/questions`;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        provideHttpClient(withInterceptorsFromDi()),
        provideHttpClientTesting(),
        QuestionService
      ]
    });
    service = TestBed.inject(QuestionService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => httpMock.verify());

  it('should create a question', () => {
    const formData = new FormData();
    formData.append('title', 'New Q');

    service.createQuestion(formData).subscribe(res => {
      expect(res.id).toBe(1);
    });

    const req = httpMock.expectOne(base);
    expect(req.request.method).toBe('POST');
    req.flush({ id: 1, title: 'New Q' });
  });

  it('should fetch all questions', () => {
    service.getQuestions().subscribe(res => {
      expect(res.length).toBe(2);
    });

    const req = httpMock.expectOne(base);
    expect(req.request.method).toBe('GET');
    req.flush([{ id: 1 }, { id: 2 }]);
  });

  it('should search questions', () => {
    service.searchQuestions('angular').subscribe(res => {
      expect(res[0].title).toBe('Angular');
    });

    const req = httpMock.expectOne(`${base}?query=angular`);
    expect(req.request.method).toBe('GET');
    req.flush([{ id: 1, title: 'Angular' }]);
  });
});
