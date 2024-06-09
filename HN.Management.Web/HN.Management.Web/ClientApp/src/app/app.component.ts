import { Component, Inject, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { I18NEXT_SERVICE, ITranslationService } from 'angular-i18next';
import { FormGroup, FormControl, Validators} from '@angular/forms';
import Aos from 'aos';
import { User } from './admin/models/user';
import { AuthService } from './admin/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {

  isNavFooter! : boolean;
  
  constructor(
    private router: Router,
    @Inject(I18NEXT_SERVICE) private i18NextService: ITranslationService,
    private authService: AuthService
  ) 
  {
    
  }

  title = 'crezco-foundation';

  ngOnInit() {

    this.isNavFooter = this.authService.getIsNavFooter;

    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        // Cuando se completa una navegación, lleva la página al principio.
        window.scrollTo(0, 0);
      }
    });

    Aos.init({
      once: false,
      duration: 500,
      easing: 'ease',
    });

    window.addEventListener('load', Aos.refresh);
  }
}
