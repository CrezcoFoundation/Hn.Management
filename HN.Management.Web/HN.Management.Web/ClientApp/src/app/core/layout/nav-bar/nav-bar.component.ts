import { Component } from '@angular/core';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { FormControl, ReactiveFormsModule, Validators} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { PaypalComponent } from "../../../shared/donation-options/paypal/paypal.component";
import { HomeComponent } from 'src/app/website/home/home.component';
import { SharedBannerComponent } from 'src/app/shared/shared-banner/shared-banner.component';
import { ContactUsComponent } from 'src/app/website/contact-us/contact-us/contact-us.component';

@Component({
    standalone: true,
    selector: 'app-nav-bar',
    templateUrl: './nav-bar.component.html',
    styleUrls: ['./nav-bar.component.scss'],
    imports: [
      ReactiveFormsModule,
        RouterModule,
        CommonModule,
        HttpClientModule,
        TranslateModule,
        PaypalComponent,
        HomeComponent,
        SharedBannerComponent,
        ContactUsComponent,
    ]
})

export class NavBarComponent  {

  selectedLanguage = new FormControl('en', Validators.required);

  constructor( private translate: TranslateService ){
    translate.use('en');
  }

  changeLanguage( lang: string ) {
    this.translate.use( lang )
  }

  isMenuOpen = false;

  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }
}
