import { Component, Inject, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { FormGroup, FormControl, Validators} from '@angular/forms';
import { I18NEXT_SERVICE, ITranslationService } from 'angular-i18next';

@Component({
  standalone: false,
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss'],
})

export class NavBarComponent implements OnInit  {

  selectedLanguage = 'en';

  changeLanguage() {
    this.translate.use(this.selectedLanguage);
  }

  form = new FormGroup({
    language: new FormControl('', Validators.required)
  });

  constructor(
    private translate: TranslateService,
    /* @Inject(I18NEXT_SERVICE) private i18NextService: ITranslationService */
  ) {}

  ngOnInit(): void {

    this.changeLanguage();
    /* this.i18NextService.events.initialized.subscribe((e) => {
      if (e) {
        this.updateState(this.i18NextService.language);
      }
    }); */
  }

  get f(){
    return this.form.controls;
  }

  isMenuOpen = false;

  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }
}
