import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators} from '@angular/forms';
import { I18NEXT_SERVICE, ITranslationService } from 'angular-i18next';

@Component({
  standalone: false,
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss'],
})

export class NavBarComponent implements OnInit  {

  language = 'en';
  languages: string[] = ['en', 'es'];

  form = new FormGroup({  
    language: new FormControl('', Validators.required)  
  });

  constructor(
    @Inject(I18NEXT_SERVICE) private i18NextService: ITranslationService
  ) {}

  ngOnInit(): void {
    this.i18NextService.events.initialized.subscribe((e) => {
      if (e) {
        this.updateState(this.i18NextService.language);
      }
    });
  }

  get f(){  
    return this.form.controls;  
  }

  private updateState(lang: string) {
    this.language = lang;
  }
  
  changeLanguage(e: any) {  
    console.log(e.target.value);
    const lang = e.target.value
    if (lang !== this.i18NextService.language) {
      this.i18NextService.changeLanguage(lang).then(x => {
        this.updateState(lang);
        document.location.reload();
      });
    }
  }
  /* Menu icon transition */
  isMenuOpen = false;

  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }
}
