import { Component } from '@angular/core';
import {
  FormGroup,
  FormControl,
  FormArray,
  Validators,
  FormBuilder,
} from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent {
  constructor(private fb: FormBuilder) {}

  registerForm = this.fb.group({
    // eslint-disable-next-line @typescript-eslint/unbound-method
    userName: ['', Validators.required],
    // eslint-disable-next-line @typescript-eslint/unbound-method
    userLastName: ['', Validators.required],
    // eslint-disable-next-line @typescript-eslint/unbound-method
    userEmail: ['', Validators.required],
    // eslint-disable-next-line @typescript-eslint/unbound-method
    password: ['', Validators.required],
    // eslint-disable-next-line @typescript-eslint/unbound-method
    confirmPassword: ['', Validators.required],
  });

  onRegister() {
    // TODO: Use EventEmitter with form value
    console.log(this.registerForm.status);
    console.log(this.registerForm.value);
  }
}
