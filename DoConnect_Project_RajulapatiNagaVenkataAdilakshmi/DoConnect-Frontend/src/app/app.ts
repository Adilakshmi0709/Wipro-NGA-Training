import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { HeaderComponent } from './share/header/header';
import { FooterComponent } from './share/footer/footer';
import { CommonModule } from '@angular/common';
import { ToastComponent } from './share/toast/toast';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterModule, CommonModule, HeaderComponent, FooterComponent, ToastComponent],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App implements AfterViewInit{
  title = 'DoConnect';
  @ViewChild('toast') toast!: ToastComponent;
  constructor(private auth: AuthService){}
  ngAfterViewInit(): void {
    this.auth.toastState$.subscribe(({ message, type }) => {
      this.toast.show(message, type);
    });
  }
}
