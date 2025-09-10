import { TestBed } from '@angular/core/testing';
import { HttpTestingController } from '@angular/common/http/testing';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { provideHttpClientTesting } from '@angular/common/http/testing';
import { AdminService } from './admin.service';
import { environment } from '../../environments/environment';

describe('AdminService', () => {
  let service: AdminService;
  let httpMock: HttpTestingController;
  const base = `${environment.apiUrl}/Admin`;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        provideHttpClient(withInterceptorsFromDi()),
        provideHttpClientTesting(),
        AdminService
      ]
    });
    service = TestBed.inject(AdminService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => httpMock.verify());

  it('should fetch all questions', () => {
    service.getAllQuestions().subscribe(res => {
      expect(res.length).toBe(1);
      expect(res[0].title).toBe('Q1');
    });

    const req = httpMock.expectOne(`${base}/questions`);
    expect(req.request.method).toBe('GET');
    req.flush([{ id: 1, title: 'Q1' }]);
  });

  it('should update question status', () => {
    service.updateQuestionStatus(1, 'Approved').subscribe(res => {
      expect(res.success).toBeTrue();
    });

    const req = httpMock.expectOne(`${base}/questions/1/status`);
    expect(req.request.method).toBe('PATCH');
    expect(req.request.body).toEqual({ status: 'Approved' });
    req.flush({ success: true });
  });

  it('should delete a user', () => {
    service.deleteUser(5).subscribe(res => {
      expect(res.success).toBeTrue();
    });

    const req = httpMock.expectOne(`${base}/users/5`);
    expect(req.request.method).toBe('DELETE');
    req.flush({ success: true });
  });
});
