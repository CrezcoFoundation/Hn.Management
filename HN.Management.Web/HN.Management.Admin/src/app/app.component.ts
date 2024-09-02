import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from './core/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'HN.Management.Admin';
  isLoggedIn$: Observable<boolean> | undefined;

    constructor(private authService: AuthService) {
        
    }
    
    ngOnInit() {
      this.isLoggedIn$ = this.authService.isLoggedIn;
    }
}
