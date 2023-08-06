import { Component } from '@angular/core';
import {
  FormGroup,
  FormControl,
  FormArray,
  Validators,
  FormBuilder,
} from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  constructor(private fb: FormBuilder) {}

  loginForm = this.fb.group({
    // eslint-disable-next-line @typescript-eslint/unbound-method
    userName: ['', Validators.required],
    //lastName: [''],
    // eslint-disable-next-line @typescript-eslint/unbound-method
    password: ['', Validators.required],
  });

  onSubmited() {
    // TODO: Use EventEmitter with form value
    console.log(this.loginForm.status);
    console.log(this.loginForm.value);
  }
}
