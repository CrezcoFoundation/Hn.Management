import { Component, Inject, OnInit } from '@angular/core';
import { NavigationEnd, Router, RouterOutlet } from '@angular/router';
import { FormGroup, FormControl, Validators, FormsModule} from '@angular/forms';
import Aos from 'aos';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from "./core/layout/footer/footer.component";
import { NavBarComponent } from "./core/layout/nav-bar/nav-bar.component";

@Component({
    standalone: true,
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss'],
    imports: [
      CommonModule,
      RouterOutlet,
      TranslateModule,
      FormsModule,
      FooterComponent,
      NavBarComponent]
})
export class AppComponent implements OnInit {

  title = 'crezco-foundation';

  form = new FormGroup({
    language: new FormControl('', Validators.required)
  });

  selectedLanguage = 'en';

  constructor( private router: Router, private translate: TranslateService ){
    translate.setDefaultLang('en');

    translate.use('en');
  }

  changeLanguage() {
    this.translate.use(this.selectedLanguage);
  }

  get f(){
    return this.form.controls;
  }

  ngOnInit() {
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
