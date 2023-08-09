import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  // @ts-ignoretypes
  loginForm: FormGroup;
  fieldTextType: boolean = false;

  constructor(private formBuilder: FormBuilder) {}

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
    /* this.initRegForm(); */
  }

  /* initRegForm() {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  } */

  toggleFieldTextType(): void {
    this.fieldTextType = !this.fieldTextType;
  }

  /* onSubmited() {
    // TODO: Use EventEmitter with form value
    console.log(this.loginForm.status);
    console.log(this.loginForm.value);
  } */
}
