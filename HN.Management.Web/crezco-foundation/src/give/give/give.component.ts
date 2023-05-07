import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { FormArray } from '@angular/forms';
@Component({
  selector: 'app-give',
  templateUrl: './give.component.html',
  styleUrls: ['./give.component.scss'],
})
export class GiveComponent {
  giveForm = this.fb.group({
    // eslint-disable-next-line @typescript-eslint/unbound-method
    firstName: ['', Validators.required],
    lastName: [''],
    // eslint-disable-next-line @typescript-eslint/unbound-method
    email: ['', Validators.email],
    // eslint-disable-next-line @typescript-eslint/unbound-method
    amount: ['', Validators.min(20)],
  });

  constructor(private fb: FormBuilder) {}

  onSubmit() {
    // TODO: Use EventEmitter with form value
    console.warn(this.giveForm.value);
  }
}
