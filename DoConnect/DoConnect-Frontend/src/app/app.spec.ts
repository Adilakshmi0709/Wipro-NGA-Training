import { TestBed } from '@angular/core/testing';
import { App } from './app';
import { AuthService } from './services/auth.service';
import { of } from 'rxjs';
import { provideHttpClient } from '@angular/common/http';
import { provideRouter } from '@angular/router';
import { provideZonelessChangeDetection } from '@angular/core';
import { Component } from '@angular/core';

// ---- Stubs for shared components ----
@Component({
  selector: 'app-toast',
  standalone: true,
  template: ''
})
class FakeToastComponent {}

@Component({
  selector: 'app-footer',
  standalone: true,
  template: ''
})
class FakeFooterComponent {}
// -------------------------------------

class MockAuthService {
  login() {
    return of({ role: 'admin' });
  }
}

describe('App', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [App],
      providers: [
        provideZonelessChangeDetection(),
        provideHttpClient(),
        provideRouter([]),
        { provide: AuthService, useClass: MockAuthService }
      ]
    })
      .overrideComponent(App, {
        set: {
          imports: [FakeToastComponent, FakeFooterComponent]
        }
      })
      .compileComponents();
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(App);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'DoConnect'`, () => {
    const fixture = TestBed.createComponent(App);
    const app = fixture.componentInstance;
    expect(app.title).toEqual('DoConnect');
  });
});
