import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { map, take } from 'rxjs';

export const authGuard: CanActivateFn = (route, state) => {

  const router = inject(Router);
  const authService = inject(AuthService);
  return authService.isLoggedIn         // {1}
      .pipe(                              // {2} 
        map((isLoggedIn: boolean) => {         // {3}
          if (isLoggedIn) {
            return true;
          } else {
            router.navigate(['/login'], { queryParams: { returnUrl: state.url }});
            return false;
          }
        })
      )
};
