import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { isPlatformBrowser } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {
  constructor(
    private router: Router,
    @Inject(PLATFORM_ID) private platformId: Object
  ) {}

  canActivate(): boolean {
    if (isPlatformBrowser(this.platformId)) {
      const role = localStorage.getItem('role');
      if (role === 'Admin') return true;  // ✅ Allow only Admin
      this.router.navigate(['/']);
      return false;
    }
    return true;  // ✅ Allow during SSR
  }
}
