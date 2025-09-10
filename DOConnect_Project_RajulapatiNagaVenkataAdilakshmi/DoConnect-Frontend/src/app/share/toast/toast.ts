import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-toast',
  templateUrl: './toast.html',
  styleUrls: ['./toast.css'],
  standalone: true,
  imports: [CommonModule]
})
export class ToastComponent implements OnInit {
  @Input() message: string = '';
  @Input() type: 'success' | 'danger' | 'info' = 'success';
  visible = false;

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.authService.toastState$.subscribe(({ message, type }) => {
      this.show(message, type);
    });
  }

  show(message: string, type: 'success' | 'danger' | 'info' = 'success') {
    this.message = message;
    this.type = type;
    this.visible = true;
    setTimeout(() => (this.visible = false), 3000); // auto-hide after 3s
  }
}
