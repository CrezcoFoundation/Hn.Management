import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs';
import { AuthService } from '../../core/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
  
  // @ts-ignoretypes
  loginForm =  new FormGroup({
    email: new FormControl,
    password: new FormControl
  });
  fieldTextType: boolean = false;
  submitted = false;
  loading = false;
  returnUrl: string = '';
  error = '';

  constructor(
    private formBuilder: FormBuilder, 
    private authService: AuthService, 
    private router: Router, 
    private route: ActivatedRoute
  ) {}
  
  ngOnInit(): void {

    if (localStorage.getItem('currentUser')) {
      this.router.navigate(['/dashboard']);
    }

    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });

    

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  // convenience getter for easy access to form fields
  get f(){
    return this.loginForm.controls;
  }

  toggleFieldTextType(): void {
    this.fieldTextType = !this.fieldTextType;
  }

  onSubmited() {
    // TODO: Use EventEmitter with form value
  this.submitted = true;

  // stop if form is invalid
  if(this.loginForm.invalid){
    return;
  }

  this.loading = true;

  this.authService.login(this.f['email'].value, this.f['password'].value)
  .pipe(first())
  .subscribe(
    _data => {
      this.router.navigate(['/dashboard']);
    },
    _error => {
      this.error = _error;
      this.loading = false;
    }
  )

}
}
