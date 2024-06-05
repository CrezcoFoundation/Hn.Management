import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { Validators } from '@angular/forms';

import { Store } from '@ngrx/store';
import { fillDonationAreas } from '../actions/give.actions';
import {
  DonatationAreasInterface,
  DonationInterface,
} from '../interfaces/donation.interface';

@Component({
  selector: 'app-give',
  templateUrl: './give.component.html',
  styleUrls: ['./give.component.scss'],
})
export class GiveComponent implements OnInit {
  donationAreasForm = this.fb.group({
    // eslint-disable-next-line @typescript-eslint/unbound-method
    collegeScholariships: [0, Validators.required],
    specialEducation: [0],
    // eslint-disable-next-line @typescript-eslint/unbound-method
    communitySupport: [0, Validators.required],
    // eslint-disable-next-line @typescript-eslint/unbound-method
    studentMissionTrip: [0, Validators.required],
    // eslint-disable-next-line @typescript-eslint/unbound-method
    medicalAssistence: [0, Validators.required],
    // eslint-disable-next-line @typescript-eslint/unbound-method
    generalDonation: [0, Validators.required],
  });

  alive = true;

  donationAreas: DonatationAreasInterface = {
    collegeScholariships: null,
    specialEducation: null,
    communitySupport: null,
    studentMissionTrip: null,
    medicalAssistence: null,
    generalDonation: null,
  };

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {

  }

  getDonateAreas() {

  }
  get collegeScholariships(): FormControl {
    // @ts-ignore
    return this.donationAreasForm.get('collegeScholariships')?.value;
  }
  get specialEducation(): FormControl {
    // @ts-ignore
    return this.donationAreasForm.get('specialEducation')?.value;
  }
  get communitySupport(): FormControl {
    // @ts-ignore
    return this.donationAreasForm.get('communitySupport')?.value;
  }
  get studentMissionTrip(): FormControl {
    // @ts-ignore
    return this.donationAreasForm.get('studentMissionTrip')?.value;
  }
  get medicalAssistence(): FormControl {
    // @ts-ignore
    return this.donationAreasForm.get('medicalAssistence')?.value;
  }
  get generalDonation(): FormControl {
    // @ts-ignore
    return this.donationAreasForm.get('generalDonation')?.value;
  }
}
