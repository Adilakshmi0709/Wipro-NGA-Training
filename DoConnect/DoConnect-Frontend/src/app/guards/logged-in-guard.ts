import { inject } from '@angular/core';
import { CanActivateFn, Router, UrlTree } from '@angular/router';
import { PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';

export const LoggedInGuard: CanActivateFn = (): boolean | UrlTree => {
  const platformId = inject(PLATFORM_ID);
  const router = inject(Router);

  if (isPlatformBrowser(platformId)) {
    const token = localStorage.getItem('token');
    if (token) {
      // already logged in → redirect properly
      return router.createUrlTree(['/home']);
    }
    return true; // not logged in → allow login/register
  }

  return true;
};
