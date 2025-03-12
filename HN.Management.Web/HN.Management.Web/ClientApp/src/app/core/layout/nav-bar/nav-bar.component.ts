
import { Component } from '@angular/core';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { FormGroup, FormControl, ReactiveFormsModule, Validators} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { PaypalComponent } from "../../../shared/donation-options/paypal/paypal.component";

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
    ]
})

export class NavBarComponent  {

  closeModalRefresh() {
    window.location.reload();
  }

  selectedLanguage = new FormControl('en', Validators.required);

  constructor( private translate: TranslateService ){
    translate.use('en');
  }

  form = new FormGroup({
    language: new FormControl('', Validators.required)
  });
 
  changeLanguage( lang: string ) {
    this.translate.use( lang )
  }

  isMenuOpen = false;

  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }
}
