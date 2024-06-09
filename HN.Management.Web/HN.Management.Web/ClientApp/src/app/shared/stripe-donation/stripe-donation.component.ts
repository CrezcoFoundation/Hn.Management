import { Donor } from './intefaces/donor';
import { StripeDonationService } from './services/stripe-donation.service';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormGroup, FormBuilder, Validators, ReactiveFormsModule, FormControl } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { donationDetails } from './intefaces/donationDetails';

@Component({
  selector: 'app-stripe-donation',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
  templateUrl: './stripe-donation.component.html',
  styleUrls: ['./stripe-donation.component.scss']
})
export class StripeDonationComponent {
  donorFormGroup: FormGroup;
  donationDetailsFormGroup: FormGroup;
  currentStep = 1;
  paso1 = 'Customer';
  paso2 = 'Price';
  paso3 = 'Setup Intent';

  productDataInfo!: string|undefined;

  currencyTypes = ['mxn', 'crc', 'usd'];
  donationTypes = ['puntual', 'recurring'];
  recurringTypes = ['diaria', 'semanal', 'mensual', 'trimensual', 'sixmensual', 'anual'];

  constructor(
    private fb: FormBuilder,
    private StripeDonationService: StripeDonationService,
  ) {
    this.donorFormGroup = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', Validators.required]
    });

    this.donationDetailsFormGroup = this.fb.group({
      donationType: [this.donationTypes[0], Validators.required],
      price: [0, Validators.required],
      currency: [this.currencyTypes[0], Validators.required],
    })
  }

  changeDonationType(selectedDonationType: string){
    const recurring: FormControl = new FormControl(this.recurringTypes[0], Validators.required);
    if (selectedDonationType === 'recurring') {
      this.donationDetailsFormGroup.addControl('recurring', recurring,)
    } else {
      this.donationDetailsFormGroup.removeControl('recurring')
    }
  }

  nextStep() {
    console.log(this.currentStep, 'insede nextStep');
    if (this.currentStep < 2) {
      this.currentStep++;
    }
  }

  previousStep() {
    console.log(this.currentStep, 'inside previos');
    if (this.currentStep > 1) {
      this.currentStep--;
    }
  }

  // isCurrentStepValid(): boolean {
  //   console.log(this.currentStep, 'step in isCurrentStepValid');
  //   switch (this.currentStep) {
  //     case 1:
  //       console.log(this.donorFormGroup.valid, 'inside case 1 ' + this.donationDetailsFormGroup.value);
  //       return this.donorFormGroup.valid;
  //     case 2:
  //       return this.donationDetailsFormGroup.valid;
  //     default:
  //       return false;
  //   }
  // }

  donorOnSubmit() {
     this.StripeDonationService.createDonor(this.donorFormGroup.value).subscribe(
      (donador: Donor) => {
        this.productDataInfo = donador.name;
        this.nextStep()
      }
    );
  }

  donationDetailsOnSubmit() {
    const donationDetails: donationDetails = {
          currency: this.donationDetailsFormGroup.controls['currency'].value,
          unit_amount: this.donationDetailsFormGroup.controls['price'].value,
          recurring: {
            interval: this.donationDetailsFormGroup.controls['recurring'].value,
          },
          productData:{
            name:`${this.productDataInfo} donó ${this.donationDetailsFormGroup.controls['price'].value} con una recurrencia de ${this.donationDetailsFormGroup.controls['recurring'].value}`},
            UnitAmountDecimal: 43243
      };

    this.StripeDonationService.createPrice(donationDetails)
      .subscribe(
        () => this.nextStep()
      )
  }


}
