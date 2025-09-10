import { TestBed } from '@angular/core/testing';
import { HttpTestingController } from '@angular/common/http/testing';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { provideHttpClientTesting } from '@angular/common/http/testing';
import { Router } from '@angular/router';
import { AuthService } from './auth.service';
import { environment } from '../../environments/environment';

describe('AuthService', () => {
  let service: AuthService;
  let httpMock: HttpTestingController;
  let routerSpy: jasmine.SpyObj<Router>;
  const base = `${environment.apiUrl}/auth`;

  beforeEach(() => {
    routerSpy = jasmine.createSpyObj('Router', ['navigate']);
    TestBed.configureTestingModule({
      providers: [
        provideHttpClient(withInterceptorsFromDi()),
        provideHttpClientTesting(),
        { provide: Router, useValue: routerSpy },
        AuthService
      ]
    });
    service = TestBed.inject(AuthService);
    httpMock = TestBed.inject(HttpTestingController);
    localStorage.clear();
  });

  afterEach(() => httpMock.verify());

  it('should login successfully', () => {
    const loginData = { username: 'test', password: '1234' };

    service.login(loginData).subscribe(res => {
      expect(res.token).toBe('abc');
    });

    const req = httpMock.expectOne(`${base}/login`);
    expect(req.request.method).toBe('POST');
    req.flush({ token: 'abc', role: 'User' });
  });

  it('should save token in localStorage', () => {
  // valid 3-part JWT with fake payload
  const mockToken =
    'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.' + // header
    'eyJleHAiOjQ3NjY0OTY4MDB9.' +             // payload with expiry
    'signature';                              // fake signature

  service.setToken(mockToken);

  expect(localStorage.getItem('token')).toBe(mockToken);
});


  it('should logout and clear storage', () => {
    localStorage.setItem('token', 'abc');
    service.logout();
    expect(localStorage.getItem('token')).toBeNull();
    expect(routerSpy.navigate).toHaveBeenCalledWith(['/login']);
  });

  it('should redirect admin after login', () => {
  const mockToken =
    'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.' + // header
    'eyJleHAiOjQ3NjY0OTY4MDB9.' +             // payload with expiry
    'signature';                              // fake signature

  const res = { token: mockToken, role: 'Admin', username: 'admin' };

  service.handleLoginResponse(res, routerSpy);

  expect(localStorage.getItem('role')).toBe('Admin');
  expect(routerSpy.navigate).toHaveBeenCalledWith(['/admin/dashboard']);
});

});
