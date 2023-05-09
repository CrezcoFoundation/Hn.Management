import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.scss'],
})
export class ContactUsComponent {
  contactForm = this.fb.group({
    // eslint-disable-next-line @typescript-eslint/unbound-method
    inputName: ['', Validators.required],
    //lastName: [''],
    // eslint-disable-next-line @typescript-eslint/unbound-method
    inputEmail: ['', Validators.email],
    // eslint-disable-next-line @typescript-eslint/unbound-method
    amount: ['', Validators.min(20)],
    // eslint-disable-next-line @typescript-eslint/unbound-method
    messageTextArea: ['', Validators.required],
    // eslint-disable-next-line @typescript-eslint/unbound-method
    checkForm: ['', Validators.required],
  });

  constructor(private fb: FormBuilder) {}

  onSubmited() {
    // TODO: Use EventEmitter with form value
    console.warn(this.contactForm.value);
  }
}
