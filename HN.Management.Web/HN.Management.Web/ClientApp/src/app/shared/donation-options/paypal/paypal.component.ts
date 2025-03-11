import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component, OnInit} from '@angular/core';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { FormGroup, FormBuilder, Validators, ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CountryStatesService } from '../../country.service';
import Swal from 'sweetalert2';

@Component({
  standalone: true,
  imports: [
    ReactiveFormsModule,
    CommonModule,
    FormsModule,
    HttpClientModule,
    TranslateModule,
  ],
  selector: 'app-paypal',
  templateUrl: './paypal.component.html',
  styleUrls: ['./paypal.component.scss'],
})
export class PaypalComponent implements OnInit {

  countries: any[] = [];

  paypal_url: string = 'https://www.paypal.com/US/fundraiser/charity/5099261';
  donationForm!: FormGroup;
  donationFormVisible : boolean = false;
  selectedDonationOption: string = '';
  cashAppQrCode!: HTMLElement | null;
  zelleQrCode!: HTMLElement | null;
  states: any[] = [];


  constructor(
    private countryService: CountryStatesService,
    private formBuilder: FormBuilder,
    private translate: TranslateService
  ) {}

  ngOnInit(): void {
    this.donationForm = this.formBuilder.group({
      fullNameDonor: ['', Validators.required],
      phoneNumberDonor: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10)]],
      emailDonor: ['', [Validators.required, Validators.email]],
      countryDonor: ['', Validators.required],
      streetDonor: ['', Validators.required],
      cityDonor: ['', Validators.required],
      stateDonor: ['', Validators.required],
      zipCodeDonor: ['', Validators.required]
    });

    this.cashAppQrCode = document.getElementById('cashAppQrCode');
    this.zelleQrCode = document.getElementById('zelleQrCode');
    this.loadCountries();
  }

  loadCountries(): void {
    this.countryService.getCountries().subscribe(data => {
      // Obtener los países de los datos del JSON
      this.countries = Object.values(data).map((country: any) => ({
        code: country.name.toLowerCase(),
        name: country.name,
        states: country.states
      }));
    });
  }

  onCountryChange(countryCode: string): void {
    // Encontrar el país seleccionado en la lista de países
    const selectedCountry = this.countries.find(country => country.code === countryCode);

    if (selectedCountry) {
      // Actualizar los estados con los del país seleccionado
      this.states = selectedCountry.states || [];
      // Resetear el campo de estado cuando se cambia el país
      this.donationForm.get('stateDonor')?.setValue('');
    }
  }

  // Alertas de QR de CashApp
  showAlertCashApp() {
    Swal.fire({
      titleText: this.translate.instant('DONOR.Form_success') + ' ' +  this.donationForm.get('fullNameDonor')?.value + '!',
      text: this.translate.instant('DONOR.Qr_legend') + ' ' +  this.selectedDonationOption,
      imageUrl: '/assets/Image/payment-logos/Cashapp-qr.jpeg',
      imageWidth: 300,
      imageHeight: 300,
      imageAlt: 'CashApp QR',
      confirmButtonText: this.translate.instant('DONOR.Form_back')
    });
  }

  showAlertZelle() {
    Swal.fire({
      titleText: this.translate.instant('DONOR.Form_success') + ' ' +  this.donationForm.get('fullNameDonor')?.value + '!',
      text: this.translate.instant('DONOR.Qr_legend') + ' ' +  this.selectedDonationOption,
      imageUrl: '/assets/Image/payment-logos/Zelle-QR-web.jpeg',
      imageWidth: 300,
      imageHeight: 300,
      imageAlt: 'Zelle QR',
      confirmButtonText: this.translate.instant('DONOR.Form_back')
    });
  }
  showInvalidForm() {
    Swal.fire({
      icon: "error",
      title: "Oops...",
      text: this.translate.instant('DONOR.Form_error'),
      timer: 1500
    });
  }

  showQrCodes() {
    if (this.selectedDonationOption === 'cashapp') {
      /* this.cashAppQrCode?.classList.remove('d-none'); */
      this.showAlertCashApp();
    } else if (this.selectedDonationOption === 'zelle') {
      /* this.zelleQrCode?.classList.remove('d-none'); */
      this.showAlertZelle();
    }
  }

  viewFormDonor(option: string): void {
    this.donationFormVisible = true;
    this.selectedDonationOption = option;
  }

  onSubmit() {
    if (this.donationForm.valid) {
      /* TODO: LÓGICA DE ENVÍO A BASE DE DATOS */
      console.log('Formulario enviado', this.donationForm.value);
      this.showQrCodes();
    } else {
      console.log('Formulario no válido');
    }

    this.donationFormVisible = false;
    this.donationForm.reset();
    /* setTimeout(() => {
    }, 1000); */
  }


  /* ngOnInit(): void {
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
  } */


}
