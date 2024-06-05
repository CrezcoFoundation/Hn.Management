import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-paypal',
  templateUrl: './paypal.component.html',
  styleUrls: ['./paypal.component.scss'],
})
export class PaypalComponent implements OnInit {
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
}
