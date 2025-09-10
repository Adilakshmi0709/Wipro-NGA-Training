import { Component, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { ToastComponent } from '../../share/toast/toast';

@Component({
  selector: 'app-login',
  templateUrl: './login.html',
  styleUrls: ['./login.css'],
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, ToastComponent]
})
export class LoginComponent {
  form: any;
  @ViewChild(ToastComponent) toast!: ToastComponent;
  showPassword = false;

  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router) {
    this.form = this.fb.nonNullable.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  login() {
    if (this.form.invalid) {
      this.toast.show('Please enter both username and password.', 'danger');
      return;
    }

    this.auth.login(this.form.value).subscribe({
      next: (res) => {
        this.auth.handleLoginResponse(res, this.router);
        this.toast.show('Login successful!', 'success');
      },
      error: () => this.toast.show('Invalid credentials', 'danger')
    });
  }
  goToForgot() {
    console.log('Forgot password clicked');        // debug: should appear in console
    this.router.navigate(['/forgot-password']).catch(err => {
      console.error('Navigation error:', err);
    });
  }
}
