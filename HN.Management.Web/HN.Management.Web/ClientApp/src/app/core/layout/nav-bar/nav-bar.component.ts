import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { FormGroup, FormControl, Validators} from '@angular/forms';

@Component({
  standalone: false,
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss'],
})

export class NavBarComponent implements OnInit  {

  form = new FormGroup({
    language: new FormControl('', Validators.required)
  });

  selectedLanguage = 'en';

  constructor( private translate: TranslateService ){
    translate.setDefaultLang('en');

    translate.use('en');
  }

  changeLanguage() {
    this.translate.use(this.selectedLanguage);
  }

  ngOnInit(): void {
    this.changeLanguage();
  }

  get f(){
    return this.form.controls;
  }

  isMenuOpen = false;

  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }
}
