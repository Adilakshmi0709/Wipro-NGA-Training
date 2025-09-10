import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-forgot-password',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './forgot-password.html',
  styleUrls: ['./forgot-password.css']
})
export class ForgotPasswordComponent {
  form: FormGroup;
  loading = false;
  errorMessage = '';

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private router: Router
  ) {
    this.form = this.fb.group({
      identifier: ['', Validators.required]   // ✅ username or email
    });
  }

  submit() {
    if (this.form.invalid) return;

    this.loading = true;
    this.errorMessage = '';

    this.http.post(`${environment.apiUrl}/auth/forgot-password`, {
      usernameOrEmail: this.form.value.identifier   // ✅ backend expects this
    }).subscribe({
      next: () => {
        this.loading = false;
        this.router.navigate(['/reset-password'], {
          queryParams: { identifier: this.form.value.identifier }
        });
      },
      error: (err) => {
        this.loading = false;
        this.errorMessage = err.error?.message || 'Validation failed. Please check your input.';
      }
    });
  }

  backToLogin() {
    this.router.navigate(['/login']);
  }
}
