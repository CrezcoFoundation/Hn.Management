import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormControl } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { Validators } from '@angular/forms';

@Component({
  selector: 'app-give-options',
  templateUrl: './give-options.component.html',
  styleUrls: ['./give-options.component.scss'],
})
export class GiveOptionsComponent {
  giveOptionsForm: FormGroup;
  constructor(private fb: FormBuilder) {
    this.giveOptionsForm = this.fb.group({
      // eslint-disable-next-line @typescript-eslint/unbound-method
      donationType: ['oneTimeDonation', Validators.required],
      donationFields: this.fb.array([]),
    });

    console.warn(this.giveOptionsForm.value);
  }

  recurringDonationChange(evt: any) {
    var donationType = evt.target.value;
    console.log('donationType:', donationType);
    this.giveOptionsForm.get('donationType')?.setValue(donationType);
    console.log('donationType:', this.donationType);
    if (donationType === 'oneTimeDonation') {
      this.cleanRecurringDonationFields(0);
      this.addRecurringDonationFields(donationType);
    }
    if (donationType === 'recurringDonation') {
      this.cleanRecurringDonationFields(0);
      this.addRecurringDonationFields(donationType);
    }
  }

  get donationType(): FormControl {
    // @ts-ignore
    return this.giveOptionsForm.get('donationType')?.value;
  }

  get donationFields(): FormArray {
    return this.giveOptionsForm.get('donationFields') as FormArray;
  }

  cleanRecurringDonationFields(indice: number) {
    this.donationFields.removeAt(indice);
  }

  addRecurringDonationFields(donationType: string) {
    let fields: FormGroup;

    if (donationType === 'oneTimeDonation') {
      fields = this.fb.group({
        day: new FormControl(''),
      });
      this.donationFields.push(fields);
    }

    if (donationType === 'recurringDonation') {
      fields = this.fb.group({
        startDate: new FormControl(''),
        endDate: new FormControl(''),
        interval: new FormControl(''),
      });
      this.donationFields.push(fields);
    }
  }

  getFormData() {
    console.warn(this.giveOptionsForm.value);
  }
}
