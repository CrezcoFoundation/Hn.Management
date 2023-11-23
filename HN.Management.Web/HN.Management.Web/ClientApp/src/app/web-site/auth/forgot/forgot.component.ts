import { Component } from '@angular/core';
import {
  FormGroup,
  FormControl,
  FormArray,
  Validators,
  FormBuilder,
} from '@angular/forms';

@Component({
  selector: 'app-forgot',
  templateUrl: './forgot.component.html',
  styleUrls: ['./forgot.component.scss'],
})
export class ForgotComponent {
  constructor(private fb: FormBuilder) {}

  forgotForm = this.fb.group({
    // eslint-disable-next-line @typescript-eslint/unbound-method
    emailName: ['', Validators.required],
  });

  onSubmited() {
    // TODO: Use EventEmitter with form value
    console.log(this.forgotForm.status);
    console.log(this.forgotForm.value);
  }
}
