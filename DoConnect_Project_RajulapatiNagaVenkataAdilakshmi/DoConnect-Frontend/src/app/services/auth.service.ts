import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';
import { Observable, Subject } from 'rxjs';
import { isPlatformBrowser } from '@angular/common';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private base = `${environment.apiUrl}/auth`;
  private logoutTimer: any;

  private toastSubject = new Subject<{ message: string, type: 'success' | 'danger' | 'info' }>();
  toastState$ = this.toastSubject.asObservable();

  constructor(
    private http: HttpClient,
    private router: Router,
    @Inject(PLATFORM_ID) private platformId: Object
  ) {}

  // 🔹 Toast helper
  showToast(message: string, type: 'success' | 'danger' | 'info' = 'info') {
    this.toastSubject.next({ message, type });
  }

  // ✅ login
  login(data: { username: string; password: string }): Observable<any> {
    return new Observable(observer => {
      this.http.post(`${this.base}/login`, data).subscribe({
        next: (res) => {
          this.showToast('Login successful!', 'success');
          observer.next(res);
          observer.complete();
        },
        error: (err) => {
          this.showToast(err.error?.message || 'Login failed', 'danger');
          observer.error(err);
        }
      });
    });
  }

  // ✅ register
  register(data: any): Observable<any> {
    return new Observable(observer => {
      this.http.post(`${this.base}/register`, data).subscribe({
        next: (res) => {
          this.showToast('Registration successful!', 'success');
          observer.next(res);
          observer.complete();
        },
        error: (err) => {
          this.showToast(err.error?.message || 'Registration failed', 'danger');
          observer.error(err);
        }
      });
    });
  }

  // ✅ save token safely
  setToken(token: string) {
    if (isPlatformBrowser(this.platformId)) {
      localStorage.setItem('token', token);
      this.startAutoLogout(token);
    }
  }

  // ✅ get token safely
  getToken(): string | null {
    if (isPlatformBrowser(this.platformId)) {
      return localStorage.getItem('token');
    }
    return null;
  }

  // ✅ save role safely
  setRole(role: string) {
    if (isPlatformBrowser(this.platformId)) {
      localStorage.setItem('role', role);
    }
  }

  getRole(): string | null {
    if (isPlatformBrowser(this.platformId)) {
      return localStorage.getItem('role');
    }
    return null;
  }

  setUsername(username: string) {
    if (isPlatformBrowser(this.platformId)) {
      localStorage.setItem('username', username);
    }
  }

  getUsername(): string | null {
    if (isPlatformBrowser(this.platformId)) {
      return localStorage.getItem('username');
    }
    return null;
  }

  // ✅ check login status safely
  isLoggedIn(): boolean {
    if (isPlatformBrowser(this.platformId)) {
      const token = this.getToken();
      return !!token && !this.isTokenExpired(token);
    }
    return false;
  }

  // ✅ check token expiry
  private isTokenExpired(token: string): boolean {
    try {
      const decoded: any = jwtDecode(token);
      if (!decoded.exp) return true;
      const now = Math.floor(Date.now() / 1000);
      return decoded.exp < now;
    } catch {
      return true;
    }
  }

  // ✅ auto logout when token expires
  private startAutoLogout(token: string) {
    if (this.logoutTimer) clearTimeout(this.logoutTimer);

    const decoded: any = jwtDecode(token);
    if (!decoded.exp) return;

    const expiresAt = decoded.exp * 1000;
    const timeout = expiresAt - Date.now();

    if (timeout > 0) {
      this.logoutTimer = setTimeout(() => {
        this.showToast('Session expired. Please login again.', 'danger');
        this.logout();
      }, timeout);
    }
  }

  // ✅ logout
  logout() {
    if (isPlatformBrowser(this.platformId)) {
      localStorage.removeItem('token');
      localStorage.removeItem('role');
      localStorage.removeItem('username');
    }
    if (this.logoutTimer) clearTimeout(this.logoutTimer);
    this.router.navigate(['/login']);
  }

  // ✅ handle login response (redirect by role)
  handleLoginResponse(res: any, router: Router) {
    if (res.token) {
      this.setToken(res.token);
      this.setRole(res.role);

      if (res.username) localStorage.setItem('username', res.username);
      if (res.firstName) localStorage.setItem('firstName', res.firstName);
      if (res.lastName) localStorage.setItem('lastName', res.lastName);
      if (res.role) localStorage.setItem('role', res.role);
      if (res.email) localStorage.setItem('email', res.email);

      if (res.role === 'Admin') {
        router.navigate(['/admin/dashboard']);
      } else {
        router.navigate(['/home']);
      }
    }
  }

  // ✅ get current user
  getCurrentUser(): Observable<any> {
    const token = this.getToken();
    if (token) {
      return this.http.get(`${environment.apiUrl}/users/me`, {
        headers: { Authorization: `Bearer ${token}` }
      });
    }
    return new Observable(observer => {
      observer.error('No token found');
    });
  }

  // ✅ forgot password
  forgotPassword(email: string) {
    return new Observable(observer => {
      this.http.post(`${this.base}/forgot-password`, { email }).subscribe({
        next: (res) => {
          this.showToast('User found with the given username or email, you can reset your password now!', 'info');
          observer.next(res);
          observer.complete();
        },
        error: (err) => {
          this.showToast(err.error?.message || 'User not found with the given username or email', 'danger');
          observer.error(err);
        }
      });
    });
  }

  // ✅ reset password
  resetPassword(token: string, newPassword: string) {
    return new Observable(observer => {
      this.http.post(`${this.base}/reset-password`, { token, newPassword }).subscribe({
        next: (res) => {
          this.showToast('Password reset successful!', 'success');
          observer.next(res);
          observer.complete();
        },
        error: (err) => {
          this.showToast(err.error?.message || 'Password reset failed', 'danger');
          observer.error(err);
        }
      });
    });
  }
}
