import { Component, OnInit } from '@angular/core';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { FormGroup, FormControl, Validators} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { PaypalComponent } from "../../../shared/donation-options/paypal/paypal.component";
import { HomeComponent } from 'src/app/website/home/home.component';
import { SharedBannerComponent } from 'src/app/shared/shared-banner/shared-banner.component';
import { ContactUsComponent } from 'src/app/website/contact-us/contact-us/contact-us.component';
import { WebSiteComponent } from 'src/app/website/website.component';

@Component({
    standalone: true,
    selector: 'app-nav-bar',
    templateUrl: './nav-bar.component.html',
    styleUrls: ['./nav-bar.component.scss'],
    imports: [
        RouterModule,
        CommonModule,
        HttpClientModule,
        TranslateModule,
        PaypalComponent,
        HomeComponent,
        SharedBannerComponent,
        ContactUsComponent,
        WebSiteComponent
    ]
})

export class NavBarComponent implements OnInit  {

  form = new FormGroup({
    language: new FormControl('', Validators.required)
  });

  selectedLanguage = 'en';

  constructor( private translate: TranslateService ){
    /* translate.setDefaultLang('en');

    translate.use('en'); */
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
