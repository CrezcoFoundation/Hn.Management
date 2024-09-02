import { AuthService } from '../services/auth.service';
import { catchError, of } from 'rxjs';

export function appInitializer(authService: AuthService) {
    return () => authService.refreshToken()
        .pipe(
            // catch error to start app on success or failure
            catchError(() => of())
        );
}