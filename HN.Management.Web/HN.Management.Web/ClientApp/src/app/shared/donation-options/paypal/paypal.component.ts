import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { environment } from 'src/environments/environment';

@Component({
  standalone: true,
  imports: [
    RouterModule,
    CommonModule,
    HttpClientModule,
    TranslateModule
  ],
  selector: 'app-paypal',
  templateUrl: './paypal.component.html',
  styleUrls: ['./paypal.component.scss'],
})
export class PaypalComponent implements OnInit {

  paypal_url:string = 'https://www.paypal.com/US/fundraiser/charity/5099261';

  ngOnInit(): void {
    // @ts-ignore
    window.PayPal.Donation.Button({
      env: environment.paypal.env,
      hosted_button_id: environment.paypal.hosted_button_id,
      business: environment.paypal.business,
      image: {
        //src: 'https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif',
        src: '/assets/Image/payment-logos/Yellow_PayPal_Button.png',
        title: 'PayPal - The safer, easier way to pay online!',
        alt: 'Donate with PayPal button',
      },
      onComplete: function (params: any) {
        // Your onComplete handler
      },
    }).render('#paypal-donate-button-container');
  }

  isModalPaypalOpen = false;
  isModalCashAppOpen = false;
  isModalZelleOpen = false;

  openModalPaypal() {
    this.isModalPaypalOpen = true;
  }

  closeModalPaypal() {
    this.isModalPaypalOpen = false;
  }

  openModalCashApp() {
    this.isModalCashAppOpen = true;
  }

  closeModalCashApp() {
    this.isModalCashAppOpen = false;
  }

  openModalZelle() {
    this.isModalZelleOpen = true;
  }

  closeModalZelle() {
    this.isModalZelleOpen = false;
  }


}
