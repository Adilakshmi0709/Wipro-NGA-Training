import { Component, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, Validators, ReactiveFormsModule, AbstractControl, ValidationErrors } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { ToastComponent } from '../../share/toast/toast';

function passwordMatchValidator(control: AbstractControl): ValidationErrors | null {
  const password = control.get('password')?.value;
  const confirmPassword = control.get('confirmPassword')?.value;
  return password === confirmPassword ? null : { passwordMismatch: true };
}

@Component({
  selector: 'app-register',
  templateUrl: './register.html',
  styleUrls: ['./register.css'],
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, ToastComponent]
})
export class RegisterComponent {
  form;
  @ViewChild(ToastComponent) toast!: ToastComponent;
  showPassword = false;
  showConfirmPassword = false;

  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router) {
    this.form = this.fb.nonNullable.group(
      {
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
        username: ['', Validators.required],
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required, Validators.minLength(6)]],
        confirmPassword: ['', Validators.required]
      },
      { validators: passwordMatchValidator }
    );
  }

  register() {
    if (this.form.invalid) {
      this.toast.show('Please fill all fields correctly.', 'danger');
      return;
    }

    const { confirmPassword, ...payload } = this.form.value; // ✅ exclude confirmPassword
    this.auth.register(payload).subscribe({
      next: () => {
        this.toast.show('Registration successful! Please login.', 'success');
        this.form.reset();
        this.router.navigate(['/login']);
      },
      error: () => this.toast.show('Registration failed. Try again.', 'danger')
    });
  }
}
